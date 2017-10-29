using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T t);
        void Update(T t);
        void Delete(T t);
       

    }
}
