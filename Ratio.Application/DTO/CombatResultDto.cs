using Ratio.Application.Enums;

namespace Ratio.Application.DTO
{
    public record CombatResultDto(
        int AttackerId,
        int DefenderId,
        ActionType ActionType,
        List<int> AttackerRolls,
        List<int> DefenderRolls,
        int AttackerDamageDealt,
        int DefenderDamageDealt,
        int AttackerRemainingWounds,
        int DefenderRemainingWounds,
        bool AttackerIncapacitated,
        bool DefenderIncapacitated,
        int AttackerCritCount,
        int AttackerNormalHitCount,
        int DefenderCritCount,
        int DefenderNormalHitCount,
        int AttackerCriticalHitsParried,
        int DefenderCriticalHitsParried,
        int AttackerNormalHitsParried,
        int DefenderNormalHitsParried,
        SimulationResultType ResultType,
        Dictionary<string, int> EffectUsageCounts
    );
}
