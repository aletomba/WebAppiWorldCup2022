﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebAppiWorldCup2022.Models
{
    public partial class Incidents
    {
        public int IdIncidents { get; set; }
        public int? IdSocceteam { get; set; }
        public int? IdPlayer { get; set; }
        public int? IdCoach { get; set; }
        public int? IdMatch { get; set; }
        public int? Goal { get; set; }
        public int? YellowCrad { get; set; }
        public int? RedCard { get; set; }
        public string Minute { get; set; }

        public virtual Coach IdCoachNavigation { get; set; }
        public virtual Match IdMatchNavigation { get; set; }
        public virtual Player IdPlayerNavigation { get; set; }
        public virtual SoccerTeam IdSocceteamNavigation { get; set; }
    }
}