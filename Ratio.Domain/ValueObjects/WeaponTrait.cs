using Ratio.Domain.Enums;

namespace Ratio.Domain.ValueObjects
{
    public class WeaponTrait
    {
        public TraitType Type { get; private set; }
        public int? Value { get; private set; }

        private WeaponTrait(TraitType type, int? value)
        {
            Type = type;
            Value = value;
        }

        public static WeaponTrait Create(TraitType type, int? value = null)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative.");

            return new WeaponTrait(type, value);
        }

        public static WeaponTrait Create(string type, int? value = null)
        {
            if (!Enum.TryParse<TraitType>(type, true, out var traitType))
                throw new ArgumentException($"Invalid trait type '{type}'", nameof(type));
            return Create(traitType, value);
        }

        public override string ToString()
        {
            return Value.HasValue ? $"{Type} {Value}" : Type.ToString();
        }
    }
}
