using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Domain.Persistance;

namespace Bussiness
{
    public class TrainRepository: ITrainRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public TrainRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<Train> GetTrains()
        {
            return _databaseContext.Trains.ToList();
        }

        public void CreateTrain(Train train)
        {
            _databaseContext.Trains.Add(train);
            _databaseContext.SaveChanges();
        }

        public void DeleteTrain(Guid trainId)
        {
            var train = GetTrainById(trainId);
            if (train == null) return;
            _databaseContext.Trains.Remove(train);
            _databaseContext.SaveChanges();
        }

        public void EditTrain(Train train)
        {
            _databaseContext.Trains.Update(train);
            _databaseContext.SaveChanges();
        }

        public Train GetTrainById(Guid trainId)
        {
            return _databaseContext.Trains.FirstOrDefault(train => train.Id == trainId);
        }
    }
}
