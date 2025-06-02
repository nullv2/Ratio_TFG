using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects.WeaponTraits
{
    public class RendingEffectShould
    {
        [Fact]
        public void ConvertNormalSuccessIntoCriticalWhenCriticalHitsExists()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 1; // Has at least one critical hit
            
            // Set up attack rolls with a normal success (>= hit threshold but < 6)
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 4, 5 }; // Both are normal successes (>= 3, < 6)
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var effect = new RendingEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            // The first normal success should be converted to a critical hit (6)
            context.AttackerAttackRolls[0].Should().Be(6);
            context.AttackerAttackRolls[1].Should().Be(5); // Unchanged
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotConvertNormalSuccessWhenNoCriticalHits()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedCriticalHits = 0; // No critical hits
            
            // Set up attack rolls with a normal success
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 4, 5 }; // Both are normal successes
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var effect = new RendingEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerAttackRolls[0].Should().Be(4); // Unchanged
            context.AttackerAttackRolls[1].Should().Be(5); // Unchanged
            
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
            context.AttackerRetainedCriticalHits = 1; // Has critical hits
            
            // Set up attack rolls with no normal successes (all failures or all crits)
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 1, 2, 6 }; // 1,2 are failures, 6 is already a crit
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var effect = new RendingEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerAttackRolls[0].Should().Be(1); // Unchanged
            context.AttackerAttackRolls[1].Should().Be(2); // Unchanged
            context.AttackerAttackRolls[2].Should().Be(6); // Unchanged
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
    }
}
