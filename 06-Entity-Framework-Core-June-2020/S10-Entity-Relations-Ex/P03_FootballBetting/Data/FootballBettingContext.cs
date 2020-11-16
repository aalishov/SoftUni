﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext() { }

        public FootballBettingContext(DbContextOptions options)
            : base(options) { }


        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FootballBetting;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(e => e.BetId);

                entity.HasOne(e => e.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(e => e.GameId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.HasOne(e => e.HomeTeam)
                    .WithMany(ht => ht.HomeGames)
                    .HasForeignKey(e => e.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.AwayTeam)
                    .WithMany(at => at.AwayGames)
                    .HasForeignKey(e => e.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.HasOne(e => e.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(e => e.PositionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(e => e.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.GameId });

                entity.HasOne(e => e.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(e => e.GameId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(e => e.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.HasOne(e => e.PrimaryKitColor)
                    .WithMany(pkc => pkc.PrimaryKitTeams)
                    .HasForeignKey(e => e.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict); 

                entity.HasOne(e => e.SecondaryKitColor)
                    .WithMany(skc => skc.SecondaryKitTeams)
                    .HasForeignKey(e => e.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Town)
                    .WithMany(t => t.Teams)
                    .HasForeignKey(e => e.TownId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownId);

                entity.HasOne(e => e.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(e => e.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });
        }
    }
}
