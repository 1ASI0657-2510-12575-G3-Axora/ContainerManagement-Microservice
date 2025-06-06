using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Domain.Models.Entities
{
    public class Alert
    {
        public int Id { get; set; }
        public int ContainerId { get; set; }
        public AlertType AlertType { get; set; }
        public AlertOrigin AlertOrigin { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime EmissionDate { get; set; } = new DateTime(1970, 1, 1);

        public void SendAlert()
        {
            // Generate an instance of the alert
        }

        public void ResolveAlert()
        {
            // Resolve the alert
        }
    }
}
