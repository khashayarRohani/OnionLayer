using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayar.Model;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace RepositoryLayar.IRepository
{
    public interface IRepository<T> where T : class, IBaseEntity<int>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        int Insert(T record);
        void Savechanges();
        bool Delete(int id);
    }
}
