using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class UpdateHealthStatusCommandHandler(
        IContainerService containerService,
        IUnitOfWork unitOfWork,
        INotificationService notificationService
        ) : IUpdateHealthStatusCommandHandler
    {
        public async Task Handle(int containerId, UpdateHealthStatusCommand command)
        {
            var container = await containerService.GetContainerById(containerId);
            if (container != null && Enum.TryParse<HealthStatus>(command.HealthStatus, true, out var result))
            {
                container.UpdateHealthStatus(result);
                await containerService.UpdateContainer(container);
                await unitOfWork.CompleteAsync();
                await notificationService.GenerateNotification(AlertType.ContainerStatusReport, containerId: container.Id);
				await unitOfWork.CompleteAsync();
            }
        }
    }
}
