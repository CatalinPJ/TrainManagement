using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string TrainNo { get; set; }
    }
}
