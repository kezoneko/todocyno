using System;
using System.Linq;
using Cynosura.EF;
using ToDo.Core.Entities;
using ToDo.Core.Security;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Data
{
    public class BaseEntityRepository<T> : EntityRepository<T> where T : BaseEntity
    {
        private readonly IUserInfoProvider _userInfoProvider;

        protected int? UserId => _userInfoProvider.GetUserInfoAsync().Result?.UserId;

        public BaseEntityRepository(IDatabaseFactory databaseFactory, IUserInfoProvider userInfoProvider)
            : base(databaseFactory)
        {
            _userInfoProvider = userInfoProvider;

            ((DataContext)Context).SavingChanges += OnSavingChanges;
        }

        private void OnSavingChanges(object sender, EventArgs eventArgs)
        {
            var entities = Context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added)
                .Where(e => e.Entity is T)
                .Select(e => new
                {
                    Entity = (T)e.Entity,
                    State = e.State
                })
                .ToList();

            if (entities.Count > 0)
            {
                foreach (var entity in entities)
                {
                    entity.Entity.ModificationDate = DateTime.UtcNow;
                    entity.Entity.ModificationUserId = UserId;

                    if (entity.State == EntityState.Added)
                    {
                        entity.Entity.CreationDate = entity.Entity.ModificationDate;
                        entity.Entity.CreationUserId = entity.Entity.ModificationUserId;
                    }
                }
            }
        }
    }
}
