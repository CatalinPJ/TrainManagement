using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Data.Domain.Interfaces
{
    public interface IRouteNodeRepository
    {
        IReadOnlyList<RouteNode> GetRouteNodes();
        void CreateRouteNode(RouteNode routeNode);
        void DeleteRouteNode(Guid routeNodeId);
        void EditRouteNode(RouteNode routeNode);
        RouteNode GetRouteNodeById(Guid routeNodeId);
    }
}