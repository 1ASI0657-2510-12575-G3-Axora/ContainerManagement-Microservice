using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Domain.Services.Application
{
	public interface ITemplateService
	{
		Task<Template?> GetTemplate(int templateId);
		Task<IEnumerable<Template>> GetTemplates();
		Task<Template> CreateTemplate(
			string name,
			double maxTemperatureThreshold,
			double minTemperatureThreshold,
			double maxHumidityThreshold,
			double minHumidityThreshold,
			double? maxOxygenThreshold,
			double? minCarbonDioxideThreshold,
			double? maxCarbonDioxideThreshold,
			double? minOxygenThreshold,
			double? minSulfurDioxideThreshold,
			double? maxSulfurDioxideThreshold,
			double? minEthyleneThreshold,
			double? maxEthyleneThreshold,
			double? minAmmoniaThreshold,
			double? maxAmmoniaThreshold,
			TemplateCategory category
		);
	}
}