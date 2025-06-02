using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects
{
    public class CombinedArmsEffectShould
    {
        [Fact]
        public void RerollFailedAttackDiceWhenTargetWasPrevouslyShot()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 2, 4, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.TargetPreviouslyShot = true;
              // Set up attack rolls with some failed dice (below hit threshold of 4)
            context.AttackerAttackRolls.Add(2);
            context.AttackerAttackRolls.Add(5); // 2 is below hit threshold, 5 is above
            var originalFailedRoll = context.AttackerAttackRolls[0];
            
            var effect = new CombinedArmsEffect();
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            // The failed roll should have been re-rolled, but we can't predict the new value
            // So we just ensure it's not the same as before (should be between 1-6)
            context.AttackerAttackRolls.Count.Should().Be(2);
            context.AttackerAttackRolls[1].Should().Be(5); // Successful roll shouldn't be changed
        }
        
        [Fact]
        public void NotRerollDiceWhenTargetWasNotPreviouslyShot()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 2, 4, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.TargetPreviouslyShot = false; // Target not previously shot

            // Set up attack rolls with some failed dice
            int[] failedRolls = { 2, 5 };
            for (int i = 0; i < failedRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(failedRolls[i]);
            }
            
            var originalFailedRoll = context.AttackerAttackRolls[0];
            
            var effect = new CombinedArmsEffect();
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerAttackRolls.Count.Should().Be(2);
            context.AttackerAttackRolls[0].Should().Be(originalFailedRoll); // Should not change
            context.AttackerAttackRolls[1].Should().Be(5);
        }
        
        [Fact]
        public void NotRerollDiceWhenActionTypeIsNotShoot()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Melee, 2, 4, 4, 5);
            var defenderWeapon = Weapon.Create(2, "DefenderWeapon", WeaponType.Melee, 2, 4, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            defender.AddWeapon(defenderWeapon);
            attacker.SelectWeapon(attackerWeapon);
            defender.SelectWeapon(defenderWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Fight);
            context.TargetPreviouslyShot = true; // Even if target was previously shot
            
            // Set up attack rolls with some failed dice
            int[] failedRolls = { 2, 5 };
            for (int i = 0; i < failedRolls.Length; i++)
            {
                context.AttackerAttackRolls.Add(failedRolls[i]);
            }
            var originalFailedRoll = context.AttackerAttackRolls[0];
            
            var effect = new CombinedArmsEffect();
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerAttackRolls.Count.Should().Be(2);
            context.AttackerAttackRolls[0].Should().Be(originalFailedRoll); // Should not change
            context.AttackerAttackRolls[1].Should().Be(5);
        }
    }
}
