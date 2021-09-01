using System;

namespace Excercise.Services
{
    public class Subscription<T> :
        IDisposable
    {
        private readonly Publisher<T> owner;
        private readonly IObserver<T> observer;
        private bool disposedValue;

        public Subscription(Publisher<T> owner, IObserver<T> observer)
        {
            this.owner = owner;
            this.observer = observer;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    owner.Unsubscribe(this.observer);
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Subscription()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
