namespace Commander.Interfaces
{
    public class CommandResult
    {
        public string ResultString { get; private set; }

        public CommandResult(string message)
        {
            ResultString = message;
        }
    }
}
