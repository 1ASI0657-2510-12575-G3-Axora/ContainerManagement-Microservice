using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Domain.Models.Entities
{
	public class Template
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		// Temperature in a range from -127 to 127 degrees Celsius
		public double MaxTemperatureThreshold { get; set; }
		public double MinTemperatureThreshold { get; set; }

		// Humidity in a range from 0 to 100%
		public double MaxHumidityThreshold { get; set; }
		public double MinHumidityThreshold { get; set; }

		// Gases measured in PPM (particles per million)
		public double? MinOxygenThreshold { get; set; }
		public double? MaxOxygenThreshold { get; set; }
		public double? MinCarbonDioxideThreshold { get; set; }
		public double? MaxCarbonDioxideThreshold { get; set; }
		public double? MinSulfurDioxideThreshold { get; set; }
		public double? MaxSulfurDioxideThreshold { get; set; }
		public double? MinEthyleneThreshold { get; set; }
		public double? MaxEthyleneThreshold { get; set; }
		public double? MinAmmoniaThreshold { get; set; }
		public double? MaxAmmoniaThreshold { get; set; }

		public TemplateCategory Category { get; set; }

		public Template() { }
		public Template(
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
		)
		{
			Name = name;
			MaxTemperatureThreshold = maxTemperatureThreshold;
			MinTemperatureThreshold = minTemperatureThreshold;
			MaxHumidityThreshold = maxHumidityThreshold;
			MinHumidityThreshold = minHumidityThreshold;
			MinOxygenThreshold = minOxygenThreshold;
			MaxOxygenThreshold = maxOxygenThreshold;
			MinCarbonDioxideThreshold = minCarbonDioxideThreshold;
			MaxCarbonDioxideThreshold = maxCarbonDioxideThreshold;
			MinSulfurDioxideThreshold = minSulfurDioxideThreshold;
			MaxSulfurDioxideThreshold = maxSulfurDioxideThreshold;
			MinEthyleneThreshold = minEthyleneThreshold;
			MaxEthyleneThreshold = maxEthyleneThreshold;
			MinAmmoniaThreshold = minAmmoniaThreshold;
			MaxAmmoniaThreshold = maxAmmoniaThreshold;
			Category = category;
		}
		public ContainerConditions ToContainerConditions()
		{
			return new ContainerConditions(
				MinTemperatureThreshold,
				MaxTemperatureThreshold,
				MinHumidityThreshold,
				MaxHumidityThreshold,
				MinOxygenThreshold ?? 0,
				MaxOxygenThreshold ?? 0,
				MinCarbonDioxideThreshold ?? 0,
				MaxCarbonDioxideThreshold ?? 0,
				MinEthyleneThreshold ?? 0,
				MaxEthyleneThreshold ?? 0,
				MinAmmoniaThreshold ?? 0,
				MaxAmmoniaThreshold ?? 0,
				MinSulfurDioxideThreshold ?? 0,
				MaxSulfurDioxideThreshold ?? 0
			);
		}
	}
}
