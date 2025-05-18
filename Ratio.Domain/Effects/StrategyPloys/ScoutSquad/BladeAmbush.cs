using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;

namespace Ratio.Domain.Effects.StrategyPloys.ScoutSquad
{
    public class BladeAmbush : IBeforeAttackRoll
    {
        public void ApplyEffect(CombatContext context)
        {
            if (context.ActionType.Equals(ActionType.Fight))
            {
                context.AttackerWeapon.AddTrait(WeaponTrait.Create(TraitType.Ceaseless));
            }
        }
    }
}
