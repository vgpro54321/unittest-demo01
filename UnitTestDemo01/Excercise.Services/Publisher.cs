using System;
using System.Collections.Generic;

namespace Excercise.Services
{
    public class Publisher<T> :
        IObservable<T>,
        IPublisher<T>
    {
        readonly List<IObserver<T>> _observers = new List<IObserver<T>>();

        public int Count { get; private set; }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _observers.Add(observer);
            return new Subscription<T>(this, observer);
        }

        public void Emit(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                _observers[i].OnNext(value);
            }
        }

        internal void Unsubscribe(IObserver<T> observer)
        {
            _observers.Remove(observer);
        }
    }
}
