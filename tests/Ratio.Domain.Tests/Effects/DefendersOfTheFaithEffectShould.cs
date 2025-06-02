using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects
{
    public class DefendersOfTheFaithEffectShould
    {
        [Fact]
        public void AddHalvedDamageFromOneNormalHit()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 5, 7);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedNormalHits = 1;
            context.TotalDamage = 0;
            
            var effect = new DefendersOfTheFaithEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            // Normal damage is 5, so halved is 3 (rounded up)
            context.TotalDamage.Should().Be(3);
            context.AttackerRetainedNormalHits.Should().Be(0); // Normal hit should be used up
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void ApplyMinimumDamageOfTwoWhenHalvedDamageIsLessThanTwo()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 2, 7); // Normal damage of 2
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedNormalHits = 1;
            context.TotalDamage = 0;
            
            var effect = new DefendersOfTheFaithEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            // Normal damage is 2, so halved would be 1, but minimum is 2
            context.TotalDamage.Should().Be(2);
            context.AttackerRetainedNormalHits.Should().Be(0); // Normal hit should be used up
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotAddDamageWhenNoNormalHits()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 5, 7);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedNormalHits = 0; // No normal hits
            context.TotalDamage = 0;
            
            var effect = new DefendersOfTheFaithEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.TotalDamage.Should().Be(0); // No damage should be added
            context.AttackerRetainedNormalHits.Should().Be(0); // No change to normal hits
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
    }
}
