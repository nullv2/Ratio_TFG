namespace Ratio.Domain.Effects.Abstraction
{
    public interface IWeaponTraitEffect : ICombatEffect { }

    public interface IWeaponTraitValueEffect : IWeaponTraitEffect
    {
        int Value { get; }
    }

}
