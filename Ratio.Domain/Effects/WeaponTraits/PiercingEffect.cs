using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Piercing X: The defender collects X less defence dice.
    /// </summary>
    public class PiercingEffect : IBeforeDefenseRoll, IWeaponTraitEffect, IWeaponTraitValueEffect
    {
        private readonly int _reduction;

        public PiercingEffect(int reduction)
        {
            _reduction = reduction;
        }

        public int Value => _reduction;

        public void ApplyEffect(CombatContext context)
        {
            context.DefenderDefenseDiceCount = Math.Max(0, context.DefenderDefenseDiceCount - _reduction);
            context.RegisterEffectUsage(GetType().Name);
        }
    }

}
