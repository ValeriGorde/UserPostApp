using Microsoft.AspNetCore.Mvc;
using UserPostApp.Models.DB;

namespace UserPostApp.Controllers
{
    public class UsersController: Controller
    {
        private readonly IBlogRepository _repository;

        public UsersController(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repository.GetUsers();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repository.AddUser(newUser);
            return View(newUser);
        }
    }
}
