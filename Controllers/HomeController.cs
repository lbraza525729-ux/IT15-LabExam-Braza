using Microsoft.AspNetCore.Mvc;
using IT15_LabExam_Braza.Data;

namespace IT15_LabExam_Braza.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalEmployees = _context.Employees.Count();
            ViewBag.TotalPayroll = _context.Payrolls.Count();
            return View();
        }
    }
}