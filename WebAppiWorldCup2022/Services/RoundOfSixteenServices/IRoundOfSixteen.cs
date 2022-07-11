using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;

namespace WebAppiWorldCup2022.Services.RoundOf16Services
{
    public interface IRoundOfSixteen
    {
        Task<IEnumerable<SoccerTeam>> GetPoints();

        Task<List<SoccerTeam>> GetWinner(/*int g*/);
    }
}
