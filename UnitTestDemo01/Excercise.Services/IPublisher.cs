using System;

namespace Excercise.Services
{
    public interface IPublisher<T> :
        IObservable<T>
    {
        void Emit(T value);
        int Count { get; }
    }
}
