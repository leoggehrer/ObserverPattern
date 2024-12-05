//MdStart
namespace ObserverPattern.Logic.WithInterfaces
{
    /// <summary>
    /// Defines the interface for a subject in the Observer pattern.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// Attaches an observer to the subject.
        /// </summary>
        /// <param name="observer">The observer to attach.</param>
        void Attach(IObserver observer);

        /// <summary>
        /// Detaches an observer from the subject.
        /// </summary>
        /// <param name="observer">The observer to detach.</param>
        void Detach(IObserver observer);

        /// <summary>
        /// Detaches all observers from the subject.
        /// </summary>
        void DetachAll();
    }
}
//MdEnd