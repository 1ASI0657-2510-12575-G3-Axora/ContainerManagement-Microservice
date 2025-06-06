using DittoBox.API.ContainerManagement.Application.Commands;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface IUpdateContainerStatusCommandHandler
    {
        public Task Handle(int containerId, UpdateContainerStatusCommand command);
    }
}
