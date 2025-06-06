using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.ContainerManagement.Application.Queries
{
    public record GetTemplateQuery(
        [Required] int TemplateId
        );
}