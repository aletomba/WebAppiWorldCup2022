﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebAppiWorldCup2022.Models
{
    public partial class Person
    {
        public Person()
        {
            Coach = new HashSet<Coach>();
            Player = new HashSet<Player>();
            Referee = new HashSet<Referee>();
        }

        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Coach> Coach { get; set; }
        public virtual ICollection<Player> Player { get; set; }
        public virtual ICollection<Referee> Referee { get; set; }
    }
}