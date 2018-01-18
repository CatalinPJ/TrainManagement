using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Domain.Entities
{
    public class Infos
    {   
        public List<Notification> Notifications { get; set; }
        public List<News> News { get; set; }
        public Infos()
        {
            Notifications = new List<Notification>();
            News = new List<News>();
        }
    }
}
