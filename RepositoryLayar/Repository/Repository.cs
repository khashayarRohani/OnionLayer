using DomainLayar.Model;
using DomainLayar.DataBase;
using Microsoft.EntityFrameworkCore;
using RepositoryLayar.IRepository;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayar.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity<int>
    {
        private readonly DbSet<T> entity;
        private readonly GenericDB db;

        public Repository(GenericDB db)
        {
            this.db = db;
            entity = db.Set<T>();
        }

        public T GetById(int id)
        {
            return entity.SingleOrDefault(x => x.Id == id);
        }
        public IEnumerable<T> GetAll()
        {
            return entity.AsEnumerable();
        }
        public void Savechanges()
        {
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            T record = entity.FirstOrDefault(x => x.Id == id);
            if (record != null)
            {
                try
                {
                    entity.Remove(record);
                    db.SaveChanges();
                    return true;
                }

                catch
                {

                    return false;
                }
            }
            else { return false; }
        }

        public int Insert(T record)
        {
            if (record != null)
            {
                entity.Add(record);
                db.SaveChanges();
                return record.Id;
            }
            else
            {
                return 0;
            }
        }

    }
}
