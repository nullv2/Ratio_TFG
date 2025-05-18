using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects.WeaponTraits
{
    /// <summary>
    /// Ceaseless: You can re-roll all attack dice results of 1 or 2.
    /// </summary>
    public class CeaselessEffect : IAfterAttackRoll, IWeaponTraitEffect
    {
        public void ApplyEffect(CombatContext context)
        {
            for (int i = 0; i < context.AttackerAttackRolls.Count; i++)
            {
                if (context.AttackerAttackRolls[i] <= 2)
                    context.AttackerAttackRolls[i] = context.RollDie();

                CombatLog.Write($"Ceaseless -> Re-rolled: {context.AttackerAttackRolls[i]}");
            }
        }
    }


}
