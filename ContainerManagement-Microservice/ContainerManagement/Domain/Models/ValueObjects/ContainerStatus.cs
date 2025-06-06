namespace DittoBox.API.ContainerManagement.Domain.Models.ValueObjects
{
    public enum ContainerStatus
    {
        Unknown = 0,        // Not known
        Off = 1,            // Last message was a turning off message
        Disconnected = 2,   // Container isn't linked to any account
        Idle = 3,           // Container is on but not running any task
        Running = 4,        // Container is running a task
    }

}
