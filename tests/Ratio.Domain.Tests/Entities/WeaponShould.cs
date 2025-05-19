using Ratio.Domain.Entities;
using FluentAssertions;
using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;

namespace Ratio.Domain.Tests.Entities
{
    public class WeaponShould
    {

        [Fact]
        public void CreateWeaponWithValidParameters()
        {
            // Arrange
            int id = 1;
            string name = "Weapon Name";
            WeaponType type = WeaponType.Melee;
            int attacks = 2;
            int hitThreshold = 3;
            int normalDamage = 4;
            int criticalDamage = 5;
            // Act
            var weapon = Weapon.Create(id, name, type, attacks, hitThreshold, normalDamage, criticalDamage);
            // Assert
            weapon.Should().NotBeNull();
            weapon.Id.Should().Be(id);
            weapon.Name.Should().Be(name);
            weapon.Type.Should().Be(type);
            weapon.Attacks.Should().Be(attacks);
            weapon.HitThreshold.Should().Be(hitThreshold);
            weapon.NormalDamage.Should().Be(normalDamage);
            weapon.CriticalDamage.Should().Be(criticalDamage);
        }


        [Fact]
        public void ShouldAddTraitToWeapon()
        {
            // Arrange
            var weapon = Weapon.Create(1, "Weapon Name", WeaponType.Melee, 2, 3, 4, 5);
            var trait = WeaponTrait.Create(TraitType.Accurate, 2);
            // Act
            weapon.AddTrait(trait);
            // Assert
            weapon.Traits.Should().ContainSingle();
            weapon.Traits[0].Should().Be(trait);
            weapon.Traits[0].Type.Should().Be(TraitType.Accurate);
            weapon.Traits[0].Value.Should().Be(2);
        }

        [Fact]
        public void ShouldHaveTrait()
        {
            // Arrange
            var weapon = Weapon.Create(1, "Weapon Name", WeaponType.Melee, 2, 3, 4, 5);
            var trait = WeaponTrait.Create(TraitType.Accurate, 2);
            weapon.AddTrait(trait);
            // Act
            bool hasTrait = weapon.HasTrait(TraitType.Accurate);
            // Assert
            hasTrait.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotHaveTrait()
        {
            // Arrange
            var weapon = Weapon.Create(1, "Weapon Name", WeaponType.Melee, 2, 3, 4, 5);
            var trait = WeaponTrait.Create(TraitType.Accurate, 2);
            weapon.AddTrait(trait);
            // Act
            bool hasTrait = weapon.HasTrait(TraitType.Ceaseless);
            // Assert
            hasTrait.Should().BeFalse();
        }

        [Fact]
        public void ShouldGetTraitValue()
        {
            // Arrange
            var weapon = Weapon.Create(1, "Weapon Name", WeaponType.Melee, 2, 3, 4, 5);
            var trait = WeaponTrait.Create(TraitType.Accurate, 2);
            weapon.AddTrait(trait);
            // Act
            int? traitValue = weapon.GetTraitValue(TraitType.Accurate);
            // Assert
            traitValue.Should().Be(2);
        }

        [Fact]
        public void ShouldNotHaveTraitValue()
        {
            // Arrange
            var weapon = Weapon.Create(1, "Weapon Name", WeaponType.Melee, 2, 3, 4, 5);
            var trait = WeaponTrait.Create(TraitType.Ceaseless);
            weapon.AddTrait(trait);
            // Act
            int? traitValue = weapon.GetTraitValue(TraitType.Ceaseless);
            // Assert
            traitValue.Should().BeNull();
        }

    }
}
