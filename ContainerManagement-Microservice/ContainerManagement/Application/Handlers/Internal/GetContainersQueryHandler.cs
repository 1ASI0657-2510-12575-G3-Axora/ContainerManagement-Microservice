using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal {
	class GetContainersQueryHandler(
		IContainerService containerService
	) : IGetContainersQueryHandler {
		public async Task<IEnumerable<ContainerResource>> Handle(GetContainersQuery query) {
			var containers = await containerService.GetContainers();
			return containers.Select(ContainerResource.FromContainer);
		}
	}
}