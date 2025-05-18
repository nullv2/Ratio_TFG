using Ratio.Domain.Combat;
using Ratio.Domain.Effects.Abstraction;

namespace Ratio.Domain.Effects
{
    public class AllIsDustEffect : IBeforeDamageResolution
    {
        public void ApplyEffect(CombatContext context)
        {
            if (context.AttackerRetainedNormalHits > 0)
            {
                context.AttackerRetainedNormalHits--;
                context.TotalDamage += 1;
            }
        }
    }
}
