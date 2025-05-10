using Company.BLL.Repository;
using Company.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Company.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepo departmentRepo;

        public DepartmentController()
        {
            departmentRepo = new DepartmentRepo();
        }
        public IActionResult Index(int page = 1)
        {
            const int PageSize = 5;

            var allDepartments = departmentRepo.GetAll().ToList();
            var totalCount = allDepartments.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / PageSize);

            var pagedDepartments = allDepartments
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(pagedDepartments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            var result = departmentRepo.Add(department);
            if (result > 0)
                return RedirectToAction("Index");

            return View(department);
        }

        [HttpGet]

        public IActionResult Details(int id)
        {
            var details = departmentRepo.getById(id);

            if (details == null)
                return NotFound();
            return View(details);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var details = departmentRepo.getById(id);
            return View(details);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            var result = departmentRepo.Update(department);
            if(result > 0)
                return RedirectToAction("Index");
            return View(department);
        }

        [HttpGet]
        public IActionResult Delete(int id ) {
            var department = departmentRepo.getById(id);

            return View(department);
        }

        [HttpPost]

        public IActionResult Delete(Department department) {

            var result = departmentRepo.Delete(department);

            if(result > 0)
                return RedirectToAction("Index");
            return View(department);
        }
    }
}