using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Interface.Resources
{
    public record ContainerStatusResource(
        string LastKnownContainerStatus,
        DateTime LastKnownContainerStatusReport
        )
    {
        public static ContainerStatusResource FromContainer(Container container)
        {
            return new ContainerStatusResource(
                ((ContainerStatus)container.LastKnownContainerStatus).ToString(),
                container.LastKnownContainerStatusReport
            );
        }
    }
}