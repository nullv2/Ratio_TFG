using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects.WeaponTraits
{
    public class PiercingCritsEffectShould
    {
        [Fact]
        public void ReduceDefenderDefenseDiceCountWhenCriticalHitsExist()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 1; // Has critical hits
            context.DefenderDefenseDiceCount = 3; // Default defense dice
            
            var piercingValue = 2;
            var effect = new PiercingCritsEffect(piercingValue);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.DefenderDefenseDiceCount.Should().Be(1); // 3 - 2 = 1
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotReduceDefenderDefenseDiceWhenNoCriticalHits()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 0; // No critical hits
            context.DefenderDefenseDiceCount = 3; // Default defense dice
            
            var piercingValue = 2;
            var effect = new PiercingCritsEffect(piercingValue);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.DefenderDefenseDiceCount.Should().Be(3); // Should remain unchanged
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotReduceDefenderDefenseDiceBelowZero()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 1; // Has critical hits
            context.DefenderDefenseDiceCount = 2; // Defense dice count
            
            var piercingValue = 3; // Greater than defense dice count
            var effect = new PiercingCritsEffect(piercingValue);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.DefenderDefenseDiceCount.Should().Be(0); // Should be reduced to 0, not negative
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void ReturnCorrectValueProperty()
        {
            // Arrange
            var piercingValue = 3;
            var effect = new PiercingCritsEffect(piercingValue);
            
            // Act & Assert
            effect.Value.Should().Be(piercingValue);
        }
    }
}
