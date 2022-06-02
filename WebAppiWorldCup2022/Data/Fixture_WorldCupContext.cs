﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAppiWorldCup2022.Models;

namespace WebAppiWorldCup2022.Data
{
    public partial class Fixture_WorldCupContext : DbContext
    {
        public Fixture_WorldCupContext()
        {
        }

        public Fixture_WorldCupContext(DbContextOptions<Fixture_WorldCupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Incidents> Incidents { get; set; }
        public virtual DbSet<Instance> Instance { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Referee> Referee { get; set; }
        public virtual DbSet<RefereeMatch> RefereeMatch { get; set; }
        public virtual DbSet<SoccerTeam> SoccerTeam { get; set; }
        public virtual DbSet<Stadium> Stadium { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>(entity =>
            {
                entity.HasKey(e => e.IdCoach);

                entity.Property(e => e.IdCoach).HasColumnName("idCoach");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.IdSoccerTeam).HasColumnName("idSoccerTeam");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coach_Person");

                entity.HasOne(d => d.IdSoccerTeamNavigation)
                    .WithMany(p => p.Coach)
                    .HasForeignKey(d => d.IdSoccerTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coach_SoccerTeam");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.IdGroups)
                    .HasName("PK_Group");

                entity.Property(e => e.IdGroups).HasColumnName("idGroups");

                entity.Property(e => e.NameGroup)
                    .HasMaxLength(10)
                    .HasColumnName("nameGroup");
            });

            modelBuilder.Entity<Incidents>(entity =>
            {
                entity.HasKey(e => e.IdIncidents);

                entity.Property(e => e.IdIncidents).HasColumnName("idIncidents");

                entity.Property(e => e.Goal).HasColumnName("goal");

                entity.Property(e => e.IdCoach).HasColumnName("idCoach");

                entity.Property(e => e.IdPlayer).HasColumnName("idPlayer");

                entity.Property(e => e.IdSocceteam).HasColumnName("idSocceteam");

                entity.Property(e => e.Minute)
                    .HasMaxLength(50)
                    .HasColumnName("minute");

                entity.Property(e => e.RedCard).HasColumnName("redCard");

                entity.Property(e => e.YellowCrad).HasColumnName("yellowCrad");

                entity.HasOne(d => d.IdCoachNavigation)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.IdCoach)
                    .HasConstraintName("FK_Incidents_Coach");

                entity.HasOne(d => d.IdMatchNavigation)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.IdMatch)
                    .HasConstraintName("FK_Incidents_Match");

                entity.HasOne(d => d.IdPlayerNavigation)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.IdPlayer)
                    .HasConstraintName("FK_Incidents_Player");

                entity.HasOne(d => d.IdSocceteamNavigation)
                    .WithMany(p => p.Incidents)
                    .HasForeignKey(d => d.IdSocceteam)
                    .HasConstraintName("FK_Incidents_SoccerTeam");
            });

            modelBuilder.Entity<Instance>(entity =>
            {
                entity.HasKey(e => e.IdInstance);

                entity.Property(e => e.IdInstance).HasColumnName("idInstance");

                entity.Property(e => e.InstanceName)
                    .HasMaxLength(50)
                    .HasColumnName("instanceName");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.IdMatch);

                entity.Property(e => e.IdMatch).HasColumnName("idMatch");

                entity.Property(e => e.IdInstance).HasColumnName("idInstance");

                entity.Property(e => e.IdScoccerTeamLocal).HasColumnName("idScoccerTeamLocal");

                entity.Property(e => e.IdSoccerteamVisit).HasColumnName("idSoccerteamVisit");

                entity.Property(e => e.IdStadium).HasColumnName("idStadium");

                entity.Property(e => e.MatchDay)
                    .HasColumnType("datetime")
                    .HasColumnName("matchDay");

                entity.HasOne(d => d.IdInstanceNavigation)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.IdInstance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Instance");

                entity.HasOne(d => d.IdScoccerTeamLocalNavigation)
                    .WithMany(p => p.MatchIdScoccerTeamLocalNavigation)
                    .HasForeignKey(d => d.IdScoccerTeamLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_SoccerTeam");

                entity.HasOne(d => d.IdSoccerteamVisitNavigation)
                    .WithMany(p => p.MatchIdSoccerteamVisitNavigation)
                    .HasForeignKey(d => d.IdSoccerteamVisit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_SoccerTeam1");

                entity.HasOne(d => d.IdStadiumNavigation)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.IdStadium)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Match_Stadium");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson);

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.IdPlayer);

                entity.Property(e => e.IdPlayer).HasColumnName("idPlayer");

                entity.Property(e => e.Goal).HasColumnName("goal");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.IdSoccerTeam).HasColumnName("idSoccerTeam");

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .HasColumnName("position")
                    .IsFixedLength();

                entity.Property(e => e.RedCard).HasColumnName("redCard");

                entity.Property(e => e.Yellowcard).HasColumnName("yellowcard");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_Person");

                entity.HasOne(d => d.IdSoccerTeamNavigation)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.IdSoccerTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_SoccerTeam1");
            });

            modelBuilder.Entity<Referee>(entity =>
            {
                entity.HasKey(e => e.IdReferee);

                entity.Property(e => e.IdReferee).HasColumnName("idReferee");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.Referee)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Referee_Person");
            });

            modelBuilder.Entity<RefereeMatch>(entity =>
            {
                entity.HasKey(e => e.IdRefereeMatch);

                entity.Property(e => e.IdRefereeMatch).HasColumnName("idRefereeMatch");

                entity.Property(e => e.IdReferee).HasColumnName("idReferee");

                entity.Property(e => e.Idmatch).HasColumnName("idmatch");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .HasColumnName("position");

                entity.HasOne(d => d.IdRefereeNavigation)
                    .WithMany(p => p.RefereeMatch)
                    .HasForeignKey(d => d.IdReferee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefereeMatch_Referee");

                entity.HasOne(d => d.IdmatchNavigation)
                    .WithMany(p => p.RefereeMatch)
                    .HasForeignKey(d => d.Idmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefereeMatch_Match");
            });

            modelBuilder.Entity<SoccerTeam>(entity =>
            {
                entity.HasKey(e => e.IdSoccerTeam);

                entity.Property(e => e.IdSoccerTeam).HasColumnName("idSoccerTeam");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.Goal).HasColumnName("goal");

                entity.Property(e => e.IdGroups).HasColumnName("idGroups");

                entity.HasOne(d => d.IdGroupsNavigation)
                    .WithMany(p => p.SoccerTeam)
                    .HasForeignKey(d => d.IdGroups)
                    .HasConstraintName("FK_SoccerTeam_Groups");
            });

            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.HasKey(e => e.IdStadium);

                entity.Property(e => e.IdStadium).HasColumnName("idStadium");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}