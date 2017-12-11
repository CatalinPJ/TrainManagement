using System.Collections.Generic;
using System.IO;
using System.Xml;

using Bussiness;
using Data.Domain.Entities;

namespace DbPopulate
{
    class CfrXmlParser
    {
        static void Main(string[] args)
        {
            FileStream xmlStream = new FileStream("trains.xml", FileMode.Open);
            XmlReader trainReader = XmlReader.Create(xmlStream);
            
            //parse the trains from the xml
            
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

                
                 //call to TrainRepo goes here to add the train
                
            }


            //parse all the stations from the routes
            xmlStream.Close();
            xmlStream = new FileStream("trains.xml", FileMode.Open);
            XmlReader stationReader = XmlReader.Create(xmlStream);
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
                Station currentStation = new Station();
                currentStation.Name = station.Value;
                currentStation.OfficialCode = station.Key;

                //call to station repo to add current station
            }

            //parse all the routes
            xmlStream.Close();
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
                do
                {
                    RouteNode currentRouteNode = new RouteNode();

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

                    /*
                     Parse Data
                    */

                    routeReader.MoveToAttribute("StationareSecunde");
                    currentRouteNode.Standing = int.Parse(routeReader.Value);

                    // add routenode through repo?

                    currentRoute.RouteNodes.Add(currentRouteNode);

                } while (routeReader.ReadToNextSibling("ElementTrasa"));

                // add route through route repo
            }
        }
    }
}
