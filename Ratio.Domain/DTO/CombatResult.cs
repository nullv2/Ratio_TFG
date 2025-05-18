using Ratio.Domain.Enums;

namespace Ratio.Domain.DTO
{
    public record CombatResult(
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
