using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonDataRepository.Interfaces
{
    public interface IBaseRepository<T>
    {
        int GetTotalRecords();
        List<T> GetAll();
        List<T> GetAll(int skip, int take, out int total);
        T GetByID(int id);
        T Update(T obj);
        T Insert(T obj);
        void Delete(int id);
    }
}
