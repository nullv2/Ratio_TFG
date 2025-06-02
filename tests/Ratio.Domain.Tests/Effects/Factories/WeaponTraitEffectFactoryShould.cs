using FluentAssertions;
using Ratio.Domain.Effects.Abstraction;
using Ratio.Domain.Effects.Factories;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;

namespace Ratio.Domain.Tests.Effects.Factories
{
    public class WeaponTraitEffectFactoryShould
    {
        [Fact]
        public void CreateEffectsForAllTraitsInWeapon()
        {
            // Arrange
            var weapon = Weapon.Create(1, "Test Weapon", WeaponType.Ranged, 4, 3, 2, 4);
            weapon.AddTrait(WeaponTrait.Create(TraitType.Accurate, 2));
            weapon.AddTrait(WeaponTrait.Create(TraitType.Balanced));
            weapon.AddTrait(WeaponTrait.Create(TraitType.Relentless));
            
            // Act
            var effects = WeaponTraitEffectFactory.CreateEffectsForWeapon(weapon);
            
            // Assert
            effects.Should().HaveCount(3);
            effects.Should().ContainItemsAssignableTo<ICombatEffect>();
            effects.Should().ContainSingle(e => e is AccurateEffect);
            effects.Should().ContainSingle(e => e is BalancedEffect);
            effects.Should().ContainSingle(e => e is RelentlessEffect);
        }
        
        [Fact]
        public void CreateAccurateEffectWithCorrectValue()
        {
            // Arrange
            var trait = WeaponTrait.Create(TraitType.Accurate, 2);
            
            // Act
            var effect = WeaponTraitEffectFactory.CreateEffect(trait);
            
            // Assert
            effect.Should().NotBeNull();
            effect.Should().BeOfType<AccurateEffect>();
            var accurateEffect = effect as AccurateEffect;
            accurateEffect!.Value.Should().Be(2);
        }
        
        [Fact]
        public void CreateDevastatingEffectWithCorrectValue()
        {
            // Arrange
            var trait = WeaponTrait.Create(TraitType.Devastating, 3);
            
            // Act
            var effect = WeaponTraitEffectFactory.CreateEffect(trait);
            
            // Assert
            effect.Should().NotBeNull();
            effect.Should().BeOfType<DevastatingEffect>();
            var devastatingEffect = effect as DevastatingEffect;
            devastatingEffect!.Value.Should().Be(3);
        }
        
        [Fact]
        public void ReturnNullForTraitsThatRequireValueButDontHaveOne()
        {
            // Arrange
            var trait = WeaponTrait.Create(TraitType.Accurate); // Missing required value
            
            // Act
            var effect = WeaponTraitEffectFactory.CreateEffect(trait);
            
            // Assert
            effect.Should().BeNull();
        }
        
        [Fact]
        public void ReturnNullForTraitsThatStayInSimulatorLogic()
        {
            // Arrange - Brutal is handled in simulator logic 
            var trait = WeaponTrait.Create(TraitType.Brutal);
            
            // Act
            var effect = WeaponTraitEffectFactory.CreateEffect(trait);
            
            // Assert
            effect.Should().BeNull();
        }
    }
}
