//MdStart
namespace ObserverPattern.Logic.WithInterfaces
{
    /// <summary>
    /// Defines the interface for an observer in the Observer pattern.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Updates the observer with the event data from the subject.
        /// </summary>
        /// <param name="sender">The subject sending the update.</param>
        /// <param name="e">The event data.</param>
        void Update(object sender, EventArgs e);
    }
}
//MdEnd