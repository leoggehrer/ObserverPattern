//MdStart
namespace ObserverPattern.Logic.WithInterfaces
{
    /// <summary>
    /// Represents an abstract subject in the Observer pattern.
    /// </summary>
    public abstract class Subject : ISubject
    {
        #region fields
        private List<IObserver> _observers = new();
        #endregion fields

        /// <summary>
        /// Attaches an observer to the subject.
        /// </summary>
        /// <param name="observer">The observer to attach.</param>
        public void Attach(IObserver observer)
        {
            lock(this)
            {
                if (_observers.Contains(observer) == false)
                {
                    _observers.Add(observer);
                }
            }
        }

        /// <summary>
        /// Detaches an observer from the subject.
        /// </summary>
        /// <param name="observer">The observer to detach.</param>
        public void Detach(IObserver observer)
        {
            lock (this)
            {
                _observers.Remove(observer);
            }
        }

        /// <summary>
        /// Detaches all observers from the subject.
        /// </summary>
        public void DetachAll()
        {
            lock (this)
            {
                _observers.Clear();
            }
        }

        /// <summary>
        /// Notifies all attached observers of an event.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected void NotifyAll(EventArgs e)
        {
            lock(this)
            {
                foreach (var observer in _observers)
                {
                    Task.Factory.StartNew(() => observer.Update(this, e));
                }
            }
        }
    }
}
//MdEnd