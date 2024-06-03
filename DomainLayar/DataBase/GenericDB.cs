using DomainLayar.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayar.DataBase
{
    public class GenericDB : DbContext
    {
        public DbSet<Student> Students { set; get; }

      public GenericDB(DbContextOptions<GenericDB> options) :base(options) 
        {
        
        }
        
    }
}
