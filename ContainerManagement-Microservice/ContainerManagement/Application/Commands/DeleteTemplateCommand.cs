using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.ContainerManagement.Application.Commands
{
    public record DeleteTemplateCommand
    (
        [Required] int TemplateId
    );
}