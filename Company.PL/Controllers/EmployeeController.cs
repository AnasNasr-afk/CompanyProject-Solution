using Company.BLL.Repository;
using Company.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepo employeeRepo;

        public EmployeeController()
        {
            employeeRepo = new EmployeeRepo();
        }

        // Modify Index to accept a page parameter
        public IActionResult Index(int page = 1)
        {
            const int PageSize = 5;

            var allEmployees = employeeRepo.GetAll().ToList();
            var totalCount = allEmployees.Count;
            var totalPages = (int)Math.Ceiling((double)totalCount / PageSize);

            var pagedEmployees = allEmployees
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewBag.TotalEmployees = totalCount;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(pagedEmployees);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var result = employeeRepo.Add(employee);
            if (result > 0)
                return RedirectToAction("Index");
            return View(result);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var details = employeeRepo.GetById(id);

            if (details == null)
                return NotFound();
            return View(details);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = employeeRepo.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var result = employeeRepo.Update(employee);

            if (result > 0)
                return RedirectToAction("Index");
            return View(result);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = employeeRepo.GetById(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            var result = employeeRepo.Delete(employee);
            if (result > 0)
                return RedirectToAction("Index");
            return View(result);
        }
    }
}
