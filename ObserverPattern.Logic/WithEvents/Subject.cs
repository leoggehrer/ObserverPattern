//MdStart
namespace ObserverPattern.Logic.WithEvents
{
    /// <summary>
    /// Represents an abstract subject in the observer pattern that uses events.
    /// </summary>
    public abstract class Subject
    {
        #region fields
        private readonly object _lock = new object();
        private event EventHandler? _notifyEvent;
        #endregion fields

        #region properties
        /// <summary>
        /// Occurs when the subject notifies its observers.
        /// </summary>
        public event EventHandler? NotifyEvent
        {
            add
            {
                lock (_lock)
                {
                    _notifyEvent += value;
                }
            }
            remove
            {
                lock (_lock)
                {
                    _notifyEvent -= value;
                }
            }
        }
        #endregion properties

        #region methods
        /// <summary>
        /// Notifies all observers by invoking the NotifyEvent.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected void NotifyAll(EventArgs e)
        {
            EventHandler? handler;
            lock (_lock)
            {
                handler = _notifyEvent;
            }

            Console.WriteLine("The subject triggers the Notify event...");
            handler?.Invoke(this, e);
        }
        #endregion methods
    }
}
//MdEnd