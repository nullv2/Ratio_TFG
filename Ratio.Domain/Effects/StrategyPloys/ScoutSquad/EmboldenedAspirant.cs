using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Effects.StrategyPloys.ScoutSquad
{
    public class EmboldenedAspirant : IAfterAttackRoll
    {
        public void ApplyEffect(CombatContext context)
        {
            if (context.ActionType.Equals(ActionType.Shoot) || context.ActionType.Equals(ActionType.Fight))
            {
                if (context.AttackerRetainedNormalHits > 0)
                {
                    if (context.Defender.Wounds > context.Attacker.Wounds)
                    {
                        context.AttackerRetainedNormalHits--;
                        context.AttackerRetainedCriticalHits++;
                    }
                }
            }
        }
    }
}
