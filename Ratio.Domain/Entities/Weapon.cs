using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;

namespace Ratio.Domain.Entities
{
    public class Weapon
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public WeaponType Type { get; private set; }
        public int Attacks { get; private set; }
        public int HitThreshold { get; private set; }
        public int NormalDamage { get; private set; }
        public int CriticalDamage { get; private set; }

        private readonly List<WeaponTrait> _traits = new();
        public IReadOnlyList<WeaponTrait> Traits => _traits.AsReadOnly();

        private Weapon(int id, string name, WeaponType type, int attacks, int hitThreshold, int normalDamage, int criticalDamage)
        {
            Id = id;
            Name = name;
            Type = type;
            Attacks = attacks;
            HitThreshold = hitThreshold;
            NormalDamage = normalDamage;
            CriticalDamage = criticalDamage;
        }

        public static Weapon Create(int id, string name, WeaponType type, int attacks, int hitThreshold, int normalDamage, int criticalDamage)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (attacks <= 0)
                throw new ArgumentOutOfRangeException(nameof(attacks), "Attacks must be greater than zero.");
            if (hitThreshold < 1 || hitThreshold > 6)
                throw new ArgumentOutOfRangeException(nameof(hitThreshold), "Hit threshold must be between 1 and 6.");
            if (normalDamage < 0)
                throw new ArgumentOutOfRangeException(nameof(normalDamage), "Normal damage cannot be negative.");
            if (criticalDamage < 0)
                throw new ArgumentOutOfRangeException(nameof(criticalDamage), "Critical damage cannot be negative.");
            if (type != WeaponType.Ranged && type != WeaponType.Melee)
                throw new ArgumentOutOfRangeException(nameof(type), "Type must be either Ranged or Melee.");

            return new Weapon(id, name, type, attacks, hitThreshold, normalDamage, criticalDamage);
        }

        public void AddTrait(WeaponTrait trait)
        {
            if (trait == null)
                throw new ArgumentNullException(nameof(trait), "Trait cannot be null.");

            if (!_traits.Any(t => t.Type == trait.Type))
            {
                _traits.Add(trait);
            }
        }

        public bool HasTrait(TraitType type) => _traits.Any(t => t.Type == type);

        public int? GetTraitValue(TraitType type) => _traits.FirstOrDefault(t => t.Type == type)?.Value;

    }
}
