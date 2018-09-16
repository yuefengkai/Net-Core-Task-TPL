using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TASK.CURD.Models;
using TASK.DTO;
using TASK.IService;

namespace TASK.CURD.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _personService.GetAll(string.Empty);

            this.ViewBag.DataPerson = list;

            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonAddOrUpdateInput person)
        {
            var personDto = new PersonDTO()
            {
                Name = person.Name,
                Age = person.Age
            };

            await _personService.AddAsync(personDto);

            return Redirect("/Home/Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
