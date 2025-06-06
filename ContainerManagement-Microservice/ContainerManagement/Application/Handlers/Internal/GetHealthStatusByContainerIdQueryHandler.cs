using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class GetHealthStatusByContainerIdQueryHandler(
        IContainerService containerService
        ) : IGetHealthStatusByContainerIdQueryHandler
    {
        public async Task<ContainerHealthResource?> Handle(GetHealthStatusByContainerIdQuery query)
        {
            var result = await containerService.GetContainerById(query.ContainerId);
            return result == null ? null : ContainerHealthResource.FromContainer(result);
        }
    }
}
