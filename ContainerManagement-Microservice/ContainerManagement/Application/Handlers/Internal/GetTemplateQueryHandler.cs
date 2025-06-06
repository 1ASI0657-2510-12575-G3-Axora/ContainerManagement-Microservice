using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
    public class GetTemplateQueryHandler(
		ITemplateService templateService
	) : IGetTemplateQueryHandler
    {
        public async Task<TemplateResource?> Handle(GetTemplateQuery query)
        {
			var template = await templateService.GetTemplate(query.TemplateId);
			return TemplateResource.FromTemplate(template);
        }
    }
}