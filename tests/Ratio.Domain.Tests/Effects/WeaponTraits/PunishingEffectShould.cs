using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects.WeaponTraits
{
    public class PunishingEffectShould
    {
        [Fact]
        public void ConvertFailedDieToNormalSuccessWhenCriticalHitsExist()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 1; // Has critical hits
            
            // Set up attack rolls with some failed dice
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 1, 2, 5 }; // 1 and 2 are below hit threshold (3), 5 is above
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var effect = new PunishingEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerAttackRolls[0].Should().Be(3); // First failed die converted to hit threshold
            context.AttackerAttackRolls[1].Should().Be(2); // Second failed die unchanged
            context.AttackerAttackRolls[2].Should().Be(5); // Successful die unchanged
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotConvertDieWhenNoCriticalHits()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 0; // No critical hits
            
            // Set up attack rolls with some failed dice
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 1, 2, 5 }; // 1 and 2 are below hit threshold (3), 5 is above
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var originalRolls = new List<int>(context.AttackerAttackRolls);
            
            var effect = new PunishingEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerAttackRolls.Should().BeEquivalentTo(originalRolls); // All rolls should remain unchanged
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotConvertDieWhenAllDiceAreSuccessful()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 1; // Has critical hits
            
            // Set up attack rolls with all successful dice
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 3, 4, 5 }; // All above or equal to hit threshold
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var originalRolls = new List<int>(context.AttackerAttackRolls);
            
            var effect = new PunishingEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerAttackRolls.Should().BeEquivalentTo(originalRolls); // All rolls should remain unchanged
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
    }
}
