namespace DittoBox.API.ContainerManagement.Application.Commands
{
    public record CreateNotificationCommand
    {
        public int AlertType { get; set; }
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
        public int? ContainerId { get; set; }
    }
}
