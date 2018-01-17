using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Domain.Entities
{
    public class Wagon
    {
        public Wagon()
        {
            Id = Guid.NewGuid();
            Seats = 0;
        }
        public Guid Id { get; set; }
        [ForeignKey("Route")]
        public Guid TrainId { get; set; }
        public int Class { get; set; }
        public long Seats { get; set; }
    }
}