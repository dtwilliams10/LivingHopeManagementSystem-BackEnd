using System.Collections.Generic;

namespace LHMSAPI.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetByID(int id);

        void Add(T item);

        void Update(T item);

        void Delete(T item);
    }

}