using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;

namespace WebAppiWorldCup2022.Services.PeopleServices
{
    public interface IPeopleService
    {
        Task<Person> CreatePeople(PersonCreateViewModel personCreate);
    }
}
