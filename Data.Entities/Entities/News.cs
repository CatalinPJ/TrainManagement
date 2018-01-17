using System;

namespace Data.Domain.Entities
{
    public class News
    {
        public News()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Content { get; set; }
    }
}
