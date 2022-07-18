using WebAppiWorldCup2022.Models;

namespace WebAppiWorldCup2022.Services.GroupService
{
    public interface IGroupService
    {
        Task<IEnumerable<Groups>> GetGroups();
    }
}
