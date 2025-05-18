using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;
using System;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Devastating x: Each retained critical success immediately inflicts x damage. The crit is still kept.
    /// </summary>
    public class DevastatingEffect : IAfterDefenseRoll, IWeaponTraitEffect, IWeaponTraitValueEffect
    {
        private readonly int _damage;

        public DevastatingEffect(int damage)
        {
            _damage = damage;
        }

        public int Value => _damage;

        public void ApplyEffect(CombatContext context)
        {
            context.TotalDamage += _damage * context.AttackerRetainedCriticalHits;
            CombatLog.Write($"Devastating {_damage} applied");
        }
    }

}
