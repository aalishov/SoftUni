using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public virtual Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        public virtual Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeGames { get; set; } = new List<Game>();

        [InverseProperty("AwayTeam")]
        public virtual ICollection<Game> AwayGames { get; set; } = new List<Game>();

        public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
