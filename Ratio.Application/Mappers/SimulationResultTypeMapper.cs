namespace Ratio.Application.Mappers
{
    public static class SimulationResultTypeMapper
    {
        public static Application.Enums.SimulationResultType ToDto(Domain.Enums.SimulationResultType domainType) => domainType switch
        {
            Domain.Enums.SimulationResultType.AttackerWins => Application.Enums.SimulationResultType.AttackerWins,
            Domain.Enums.SimulationResultType.DefenderWins => Application.Enums.SimulationResultType.DefenderWins,
            Domain.Enums.SimulationResultType.Draw => Application.Enums.SimulationResultType.Draw,
            Domain.Enums.SimulationResultType.None => Application.Enums.SimulationResultType.None,
            _ => throw new ArgumentOutOfRangeException(nameof(domainType), $"Unhandled result type {domainType}")
        };

        public static Domain.Enums.SimulationResultType ToDomain(Application.Enums.SimulationResultType applicationType) => applicationType switch
        {
            Application.Enums.SimulationResultType.AttackerWins => Domain.Enums.SimulationResultType.AttackerWins,
            Application.Enums.SimulationResultType.DefenderWins => Domain.Enums.SimulationResultType.DefenderWins,
            Application.Enums.SimulationResultType.Draw => Domain.Enums.SimulationResultType.Draw,
            Application.Enums.SimulationResultType.None => Domain.Enums.SimulationResultType.None,
            _ => throw new ArgumentOutOfRangeException(nameof(applicationType), $"Unhandled result type {applicationType}")
        };
    }
}
