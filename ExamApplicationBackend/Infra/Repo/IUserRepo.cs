using Core;
using Infra.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public interface IUserRepo
    {
        Task<bool> UserExistsAsync(string emailId);
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailId(string emailId);
        Task ChangePasswordAsync(ChangePasswordDto rec,Int64 id);
    }
}
