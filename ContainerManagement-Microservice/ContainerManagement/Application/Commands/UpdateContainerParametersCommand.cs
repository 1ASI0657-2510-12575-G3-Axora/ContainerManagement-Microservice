using System.ComponentModel.DataAnnotations;

namespace DittoBox.API.ContainerManagement.Application.Commands
{
    public record UpdateContainerParametersCommand (
        double? MinTemp, double? MaxTemp,
        double? MinHumidity, double? MaxHumidity,
        double? OxygenMin, double? OxygenMax,
        double? DioxideMin, double? DioxideMax,
        double? EthyleneMin, double? EthyleneMax,
        double? AmmoniaMin, double? AmmoniaMax,
        double? SulfurDioxideMin, double? SulfurDioxideMax);
}
