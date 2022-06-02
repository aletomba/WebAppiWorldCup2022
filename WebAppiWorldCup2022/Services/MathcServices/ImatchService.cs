using Microsoft.AspNetCore.Mvc;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;

namespace WebAppiWorldCup2022.Services
{
    public interface ImatchService
    {
        Task<IEnumerable<Match>> GetMatch();
       Task<Match>PostMatch(CreateMatchViewModel createMatchView);
    }
}
