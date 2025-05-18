using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Severe: If you don’t retain any critical successes, convert one normal success to a critical success.
    /// </summary>
    public class SevereEffect : IAfterAttackRoll, IWeaponTraitEffect
    {
        public void ApplyEffect(CombatContext context)
        {
            if (context.AttackerRetainedCriticalHits == 0)
            {
                int index = context.AttackerAttackRolls.FindIndex(r =>
                    r >= context.AttackerWeapon.HitThreshold && r < 6);
                if (index >= 0)
                {
                    context.AttackerAttackRolls[index] = 6;
                }
            }
        }
    }

}
