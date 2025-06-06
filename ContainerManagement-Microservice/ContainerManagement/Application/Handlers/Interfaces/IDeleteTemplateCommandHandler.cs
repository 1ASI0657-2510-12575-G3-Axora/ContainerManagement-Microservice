using DittoBox.API.ContainerManagement.Application.Commands;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface IDeleteTemplateCommandHandler
    {
        public Task Handle(DeleteTemplateCommand command);
    }
}