using System.Collections.Generic;
using System.IO;
using System.Xml;
using Data.Domain.Entities;
using System;

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

                trainReader.MoveToContent();

                trainReader.ReadToDescendant("Trase");
                trainReader.ReadToDescendant("Trasa");

                trainReader.MoveToContent();
                trainReader.ReadToDescendant("ElementTrasa");
                int counter = 0;
                int OraS = -1;
                do
                {
                    RouteNode currentRouteNode = new RouteNode();

                    trainReader.MoveToAttribute("CodStaDest");
                    currentRouteNode.DestinationStationCode = int.Parse(trainReader.Value);

                    trainReader.MoveToAttribute("CodStaOrigine");
                    currentRouteNode.OriginStationCode = int.Parse(trainReader.Value);

                    trainReader.MoveToAttribute("DenStaDestinatie");
                    currentRouteNode.DestinationStationName = trainReader.Value;

                    trainReader.MoveToAttribute("DenStaOrigine");
                    currentRouteNode.OriginStationName = trainReader.Value;

                    trainReader.MoveToAttribute("OraP");
                    currentRouteNode.DepartureTime = long.Parse(trainReader.Value);

                    trainReader.MoveToAttribute("OraS");
                    currentRouteNode.ArrivalTime = OraS;
                    OraS = int.Parse(trainReader.Value);

                    trainReader.MoveToAttribute("Km");
                    currentRouteNode.Km = int.Parse(trainReader.Value);
                    currentRouteNode.OfficialCode = counter++;
                    currentRouteNode.TrainId = currentTrain.Id;

                    trainReader.MoveToAttribute("StationareSecunde");
                    currentRouteNode.Standing = int.Parse(trainReader.Value);


                    currentTrain.RouteNodes.Add(currentRouteNode);

                } while (trainReader.ReadToNextSibling("ElementTrasa"));

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
    }
}