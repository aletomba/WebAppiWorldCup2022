using AutoMapper;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;
using WebAppiWorldCup2022.Models.ViewModels.IncidentsviewModels;
using WebAppiWorldCup2022.Models.ViewModels.MatchViewModels;
using WebAppiWorldCup2022.ViewModels.GroupsViewModels;
using WebAppiWorldCup2022.ViewModels.InstancesViewModels;
using WebAppiWorldCup2022.ViewModels.MatchViewModels;
using WebAppiWorldCup2022.ViewModels.PLayerViewModel;
using WebAppiWorldCup2022.ViewModels.SoccerTeamViewmodels;
using WebAppiWorldCup2022.ViewModels.StadiumViewMoldels;

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

            CreateMap<Player, PlayerView>()
                .ForMember(m => m.IdPLayer, o => o.MapFrom(x => x.IdPlayer))
                .ForMember(m => m.Name, o => o.MapFrom(x => x.IdPersonNavigation.Name))
                .ForMember(m => m.LastName, o => o.MapFrom(x => x.IdPersonNavigation.LastName))
                .ForMember(m => m.Position, o => o.MapFrom(x => x.Position))
                .ForMember(m => m.Country, o => o.MapFrom(x => x.IdSoccerTeamNavigation.Country));



            CreateMap<Incidents, IncidentViewModel>()
                .ForMember(m => m.Stadium, o => o.MapFrom(x => x.IdMatchNavigation.IdStadiumNavigation.Name))                
                .ForMember(m => m.SoccerTeamLocal, o => o.MapFrom(x => x.IdMatchNavigation.IdScoccerTeamLocalNavigation.Country))
                .ForMember(m => m.SoccerTeamVisit, o => o.MapFrom(x => x.IdMatchNavigation.IdSoccerteamVisitNavigation.Country))
                .ForMember(m => m.Instance, o => o.MapFrom(x => x.IdSocceteamNavigation.IdGroupsNavigation.NameGroup))
                .ForMember(m => m.MatchDay, o => o.MapFrom(x => x.IdMatchNavigation.MatchDay))
                .ForMember(m => m.Goal, o => o.MapFrom(x => x.IdSocceteamNavigation.Goal))
                .ForMember(m => m.YellowCard, o => o.MapFrom(x => x.YellowCrad))
                .ForMember(m => m.RedCard, o => o.MapFrom(x => x.RedCard));

            CreateMap<Incidents, CreateIncidentsViewmodel>()

                .ForMember(m => m.Soccerteam, o => o.MapFrom(x => x.IdMatchNavigation.IdScoccerTeamLocalNavigation.Country))
                .ForMember(m => m.NamePlayer, o => o.MapFrom(x => x.IdPlayerNavigation.IdPersonNavigation.Name))
                .ForMember(m => m.idMatch, o => o.MapFrom(x => x.IdMatchNavigation.IdMatch))
                .ForMember(m => m.Goal, o => o.MapFrom(x => x.Goal));
               

            CreateMap<Match, CreateMatchViewModel>()                
                .ForMember(m => m.Stadium, o => o.MapFrom(x => x.IdStadium))
                .ForMember(m => m.Instance, o => o.MapFrom(x => x.IdInstance))
                .ForMember(m => m.SoccerTeamLocal, o => o.MapFrom(x => x.IdScoccerTeamLocal))
                .ForMember(m => m.SoccerTeamVisit, o => o.MapFrom(x => x.IdSoccerteamVisit))
                .ForMember(m => m.MatchDay, o => o.MapFrom(x => x.MatchDay));

            CreateMap<Match, CreateUpdateViewModel>()
                .ForMember(m => m.Stadium, o => o.MapFrom(x => x.IdStadium))
                .ForMember(m => m.StadiumView, o => o.MapFrom(x => x.IdStadiumNavigation.Name))
                .ForMember(m => m.InstanceView, o => o.MapFrom(x => x.IdInstanceNavigation.InstanceName))
                .ForMember(m => m.Instance, o => o.MapFrom(x => x.IdInstance))
                .ForMember(m => m.SoccerTeamLocalView, o => o.MapFrom(x => x.IdScoccerTeamLocalNavigation.Country))
                .ForMember(m => m.SoccerTeamLocal, o => o.MapFrom(x => x.IdScoccerTeamLocal))
                .ForMember(m => m.SoccerTeamVisiView, o => o.MapFrom(x => x.IdSoccerteamVisitNavigation.Country))
                .ForMember(m => m.SoccerTeamVisit, o => o.MapFrom(x => x.IdSoccerteamVisit))
                .ForMember(m => m.MatchDay, o => o.MapFrom(x => x.MatchDay));

            CreateMap<SoccerTeam, Matchkey>()
                .ForMember(m => m.SoccerTeam1, o => o.MapFrom(x => x.Country[0]))
                .ForMember(m => m.SoccerTeam2, o => o.MapFrom(x => x.Country[1]));

            CreateMap<SoccerTeam, SoccerTeamViewModel>()
               .ForMember(m => m.idCountry, o => o.MapFrom(x => x.IdSoccerTeam))
               .ForMember(m => m.Country, o => o.MapFrom(x => x.Country))
               .ForMember(m => m.IdGroup, o => o.MapFrom(x => x.IdGroups))
               .ForMember(m => m.Group, o => o.MapFrom(x => x.IdGroupsNavigation.NameGroup))
               .ForMember(m => m.Goal, o => o.MapFrom(x => x.Goal))
               .ForMember(m => m.Points, o => o.MapFrom(x => x.Points));

            CreateMap<Stadium, StadiumView>()
              .ForMember(m => m.IdStadium, o => o.MapFrom(x => x.IdStadium))
              .ForMember(m => m.Name, o => o.MapFrom(x => x.Name));

            CreateMap<Instance, InstanceView>()
                .ForMember(m => m.IdInstance, o => o.MapFrom(x => x.IdInstance))
                .ForMember(m => m.Descrition, o => o.MapFrom(x => x.InstanceName));
        

            CreateMap<Groups, GroupView>()
               .ForMember(m => m.GroupId, o => o.MapFrom(x => x.IdGroups))
               .ForMember(m => m.GroupName, o => o.MapFrom(x => x.NameGroup));
        }
        
    }
}
