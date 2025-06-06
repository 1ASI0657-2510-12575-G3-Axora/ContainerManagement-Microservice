using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Application.Queries;
using DittoBox.API.ContainerManagement.Interface.Resources;
using Microsoft.AspNetCore.Mvc;

namespace DittoBox.API.ContainerManagement.Interface.Controllers
{
    /// <summary>
    /// Controller for managing templates within the container management system.
    /// Provides endpoints for creating and retrieving templates.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TemplateController(
		ILogger<TemplateController> _logger,
		IGetTemplateQueryHandler getTemplateQueryHandler,
        IGetTemplatesQueryHandler getTemplatesQueryHandler,
		ICreateTemplateCommandHandler createTemplateCommandHandler
	) : ControllerBase
    {
    	/// <summary>
        /// Retrieves a specific template by its ID.
        /// </summary>
        /// <param name="templateId">The ID of the template to retrieve.</param>
        /// <returns>An ActionResult containing the requested TemplateResource or a NotFound status.</returns>
        [HttpGet]
        [Route("{templateId}")]
        public async Task<ActionResult<TemplateResource>> GetTemplate([FromRoute] int templateId)
        {
			var query = new GetTemplateQuery(templateId);
			try
            {
                var response = await getTemplateQueryHandler.Handle(query);
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting template with templateId: {templateId}", query.TemplateId);
                return StatusCode(500, "Internal server error");
            }
        }
 	/// <summary>
        /// Retrieves all templates.
        /// </summary>
        /// <returns>An ActionResult containing a collection of TemplateResource objects.</returns>

        [HttpGet]
        public async Task<ActionResult<ICollection<TemplateResource>>> GetTemplates()
        {
			var query = new GetTemplatesQuery();
			try
			{
				var response = await getTemplatesQueryHandler.Handle(query);
				return Ok(response);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error ocurred while getting templates.");
				return StatusCode(500, "Internal server error");
			}
        }
	 /// <summary>
        /// Creates a new template based on the provided details.
        /// </summary>
        /// <param name="template">The CreateTemplateCommand containing the details of the template to create.</param>
        /// <returns>An ActionResult containing the created TemplateResource and a 201 Created status.</returns>

		[HttpPost]
		public async Task<ActionResult<TemplateResource>> CreateTemplate([FromBody] CreateTemplateCommand template) {
			try
			{
				var response = await createTemplateCommandHandler.Handle(template);
				_logger.LogInformation("Template created with name {name} and id {id}", response.Name, response.Id);
				return StatusCode(201, response);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while creating template with name {name}", template.Name);
				return StatusCode(500, "Internal server error");
			}
		}
    }
}
