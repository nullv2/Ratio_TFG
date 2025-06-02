using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Combat.Simulator;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;

namespace Ratio.Domain.Tests.Combat.Simulator
{
    // We need to create a testable implementation of BaseSimulator since it's abstract
    public class TestableBaseSimulator : BaseSimulator
    {
        public HitPool TestClassifyHits(List<int> rolls, Weapon weapon)
        {
            return ClassifyHits(rolls, weapon);
        }
        
        public void TestRollAttackDice(CombatContext context, Weapon weapon, CombatantRole role)
        {
            RollAttackDice(context, weapon, role);
        }
        
        public void TestRollDefenseDice(CombatContext context)
        {
            RollDefenseDice(context);
        }
    }
    
    public class BaseSimulatorShould
    {
        [Fact]
        public void ClassifyHitsCorrectlyWithoutLethalTrait()
        {
            // Arrange
            var simulator = new TestableBaseSimulator();
            var weapon = Weapon.Create(1, "Test Weapon", WeaponType.Ranged, 4, 3, 2, 4);
            var rolls = new List<int> { 1, 2, 3, 4, 5, 6 };
            
            // Act
            var result = simulator.TestClassifyHits(rolls, weapon);
            
            // Assert
            // Rolls of 3, 4, 5, 6 are hits (>= hitThreshold of 3)
            // But only 6 is a crit (>= lethalThreshold of 6 by default)
            result.Crits.Should().Be(1); // Only the 6 is a crit
            result.Normals.Should().Be(3); // 3, 4, 5 are normal hits
        }
        
        [Fact]
        public void ClassifyHitsCorrectlyWithLethalTrait()
        {
            // Arrange
            var simulator = new TestableBaseSimulator();
            var weapon = Weapon.Create(1, "Test Weapon", WeaponType.Ranged, 4, 3, 2, 4);
            weapon.AddTrait(WeaponTrait.Create(TraitType.Lethal, 5)); // Lethal 5: 5+ are crits
            var rolls = new List<int> { 1, 2, 3, 4, 5, 6 };
            
            // Act
            var result = simulator.TestClassifyHits(rolls, weapon);
            
            // Assert
            // Rolls of 3, 4, 5, 6 are hits (>= hitThreshold of 3)
            // With Lethal 5, rolls of 5, 6 are crits
            result.Crits.Should().Be(2); // 5 and 6 are crits
            result.Normals.Should().Be(2); // 3 and 4 are normal hits
        }
        
        [Fact]
        public void RollAttackDiceForAttacker()
        {
            // Arrange
            var simulator = new TestableBaseSimulator();
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "Attacker Weapon", WeaponType.Ranged, 3, 3, 2, 4);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
              var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            
            // We need to clear the list before testing
            while (context.AttackerAttackRolls.Count > 0)
                context.AttackerAttackRolls.RemoveAt(0);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            simulator.TestRollAttackDice(context, attackerWeapon, CombatantRole.Attacker);
            
            // Assert
            context.AttackerAttackRolls.Should().HaveCount(attackerWeapon.Attacks);
            context.AttackerAttackRolls.Should().AllSatisfy(roll => 
            {
                roll.Should().BeGreaterThanOrEqualTo(1);
                roll.Should().BeLessThanOrEqualTo(6);
            });
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void RollAttackDiceForDefender()
        {
            // Arrange
            var simulator = new TestableBaseSimulator();
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "Attacker Weapon", WeaponType.Melee, 3, 3, 2, 4);
            var defenderWeapon = Weapon.Create(2, "Defender Weapon", WeaponType.Melee, 2, 3, 2, 3);
            
            attacker.AddWeapon(attackerWeapon);
            defender.AddWeapon(defenderWeapon);
            attacker.SelectWeapon(attackerWeapon);
            defender.SelectWeapon(defenderWeapon);
              var context = CombatContext.Create(attacker, defender, ActionType.Fight);
            
            // We need to clear the list before testing
            while (context.DefenderAttackRolls.Count > 0)
                context.DefenderAttackRolls.RemoveAt(0);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            simulator.TestRollAttackDice(context, defenderWeapon, CombatantRole.Defender);
            
            // Assert
            context.DefenderAttackRolls.Should().HaveCount(defenderWeapon.Attacks);
            context.DefenderAttackRolls.Should().AllSatisfy(roll => 
            {
                roll.Should().BeGreaterThanOrEqualTo(1);
                roll.Should().BeLessThanOrEqualTo(6);
            });
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
        
        [Fact]
        public void RollDefenseDice()
        {
            // Arrange
            var simulator = new TestableBaseSimulator();
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "Attacker Weapon", WeaponType.Ranged, 3, 3, 2, 4);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
              var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.DefenderDefenseDiceCount = 3;
            
            // We need to clear the list before testing
            while (context.DefenderDefenseRolls.Count > 0)
                context.DefenderDefenseRolls.RemoveAt(0);
            
            // Disable combat log for the test
            CombatLog.IsEnabled = false;
            
            // Act
            simulator.TestRollDefenseDice(context);
            
            // Assert
            context.DefenderDefenseRolls.Should().HaveCount(context.DefenderDefenseDiceCount);
            context.DefenderDefenseRolls.Should().AllSatisfy(roll => 
            {
                roll.Should().BeGreaterThanOrEqualTo(1);
                roll.Should().BeLessThanOrEqualTo(6);
            });
            
            // Re-enable combat log after test
            CombatLog.IsEnabled = true;
        }
    }
}
