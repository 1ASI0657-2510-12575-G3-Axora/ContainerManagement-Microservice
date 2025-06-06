namespace DittoBox.API.ContainerManagement.Domain.Models.ValueObjects
{
    public class ContainerConditions
    {
        public double? MaxTemperature { get; set; }
        public double? MinTemperature { get; set; }
        public double? MaxHumidity { get; set; }
        public double? MinHumidity { get; set; }

        public double? OxygenMin { get; set; }
        public double? OxygenMax { get; set; }
        public double? DioxideMin { get; set; }
        public double? DioxideMax { get; set; }
        public double? EthyleneMin { get; set; }
        public double? EthyleneMax { get; set; }
        public double? AmmoniaMin { get; set; }
        public double? AmmoniaMax { get; set; }
        public double? SulfurDioxideMin { get; set; }
        public double? SulfurDioxideMax { get; set; }

        public ContainerConditions() { }

        public ContainerConditions(
            double? minTemp, double? maxTemp,
            double? minHumidity, double? maxHumidity,
            double? oxygenMin, double? oxygenMax,
            double? dioxideMin, double? dioxideMax,
            double? ethyleneMin, double? ethyleneMax,
            double? ammoniaMin, double? ammoniaMax,
            double? sulfurDioxideMin, double? sulfurDioxideMax)
        {
            MinTemperature = minTemp;
            MaxTemperature = maxTemp;
            MinHumidity = minHumidity;
            MaxHumidity = maxHumidity;
            OxygenMin = oxygenMin;
            OxygenMax = oxygenMax;
            DioxideMin = dioxideMin;
            DioxideMax = dioxideMax;
            EthyleneMin = ethyleneMin;
            EthyleneMax = ethyleneMax;
            AmmoniaMin = ammoniaMin;
            AmmoniaMax = ammoniaMax;
            SulfurDioxideMin = sulfurDioxideMin;
            SulfurDioxideMax = sulfurDioxideMax;
        }
    }
}
