namespace ObserverPattern.ConApp
{
    /// <summary>
    /// Represents an observer in the observer pattern.
    /// </summary>
    public class InterfaceObserver : Logic.WithInterfaces.IObserver
    {
        #region fields
        private string _text;
        #endregion fields

        /// <summary>
        /// Initializes a new instance of the <see cref="InterfaceObserver"/> class with the specified text.
        /// </summary>
        /// <param name="text">The text associated with the observer.</param>
        public InterfaceObserver(string text)
        {
            _text = text;
        }

        /// <summary>
        /// Updates the observer with the specified sender and event data.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        public void Update(object sender, EventArgs e)
        {
            Console.WriteLine($"{_text} received notification from {sender.GetType().Name}");
        }
    }
}