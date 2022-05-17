using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeDatabase.Models
{
    public class Animeliste
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [StringLength(25, MinimumLength = 4)]
        [Required]
        public string Genre { get; set; }

        [Required]
        public int Episoden { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }
       
    }
}
