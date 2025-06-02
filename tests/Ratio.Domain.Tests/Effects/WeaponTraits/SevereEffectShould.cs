using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects.WeaponTraits
{
    public class SevereEffectShould
    {
        [Fact]
        public void ConvertNormalSuccessToCriticalWhenNoCriticalHits()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 0; // No critical hits
            
            // Set up attack rolls with normal successes
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 2, 4, 5 }; // 2 is below hit threshold (3), 4 and 5 are normal successes
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var effect = new SevereEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerAttackRolls[0].Should().Be(2); // Failed roll unchanged
            context.AttackerAttackRolls[1].Should().Be(6); // First normal success converted to critical
            context.AttackerAttackRolls[2].Should().Be(5); // Second normal success unchanged
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotConvertNormalSuccessToCriticalWhenCriticalHitsExist()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 1; // Has critical hits
            
            // Set up attack rolls with normal successes
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 2, 4, 5 }; // 2 is below hit threshold (3), 4 and 5 are normal successes
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var originalRolls = new List<int>(context.AttackerAttackRolls);
            
            var effect = new SevereEffect();
            
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
        public void NotConvertWhenNoNormalSuccesses()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 0; // No critical hits
            
            // Set up attack rolls with no normal successes (all failures or all crits)
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 1, 2, 6 }; // 1,2 are failures, 6 is already a crit
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var originalRolls = new List<int>(context.AttackerAttackRolls);
            
            var effect = new SevereEffect();
            
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
