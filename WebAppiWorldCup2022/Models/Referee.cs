﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WebAppiWorldCup2022.Models
{
    public partial class Referee
    {
        public Referee()
        {
            RefereeMatch = new HashSet<RefereeMatch>();
        }

        public int IdReferee { get; set; }
        public int IdPerson { get; set; }

        public virtual Person IdPersonNavigation { get; set; }
        public virtual ICollection<RefereeMatch> RefereeMatch { get; set; }
    }
}