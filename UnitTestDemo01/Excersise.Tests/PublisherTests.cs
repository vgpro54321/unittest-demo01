using Excercise.Services;
using Moq;
using System;
using Xunit;

namespace Excersise.Tests
{
    public class PublisherTests
    {
        [Fact]
        public void Emit_ShouldCallOnNext()
        {
            // Arrange
            IPublisher<int> publisher = new Publisher<int>();

            var subscriber = new Mock<IObserver<int>>(MockBehavior.Strict);
            subscriber.Setup((x) => x.OnNext(It.IsAny<int>()));

            // Act
            var subscription = publisher.Subscribe(subscriber.Object);
            publisher.Emit(1);

            // Assert
            subscriber.Verify((x) => x.OnNext(It.IsAny<int>()), Times.Once);
        }
    }
}
