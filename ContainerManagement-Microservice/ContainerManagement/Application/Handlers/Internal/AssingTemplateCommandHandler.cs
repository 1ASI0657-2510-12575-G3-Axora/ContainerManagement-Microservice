using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public class AssingTemplateCommandHandler(
        IContainerService containerService,
        IUnitOfWork unitOfWork,
        ITemplateService templateService,
        ILogger<AssingTemplateCommandHandler> logger,
        INotificationService notificationService
        ) : IAssingTemplateCommandHandler
    {
    public async Task Handle(AssingTemplateCommand command)
        {
            var container = await containerService.GetContainerById(command.ContainerId);
            if (container == null)
            {
                logger.LogError($"Container with id {command.ContainerId} not found.");
                return;
            }

            var template = await templateService.GetTemplate(command.TemplateId);
            if (template == null)
            {
                logger.LogError($"Template with id {command.TemplateId} not found.");
                return;
            }
            if (template != null && container != null)
            {
                container.ContainerConditions = template.ToContainerConditions();
                await unitOfWork.CompleteAsync();
                await notificationService.GenerateNotification(AlertType.TemplateAssigned, containerId: container.Id);
            }
        }
    }
}