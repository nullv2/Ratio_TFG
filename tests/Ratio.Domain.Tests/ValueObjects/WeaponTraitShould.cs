using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;
using FluentAssertions;

namespace Ratio.Domain.Tests.ValueObjects
{
    public class WeaponTraitShould
    {
        [Fact]
        public void CreateWeaponTraitWithValidTypeAndValue()
        {
            // Arrange
            var type = TraitType.Accurate;
            var value = 2;
            
            // Act
            var trait = WeaponTrait.Create(type, value);
            
            // Assert
            trait.Should().NotBeNull();
            trait.Type.Should().Be(type);
            trait.Value.Should().Be(value);
        }
        
        [Fact]
        public void CreateWeaponTraitWithValidTypeAndNoValue()
        {
            // Arrange
            var type = TraitType.Ceaseless;
            
            // Act
            var trait = WeaponTrait.Create(type);
            
            // Assert
            trait.Should().NotBeNull();
            trait.Type.Should().Be(type);
            trait.Value.Should().BeNull();
        }
        
        [Fact]
        public void ThrowExceptionWhenCreatingTraitWithNegativeValue()
        {
            // Arrange
            var type = TraitType.Accurate;
            var negativeValue = -1;
            
            // Act
            Action act = () => WeaponTrait.Create(type, negativeValue);
            
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Value cannot be negative. (Parameter 'value')");
        }
        
        [Fact]
        public void CreateWeaponTraitWithValidStringType()
        {
            // Arrange
            var typeString = "Accurate";
            var value = 2;
            
            // Act
            var trait = WeaponTrait.Create(typeString, value);
            
            // Assert
            trait.Should().NotBeNull();
            trait.Type.Should().Be(TraitType.Accurate);
            trait.Value.Should().Be(value);
        }
        
        [Fact]
        public void ThrowExceptionWhenCreatingTraitWithInvalidStringType()
        {
            // Arrange
            var invalidTypeString = "InvalidTrait";
            
            // Act
            Action act = () => WeaponTrait.Create(invalidTypeString);
            
            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Invalid trait type 'InvalidTrait' (Parameter 'type')");
        }
        
        [Fact]
        public void DisplayTypeAndValueInToString()
        {
            // Arrange
            var type = TraitType.Accurate;
            var value = 2;
            var expectedString = "Accurate 2";
            
            // Act
            var trait = WeaponTrait.Create(type, value);
            var result = trait.ToString();
            
            // Assert
            result.Should().Be(expectedString);
        }
        
        [Fact]
        public void DisplayOnlyTypeInToStringWhenValueIsNull()
        {
            // Arrange
            var type = TraitType.Ceaseless;
            var expectedString = "Ceaseless";
            
            // Act
            var trait = WeaponTrait.Create(type);
            var result = trait.ToString();
            
            // Assert
            result.Should().Be(expectedString);
        }
    }
}
