using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cynosura.Web.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace ToDo.Web.Authorization
{
    public class TaskModule : IPolicyModule
    {
        public void RegisterPolicies(AuthorizationOptions options)
        {
            options.AddPolicy("ReadTask",
                policy => policy.RequireClaim(ClaimTypes.Role, "Administrator"));
            options.AddPolicy("WriteTask",
                policy => policy.RequireClaim(ClaimTypes.Role, "Administrator"));
        }
    }
}