using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Accurate X: You can retain up to X attack dice as normal successes without rolling them.
    /// </summary>
    public class AccurateEffect : IBeforeAttackRoll, IWeaponTraitEffect, IWeaponTraitValueEffect
    {
        private readonly int _retainedCount;

        public AccurateEffect(int retainedCount)
        {
            _retainedCount = retainedCount;
        }

        public int Value => _retainedCount;

        public void ApplyEffect(CombatContext context)
        {
            context.AttackerRetainedNormalHits += Math.Min(_retainedCount, context.AttackerWeapon.Attacks);
        }
    }
}
