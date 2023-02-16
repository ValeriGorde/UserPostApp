﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UserPostApp.Models;
using UserPostApp.Models.DB;

namespace UserPostApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _repository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repository)
        {
            _logger = logger;
            _repository = repository;   
        }

        public async Task<IActionResult> Index()
        {
            // Добавим создание нового пользователя
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Andrey",
                LastName = "Petrov",
                JoinDate = DateTime.Now
            };

            // Добавим в базу
            await _repository.AddUser(newUser);

            // Выведем результат
            Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

            return View();
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