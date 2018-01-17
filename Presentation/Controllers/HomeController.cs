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
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<Notification> _notificationRepository;

        public HomeController(IRepository<Station> repository, IRepository<Ticket> ticketRepository, IRepository<Notification> notificationRepository)
        {
            _repository = repository;
            _ticketRepository = ticketRepository;
            _notificationRepository = notificationRepository;
        }

        public IActionResult Index()
        {
            //            string mail = "petronel.catalin@gmail.com";
            string mail = this.User.Identity.Name;
            List<Ticket> tickets = _ticketRepository.GetAll().Where(o => o.Email == mail).ToList();
            List<Notification> notifications = _notificationRepository.GetAll().ToList();
            List<Notification> result = new List<Notification>();
            foreach (Ticket ticket in tickets)
            {
                foreach (var notification in notifications)
                    if (ticket.TrainNumber == notification.TrainNo)
                        result.Add(notification);
            }
            return View(result);
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
