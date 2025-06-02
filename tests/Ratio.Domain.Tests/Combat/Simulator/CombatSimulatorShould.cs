using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Combat.Simulator;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Combat.Simulator
{
    public class CombatSimulatorShould
    {
        [Fact]
        public void SimulateShootingCombatWhenActionTypeIsShoot()
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
            var result = CombatSimulator.Simulate(attacker, defender, ActionType.Shoot);
            
            // Assert
            result.Should().NotBeNull();
            result.ActionType.Should().Be(ActionType.Shoot);
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void SimulateFightCombatWhenActionTypeIsFight()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 10, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 10, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Melee, 4, 3, 4, 5);
            var defenderWeapon = Weapon.Create(2, "DefenderWeapon", WeaponType.Melee, 3, 3, 3, 4);
            
            attacker.AddWeapon(attackerWeapon);
            defender.AddWeapon(defenderWeapon);
            attacker.SelectWeapon(attackerWeapon);
            defender.SelectWeapon(defenderWeapon);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            var result = CombatSimulator.Simulate(attacker, defender, ActionType.Fight);
            
            // Assert
            result.Should().NotBeNull();
            result.ActionType.Should().Be(ActionType.Fight);
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
    }
}
