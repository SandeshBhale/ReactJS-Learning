using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public interface IAdminRepo
    {
        Task<bool> AdminExistsAsync(string emailId);
        Task AddAdminAsync(Admin admin);
        Task<Admin> GetAdminByEmailId(string emailId);
    }
}
