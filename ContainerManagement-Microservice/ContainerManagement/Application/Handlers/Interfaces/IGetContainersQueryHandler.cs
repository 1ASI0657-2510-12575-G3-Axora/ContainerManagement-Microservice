using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
	public interface IGetContainersQueryHandler
	{
		public Task<IEnumerable<ContainerResource>> Handle(GetContainersQuery query);
	}
}