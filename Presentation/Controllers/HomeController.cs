using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Data.Domain.Entities;
using Data.Domain.Interfaces;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Station> _repository;

        public HomeController(IRepository<Station> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetStations(string prefix) {
            if (_repository != null)
            {
                List<Station> stations = _repository.GetAll().Where(o=>o.Name.StartsWith(prefix)).ToList();
                return Json(stations);
            }
            return null;
        }

    }
}
