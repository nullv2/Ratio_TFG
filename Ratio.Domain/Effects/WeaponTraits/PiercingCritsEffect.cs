using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Piercing Crits X: If you retain any critical successes, the defender collects X less defence dice.
    /// </summary>
    public class PiercingCritsEffect : IBeforeDefenseRoll, IWeaponTraitEffect, IWeaponTraitValueEffect
    {
        private readonly int _reduction;

        public PiercingCritsEffect(int reduction)
        {
            _reduction = reduction;
        }

        public int Value => _reduction;

        public void ApplyEffect(CombatContext context)
        {
            if (context.AttackerRetainedCriticalHits > 0)
            {
                context.DefenderDefenseDiceCount = Math.Max(0, context.DefenderDefenseDiceCount - _reduction);
            }
        }
    }

}
