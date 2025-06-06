using DittoBox.API.ContainerManagement.Application.Commands;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface IUpdateTemplateCommandHandler
    {
        public Task Handle(UpdateTemplateCommand command);
    }
}