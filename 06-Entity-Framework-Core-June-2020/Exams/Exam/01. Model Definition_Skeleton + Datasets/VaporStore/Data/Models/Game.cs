﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VaporStore.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [ForeignKey("Developer")]
        public int DeveloperId { get; set; }

        [Required]
        public virtual Developer Developer { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public virtual Genre Genre { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

        public virtual ICollection<GameTag> GameTags { get; set; } = new HashSet<GameTag>();
    }
}
