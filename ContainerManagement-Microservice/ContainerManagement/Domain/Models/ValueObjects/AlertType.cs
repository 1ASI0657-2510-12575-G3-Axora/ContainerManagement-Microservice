namespace DittoBox.API.ContainerManagement.Domain.Models.ValueObjects
{
    public enum AlertType
    {
        TemperatureThresholdExceeded = 1,
        HumidityThresholdExceeded = 2,
        DecompositionGasesDetected = 3,
        ContainerLinked = 4,
        ContainerUnlinked = 5,
        ContainerOff = 6,
        ContainerOn = 7,
        TemplateAssigned = 8,
        ContainerActivated = 9,
        ContainerDeactivated = 10,
        TemperatureRegulationTriggered = 11,
        TemperatureRegulationSuccessful = 12,
        TemperatureRegulationFailed = 13,
        HumidityRegulationTriggered = 14,
        HumidityRegulationSuccessful = 15,
        HumidityRegulationFailed = 16,
        VentilationRegulationTriggered = 17,
        VentilationRegulationSuccessful = 18,
        VentilationRegulationFailed = 19,
        ContainerHealthReport = 20,
        ContainerStatusReport = 21,
        ContainerManualOn = 22,
        ContainerManualOff = 23,
        ContainerOpened = 24,
        ContainerOnline = 25,
        ContainerOffline = 26,
    }
}
