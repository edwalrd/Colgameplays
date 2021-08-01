using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contract
{
  public  interface IGenericRepository<T> where T: class
    {
        Task<List<T>> GetallAsyn();
        Task<List<T>> SearchAsyn(string search);
        Task<T> GetOneAsyn(int id);
        Task<T> Add(T entity);
        Task<bool> Update(int id, T entity);
        Task<bool> Delete(int id);

    }
}
