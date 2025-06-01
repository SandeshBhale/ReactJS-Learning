using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public class AdminRepo : IAdminRepo
    {
        ExamContext ec;
        public AdminRepo(ExamContext ec)
        {
            this.ec = ec;
        }

        public async Task AddAdminAsync(Admin admin)
        {
            await this.ec.Admins.AddAsync(admin);
            await this.ec.SaveChangesAsync();
        }

        public async Task<bool> AdminExistsAsync(string emailId)
        {
            return await this.ec.Admins.AnyAsync(u => u.EmailId == emailId);
        }

        public async Task<Admin> GetAdminByEmailId(string emailId)
        {
            return await this.ec.Admins.FirstOrDefaultAsync(u => u.EmailId == emailId);
        }
    }
}
