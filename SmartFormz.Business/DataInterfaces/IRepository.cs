using System.Collections.Generic;
using System.Threading.Tasks;
using SmartFormz.Business.ResultModels;

namespace SmartFormz.Business.DataInterfaces
{
    public interface IRepository<T, IdT>
    {
        T Get(IdT id);
        Task<T> GetAsync(IdT id);
        ICollection<T> Get();
        Task<List<T>> GetAsync();
        SaveResult<T> Save(T model);
        Task<SaveResult<T>> SaveAsync(T model);
        void Delete(T model);
    }
}
