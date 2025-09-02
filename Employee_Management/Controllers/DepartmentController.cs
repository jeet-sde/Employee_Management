using Employee_Management.Data;
using Employee_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }



        //READ THE LIST
        public IActionResult Index()
        {
            var department = _db.Department_table.ToList();
            return View(department);
        }

        //Create: get
        public IActionResult Create()
        {
            return View();
        }

        //Create: post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department_table obj)
        {
            if (ModelState.IsValid)
            {
                _db.Department_table.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Update: Get
        public IActionResult Edit(int id)
        {
            var department = _db.Department_table.Find(id);
            if (department == null)

                return NotFound();

            return View(department);
        }

        //Update: Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department_table obj)
        {
            if (ModelState.IsValid)
            {
                _db.Department_table.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete : get
        public IActionResult Delete(int id)
        {
            var department = _db.Department_table.Find(id);
            if (department == null)
                return NotFound();
            return View(department);
        }

        //Delete: Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id) {
            {
                var department = _db.Department_table.Find(id);
                if (department != null)
                {
                    _db.Department_table.Remove(department);
                    _db.SaveChanges();

                }
                return RedirectToAction("Index");

            }
        }
    }
}
