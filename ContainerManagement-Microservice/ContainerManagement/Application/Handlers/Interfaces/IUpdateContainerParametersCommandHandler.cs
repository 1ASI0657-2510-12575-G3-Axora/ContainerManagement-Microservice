using DittoBox.API.ContainerManagement.Application.Commands;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface IUpdateContainerParametersCommandHandler
    {
        public Task Handle(int containerId, UpdateContainerParametersCommand command);
    }
}
