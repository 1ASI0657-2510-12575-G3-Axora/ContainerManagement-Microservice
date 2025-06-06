using DittoBox.API.ContainerManagement.Domain.Models.ValueObjects;

namespace DittoBox.API.ContainerManagement.Domain.Models.Entities
{
	public class Container
	{
		public int Id { get; set; }
		public string Uiid { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int? AccountId { get; set; }
		public int? GroupId { get; set; }
		public double? Temperature { get; set; }
		public double? Humidity { get; set; }
		public double? Oxygen { get; set; }
		public double? Dioxide { get; set; }
		public double? Ethylene { get; set; }
		public double? Ammonia { get; set; }
		public double? SulfurDioxide { get; set; }

		public ContainerConditions? ContainerConditions { get; set; }

		public int LastKnownHealthStatus { get; private set; } = 0;
		public DateTime? LastKnownHealthStatusReport { get; private set; } = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
		public int LastKnownContainerStatus { get; set; } = 0;
		public DateTime LastKnownContainerStatusReport { get; set; } = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
		public DateTime LastSync { get; set; } = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);

		public Container(
		)
		{ }

		public void UpdateHealthStatus(HealthStatus status)
		{
			LastKnownHealthStatus = (int)status;
			LastKnownHealthStatusReport = DateTime.UtcNow;
			LastSync = DateTime.UtcNow;
		}

		public void UpdateContainerStatus(ContainerStatus status)
		{
			LastKnownContainerStatus = (int)status;
			LastKnownContainerStatusReport = DateTime.UtcNow;
			LastSync = DateTime.UtcNow;
		}

		public void UpdateConditions(ContainerConditions newConditions)
		{
			ContainerConditions = newConditions;
		}

		public void UpdateMetrics(double temperature, double humidity, double oxygen, double dioxide, double ethylene, double ammonia, double sulfurDioxide)
		{
			Temperature = temperature;
			Humidity = humidity;
			Oxygen = oxygen;
			Dioxide = dioxide;
			Ethylene = ethylene;
			Ammonia = ammonia;
			SulfurDioxide = sulfurDioxide;
			LastSync = DateTime.UtcNow;
		}

		public bool IsTemperatureWithinRange()
        {
            if (ContainerConditions?.MinTemperature != null && ContainerConditions?.MaxTemperature != null)
            {
                return Temperature >= ContainerConditions.MinTemperature && Temperature <= ContainerConditions.MaxTemperature;
            }
            return true;
        }

        public bool IsHumidityWithinRange()
        {
            if (ContainerConditions?.MinHumidity != null && ContainerConditions?.MaxHumidity != null)
            {
                return Humidity >= ContainerConditions.MinHumidity && Humidity <= ContainerConditions.MaxHumidity;
            }
            return true;
        }

    }
}
