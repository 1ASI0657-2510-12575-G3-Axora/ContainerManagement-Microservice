using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.ContainerManagement.Application.Commands
{
    public record AssingTemplateCommand(
        [Required] int ContainerId,
        [Required] int TemplateId
    );
}