//MdStart
namespace ObserverPattern.ConApp
{
    /// <summary>
    /// Represents a subject in the observer pattern that uses events.
    /// </summary>
    public class EventSubject : Logic.WithEvents.Subject
    {
        /// <summary>
        /// Notifies all observers by invoking the NotifyEvent.
        /// </summary>
        public void Notify()
        {
            NotifyAll(new EventArgs());
        }
    }
}
//MdEnd