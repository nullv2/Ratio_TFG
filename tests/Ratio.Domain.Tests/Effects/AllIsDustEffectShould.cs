using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects
{
    public class AllIsDustEffectShould
    {
        [Fact]
        public void DecreaseNormalHitsAndAddOneDamageWhenNormalHitsExist()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 2, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedNormalHits = 2;
            context.TotalDamage = 0;
            
            var effect = new AllIsDustEffect();
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerRetainedNormalHits.Should().Be(1);
            context.TotalDamage.Should().Be(1);
        }
        
        [Fact]
        public void NotAddDamageWhenNoNormalHitsExist()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 2, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedNormalHits = 0;
            context.TotalDamage = 0;
            
            var effect = new AllIsDustEffect();
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerRetainedNormalHits.Should().Be(0);
            context.TotalDamage.Should().Be(0);
        }
    }
}
