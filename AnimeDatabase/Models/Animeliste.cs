using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeDatabase.Models
{
    public class Animeliste
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string Title { get; set; }

        [StringLength(25, MinimumLength = 4)]
        [Required]
        public string Genre { get; set; }

        [Required]
        [Range(1, 9999)]
        public int Episoden { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 10)]
        [Required]
        public int Rating { get; set; }
    }
}
