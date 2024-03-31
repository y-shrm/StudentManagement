using Microsoft.AspNetCore.Mvc;
using studentManagementSystem.Data;
using studentManagementSystem.Models;
using System.ComponentModel;
using System.Diagnostics;

namespace studentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            this._db = db;
        }


        public IActionResult Index()
        {
            List<Student> objStudentList = _db.Students.Where(s => !s.IsDeleted).ToList();
            
            return View(objStudentList);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student student)
        {
            
                _db.Add(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            

        }




        public IActionResult Update(int id)
        {
            if(id == 0) {
                return NotFound();
            }

            Student? studentFromDb = _db.Students.Find(id);
            if (studentFromDb == null)
            {
                return NotFound();
            }

            return View(studentFromDb);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            
                _db.Students.Update(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }


        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Student? studentFromDb = _db.Students.Find(id);
            if (studentFromDb == null)
            {
                return NotFound();
            }

            return View(studentFromDb);
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        {
           
                Student? studentFromDb = _db.Students.Find(student.Id);
                if (studentFromDb == null)
                {
                    return NotFound();
                }

                studentFromDb.IsDeleted = true;
                _db.SaveChanges();
                return RedirectToAction("Index");
            
            //return View();
        }







        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
