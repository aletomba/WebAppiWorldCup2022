using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.ViewModels.SoccerTeamViewmodels;

namespace WebAppiWorldCup2022.Services.SoccerteamService
{
    public interface ISoccerTeamService
    {
        Task<IEnumerable<SoccerTeam>> GetSoccerTeam();
        Task<SoccerTeam> SoccerTeamById(int id);
        Task<SoccerTeam> CreateSoccerTeam(SoccerTeamViewModel soccerTeam);
        Task<SoccerTeam> UpdateSoccerTeam(SoccerTeamViewModel soccerTeam);
        Task<SoccerTeam> DeleteSoccerTeam(int id);
    }
}
