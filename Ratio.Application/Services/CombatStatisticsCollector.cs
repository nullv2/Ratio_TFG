using Ratio.Application.DTO;
using Ratio.Application.Enums;

namespace Ratio.Application.Services
{
    public class CombatStatisticsCollector
    {
        private readonly List<CombatResultDto> _results = new();

        public void AddResult(CombatResultDto result)
        {
            _results.Add(result);
        }

        public SimulationStatisticsDto GenerateResult()
        {
            if (_results.Count == 0)
                throw new InvalidOperationException("No results collected.");

            var first = _results.First();

            var attackerRolls = AggregateRolls(r => r.AttackerRolls) ?? new List<int>();
            var defenderRolls = AggregateRolls(r => r.DefenderRolls) ?? new List<int>();

            var attackerAverageDamageDealt = _results.Any() ? _results.Average(r => r.AttackerDamageDealt) : 0;
            var defenderAverageDamageDealt = _results.Any() ? _results.Average(r => r.DefenderDamageDealt) : 0;

            var attackerAverageWounds = _results.Any() ? _results.Average(r => r.AttackerRemainingWounds) : 0;
            var defenderAverageWounds = _results.Any() ? _results.Average(r => r.DefenderRemainingWounds) : 0;

            var attackerCritCount = _results.Any() ? _results.Sum(r => r.AttackerCritCount) : 0;
            var attackerNormalHitCount = _results.Any() ? _results.Sum(r => r.AttackerNormalHitCount) : 0;

            var defenderCritCount = _results.Any() ? _results.Sum(r => r.DefenderCritCount) : 0;
            var defenderNormalHitCount = _results.Any() ? _results.Sum(r => r.DefenderNormalHitCount) : 0;

            var attackerIncapacitatedCount = _results.Count(r => r.AttackerIncapacitated);
            var defenderIncapacitatedCount = _results.Count(r => r.DefenderIncapacitated);

            var attackerSurvivalRate = _results.Count > 0 ? (decimal)(_results.Count - attackerIncapacitatedCount) / _results.Count : 0;
            var defenderSurvivalRate = _results.Count > 0 ? (decimal)(_results.Count - defenderIncapacitatedCount) / _results.Count : 0;

            var effectUsageCounts = AggregateEffectUsage() ?? new Dictionary<string, int>();

            var totalAttackerRolls = _results.Sum(r => r.AttackerRolls.Count);
            var attackerAverageCritChance = totalAttackerRolls > 0 ? (decimal)attackerCritCount / totalAttackerRolls : 0;
            var attackerAverageNormalHitChance = totalAttackerRolls > 0 ? (decimal)attackerNormalHitCount / totalAttackerRolls : 0;

            // Defender side
            var totalDefenderRolls = _results.Sum(r => r.DefenderRolls.Count);
            var defenderAverageCritChance = totalDefenderRolls > 0 ? (decimal)defenderCritCount / totalDefenderRolls : 0;
            var defenderAverageNormalHitChance = totalDefenderRolls > 0 ? (decimal)defenderNormalHitCount / totalDefenderRolls : 0;

            var attackerWeaponName = "first.AttackerWeaponName";
            var defenderWeaponName = "first.DefenderWeaponName";
            var actionType = first.ActionType;
            var simulationCount = _results.Count;
            var attackerId = first.AttackerId;
            var defenderId = first.DefenderId;
            var attackerName = "first.AttackerName";
            var defenderName = "first.DefenderName";

            var attackerAverageDefenseRoll = attackerRolls.Any() ? (int)attackerRolls.Average() : 0;
            var defenderAverageDefenseRoll = defenderRolls.Any() ? (int)defenderRolls.Average() : 0;
            var attackerAverageDamageRoll = attackerRolls.Any() ? (int)attackerRolls.Average() : 0;
            var defenderAverageDamageRoll = defenderRolls.Any() ? (int)defenderRolls.Average() : 0;

            var attackerCriticalHitsParried = _results.Sum(r => r.AttackerCriticalHitsParried);
            var defenderCriticalHitsParried = _results.Sum(r => r.DefenderCriticalHitsParried);
            var attackerNormalHitsParried = _results.Sum(r => r.AttackerNormalHitsParried);
            var defenderNormalHitsParried = _results.Sum(r => r.DefenderNormalHitsParried);

            //Results
            var attackerWins = _results.Count(r => r.ResultType == SimulationResultType.AttackerWins);
            var defenderWins = _results.Count(r => r.ResultType == SimulationResultType.DefenderWins);
            var draws = _results.Count(r => r.ResultType == SimulationResultType.Draw);

            return new SimulationStatisticsDto(attackerId, attackerName, defenderId, defenderName,
                actionType, simulationCount, attackerWeaponName, defenderWeaponName,
                attackerRolls, defenderRolls, (int)attackerAverageDamageDealt,
                (int)defenderAverageDamageDealt, (int)attackerAverageWounds,
                (int)defenderAverageWounds, attackerIncapacitatedCount,
                defenderIncapacitatedCount, attackerCritCount, attackerNormalHitCount,
                defenderCritCount, defenderNormalHitCount, attackerAverageCritChance,
                attackerAverageNormalHitChance, defenderAverageCritChance,
                defenderAverageNormalHitChance, attackerAverageDefenseRoll, 
                defenderAverageDefenseRoll, attackerAverageDamageRoll, defenderAverageDamageRoll,
                attackerSurvivalRate, defenderSurvivalRate,
                attackerCriticalHitsParried, defenderCriticalHitsParried,
                attackerNormalHitsParried, defenderNormalHitsParried, 
                attackerWins, defenderWins, draws,
                effectUsageCounts);
        }

        private List<int> AggregateRolls(System.Func<CombatResultDto, IEnumerable<int>> selector)
        {
            return _results.SelectMany(selector).ToList();
        }

        private Dictionary<string, int> AggregateEffectUsage()
        {
            var combined = new Dictionary<string, int>();
            foreach (var result in _results)
            {
                foreach (var effect in result.EffectUsageCounts)
                {
                    if (combined.ContainsKey(effect.Key))
                        combined[effect.Key] += effect.Value;
                    else
                        combined[effect.Key] = effect.Value;
                }
            }
            return combined;
        }
    }
}
