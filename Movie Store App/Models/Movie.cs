﻿using System.ComponentModel.DataAnnotations;

namespace Movie_Store_App.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public int ReleasYear { get; set; }
        [Required]
        public decimal Pirce { get; set; }

    }
}
