using Microsoft.AspNetCore.Mvc;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;
using WebAppiWorldCup2022.ViewModels.MatchViewModels;

namespace WebAppiWorldCup2022.Services
{
    public interface ImatchService
    {
        Task<IEnumerable<Match>> GetMatch();
        Task<Match>PostMatch(CreateMatchViewModel createMatchView);
        Task<Match> GetMatchById(int id);

        Task<Match> PutMatch(CreateUpdateViewModel updateMatch);    


    }
}
