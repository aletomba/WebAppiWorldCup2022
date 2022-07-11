using WebAppiWorldCup2022.Models;

namespace WebAppiWorldCup2022.Services.SoccerteamService
{
    public interface ISoccerTeamService
    {
        Task<IEnumerable<SoccerTeam>> GetSoccerTeam();
        Task<IEnumerable<SoccerTeam>> CreateSoccerTeam();
    }
}
