using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Domain.Services.Application
{
    public interface INotificationService
    {
        public Task GenerateNotification(AlertType alertType, int? accountId = 0, int? groupId = 0, int? containerId = 0);
    }
}
