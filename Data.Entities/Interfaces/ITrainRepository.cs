using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Data.Domain.Interfaces
{
    public interface ITrainRepository
    {
        IReadOnlyList<Train> GetTrains();
        void CreateTrain(Train train);
        void DeleteTrain(Guid trainId);
        void EditTrain(Train train);
        Train GetTrainById(Guid trainId);
    }
}
