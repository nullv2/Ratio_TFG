using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Relentless: You can re-roll any of your attack dice.
    /// </summary>
    public class RelentlessEffect : IAfterAttackRoll, IWeaponTraitEffect
    {
        public void ApplyEffect(CombatContext context)
        {
            for (int i = 0; i < context.AttackerAttackRolls.Count; i++)
            {
                if (context.AttackerAttackRolls[i] < context.AttackerWeapon.HitThreshold)
                    context.AttackerAttackRolls[i] = context.RollDie();
            }
        }
    }
}
