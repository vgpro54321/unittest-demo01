using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestDemo.Services
{
    public class PersonRepository :
        IPersonRepository
    {
        int _id = 1;
        List<PersonDto> personDtos = new List<PersonDto>();
        public PersonDto PersonSelect(int personId)
        {
            return personDtos.FirstOrDefault(p => p.Id.Value == personId);
        }


        public PersonDto PersonCreate(PersonDto personDraft)
        {
            PersonDto personDto = (PersonDto)personDraft.Clone();
            personDto.Id = _id++;
            personDtos.Add(personDto);
            return personDto;

        } 

        public void PersonUpdate(PersonDto personDraft)
        {
            int index = GetIndexById(personDraft.Id.Value);

            PersonDto person = personDtos[index];
            person.Name = personDraft.Name;
        }

        public void PersonDelete(int id)
        {
            int index = GetIndexById(id);

            personDtos.RemoveAt(index);
        }

        private int GetIndexById(int personId)
        {
            int index = personDtos.FindIndex(p => p.Id.Value == personId);
            if (index < 0)
                throw new Exception($"Person with id {personId} not found.");
            return index;
        }
    }
}
