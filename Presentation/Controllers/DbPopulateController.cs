using Microsoft.AspNetCore.Mvc;
using Data.Persistance;
using Bussiness;
using Data.Domain.Entities;
using System.Collections.Generic;
using System;

namespace _Presentation.Controllers
{
    public class DbPopulateController : Controller
    {
        private DatabaseContext databaseContext;
        
        DbPopulate dbPopulate;
        public DbPopulateController(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
            /*trainReapository = new TrainRepository(databaseContext);
            ticketRepository = new TicketRepository(databaseContext);
            stationRepository = new StationRepository(databaseContext);
            routeNodeRepository = new RouteNodeRepository(databaseContext);
            */
            dbPopulate = new Data.Domain.Entities.DbPopulate();

        }

        // GET: DbPopulate
        public ActionResult Index()
        {
            return View();
        }


        // POST: DbPopulate/Create
        [Route("DbPopulate/Trains")]
        public ActionResult AddTrains()
        {
            List<Train> trains = dbPopulate.GetTrains();
            foreach (var train in trains)
            {
                //trainReapository.CreateTrain(train);
            }
            return new EmptyResult();
        }

        [Route("DbPopulate/Stations")]
        public ActionResult AddStations()
        {
            List<Station> stations = dbPopulate.GetStations();
            foreach (var station in stations)
            {
                //stationRepository.CreateStation(station);
            }
            return new EmptyResult();
        }

    }
}