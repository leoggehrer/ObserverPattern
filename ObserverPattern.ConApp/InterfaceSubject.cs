//MdStart
namespace ObserverPattern.ConApp
{
    /// <summary>
    /// Represents a subject in the observer pattern.
    /// </summary>
    public class InterfaceSubject : Logic.WithInterfaces.Subject
    {
        public void Notify()
        {
            NotifyAll(new EventArgs());
        }
    }
}
//MdEnd