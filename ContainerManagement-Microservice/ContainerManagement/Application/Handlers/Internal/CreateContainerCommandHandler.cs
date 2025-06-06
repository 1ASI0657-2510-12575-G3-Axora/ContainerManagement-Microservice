using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class CreateContainerCommandHandler(
        IContainerService containerService,
        IUnitOfWork unitOfWork,
        INotificationService notificationService
        ) : ICreateContainerCommandHandler
    {
        public async Task<CreateContainerResource> Handle(CreateContainerCommand command)
        {
            var result = await containerService.CreateContainer(command.DeviceId, command.Name, command.Description, command.AccountId, command.GroupId);
            await unitOfWork.CompleteAsync();
            await notificationService.GenerateNotification(AlertType.ContainerLinked, containerId: result.Id, accountId: command.AccountId, groupId: command.GroupId);
            return CreateContainerResource.FromContainer(result);
        }
    }
}
