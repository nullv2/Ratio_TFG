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

        [Fact]
        public void ThrowExceptionWhenIdIsNegative()
        {
            // Arrange
            int id = -1;
            string name = "Weapon Name";
            WeaponType type = WeaponType.Melee;
            int attacks = 2;
            int hitThreshold = 3;
            int normalDamage = 4;
            int criticalDamage = 5;
            
            // Act
            Action act = () => Weapon.Create(id, name, type, attacks, hitThreshold, normalDamage, criticalDamage);
            
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Id cannot be negative. (Parameter 'id')");
        }

        [Fact]
        public void ThrowExceptionWhenNameIsEmpty()
        {
            // Arrange
            int id = 1;
            string name = "";
            WeaponType type = WeaponType.Melee;
            int attacks = 2;
            int hitThreshold = 3;
            int normalDamage = 4;
            int criticalDamage = 5;
            
            // Act
            Action act = () => Weapon.Create(id, name, type, attacks, hitThreshold, normalDamage, criticalDamage);
            
            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Name cannot be empty. (Parameter 'name')");
        }

        [Fact]
        public void ThrowExceptionWhenAttacksIsZeroOrLess()
        {
            // Arrange
            int id = 1;
            string name = "Weapon Name";
            WeaponType type = WeaponType.Melee;
            int attacks = 0;
            int hitThreshold = 3;
            int normalDamage = 4;
            int criticalDamage = 5;
            
            // Act
            Action act = () => Weapon.Create(id, name, type, attacks, hitThreshold, normalDamage, criticalDamage);
            
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Attacks must be greater than zero. (Parameter 'attacks')");
        }

        [Fact]
        public void ThrowExceptionWhenHitThresholdIsOutOfRange()
        {
            // Arrange
            int id = 1;
            string name = "Weapon Name";
            WeaponType type = WeaponType.Melee;
            int attacks = 2;
            int hitThreshold = 7; // Valid range is 1-6
            int normalDamage = 4;
            int criticalDamage = 5;
            
            // Act
            Action act = () => Weapon.Create(id, name, type, attacks, hitThreshold, normalDamage, criticalDamage);
            
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Hit threshold must be between 1 and 6. (Parameter 'hitThreshold')");
        }

        [Fact]
        public void ThrowExceptionWhenNormalDamageIsNegative()
        {
            // Arrange
            int id = 1;
            string name = "Weapon Name";
            WeaponType type = WeaponType.Melee;
            int attacks = 2;
            int hitThreshold = 3;
            int normalDamage = -1;
            int criticalDamage = 5;
            
            // Act
            Action act = () => Weapon.Create(id, name, type, attacks, hitThreshold, normalDamage, criticalDamage);
            
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Normal damage cannot be negative. (Parameter 'normalDamage')");
        }

        [Fact]
        public void ThrowExceptionWhenCriticalDamageIsNegative()
        {
            // Arrange
            int id = 1;
            string name = "Weapon Name";
            WeaponType type = WeaponType.Melee;
            int attacks = 2;
            int hitThreshold = 3;
            int normalDamage = 4;
            int criticalDamage = -1;
            
            // Act
            Action act = () => Weapon.Create(id, name, type, attacks, hitThreshold, normalDamage, criticalDamage);
            
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Critical damage cannot be negative. (Parameter 'criticalDamage')");
        }        [Fact]
        public void ThrowExceptionWhenAddingNullTrait()
        {
            // Arrange
            var weapon = Weapon.Create(1, "Weapon Name", WeaponType.Melee, 2, 3, 4, 5);
            WeaponTrait? nullTrait = null;
            
            // Act
            #pragma warning disable CS8604 // Possible null reference argument.
            Action act = () => weapon.AddTrait(nullTrait);
            #pragma warning restore CS8604 // Possible null reference argument.
              // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Trait cannot be null. (Parameter 'trait')");
        }

        [Fact]
        public void NotAddDuplicateTraitType()
        {
            // Arrange
            var weapon = Weapon.Create(1, "Weapon Name", WeaponType.Melee, 2, 3, 4, 5);
            var trait1 = WeaponTrait.Create(TraitType.Accurate, 2);
            var trait2 = WeaponTrait.Create(TraitType.Accurate, 3); // Same type, different value
            
            // Act
            weapon.AddTrait(trait1);
            weapon.AddTrait(trait2); // Should not be added
            
            // Assert
            weapon.Traits.Should().HaveCount(1);
            weapon.GetTraitValue(TraitType.Accurate).Should().Be(2); // Should keep the first value
        }
    }
}
