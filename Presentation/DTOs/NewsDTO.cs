using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.DTOs
{
    public class NewsDTO
    {
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
    }
}
