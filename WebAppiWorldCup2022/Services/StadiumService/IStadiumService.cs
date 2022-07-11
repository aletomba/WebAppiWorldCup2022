using WebAppiWorldCup2022.Models;

namespace WebAppiWorldCup2022.Services.StadiumService
{
    public interface IStadiumService
    {
        Task<IEnumerable<Stadium>> GetStadium();
    }
}
