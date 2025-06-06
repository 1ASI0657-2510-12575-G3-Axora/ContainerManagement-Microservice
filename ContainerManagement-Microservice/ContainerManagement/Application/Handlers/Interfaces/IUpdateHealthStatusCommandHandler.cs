using DittoBox.API.ContainerManagement.Application.Commands;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface IUpdateHealthStatusCommandHandler
    {
        public Task Handle(int containerId, UpdateHealthStatusCommand command);
    }
}
