using Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Domain.Entities;
using Data.Persistance;
using System.Linq;

namespace Bussiness
{
    public class RouteRepository : IRouteRepository
    {
        private readonly IDatabaseContext _databaseContext;
        public RouteRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void CreateRoute(Route route)
        {
            _databaseContext.Routes.Add(route);
            _databaseContext.SaveChanges();
        }

        public void DeleteRoute(Guid routeId)
        {
            var entity = GetRouteById(routeId);
            _databaseContext.Routes.Remove(entity);
            _databaseContext.SaveChanges();
        }

        public void EditRoute(Route route)
        {
            _databaseContext.Routes.Update(route);
            _databaseContext.SaveChanges();
        }

        public Route GetRouteById(Guid routeId)
        {
            return _databaseContext.Routes.FirstOrDefault(o => o.Id == routeId);
        }

        public IReadOnlyList<Route> GetRoutes()
        {
            return _databaseContext.Routes.ToList();
        }
    }
}