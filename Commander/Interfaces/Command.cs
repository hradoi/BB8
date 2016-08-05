using StorageYard.Data;

namespace Commander.Interfaces
{
    public interface Command
    {
        CommandResult execute(Order context);
    }
}
