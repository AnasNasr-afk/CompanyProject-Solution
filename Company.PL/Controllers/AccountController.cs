//using Company.BLL.Repository;
//using Company.DAL.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;

//namespace Company.PL.Controllers
//{
//    public class AccountController : Controller
//    {
//        private readonly UserRepo _userRepo;

//        // Use dependency injection to get UserRepo
//        public AccountController(UserRepo userRepo)
//        {
//            _userRepo = userRepo;
//        }

//        [HttpGet]
//        public IActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Register(User user)
//        {
//            if (!ModelState.IsValid)
//                return View(user);

//            var result = _userRepo.Register(user);
//            if (result == 1)
//                return RedirectToAction("Login");

//            ViewBag.Error = "Username already exists!";
//            return View(user);
//        }

//        [HttpGet]
//        public IActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Login(User user)
//        {
//            if (!ModelState.IsValid)
//                return View(user);

//            var existingUser = _userRepo.Login(user.Username, user.Password);
//            if (existingUser != null)
//            {
//                HttpContext.Session.SetString("Username", existingUser.Username);
//                return RedirectToAction("Index", "Department");
//            }

//            ViewBag.Error = "Invalid credentials.";
//            return View(user);
//        }

//        public IActionResult Logout()
//        {
//            HttpContext.Session.Clear();
//            return RedirectToAction("Login");
//        }
//    }
//}
