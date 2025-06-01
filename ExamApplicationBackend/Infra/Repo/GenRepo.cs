using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public class GenRepo<T> : IGenRepo<T> where T : class
    {
        ExamContext ec;
        public GenRepo(ExamContext ec)
        {
            this.ec = ec;
        }

        public async Task<RepoResultDto> Create(T entity)
        {
            RepoResultDto res = new RepoResultDto();
            try
            {
                await this.ec.Set<T>().AddAsync(entity);
                await this.ec.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Record Created !";
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<RepoResultDto> Delete(long id)
        {
            RepoResultDto res = new RepoResultDto();
            try
            {
                var rec = await this.ec.Set<T>().FindAsync(id);
                this.ec.Set<T>().Remove(rec);
                await this.ec.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Record Deleted !";
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<T> FindById(Int64 id)
        {
             return await this.ec.Set<T>().FindAsync(id);
        }

        public Task<List<T>> GetAll()
        {
            return this.ec.Set<T>().ToListAsync();
        }

        public async Task<RepoResultDto> Update(T entity)
        {
            RepoResultDto res = new RepoResultDto();
            try
            {
                this.ec.Entry(entity).State = EntityState.Modified;
                await this.ec.SaveChangesAsync();
                res.IsSuccess = true;
                res.Message = "Record Updated !";
            }
            catch(Exception ex)
            {
                res.IsSuccess = false;
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
