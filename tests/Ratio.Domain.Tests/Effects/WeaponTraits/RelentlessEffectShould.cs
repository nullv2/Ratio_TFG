using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects.WeaponTraits
{
    public class RelentlessEffectShould
    {
        [Fact]
        public void RerollAllFailedAttackDice()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 4, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            
            // Set up attack rolls with some failed dice
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 1, 2, 3, 5 }; // 1, 2, 3 are below hit threshold (4), 5 is above
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var effect = new RelentlessEffect();
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            // We can't predict the new values, but rolls that were failed should have changed
            // and successful rolls should remain unchanged
            context.AttackerAttackRolls.Count.Should().Be(4);
            context.AttackerAttackRolls[3].Should().Be(5); // Successful roll remains unchanged
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void NotRerollSuccessfulDice()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            
            // Set up attack rolls with all successful dice
            context.AttackerAttackRolls.Clear();
            int[] attackRolls = { 3, 4, 5, 6 }; // All above or equal to hit threshold (3)
            for (int i = 0; i < attackRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(attackRolls[i]);
            }
            
            var originalRolls = new List<int>(context.AttackerAttackRolls);
            
            var effect = new RelentlessEffect();
            
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
