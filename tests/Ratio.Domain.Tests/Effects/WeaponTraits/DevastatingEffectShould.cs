using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects.WeaponTraits
{
    public class DevastatingEffectShould
    {
        [Fact]
        public void AddAdditionalDamageBasedOnCriticalHits()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 2;
            context.TotalDamage = 0;
            
            var devastatingValue = 3;
            var effect = new DevastatingEffect(devastatingValue);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            // Damage should be devastatingValue * criticalHits = 3 * 2 = 6
            context.TotalDamage.Should().Be(6);
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotAddDamageWhenNoCriticalHits()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 0;
            context.TotalDamage = 0;
            
            var devastatingValue = 3;
            var effect = new DevastatingEffect(devastatingValue);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.TotalDamage.Should().Be(0);
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void ReturnCorrectValueProperty()
        {
            // Arrange
            var devastatingValue = 3;
            var effect = new DevastatingEffect(devastatingValue);
            
            // Act & Assert
            effect.Value.Should().Be(devastatingValue);
        }
    }
}
