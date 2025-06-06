using DittoBox.API.ContainerManagement.Application.Commands;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface IUpdateContainerMetricsCommandHandler
    {
        public Task Handle(int containerId, UpdateContainerMetricsCommand command);
    }
}
