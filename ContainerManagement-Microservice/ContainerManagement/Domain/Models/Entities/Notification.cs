using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Domain.Models.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public AlertType AlertType { get; set; }
        public DateTime IssuedAt { get; set; }
        public int AccountId { get; set; }
        public int GroupId { get; set; }
        public int ContainerId { get; set; }

        public Notification()
        {
        }
    }
}
