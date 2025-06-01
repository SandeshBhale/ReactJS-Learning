using BCrypt.Net;
using Core;
using Infra.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly ExamContext ec;

        public UserRepo(ExamContext ec)
        {
            this.ec = ec;
        }

        public async Task AddUserAsync(User user)
        {
            await this.ec.AddAsync(user);
            await this.ec.SaveChangesAsync();
        }

        public async Task ChangePasswordAsync(ChangePasswordDto rec,Int64 id)
        {
            var oldrec = this.ec.Users.Find(id);
            oldrec.Password = rec.NewPassword;
            this.ec.SaveChanges();

        }

        public async Task<User> GetUserByEmailId(string emailId)
        {
            return await this.ec.Users.FirstOrDefaultAsync(u => u.EmailId == emailId);
        }

        public async Task<bool> UserExistsAsync(string emailId)
        {
            return await this.ec.Users.AnyAsync(u => u.EmailId == emailId);
        }
    }
}
