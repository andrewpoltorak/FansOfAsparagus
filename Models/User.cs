using System;
using System.ComponentModel.DataAnnotations;

namespace FansOfAsparagus.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        public int Count { get; set; } = 1;
    }
}
