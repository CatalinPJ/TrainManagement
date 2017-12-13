using System.Collections.Generic;
using System.IO;
using System.Xml;
using Data.Domain.Entities;

namespace Data.Domain.Entities
{
    public class DbPopulate
    {
        FileStream xmlStream;
        public DbPopulate()
        {
            //xmlStream = new FileStream("trains.xml", FileMode.Open);
            //trainReader = XmlReader.Create(xmlStream);
        }
        public List<Train> GetTrains()
        {
            xmlStream = new FileStream("trains.xml", FileMode.Open);
            XmlReader trainReader = XmlReader.Create(xmlStream);
            List<Train> trains = new List<Train>();
            while (trainReader.ReadToFollowing("Tren"))
            {
                Train currentTrain = new Train();

                trainReader.MoveToAttribute("CategorieTren");
                currentTrain.Category = trainReader.Value;

                trainReader.MoveToAttribute("KmCum");
                currentTrain.CumulatedKm = (int)float.Parse(trainReader.Value);

                trainReader.MoveToAttribute("Numar");
                currentTrain.OfficialNumber = trainReader.Value;

                trainReader.MoveToAttribute("Lungime");
                currentTrain.Length = int.Parse(trainReader.Value);

                trainReader.MoveToAttribute("Operator");
                currentTrain.OperatorCode = int.Parse(trainReader.Value);

                trainReader.MoveToAttribute("Proprietar");
                currentTrain.OwnerCode = int.Parse(trainReader.Value);

                trainReader.MoveToAttribute("Rang");
                currentTrain.Rank = int.Parse(trainReader.Value);

                trainReader.MoveToAttribute("Tonaj");
                currentTrain.Weight = int.Parse(trainReader.Value);

                trains.Add(currentTrain);
            }
            xmlStream.Close();
            return trains;
        }

        public List<Station> GetStations()
        {
            xmlStream = new FileStream("trains.xml", FileMode.Open);
            XmlReader stationReader = XmlReader.Create(xmlStream);
            List<Station> _stations = new List<Station>();
            Dictionary<int, string> stations = new Dictionary<int, string>();
            while (stationReader.ReadToFollowing("ElementTrasa"))
            {

                stationReader.MoveToAttribute("CodStaOrigine");
                int id = int.Parse(stationReader.Value);

                stationReader.MoveToAttribute("DenStaOrigine");
                string stationName = stationReader.Value;

                if (!stations.ContainsKey(id))
                {
                    stations.Add(id, stationName);
                }
            }
            foreach (var station in stations)
            {
                Station currentStation = new Station
                {
                    Name = station.Value,
                    OfficialCode = station.Key
                };
                _stations.Add(currentStation);
            }
            xmlStream.Close();
            return _stations;
        }

        public List<Route> GetRoutes()
        {
            List<Route> _routes = new List<Route>();
            xmlStream = new FileStream("trains.xml", FileMode.Open);
            XmlReader routeReader = XmlReader.Create(xmlStream);
            while (routeReader.ReadToFollowing("Trasa"))
            {
                Route currentRoute = new Route();

                routeReader.MoveToAttribute("CodStatieFinala");
                currentRoute.DestinationStationCode = int.Parse(routeReader.Value);

                routeReader.MoveToAttribute("CodStatieInitiala");
                currentRoute.OriginStationCode = int.Parse(routeReader.Value);

                routeReader.MoveToAttribute("Tip");
                currentRoute.Type = routeReader.Value;

                routeReader.MoveToContent();
                routeReader.ReadToDescendant("ElementTrasa");
                int counter = 0;
                do
                {
                    RouteNode currentRouteNode = new RouteNode();

                    routeReader.MoveToAttribute("DenStaOrigine");
                    currentRouteNode.Name = routeReader.Value;

                    routeReader.MoveToAttribute("CodStaDest");
                    currentRouteNode.DestinationStationCode = int.Parse(routeReader.Value);

                    routeReader.MoveToAttribute("CodStaOrigine");
                    currentRouteNode.OriginStationCode = int.Parse(routeReader.Value);

                    routeReader.MoveToAttribute("DenStaDestinatie");
                    currentRouteNode.DestinationStationName = routeReader.Value;

                    routeReader.MoveToAttribute("DenStaOrigine");
                    currentRouteNode.OriginStationName = routeReader.Value;

                    routeReader.MoveToAttribute("Km");
                    currentRouteNode.Km = int.Parse(routeReader.Value);
                    currentRouteNode.OfficialCode = counter++;
                    currentRouteNode.RouteId = currentRoute.Id;
                    /*
                     Parse Data
                    */

                    routeReader.MoveToAttribute("StationareSecunde");
                    currentRouteNode.Standing = int.Parse(routeReader.Value);

                    // add routenode through repo? YES, we'll do

                    currentRoute.RouteNodes.Add(currentRouteNode);

                } while (routeReader.ReadToNextSibling("ElementTrasa"));
                _routes.Add(currentRoute);
                // add route through route repo
            }
            xmlStream.Close();
            return _routes;
        }

        /*public List<Route> GetRoutes()
        {
            List<Route> routes = new List<Route>();
            return routes;
        }*/

    }
}