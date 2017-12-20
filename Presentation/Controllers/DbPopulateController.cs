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
        GenericRepository<Train> trainsRepository;
        GenericRepository<Station> stationRepository;
        DbPopulate dbPopulate;
        
        public DbPopulateController(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
            trainsRepository = new GenericRepository<Train>(databaseContext);
            stationRepository = new GenericRepository<Station>(databaseContext);
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
                trainsRepository.Create(train);
            }
            return new EmptyResult();
        }

        [Route("DbPopulate/Stations")]
        public ActionResult AddStations()
        {
            List<Station> stations = dbPopulate.GetStations();
            foreach (var station in stations)
            {
                stationRepository.Create(station);
            }
            return new EmptyResult();
        }

    }
}