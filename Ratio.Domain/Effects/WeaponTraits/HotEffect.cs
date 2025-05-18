using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Hot: After using this weapon, roll one D6. If result is less than Hit stat, suffer result × 2 damage.
    /// </summary>
    public class HotEffect : IAfterAttackRoll, IWeaponTraitEffect
    {
        public void ApplyEffect(CombatContext context)
        {
            int roll = context.RollDie();
            if (roll < context.AttackerWeapon.HitThreshold)
            {
                int selfDamage = roll * 2;
                context.Attacker.TakeDamage(selfDamage);
            }
        }
    }
}
