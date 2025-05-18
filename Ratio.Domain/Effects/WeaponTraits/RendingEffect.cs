using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Rending: If you retain any critical successes, convert one normal success into a critical.
    /// </summary>
    public class RendingEffect : IAfterAttackRoll, IWeaponTraitEffect
    {
        public void ApplyEffect(CombatContext context)
        {
            int index = context.AttackerAttackRolls.FindIndex(r =>
                r >= context.AttackerWeapon.HitThreshold && r < 6);
            if (context.AttackerRetainedCriticalHits > 0 && index >= 0)
            {
                context.AttackerAttackRolls[index] = 6;
            }
        }
    }

}
