﻿using AutoMapper;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;
using WebAppiWorldCup2022.Models.ViewModels.MatchViewModels;

namespace WebAppiWorldCup2022.Profiles
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Person, PersonCreateViewModel>()
                .ForMember(m => m.Name, o => o.MapFrom(x => x.Name))
                .ForMember(m => m.LastName, o => o.MapFrom(x => x.LastName))
                .ForMember(m => m.DateOfBirth, o => o.MapFrom(x => x.DateOfBirth));

            CreateMap<Player, PersonCreateViewModel>()
                .ForMember(m => m.SoccerTeam, o => o.MapFrom(x => x.IdSoccerTeamNavigation))
                .ForMember(m => m.Position, o => o.MapFrom(x => x.Position));

            CreateMap<Incidents, IncidentViewModel>()
                .ForMember(m => m.Stadium, o => o.MapFrom(x => x.IdMatchNavigation.IdStadiumNavigation.Name))
                .ForMember(m => m.Instance, o => o.MapFrom(x => x.IdMatchNavigation.IdInstanceNavigation.InstanceName))
                .ForMember(m => m.SoccerTeamLocal, o => o.MapFrom(x => x.IdMatchNavigation.IdScoccerTeamLocalNavigation.Country))
                .ForMember(m => m.SoccerTeamVisit, o => o.MapFrom(x => x.IdMatchNavigation.IdSoccerteamVisitNavigation.Country))
                .ForMember(m => m.MatchDay, o => o.MapFrom(x => x.IdMatchNavigation.MatchDay))
                .ForMember(m => m.Goal, o => o.MapFrom(x => x.IdSocceteamNavigation.Country))
                .ForMember(m => m.YellowCard, o => o.MapFrom(x => x.YellowCrad))
                .ForMember(m => m.RedCard, o => o.MapFrom(x => x.RedCard));

            CreateMap<Match, CreateMatchViewModel>()
                .ForMember(m => m.Stadium, o => o.MapFrom(x => x.IdStadium))
                .ForMember(m => m.Instance, o => o.MapFrom(x => x.IdInstance))
                .ForMember(m => m.SoccerTeamLocal, o => o.MapFrom(x => x.IdScoccerTeamLocal))
                .ForMember(m => m.SoccerTeamVisit, o => o.MapFrom(x => x.IdSoccerteamVisit))
                .ForMember(m => m.MatchDay, o => o.MapFrom(x => x.MatchDay));

            CreateMap<Match, MatchViewModel>()
                .ForMember(m => m.Stadium, o => o.MapFrom(x => x.IdStadiumNavigation.Name))
                .ForMember(m => m.Instance, o => o.MapFrom(x => x.IdInstanceNavigation.InstanceName))
                .ForMember(m => m.SoccerTeamLocal, o => o.MapFrom(x => x.IdScoccerTeamLocalNavigation.Country))
                .ForMember(m => m.SoccerTeamVisit, o => o.MapFrom(x => x.IdSoccerteamVisitNavigation.Country))
                .ForMember(m => m.MatchDay, o => o.MapFrom(x => x.MatchDay));


        }
        
    }
}