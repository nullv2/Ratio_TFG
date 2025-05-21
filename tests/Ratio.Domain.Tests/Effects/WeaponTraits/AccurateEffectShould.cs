using FluentAssertions;
using Ratio.Domain.Combat;
using Ratio.Domain.Effects.WeaponTraits;
using Ratio.Domain.Entities;
using Ratio.Domain.Enums;

namespace Ratio.Domain.Tests.Effects.WeaponTraits
{
    public class AccurateEffectShould
    {
        [Fact]
        public void AddRetainedNormalHitsBeforeAttackRoll()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 4, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedNormalHits = 0;
            
            var accurateValue = 2;
            var effect = new AccurateEffect(accurateValue);
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerRetainedNormalHits.Should().Be(accurateValue);
            context.EffectUsageCounts.Should().ContainKey("AccurateEffect");
            context.EffectUsageCounts["AccurateEffect"].Should().Be(1);
        }
        
        [Fact]
        public void LimitRetainedHitsToWeaponAttackCount()
        {
            // Arrange
            var attacker = Operative.Create(1, "Attacker", 5, 2, 3, 4);
            var defender = Operative.Create(2, "Defender", 5, 2, 3, 4);
            var attackerWeapon = Weapon.Create(1, "AttackerWeapon", WeaponType.Ranged, 2, 3, 4, 5);
            
            attacker.AddWeapon(attackerWeapon);
            attacker.SelectWeapon(attackerWeapon);
            
            var context = CombatContext.Create(attacker, defender, ActionType.Shoot);
            context.AttackerRetainedNormalHits = 0;
            
            var accurateValue = 4; // More than weapon's attack count
            var effect = new AccurateEffect(accurateValue);
            
            // Act
            effect.ApplyEffect(context);
            
            // Assert
            context.AttackerRetainedNormalHits.Should().Be(2); // Limited to weapon's attack count
            context.EffectUsageCounts.Should().ContainKey("AccurateEffect");
            context.EffectUsageCounts["AccurateEffect"].Should().Be(1);
        }
        
        [Fact]
        public void ReturnCorrectValueProperty()
        {
            // Arrange
            var accurateValue = 3;
            var effect = new AccurateEffect(accurateValue);
            
            // Act & Assert
            effect.Value.Should().Be(accurateValue);
        }
    }
}
