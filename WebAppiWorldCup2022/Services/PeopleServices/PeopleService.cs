using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Models;
using WebAppiWorldCup2022.Models.ViewModels;

namespace WebAppiWorldCup2022.Services.PeopleServices
{
    public class PeopleService : IPeopleService
    {
        private readonly Fixture_WorldCupContext _context;

        public PeopleService(Fixture_WorldCupContext context)
        {
            _context = context;      
        }

        public async Task<Person> CreatePeople(PersonCreateViewModel personCreate)
        {
            if (personCreate != null)
            {
                var person = new Person()
                {
                    Name = personCreate.Name,
                    LastName = personCreate.LastName,
                    DateOfBirth = (DateTime.Parse(personCreate.DateOfBirth))
                };
                await _context.Person.AddAsync(person);
                await _context.SaveChangesAsync();
                return person;
            }
            else
            {
                throw new Exception();
            } 

        }
    }
}
