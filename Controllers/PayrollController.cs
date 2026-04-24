using Microsoft.AspNetCore.Mvc;
using IT15_LabExam_Braza.Data;
using IT15_LabExam_Braza.Models;

namespace IT15_LabExam_Braza.Controllers
{
    public class PayrollController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayrollController(ApplicationDbContext context)
        {
            _context = context;
        }

        // PAYROLL LIST PER EMPLOYEE
        public IActionResult Index(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);

            if (employee == null)
                return RedirectToAction("Index", "Employees");

            ViewBag.EmployeeId = employee.EmployeeID;
            ViewBag.EmployeeName = employee.FirstName + " " + employee.LastName;
            ViewBag.DailyRate = employee.DailyRate;

            var payrolls = _context.Payrolls
                .Where(p => p.EmployeeID == employeeId)
                .OrderByDescending(p => p.Date)
                .ToList();

            ViewBag.MonthlyTotal = payrolls
                .Where(p => p.Date.Month == System.DateTime.Now.Month
                         && p.Date.Year == System.DateTime.Now.Year)
                .Sum(p => p.NetPay);

            return View(payrolls);
        }

        // CREATE (GET)
        public IActionResult Create(int employeeId)
        {
            var emp = _context.Employees.Find(employeeId);

            if (emp == null)
                return RedirectToAction("Index", "Employees");

            ViewBag.EmployeeId = emp.EmployeeID;
            ViewBag.EmployeeName = emp.FirstName + " " + emp.LastName;

            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(Payroll p)
        {
            var emp = _context.Employees.Find(p.EmployeeID);

            if (emp == null) return RedirectToAction("Index", "Employees");

            p.GrossPay = p.DaysWorked * emp.DailyRate;
            p.NetPay = p.GrossPay - p.Deduction;

            if (p.Date == default)
                p.Date = System.DateTime.Now;

            _context.Payrolls.Add(p);
            _context.SaveChanges();

            return RedirectToAction("Index", new { employeeId = p.EmployeeID });
        }
    }
}