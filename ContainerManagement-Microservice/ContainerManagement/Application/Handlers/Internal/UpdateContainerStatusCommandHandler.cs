using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class UpdateContainerStatusCommandHandler(
        IContainerService containerService,
        IUnitOfWork unitOfWork,
        INotificationService notificationService    
    ) : IUpdateContainerStatusCommandHandler
    {
        public async Task Handle(int containerId, UpdateContainerStatusCommand command)
        {
            var container = await containerService.GetContainerById(containerId);
            if (container != null && Enum.TryParse<ContainerStatus>(command.ContainerStatus, true, out var result))
            {
                container.UpdateContainerStatus(result);
                await containerService.UpdateContainer(container);
                await unitOfWork.CompleteAsync();
                await notificationService.GenerateNotification(AlertType.ContainerStatusReport, containerId: container.Id);
				await unitOfWork.CompleteAsync();

                if (!container.IsTemperatureWithinRange())
                {
                    await notificationService.GenerateNotification(AlertType.TemperatureThresholdExceeded, containerId: container.Id);
					await unitOfWork.CompleteAsync();
                }

                if (!container.IsHumidityWithinRange())
                {
                    await notificationService.GenerateNotification(AlertType.HumidityThresholdExceeded, containerId: container.Id);
					await unitOfWork.CompleteAsync();
                }
            }
        }
    }
}
