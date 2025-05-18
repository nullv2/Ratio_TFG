using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Punishing: If you retain any critical successes, convert one failed die into a normal success.
    /// </summary>
    public class PunishingEffect : IAfterAttackRoll, IWeaponTraitEffect
    {
        public void ApplyEffect(CombatContext context)
        {
            if (context.AttackerRetainedCriticalHits > 0)
            {
                int index = context.AttackerAttackRolls.FindIndex(r => r < context.AttackerWeapon.HitThreshold);
                if (index >= 0)
                {
                    context.AttackerAttackRolls[index] = context.AttackerWeapon.HitThreshold;
                }
            }
        }
    }
}
