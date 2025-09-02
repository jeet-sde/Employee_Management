using Employee_Management.Data;
using Employee_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }


        //Read: list the employees
        public IActionResult Index()
        {

            var employees = _db.Employees.ToList();
            return View(employees);
        }

        //Create: get
        public IActionResult Create()
        {
         
            
            return View();
            
        }

        //Create: Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(emp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
         return View(emp);
        }

        //Upadate: Get
        public IActionResult Edit(int id)
        {

            var employee = _db.Employees.Find(id);
            if (employee == null)
            
                return NotFound();

                return View(employee);
        }

        //Upadate: Post
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete: Get

        public IActionResult Delete(int id)
        {
            var employee = _db.Employees.Find(id);
            if(employee == null)
                return NotFound();

            return View(employee);
        }

        //Delete: Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var employee = _db.Employees.Find(id);
            if(employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }

        // Details
        public IActionResult Details(int id)
        {
            var employee = _db.Employees.FirstOrDefault(e =>  e.id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }




    }


}
