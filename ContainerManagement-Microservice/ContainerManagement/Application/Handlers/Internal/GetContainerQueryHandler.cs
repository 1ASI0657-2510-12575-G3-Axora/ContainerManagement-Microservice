using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class GetContainerQueryHandler(
        IContainerService containerService
        ) : IGetContainerQueryHandler
    {
        public async Task<ContainerResource?> Handle(GetContainerByIdQuery query)
        {
            var result = await containerService.GetContainerById(query.ContainerId);

            return result == null ? null : ContainerResource.FromContainer(result);
        }
    }
}
