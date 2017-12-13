using Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Data.Domain.Interfaces
{
    public interface IRouteRepository
    {
        IReadOnlyList<Route> GetRoutes();
        void CreateRoute(Route route);
        void DeleteRoute(Guid routeId);
        void EditRoute(Route route);
        Route GetRouteById(Guid routeId);
    }
}