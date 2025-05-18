using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Effects.Factories;

namespace Ratio.Domain.Entities
{
    public class Operative
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Move { get; private set; }
        public int APL { get; private set; }
        public int Wounds { get; private set; }
        public int Save { get; private set; }

        private readonly List<Weapon> _weapons = new();
        public IReadOnlyList<Weapon> Weapons => _weapons.AsReadOnly();

        private readonly List<ICombatEffect> _activeEffects = new();
        public IReadOnlyList<ICombatEffect> ActiveEffects => _activeEffects.AsReadOnly();

        public Weapon SelectedWeapon { get; private set; }

        private Operative(int id, string name, int move, int apl, int wounds, int save)
        {
            Id = id;
            Name = name;
            Move = move;
            APL = apl;
            Wounds = wounds;
            Save = save;
        }

        public static Operative Create(int id, string name, int move, int apl, int wounds, int save)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (move <= 0)
                throw new ArgumentOutOfRangeException(nameof(move), "Move must be greater than zero.");
            if (apl < 0)
                throw new ArgumentOutOfRangeException(nameof(apl), "APL cannot be negative.");
            if (wounds <= 0)
                throw new ArgumentOutOfRangeException(nameof(wounds), "Wounds must be greater than zero.");
            if (save < 0 || save > 6)
                throw new ArgumentOutOfRangeException(nameof(save), "Save must be between 0 and 6.");
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative.");

            return new Operative(id, name, move, apl, wounds, save);
        }

        public void AddWeapon(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon), "Weapon cannot be null.");
            _weapons.Add(weapon);
        }

        public void SelectWeapon(Weapon weapon)
        {
            if (!_weapons.Contains(weapon))
                throw new ArgumentException("Weapon not owned by this operative.");

            SelectedWeapon = weapon;

            // Clear previous weapon effects
            _activeEffects.RemoveAll(e => e is IWeaponTraitEffect);

            // Add new weapon effects
            var traitEffects = WeaponTraitEffectFactory.CreateEffectsForWeapon(weapon);
            _activeEffects.AddRange(traitEffects);
        }

        //public void AddEffect(ICombatEffect effect)
        //{
        //    if (effect == null)
        //        throw new ArgumentNullException(nameof(effect), "Effect cannot be null.");
        //    if (_activeEffects.Contains(effect))
        //    {
        //        if (effect is IWeaponTraitValueEffect)
        //        {
        //            int value = ((IWeaponTraitValueEffect)effect).Value;
        //            var existingEffect = _activeEffects.OfType<IWeaponTraitValueEffect>()
        //                .FirstOrDefault(e => e.GetType() == effect.GetType());
        //            if (existingEffect != null)
        //            {
        //                // Check if the new effect has a higher value - LESS is better
        //                if (value < existingEffect.Value)
        //                {
        //                    // Remove the existing effect
        //                    _activeEffects.Remove(existingEffect);
        //                    _activeEffects.Add(effect);
        //                }
        //                else
        //                {
        //                    // Ignore the new effect as it has a lower or equal value
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                // Add the new effect
        //                _activeEffects.Add(effect);
        //            }
        //        }
        //        else
        //            return;
        //    }
        //    return;
        //}

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage cannot be negative.");
            Wounds -= damage;
            if (Wounds < 0)
                Wounds = 0;
        }

        public void Kaput()
        {
            Wounds = 0;
        }

        public Operative DeepClone()
        {
            var clone = (Operative)MemberwiseClone();
            return clone;
        }
    }
}
