using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Application.Handlers.Interfaces;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.ContainerManagement.Interface.Resources;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Internal {
	public class CreateTemplateCommandHandler(
		ITemplateService templateService,
		IUnitOfWork unitOfWork
	) : ICreateTemplateCommandHandler {
		public async Task<TemplateResource> Handle(CreateTemplateCommand command) {
			var template = await templateService.CreateTemplate(
				command.Name,
				command.MaxTemperatureThreshold,
				command.MinTemperatureThreshold,
				command.MaxHumidityThreshold,
				command.MinHumidityThreshold,
				command.MaxOxygenThreshold,
				command.MinCarbonDioxideThreshold,
				command.MaxCarbonDioxideThreshold,
				command.MinOxygenThreshold,
				command.MinSulfurDioxideThreshold,
				command.MaxSulfurDioxideThreshold,
				command.MinEthyleneThreshold,
				command.MaxEthyleneThreshold,
				command.MinAmmoniaThreshold,
				command.MaxAmmoniaThreshold,
				command.Category
			);

			await unitOfWork.CompleteAsync();

			return TemplateResource.FromTemplate(template);
		}
	}
}