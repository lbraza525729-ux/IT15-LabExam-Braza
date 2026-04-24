using Microsoft.AspNetCore.Mvc;
using IT15_LabExam_Braza.Data;
using IT15_LabExam_Braza.Models;

namespace IT15_LabExam_Braza.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid) return View(emp);

            _context.Employees.Add(emp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);

            if (emp == null)
                return NotFound();

            return View(emp);
        }

        // EDIT (POST) ✔️ THIS IS THE FIX
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (!ModelState.IsValid) return View(emp);

            var existing = _context.Employees.FirstOrDefault(e => e.EmployeeID == emp.EmployeeID);

            if (existing == null)
                return NotFound();

            // update fields properly
            existing.FirstName = emp.FirstName;
            existing.LastName = emp.LastName;
            existing.Position = emp.Position;
            existing.Department = emp.Department;
            existing.DailyRate = emp.DailyRate;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);

            if (emp == null)
                return NotFound();

            _context.Employees.Remove(emp);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}