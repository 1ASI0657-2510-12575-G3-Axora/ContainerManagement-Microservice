using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Services.Application;

namespace DittoBox.API.ContainerManagement.Application.Services
{
    public class NotificationService(
        INotificationRepository notificationRepository,
        ILogger<NotificationService> logger
    ) : INotificationService
    {
        public async Task GenerateNotification(AlertType alertType, int? accountId = 0, int? groupId = 0, int? containerId = 0)
        {
            var notification = new Notification
            {
                AlertType = alertType,
                IssuedAt = DateTime.UtcNow,
                AccountId = accountId ?? 0,
                GroupId = groupId ?? 0,
                ContainerId = containerId ?? 0
            };

            await notificationRepository.Add(notification);
            logger.LogInformation($"Notification of type '{notification.AlertType}' generated at {notification.IssuedAt}");
        }
    }
}
