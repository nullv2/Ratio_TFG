using Ratio.Domain.Combat;
using Ratio.Domain.DTO;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Extensions
{
    public static class CombatContextExtension
    {
        public static CombatResult ToCombatResult(this CombatContext context)
        {
            var defenderDices = context.ActionType == ActionType.Fight
                ? context.DefenderAttackRolls.ToList()
                : context.DefenderDefenseRolls.ToList();


            //If context.action type is shoot then 0
            var defenderDamageDealt = context.ActionType == ActionType.Shoot
                ? 0
                : context.DefenderRetainedNormalHits * context.DefenderWeapon.NormalDamage + context.DefenderRetainedCriticalHits * context.DefenderWeapon.CriticalDamage;


            var attackerDamageDealt = context.AttackerRetainedNormalHits * context.AttackerWeapon.NormalDamage + context.AttackerRetainedCriticalHits * context.AttackerWeapon.CriticalDamage;


            return new CombatResult(
                context.Attacker.Id,
                context.Defender.Id,
                context.ActionType,
                context.AttackerAttackRolls.ToList(),
                //depends on action type, if fight, then defenderAttackRolls, if shoot then defenderDefenseRolls
                defenderDices,
                attackerDamageDealt,
                defenderDamageDealt,
                context.Attacker.Wounds,
                context.Defender.Wounds,
                context.Attacker.Wounds <= 0,
                context.Defender.Wounds <= 0,
                context.AttackerRetainedCriticalHits,
                context.AttackerRetainedNormalHits,
                context.DefenderRetainedCriticalHits,
                context.DefenderRetainedNormalHits,
                context.AttackerCriticalHitsParried,
                context.DefenderCriticalHitsParried,
                context.AttackerNormalHitsParried,
                context.DefenderNormalHitsParried,
                context.ResultType,
                context.EffectUsageCounts
            );
        }
    }
}
