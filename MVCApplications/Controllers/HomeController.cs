using DomainLayar.Model;
using Microsoft.AspNetCore.Mvc;
using MVCApplications.ViewModels;
using System.Text;

namespace MVCApplications.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Insert()
        { return View(); }

        public async Task<IActionResult> InsertConfirm(InsertViewModel model)
        {
            Student student = new Student()
            {

                Name = model.Name,
                Family = model.Family,
                Grade = model.Grade
            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(student);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("https://localhost:7078/api/Students/InsertStudent", content);

            return RedirectToAction("Insert");
        }

        public async Task<IActionResult> Show()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://localhost:7078/api/Students/GetAllStudents");
            if (httpResponseMessage != null)
            {
                string json = await httpResponseMessage.Content.ReadAsStringAsync();

                List<Student> StudentData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);

                return View(StudentData);
            }
            else
            { return View(null); }

        }

        public async Task<IActionResult> ShowSingleStudent(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.GetAsync("https://localhost:7078/api/Students/GetSingleStudent?id=" + id.ToString());
            if (httpResponseMessage != null)
            {
                string json = await httpResponseMessage.Content.ReadAsStringAsync();

                Student student = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(json);

                return View(student);
            }
            else { return View(null); }

        }
        public async Task<IActionResult> DeleteStudent(int id)
        {
            string i = id.ToString();
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.DeleteAsync("https://localhost:7044/api/Students/DeleteStudent?id=" + i);
            return RedirectToAction("ListStudent");
        }

        public async Task<IActionResult> Update(int id, Student student)
        {
            HttpClient client = new HttpClient();
            Student Existedstudent = new Student();
           HttpResponseMessage httpResponseMessage = await client.GetAsync("https://localhost:7078/api/Students/GetAllStudents" + id.ToString());
            if (httpResponseMessage != null)
            {
                 string json = await httpResponseMessage.Content.ReadAsStringAsync();

                Existedstudent = Newtonsoft.Json.JsonConvert.DeserializeObject<Student> (json);

                Existedstudent.Name = student.Name;
                Existedstudent.Family = student.Family;
                Existedstudent.Grade = student.Grade;
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage1 = await client.PutAsync("https://localhost:7078/api/Students/UodateStudent", content);
                return RedirectToAction("Insert");
            }
            else { return View(null); }
             
        }


    }
}
