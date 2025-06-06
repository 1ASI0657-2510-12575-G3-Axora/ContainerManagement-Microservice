using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Interface.Resources
{
    public record TemplateResource(
        int Id,
        string Name,
        double MaxTemperatureThreshold,
        double MinTemperatureThreshold,
        double MaxHumidityThreshold,
        double MinHumidityThreshold,
        double? MaxOxygenThreshold,
        double? MinCarbonDioxideThreshold,
        double? MaxCarbonDioxideThreshold,
        double? MinOxygenThreshold,
        double? MinSulfurDioxideThreshold,
        double? MaxSulfurDioxideThreshold,
        double? MinEthyleneThreshold,
        double? MaxEthyleneThreshold,
        double? MinAmmoniaThreshold,
        double? MaxAmmoniaThreshold,
		TemplateCategory Category
    ) {
		public static TemplateResource FromTemplate(DittoBox.API.ContainerManagement.Domain.Models.Entities.Template template)
		{
			return new TemplateResource(
				template.Id,
				template.Name,
				template.MaxTemperatureThreshold,
				template.MinTemperatureThreshold,
				template.MaxHumidityThreshold,
				template.MinHumidityThreshold,
				template.MaxOxygenThreshold,
				template.MinCarbonDioxideThreshold,
				template.MaxCarbonDioxideThreshold,
				template.MinOxygenThreshold,
				template.MinSulfurDioxideThreshold,
				template.MaxSulfurDioxideThreshold,
				template.MinEthyleneThreshold,
				template.MaxEthyleneThreshold,
				template.MinAmmoniaThreshold,
				template.MaxAmmoniaThreshold,
				template.Category
			);
		}
	}
}