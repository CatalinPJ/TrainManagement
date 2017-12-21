using Data.Domain.Entities;
using Data.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class RouteFinder
    {
        DatabaseContext _context;
        public RouteFinder(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
        /*public List<List<RouteNode>> GetNodes(int originCode, int destinationCode)
        {
            List<List<RouteNode>> nodes = new List<List<RouteNode>>();
            List<Route> routes = _context.Routes.ToList();
            List<RouteNode> routeNodes = _context.RouteNodes.ToList();
            foreach (var item in routes)
            {
                foreach (var routeNode in item.RouteNodes)
                {
                    routeNodes.Add(routeNode);
                }
            }
            foreach (var route in routes)
            {
                bool valid = false;
                int count = 0, origin = 0, destination = 0;

                for (int j = 0; j < route.RouteNodes.Count; j++)
                {
                    if (route.RouteNodes[j].OriginStationCode == originCode)
                    {
                        count++;
                        origin = j;
                    }
                    if (route.RouteNodes[j].OriginStationCode == destinationCode)
                    {
                        destination = j;
                        count++;
                    }

                    if (count == 2 && origin < destination)
                    {
                        valid = true;
                    }
                }
                if (valid)
                {
                    nodes.Add(route.RouteNodes.Skip(origin).Take(destination - origin + 1).ToList());
                }

            }
            return nodes;
        }*/
        public List<Train> GetTrains(string originName, string destinationName, TimeSpan leavingAfter)
        {
            var allTrainsToDestination = _context.Trains
                .Join(_context.RouteNodes,
                    train => train.Id,
                    node => node.TrainId,
                    (train, node) => new { Train = train, RouteNode = node })
                .Where(trainAndNode => trainAndNode.RouteNode.DestinationStationName == destinationName).
                Where(train => train.Train.DepartureTime > leavingAfter.TotalSeconds)
                .Select(trainAndNode => trainAndNode.Train.Id).ToList();

            var trainsFromOriginToDestination = _context.Trains
                .Join(_context.RouteNodes,
                    train => train.Id,
                    node => node.TrainId,
                    (train, node) => new { Train = train, RouteNode = node })
                .Where(trainAndNode => trainAndNode.RouteNode.OriginStationName == originName).
                Where(train => train.Train.DepartureTime > leavingAfter.TotalSeconds)
                .Where(trainAndNode => allTrainsToDestination.Contains(trainAndNode.Train.Id)).ToList();

            List<Train> result = new List<Train>();
            result = trainsFromOriginToDestination.AsEnumerable()
                .Select(train => train.Train).ToList();

            return result;
        }
    }
}