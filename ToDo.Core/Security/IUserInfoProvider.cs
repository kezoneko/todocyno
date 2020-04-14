using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Security
{
    public interface IUserInfoProvider
    {
        Task<UserInfoModel> GetUserInfoAsync();
    }
}
