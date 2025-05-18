using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;

namespace Ratio.Domain.Effects.StrategyPloys.ScoutSquad
{
    public class TargetingOculars : IBeforeAttackRoll
    {
        public void ApplyEffect(CombatContext context)
        {
            if (context.ActionType.Equals(ActionType.Shoot))
            {
                context.AttackerWeapon.AddTrait(WeaponTrait.Create(TraitType.Lethal, 5));
                //context.AttackerWeapon.AddTrait(WeaponTrait.Create(TraitType.Saturate)); -- Not implemented
            }
        }
    }
}
