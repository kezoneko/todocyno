using System;
using System.Linq;
using ToDo.Core.Entities;
using ToDo.Core.Infrastructure;
using ToDo.Core.Requests.Tasks.Models;

namespace ToDo.Core.Requests.Tasks
{
    public static class TaskExtensions
    {
        public static IOrderedQueryable<Task> OrderBy(this IQueryable<Task> queryable, string propertyName, OrderDirection? direction)
        {
            switch (propertyName)
            {                
                case "Title":
                    return direction == OrderDirection.Descending
                        ? queryable.OrderByDescending(e => e.Title)
                        : queryable.OrderBy(e => e.Title);
                case "Status":
                    return direction == OrderDirection.Descending
                        ? queryable.OrderByDescending(e => e.Status)
                        : queryable.OrderBy(e => e.Status);
                case "":
                case null:
                    return queryable.OrderBy(e => e.Id);
                default:
                    throw new ArgumentException("Property not found", nameof(propertyName));
            }
        }

        public static IQueryable<Task> Filter(this IQueryable<Task> queryable, TaskFilter filter)
        {
            if (!string.IsNullOrEmpty(filter?.Text))
            {
                queryable = queryable.Where(e => e.Title.Contains(filter.Text));
            }
            if (!string.IsNullOrEmpty(filter?.Title))
            {
                queryable = queryable.Where(e => e.Title.Contains(filter.Title));
            }
            if (filter?.Status != null)
            {
                queryable = queryable.Where(e => e.Status == filter.Status);
            }
            return queryable;
        }
    }
}
