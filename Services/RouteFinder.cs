﻿using Data.Domain.Entities;
using Data.Persistance;
using Microsoft.EntityFrameworkCore;
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
        public List<Train> GetTrains(int originCode, int destinationCode)
        {
            List<Train> all_trains = _context.Trains.Include("RouteNodes").ToList();
            List<Train> trains = new List<Train>();
            trains.Add(all_trains.FirstOrDefault(o => o.OfficialNumber == "8444"));
            /*List<Route> routes = _context.Routes.ToList();
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
                    nodes.Add(route.TrainOfficialNumber);
                }

            }*/
            return trains;
        }
    }
}