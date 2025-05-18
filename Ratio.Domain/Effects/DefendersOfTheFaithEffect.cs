using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects
{
    public class DefendersOfTheFaithEffect : IBeforeDamageResolution
    {
        public void ApplyEffect(CombatContext context)
        {
            if (context.AttackerRetainedNormalHits > 0)
            {
                int baseDmg = context.Attacker.SelectedWeapon.NormalDamage;
                int halvedDmg = (baseDmg + 1) / 2;
                if (halvedDmg < 2) halvedDmg = 2;

                context.AttackerRetainedNormalHits--;
                context.TotalDamage += halvedDmg;
            }
        }
    }
}
