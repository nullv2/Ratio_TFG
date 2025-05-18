using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Effects
{
    public class CombinedArmsEffect : IAfterAttackRoll
    {
        public void ApplyEffect(CombatContext context)
        {
            if (context.ActionType != ActionType.Shoot || !context.TargetPreviouslyShot)
                return;

            int hitThreshold = context.Attacker.SelectedWeapon.HitThreshold;

            for (int i = 0; i < context.AttackerAttackRolls.Count; i++)
            {
                int roll = context.AttackerAttackRolls[i];
                if (roll < hitThreshold)
                {
                    context.AttackerAttackRolls[i] = context.RollDie();
                }
            }
        }
    }
}
