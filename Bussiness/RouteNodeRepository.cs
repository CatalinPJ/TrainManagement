using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistance;

namespace Bussiness
{
    public class RouteNodeRepository : IRepository<RouteNode>
    {
        private readonly IDatabaseContext _databaseContext;

        public RouteNodeRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<RouteNode> GetAll()
        {
            return _databaseContext.RouteNodes.ToList();
        }

        public void Create(RouteNode routeNode)
        {
            _databaseContext.RouteNodes.Add(routeNode);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid routeNodeId)
        {
            var routeNode = GetById(routeNodeId);
            _databaseContext.RouteNodes.Remove(routeNode);
            _databaseContext.SaveChanges();
        }

        public void Edit(RouteNode routeNode)
        {
            _databaseContext.RouteNodes.Update(routeNode);
            _databaseContext.SaveChanges();
        }

        public RouteNode GetById(Guid routeNodeId)
        {
            return _databaseContext.RouteNodes.FirstOrDefault(n => n.Id == routeNodeId);
        }
    }
}
