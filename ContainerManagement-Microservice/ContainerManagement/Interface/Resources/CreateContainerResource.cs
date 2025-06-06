using DittoBox.API.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.API.ContainerManagement.Interface.Resources
{
	public record CreateContainerResource(
			int Id,
			string Uuid,
			string Name,
			string Description
		)
	{
		public static CreateContainerResource FromContainer(Container container)
		{
			return new CreateContainerResource(
				container.Id,
				container.Uiid,
				container.Name,
				container.Description
			);
		}
	}
}