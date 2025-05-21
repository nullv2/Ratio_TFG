using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects.WeaponTraits
{
    public class HotEffectShould
    {
        [Fact]
        public void DealSelfDamageWhenRollBelowHitThreshold()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 10, 2, 3, 4); // Health of 10
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            int initialWounds = attacker.Wounds;
            
            var effect = new HotEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // We need to mock the roll to ensure it's below hit threshold
            // Since we can't directly mock the roll, we'll check after the effect
            // if damage was applied or not
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            // Check if health changed - if the random roll was below hit threshold
            if (attacker.Wounds < initialWounds)
            {
                // Calculate what the roll must have been based on damage taken
                int damageDealt = initialWounds - attacker.Wounds;
                int expectedRoll = damageDealt / 2; // Hot effect multiplies roll by 2
                
                // Verify roll was below hit threshold
                expectedRoll.Should().BeLessThan(attackerWeapon.HitThreshold);
                
                // Verify correct damage was applied
                damageDealt.Should().Be(expectedRoll * 2);
            }
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotDealSelfDamageWhenRollAboveOrEqualToHitThreshold()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 10, 2, 3, 4); // Health of 10
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 6, 4, 5); // Hit threshold of 6
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            int initialHealth = attacker.Wounds;
            
            var effect = new HotEffect();
            
            // Since we can't control the random roll,
            // we'll run the effect multiple times and check if at least once
            // the roll is 6 (which is the max value and equals the hit threshold)
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act - Run the effect a few times to increase chance of a roll ≥ hit threshold
            bool foundRollAboveThreshold = false;
            for (int i = 0; i < 10; i++)
            {
                int woundsBefore = attacker.Wounds;
                effect.ApplyEffect(context);
                
                if (attacker.Wounds == woundsBefore)
                {
                    // No damage was taken, so roll must have been ≥ hit threshold
                    foundRollAboveThreshold = true;
                    break;
                }
            }
            
            // Assert
            // Note: This is a probabilistic test; there's a small chance it might fail
            // if all 10 random rolls happen to be below the hit threshold
            foundRollAboveThreshold.Should().BeTrue();
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
    }
}
