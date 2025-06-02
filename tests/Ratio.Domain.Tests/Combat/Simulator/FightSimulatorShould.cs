using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Combat.Simulator;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Combat.Simulator
{
    public class FightSimulatorShould
    {
        [Fact]
        public void SimulateFightCombatSuccessfully()
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
            var result = FightSimulator.Simulate(attacker, defender);
            
            // Assert
            result.Should().NotBeNull();
            result.ActionType.Should().Be(ActionType.Fight);
            result.Attacker.Should().Be(attacker);
            result.Defender.Should().Be(defender);
            result.AttackerWeapon.Should().Be(attackerWeapon);
            result.DefenderWeapon.Should().Be(defenderWeapon);
            
            result.AttackerAttackRolls.Count.Should().Be(attackerWeapon.Attacks);
            result.DefenderAttackRolls.Count.Should().Be(defenderWeapon.Attacks);
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void ApplyDamageToParticipantsBasedOnHits()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 10, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 10, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Melee, 4, 3, 4, 6);
            var defenderWeapon = Weapon.Create(2, "DefenderWeapon", WeaponType.Melee, 3, 3, 3, 5);
            
            attacker.AddWeapon(attackerWeapon);
            defender.AddWeapon(defenderWeapon);
            attacker.SelectWeapon(attackerWeapon);
            defender.SelectWeapon(defenderWeapon);
            
            int attackerInitialWounds = attacker.Wounds;
            int defenderInitialWounds = defender.Wounds;
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            var result = FightSimulator.Simulate(attacker, defender);
            
            // Assert
            // We can't predict the exact damage, but we can check if damage logic was applied
            // Either one or both participants may take damage
            if (result.TotalDamage > 0)
            {
                (defender.Wounds < defenderInitialWounds || attacker.Wounds < attackerInitialWounds)
                    .Should().BeTrue();
            }
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void RegisterAppropriateWinnerWhenOneParticipantKilled()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 10, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 1, 2, 3, 4); // Only 1 health
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Melee, 4, 2, 4, 6);
            var defenderWeapon = Weapon.Create(2, "DefenderWeapon", WeaponType.Melee, 1, 4, 1, 2);
            
            attacker.AddWeapon(attackerWeapon);
            defender.AddWeapon(defenderWeapon);
            attacker.SelectWeapon(attackerWeapon);
            defender.SelectWeapon(defenderWeapon);
            
            // Modify the defender to ensure it will be killed more easily
            defender.TakeDamage(defender.Wounds - 1); // Leave only 1 wound
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            var result = FightSimulator.Simulate(attacker, defender);
            
            // Assert
            // If the defender was killed, the result should indicate AttackerWins
            if (defender.Wounds <= 0 && attacker.Wounds > 0)
            {
                result.ResultType.Should().Be(SimulationResultType.AttackerWins);
            }
            // If the attacker was killed, the result should indicate DefenderWins
            else if (attacker.Wounds <= 0 && defender.Wounds > 0)
            {
                result.ResultType.Should().Be(SimulationResultType.DefenderWins);
            }
            // If both were killed, the result should indicate Draw
            else if (attacker.Wounds <= 0 && defender.Wounds <= 0)
            {
                result.ResultType.Should().Be(SimulationResultType.Draw);
            }
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
    }
}
