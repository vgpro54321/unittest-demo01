using Moq;
using UnitTestDemo.Services;
using Xunit;

namespace UnitTestDemo.Test
{
    public class PersonCacheServiceTests
    {
        
        private PersonDto CreatePerson(int id)
        {
            return new PersonDto()
            {
                Id = id,
                Name = "John Smith"
            };
        }

        [Fact]
        public void GetPerson_CalledOnce_RetrievesPersonFromRepositoryOnce()
        {
            // Arrange
            Mock<IPersonRepository> repository = new Mock<IPersonRepository>(MockBehavior.Strict);

            repository.Setup(x => x.PersonSelect(It.IsAny<int>()))
                .Returns((int id) => CreatePerson(id));

            IPersonCacheService personCacheService = new PersonCacheService(repository.Object);

            // Act
            var person = personCacheService.GetPerson(1);

            // Assert
            repository.Verify(x => x.PersonSelect(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetPerson_CalledTwice_RetrievesPersonFromRepositoryOnce()
        {
            // Arrange
            Mock<IPersonRepository> repository = new Mock<IPersonRepository>(MockBehavior.Strict);

            repository.Setup(x => x.PersonSelect(It.IsAny<int>()))
                .Returns((int id) => CreatePerson(id));

            IPersonCacheService personCacheService = new PersonCacheService(repository.Object);

            // Act
            var person1 = personCacheService.GetPerson(1);
            var person2 = personCacheService.GetPerson(1);

            // Assert
            repository.Verify(x => x.PersonSelect(It.IsAny<int>()), Times.Once);
        }
    }
}
