using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Balanced: You can re-roll one of your attack dice.
    /// </summary>
    public class BalancedEffect : IAfterAttackRoll, IWeaponTraitEffect
    {
        public void ApplyEffect(CombatContext context)
        {
            int index = context.AttackerAttackRolls.FindIndex(r => r < context.AttackerWeapon.HitThreshold);
            if (index >= 0)
            {
                // Re-roll the first attack roll that is below the hit threshold
                context.AttackerAttackRolls[index] = context.RollDie();
                CombatLog.Write($"Re-rolled: {context.AttackerAttackRolls[index]}");
                CombatLog.Write($"All dice rolls: {string.Join(", ", context.AttackerAttackRolls)}");
            }

        }
    }


}
