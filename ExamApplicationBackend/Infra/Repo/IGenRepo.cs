using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repo
{
    public interface IGenRepo<T> where T:class
    {
        Task<List<T>> GetAll();
        Task<T> FindById(Int64 id);
        Task<RepoResultDto> Create(T entity);
        Task<RepoResultDto> Update(T entity);
        Task<RepoResultDto> Delete(Int64 id);

    }
}
