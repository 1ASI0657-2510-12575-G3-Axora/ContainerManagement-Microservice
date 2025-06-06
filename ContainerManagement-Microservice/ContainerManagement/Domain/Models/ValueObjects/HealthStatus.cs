namespace DittoBox.API.ContainerManagement.Domain.Models.ValueObjects
{
    public enum HealthStatus
    {
        Unknown = 0,        // Container hasn't reported any health status
        Healthy = 1,        // Container is healthy
        Warning = 2,        // Sensors or actuators are experiencing degraded performance
        Critical = 3,       // Sensors or actuators are failing
    }
}
