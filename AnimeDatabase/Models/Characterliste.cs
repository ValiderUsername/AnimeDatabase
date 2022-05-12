using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeDatabase.Models
{
    public class Characterliste
    {
        public int ID { get; set; }

        [StringLength(40, MinimumLength = 2)]
        [Required]
        public string? Name { get; set; }

        [Range(1, 500000)]
        [Required]
        public int Alter { get; set; }

        [Required]
        public decimal Grösse { get; set; }
    }
}
