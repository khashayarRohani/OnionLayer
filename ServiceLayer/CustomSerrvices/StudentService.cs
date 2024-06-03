using DomainLayar.Model;
using RepositoryLayar.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CustomSerrvices
{
    public class StudentService : ICustomService<Student>
    {

        private readonly IRepository<Student> studentService;

        public StudentService(IRepository<Student> student)
        {
            studentService = student;
        }


        public Student Get(int Id)
        {
            return studentService.GetById(Id);
        }
        public bool Delete(int Id)
        {
            return studentService.Delete(Id);
        }
        public IEnumerable<Student> GetAll()
        {
            return studentService.GetAll();
        }
        public int Insert(Student record)
        {
          return studentService.Insert(record); 
        }

    }
}
