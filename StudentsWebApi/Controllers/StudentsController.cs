using DomainLayar.DataBase;
using DomainLayar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ICustomServices;

namespace StudentsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ICustomService<Student> customService;
        private readonly GenericDB db;
        public StudentsController(ICustomService<Student> customService, GenericDB db)
        {
            this.customService = customService;
            this.db = db;
        }
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            List<Student> students = customService.GetAll().ToList();
            return Ok(students);
        }
        [HttpGet("GetSingleStudent")]
        public IActionResult GetSingleStudent(int id)
        {
            Student student = customService.Get(id);

            return Ok(student);
        }
        [HttpPost("InsertStudent")]
        public IActionResult InsertStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Information required");
            }
            else
            {
                return Ok(customService.Insert(student));
            }
        }

        [HttpPut("UodateStudent")]
        public IActionResult UpdateStudent(Student student)
        {
            Student OldInfoStudent = customService.Get(student.Id);


            if (OldInfoStudent == null)
            {
                return BadRequest();
            }
            else
            {
                OldInfoStudent.Id = student.Id;
                OldInfoStudent.Name = student.Name;
                OldInfoStudent.Family = student.Family;
                OldInfoStudent.Grade = student.Grade;

                db.Update(OldInfoStudent);
                db.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            Student student = customService.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                if (customService.Delete(student.Id))
                    return Ok();

                else
                    return BadRequest();
            }
        }

    }
}
