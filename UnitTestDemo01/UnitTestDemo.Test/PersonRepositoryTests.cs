using System;
using UnitTestDemo.Services;
using Xunit;

namespace UnitTestDemo.Test
{
    public class PersonRepositoryTests
    {
        private IPersonRepository CreateRepository()
        {
            return new PersonRepository();
        }

        private PersonDto CreatePerson()
        {
            return new PersonDto()
            {
                Name = "John Smith"
            };
        }



        [Fact]
        public void PersonSelect_WithInvalidKey_ReturnsNull()
        {
            // Arrange
            IPersonRepository repository = CreateRepository();

            // Act
            var personSelect = repository.PersonSelect(-1);

            // Assert
            Assert.Null(personSelect);
        }

      

        [Fact]
        public void PersonCreate_CreatesPerson()
        {
            // Arrange
            IPersonRepository repository = CreateRepository();

            // Act
            PersonDto personDraft = CreatePerson();

            var person = repository.PersonCreate(personDraft);

            var personSelect = repository.PersonSelect(person.Id.Value);

            // Assert
            Assert.NotNull(personSelect);

            Assert.Equal(personDraft.Name, personSelect.Name);
        }

        [Fact]
        public void PersonUpdate_WithValidKey_UpdatesPerson()
        {
            // Arrange
            IPersonRepository repository = CreateRepository();

            // Act
            PersonDto personDraft = CreatePerson();

            var person = repository.PersonCreate(personDraft);

            person.Name += "Changed";
            repository.PersonUpdate(person);

            var personSelect = repository.PersonSelect(person.Id.Value);

            // Assert
            Assert.Equal(person.Name, personSelect.Name);
        }

        [Fact]
        public void PersonUpdate_WithInvalidKey_Fails()
        {
            // Arrange
            IPersonRepository repository = CreateRepository();

            PersonDto person = CreatePerson();
            person.Id = -1;

            // Act / Assert
            Assert.Throws<Exception>(() => 
            { 
                repository.PersonUpdate(person); 
            });

        }

        [Fact]
        public void PersonDelete_WithValidKey_DeletesPerson()
        {
            // Arrange
            IPersonRepository repository = CreateRepository();

            // Act
            PersonDto personDraft = CreatePerson();

            var person = repository.PersonCreate(personDraft);

            repository.PersonDelete(person.Id.Value);

            var personSelect = repository.PersonSelect(person.Id.Value);

            // Assert
            Assert.Null(personSelect);
        }

        [Fact]
        public void PersonDelete_WithInvalidKey_Fails()
        {
            // Arrange
            IPersonRepository repository = CreateRepository();

            // Act / Assert
            Assert.Throws<Exception>(() =>
            {
                repository.PersonDelete(-1);
            });
        }
    }
}
