using System.Collections.Generic;

namespace UnitTestDemo.Services
{
    public class PersonCacheService :
        IPersonCacheService
    {
        private readonly IPersonRepository personRepository;
        readonly Dictionary<object, PersonDto> _cache = new();

        public PersonCacheService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public PersonDto GetPerson(int personId)
        {
            bool found = _cache.TryGetValue(personId, out var person);
            if (!found)
            {
                person = personRepository.PersonSelect(personId);
                _cache.Add(person, person);
            }

            return person;
        }
    }
}
