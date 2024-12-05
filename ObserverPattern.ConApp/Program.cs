//MdStart
namespace ObserverPattern.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstrating the Observer Pattern with interfaces:");

            RunInterfaceSubject();
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

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
    }
}
//MdEnd