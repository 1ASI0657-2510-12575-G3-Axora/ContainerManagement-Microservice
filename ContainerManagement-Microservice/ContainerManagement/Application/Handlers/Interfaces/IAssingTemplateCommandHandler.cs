using DittoBox.API.ContainerManagement.Application.Commands;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface IAssingTemplateCommandHandler
    {
        Task Handle(AssingTemplateCommand command);
    }
}