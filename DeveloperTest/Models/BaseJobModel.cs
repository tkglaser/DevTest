using System;
using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Models
{
    public class BaseJobModel
    {
        [Required]
        public string Engineer { get; set; }

        [Required]
        public DateTime When { get; set; }

        [Required]
        public int? CustomerId { get; set; }
    }
}
