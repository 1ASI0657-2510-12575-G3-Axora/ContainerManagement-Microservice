using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface IGetHealthStatusByContainerIdQueryHandler
    {
        public Task<ContainerHealthResource?> Handle(GetHealthStatusByContainerIdQuery query);
    }
}
