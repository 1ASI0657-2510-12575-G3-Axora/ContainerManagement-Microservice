using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal
{
	public class GetTemplatesQueryHandler(ITemplateService templateService) : IGetTemplatesQueryHandler
	{

		public async Task<IEnumerable<TemplateResource>> Handle(GetTemplatesQuery query)
		{
			var templates = await templateService.GetTemplates();
			return templates.Select(TemplateResource.FromTemplate);
		}
	}
}