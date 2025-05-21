using Ratio.Domain.Entities;
using FluentAssertions;
using Ratio.Domain.Enums;
using Ratio.Domain.ValueObjects;
using Ratio.Domain.Combat;

namespace Ratio.Domain.Tests.Combat
{
    public class CombatContextShould
    {

        [Fact]
        public void CreateCombatContextWithValidParameters()
        {
            // Arrange
            // Create operatives
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            // Create weapons
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Melee, 2, 3, 4, 5);
            var defenderWeapon = Weapon.Create(2, "DefenderWeapon", WeaponType.Melee, 2, 3, 4, 5);

            // Add weapons to the operatives
            attacker.AddWeapon(attackerWeapon);
            defender.AddWeapon(defenderWeapon);
            // Set the weapons for the combat context
            attacker.SelectWeapon(attackerWeapon);
            defender.SelectWeapon(defenderWeapon);

            // Set the action type
            var actionType = ActionType.Fight;
            // Act
            var combatContext = CombatContext.Create(attacker, defender, actionType);
            // Assert
            combatContext.Should().NotBeNull();
            combatContext.Attacker.Should().Be(attacker);
            combatContext.Defender.Should().Be(defender);
            combatContext.AttackerWeapon.Should().Be(attackerWeapon);
            combatContext.DefenderWeapon.Should().Be(defenderWeapon);
            combatContext.ActionType.Should().Be(actionType);
        }

        //validate defender has no weapon if shoot
        [Fact]
        public void CreateCombatContextWithNoDefenderWeaponForShoot()
        {
            // Arrange
            // Create operatives
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            // Create weapons
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 2, 3, 4, 5);
            // Add weapons to the operatives
            attacker.AddWeapon(attackerWeapon);
            // Set the weapons for the combat context
            attacker.SelectWeapon(attackerWeapon);
            // Set the action type
            var actionType = ActionType.Shoot;
            // Act
            var combatContext = CombatContext.Create(attacker, defender, actionType);
            // Assert
            combatContext.Should().NotBeNull();
            combatContext.Attacker.Should().Be(attacker);
            combatContext.Defender.Should().Be(defender);
            combatContext.AttackerWeapon.Should().Be(attackerWeapon);
            combatContext.DefenderWeapon.Should().BeNull();
            combatContext.ActionType.Should().Be(actionType);
        }

        [Fact]
        public void ThrowExceptionWhenAttackerIsNull()
        {
            // Arrange
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var actionType = ActionType.Fight;
              // Act
            Operative nullAttacker = null!;
            Action act = () => CombatContext.Create(nullAttacker, defender, actionType);
            
            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'attacker')");
        }

        [Fact]
        public void ThrowExceptionWhenDefenderIsNull()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var actionType = ActionType.Fight;
              // Act
            Operative nullDefender = null!;
            Action act = () => CombatContext.Create(attacker, nullDefender, actionType);
            
            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'defender')");
        }

        [Fact]
        public void ThrowExceptionWhenAttackerHasNoSelectedWeaponForFight()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var defenderWeapon = Weapon.Create(2, "DefenderWeapon", WeaponType.Melee, 2, 3, 4, 5);
            
            defender.AddWeapon(defenderWeapon);
            defender.SelectWeapon(defenderWeapon);
            
            var actionType = ActionType.Fight;
            
            // Act
            Action act = () => CombatContext.Create(attacker, defender, actionType);
            
            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Attacker must have a selected weapon for fighting.");
        }

        [Fact]
        public void ThrowExceptionWhenDefenderHasNoSelectedWeaponForFight()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Melee, 2, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var actionType = ActionType.Fight;
            
            // Act
            Action act = () => CombatContext.Create(attacker, defender, actionType);
            
            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Defender must have a selected weapon for fighting.");
        }

        [Fact]
        public void ThrowExceptionWhenAttackerHasNoSelectedWeaponForShoot()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var actionType = ActionType.Shoot;
            
            // Act
            Action act = () => CombatContext.Create(attacker, defender, actionType);
            
            // Assert
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Attacker must have a selected weapon for shooting.");
        }

        [Fact]
        public void IncrementEffectUsageCountWhenEffectIsRegistered()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 2, 3, 4, 5);
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var combatContext = CombatContext.Create(attacker, defender, ActionType.Shoot);
            string effectName = "TestEffect";
            
            // Act
            combatContext.RegisterEffectUsage(effectName);
            combatContext.RegisterEffectUsage(effectName);
            
            // Assert
            combatContext.EffectUsageCounts.Should().ContainKey(effectName);
            combatContext.EffectUsageCounts[effectName].Should().Be(2);
        }

        [Fact]
        public void ReturnValueBetweenOneAndSixWhenRollingDie()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 2, 3, 4, 5);
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var combatContext = CombatContext.Create(attacker, defender, ActionType.Shoot);
            
            // Act
            var result = combatContext.RollDie();
              // Assert
            result.Should().BeGreaterThanOrEqualTo(1);
            result.Should().BeLessThanOrEqualTo(6);
        }
    }
}
