using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Security;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ToDo.Web.Infrastructure
{
    public class UserInfoModelBinder : IModelBinder
    {
        private readonly IUserInfoProvider _userInfoProvider;

        public UserInfoModelBinder(IUserInfoProvider userInfoProvider)
        {
            _userInfoProvider = userInfoProvider;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.Model != null)
                throw new InvalidOperationException("Cannot update instances");

            bindingContext.Result = ModelBindingResult.Success(await _userInfoProvider.GetUserInfoAsync());
        }
    }
}
