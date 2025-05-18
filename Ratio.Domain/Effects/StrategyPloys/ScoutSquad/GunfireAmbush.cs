using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;

namespace Ratio.Domain.Effects.StrategyPloys.ScoutSquad
{
    public class GunfireAmbush : IBeforeAttackRoll
    {
        public void ApplyEffect(CombatContext context)
        {
            if (context.ActionType.Equals(ActionType.Shoot)) {
                context.AttackerWeapon.AddTrait(WeaponTrait.Create(TraitType.Balanced));
            }
        }
    }
}
