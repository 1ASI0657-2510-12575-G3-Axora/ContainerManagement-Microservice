namespace DittoBox.API.ContainerManagement.Domain.Models.ValueObjects
{
    public enum TargetType
    {
        Power = 0,          // Send a turn on/off message
        Temperature = 1,    // Send a temperature regulation message
        Humidity = 2        // Send a humidity regulation message
    }
}
