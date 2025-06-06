using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface ICreateContainerCommandHandler
    {
        public Task<CreateContainerResource> Handle(CreateContainerCommand command);
    }
}
