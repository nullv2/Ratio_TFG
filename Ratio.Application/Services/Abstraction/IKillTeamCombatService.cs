using Ratio.Application.DTO;
using Ratio.Domain.DTO;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Application.Services.Abstraction
{
    public interface IKillTeamCombatService
    {
        abstract Task<SimulationStatisticsDto> SimulateAsync(OperativeToSim attacker, OperativeToSim defender, Application.Enums.ActionType actionType, int simulations, ISimulationProgressReporter? progressReporter = null);
    }
}
