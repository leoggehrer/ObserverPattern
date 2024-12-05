namespace ObserverPattern.ConApp
{
    /// <summary>
    /// The main program class for demonstrating the Observer Pattern with interfaces and events.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstrating the Observer Pattern with interfaces:");

            Console.WriteLine("Subject implemented with interfaces...");
            RunInterfaceSubject();

            Console.WriteLine("Subject implemented with events...");
            RunEventSubject();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// Runs the demonstration of the observer pattern using interface-based subjects and observers.
        /// </summary>
        static void RunInterfaceSubject()
        {
            InterfaceSubject subject = new InterfaceSubject();
            InterfaceObserver observer1 = new InterfaceObserver("InterfaceObserver 1");
            InterfaceObserver observer2 = new InterfaceObserver("InterfaceObserver 2");
            InterfaceObserver observer3 = new InterfaceObserver("InterfaceObserver 3");

            subject.Attach(observer1);
            subject.Attach(observer2);
            subject.Attach(observer3);

            subject.Notify();
            subject.DetachAll();
        }

        /// <summary>
        /// Runs the demonstration of the observer pattern using event-based subjects and observers.
        /// </summary>
        static void RunEventSubject()
        {
            EventSubject subject = new EventSubject();
            EventHandler observer1 = (s, e) => Console.WriteLine("EventObserver 1");
            EventHandler observer2 = (s, e) => Console.WriteLine("EventObserver 2");
            EventHandler observer3 = (s, e) => Console.WriteLine("EventObserver 3");

            subject.NotifyEvent += observer1;
            subject.NotifyEvent += observer2;
            subject.NotifyEvent += observer3;

            subject.Notify();

            subject.NotifyEvent -= observer1;
            subject.NotifyEvent -= observer2;
            subject.NotifyEvent -= observer3;
        }
    }
}