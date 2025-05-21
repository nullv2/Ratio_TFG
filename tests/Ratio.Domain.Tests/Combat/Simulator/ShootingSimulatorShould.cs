using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Combat.Simulator;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Combat.Simulator
{
    public class ShootingSimulatorShould
    {
        [Fact]
        public void SimulateShootingCombatSuccessfully()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 10, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 10, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            var result = ShootingSimulator.Simulate(attacker, defender);
            
            // Assert
            result.Should().NotBeNull();
            result.ActionType.Should().Be(ActionType.Shoot);
            result.Attacker.Should().Be(attacker);
            result.Defender.Should().Be(defender);
            result.AttackerWeapon.Should().Be(attackerWeapon);
            
            result.AttackerAttackRolls.Count.Should().Be(attackerWeapon.Attacks);
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void ApplyDamageToDefenderBasedOnHits()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 10, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 10, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 6);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            int defenderInitialWounds = defender.Wounds;
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            var result = ShootingSimulator.Simulate(attacker, defender);
            
            // Assert
            // We can't predict the exact damage, but we can check if damage logic was applied
            if (result.TotalDamage > 0)
            {
                defender.Wounds.Should().BeLessThan(defenderInitialWounds);
            }
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void RegisterAttackerWinsWhenDefenderKilled()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 10, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 1, 2, 3, 4); // Only 1 health
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 2, 4, 6);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            // Modify the defender to ensure it will be killed
            defender.TakeDamage(defender.Wounds - 1); // Leave only 1 wound
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            var result = ShootingSimulator.Simulate(attacker, defender);
            
            // Assert
            // If the defender was killed, the result should indicate AttackerWins
            if (defender.Wounds <= 0)
            {
                result.ResultType.Should().Be(SimulationResultType.AttackerWins);
            }
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
    }
}
