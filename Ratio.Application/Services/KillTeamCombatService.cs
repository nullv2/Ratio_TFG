using Ratio.Application.DTO;
using Ratio.Application.Mappers;
using Ratio.Application.Services.Abstraction;
using Ratio.Application.Enums;
using Ratio.Domain.Combat.Simulator;
using Ratio.Domain.DTO;
using Ratio.Domain.Extensions;

namespace Ratio.Application.Services
{
    public class KillTeamCombatService : IKillTeamCombatService
    {
        private readonly OperativeMapper _operativeMapper;

        public KillTeamCombatService(OperativeMapper operativeMapper)
        {
            _operativeMapper = operativeMapper ?? throw new ArgumentNullException(nameof(operativeMapper));
        }

        //public async Task<SimulationStatistics> SimulateAsync(Operative attacker, Operative defender, ActionType actionType, int simulations = 1)
        //{
        //    var collector = new CombatStatisticsCollector();

        //    for (int i = 0; i < simulations; i++)
        //    {
        //        var tempAttacker = attacker.DeepClone();
        //        var tempDefender = defender.DeepClone();

        //        var context = CombatSimulator.Simulate(tempAttacker, tempDefender, actionType);
        //        var result = context.ToCombatResult();

        //        collector.AddResult(result);
        //    }

        //    return collector.GenerateResult();
        //}

        // method that is used in Mobile (takes OperativeToSim DTO instead of Operative)
        public async Task<SimulationStatisticsDto> SimulateAsync(OperativeToSim attacker, OperativeToSim defender, Application.Enums.ActionType actionType, int simulations, ISimulationProgressReporter? progressReporter = null)
        {
            var collector = new CombatStatisticsCollector();
            for (int i = 0; i < simulations; i++)
            {
                var tempAttacker = await _operativeMapper.ToOperativeAsync(attacker, actionType, OperativeType.Attacker);
                var tempDefender = await _operativeMapper.ToOperativeAsync(defender, actionType, OperativeType.Defender);

                var domainActionType = ActionTypeMapper.ToDomain(actionType);

                progressReporter.ReportProgress(i, simulations, "Simulating...");
                var context = CombatSimulator.Simulate(tempAttacker, tempDefender, domainActionType);
                var result = context.ToCombatResult();
                // Map the result to DTO
                var resultDto = MapToDto(result);
                collector.AddResult(resultDto);
            }
            return collector.GenerateResult();
        }

        public static SimulationStatisticsDto ToSimulationResultDto(SimulationStatistics stats)
        {
            var dto = new SimulationStatisticsDto(
                stats.AttackerId,
                stats.AttackerName,
                stats.DefenderId,
                stats.DefenderName,
                ActionTypeMapper.ToDto(stats.ActionType),
                stats.SimulationCount,
                stats.AttackerWeaponName,
                stats.DefenderWeaponName,
                stats.AttackerRolls,
                stats.DefenderRolls,
                stats.AttackerAverageDamageDealt,
                stats.DefenderAverageDamageDealt,
                stats.AttackerAverageRemainingWounds,
                stats.DefenderAverageRemainingWounds,
                stats.AttackerIncapacitatedCount,
                stats.DefenderIncapacitatedCount,
                stats.AttackerCritHitCount,
                stats.AttackerNormalHitCount,
                stats.DefenderCritHitCount,
                stats.DefenderNormalHitCount,
                stats.AttackerAverageCritHitChance,
                stats.AttackerAverageNormalHitChance,
                stats.DefenderAverageCritHitChance,
                stats.DefenderAverageNormalHitChance,
                stats.AttackerAverageDefenseRoll,
                stats.DefenderAverageDefenseRoll,
                stats.AttackerAverageDamageRoll,
                stats.DefenderAverageDamageRoll,
                stats.AttackerSurvivalRate,
                stats.DefenderSurvivalRate,
                stats.AttackerCriticalHitsParried,
                stats.DefenderCriticalHitsParried,
                stats.AttackerNormalHitsParried,
                stats.DefenderNormalHitsParried,
                stats.AttackerWins,
                stats.DefenderWins,
                stats.Draws,
                stats.EffectUsageCounts
            );

            return dto;
        }
        public static CombatResultDto MapToDto(CombatResult result)
        {
            return new CombatResultDto(
                result.AttackerId,
                result.DefenderId,
                ActionTypeMapper.ToDto(result.ActionType),
                result.AttackerRolls,
                result.DefenderRolls,
                result.AttackerDamageDealt,
                result.DefenderDamageDealt,
                result.AttackerRemainingWounds,
                result.DefenderRemainingWounds,
                result.AttackerIncapacitated,
                result.DefenderIncapacitated,
                result.AttackerCritCount,
                result.AttackerNormalHitCount,
                result.DefenderCritCount,
                result.DefenderNormalHitCount,
                result.AttackerCriticalHitsParried,
                result.DefenderCriticalHitsParried,
                result.AttackerNormalHitsParried,
                result.DefenderNormalHitsParried,
                SimulationResultTypeMapper.ToDto(result.ResultType),
                result.EffectUsageCounts
            );
        }
    }
}
