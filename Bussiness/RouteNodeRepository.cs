using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistance;

namespace Bussiness
{
    class RouteNodeRepository : IRouteNodeRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public RouteNodeRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<RouteNode> GetRouteNodes()
        {
            return _databaseContext.RouteNodes.ToList();
        }

        public void CreateRouteNode(RouteNode routeNode)
        {
            _databaseContext.RouteNodes.Add(routeNode);
            _databaseContext.SaveChanges();
        }

        public void DeleteRouteNode(Guid routeNodeId)
        {
            var routeNode = GetRouteNodeById(routeNodeId);
            _databaseContext.RouteNodes.Remove(routeNode);
            _databaseContext.SaveChanges();
        }

        public void EditRouteNode(RouteNode routeNode)
        {
            _databaseContext.RouteNodes.Update(routeNode);
            _databaseContext.SaveChanges();
        }

        public RouteNode GetRouteNodeById(Guid routeNodeId)
        {
            return _databaseContext.RouteNodes.FirstOrDefault(n => n.Id == routeNodeId);
        }
    }
}
