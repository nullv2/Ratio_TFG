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
        }




    }
}
