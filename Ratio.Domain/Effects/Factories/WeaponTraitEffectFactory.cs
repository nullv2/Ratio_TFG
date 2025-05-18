using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;

namespace Ratio.Domain.Effects.Factories
{
    public static class WeaponTraitEffectFactory
    {
        public static List<ICombatEffect> CreateEffectsForWeapon(Weapon weapon)
        {
            var effects = new List<ICombatEffect>();

            foreach (var trait in weapon.Traits)
            {
                var effect = CreateEffect(trait);
                if (effect != null)
                    effects.Add(effect);
            }

            return effects;
        }

        public static ICombatEffect? CreateEffect(WeaponTrait trait)
        {
            switch (trait.Type)
            {
                case TraitType.Accurate:
                    if (trait.Value.HasValue)
                        return new AccurateEffect(trait.Value.Value);
                    break;

                case TraitType.Balanced:
                    return new BalancedEffect();

                case TraitType.Ceaseless:
                    return new CeaselessEffect();

                case TraitType.Devastating:
                    if (trait.Value.HasValue)
                        return new DevastatingEffect(trait.Value.Value);
                    break;

                case TraitType.Hot:
                    return new HotEffect();

                case TraitType.Piercing:
                    if (trait.Value.HasValue)
                        return new PiercingEffect(trait.Value.Value);
                    break;

                case TraitType.PiercingCrits:
                    if (trait.Value.HasValue)
                        return new PiercingCritsEffect(trait.Value.Value);
                    break;

                case TraitType.Punishing:
                    return new PunishingEffect();

                case TraitType.Relentless:
                    return new RelentlessEffect();

                case TraitType.Rending:
                    return new RendingEffect();

                case TraitType.Severe:
                    return new SevereEffect();

                //Brutal, Lethal and Shock and stay in simulator logic
            }

            return null;
        }

    }
}
