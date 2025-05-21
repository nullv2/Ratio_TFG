using Ratio.Domain.Entities;
using FluentAssertions;

namespace Ratio.Domain.Tests.Entities
{
    public class OperativeShould
    {

        [Fact]
        public void CreateOperativeWithValidParameters()
        {
            // Arrange
            int id = 1;
            string name = "Operative Name";
            int move = 5;
            int apl = 2;
            int wounds = 3;
            int save = 4;
            // Act
            var operative = Operative.Create(id, name, move, apl, wounds, save);
            // Assert
            operative.Should().NotBeNull();
            operative.Id.Should().Be(id);
            operative.Name.Should().Be(name);
            operative.Move.Should().Be(move);
            operative.APL.Should().Be(apl);
            operative.Wounds.Should().Be(wounds);
            operative.Save.Should().Be(save);
        }

        [Fact]
        public void ThrowExceptionWhenCreatingOperativeWithInvalidId()
        {
            // Arrange
            int id = -1;
            string name = "Operative Name";
            int move = 5;
            int apl = 2;
            int wounds = 3;
            int save = 4;
            // Act
            Action act = () => Operative.Create(id, name, move, apl, wounds, save);
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Id cannot be negative. (Parameter 'id')");
        }

        [Fact]
        public void ThrowExceptionWhenCreatingOperativeWithInvalidName()
        {
            // Arrange
            int id = 1;
            string name = "";
            int move = 5;
            int apl = 2;
            int wounds = 3;
            int save = 4;
            // Act
            Action act = () => Operative.Create(id, name, move, apl, wounds, save);
            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Name cannot be empty. (Parameter 'name')");
        }

        [Fact]
        public void ThrowExceptionWhenCreatingOperativeWithInvalidMove()
        {
            // Arrange
            int id = 1;
            string name = "Operative Name";
            int move = 0;
            int apl = 2;
            int wounds = 3;
            int save = 4;
            // Act
            Action act = () => Operative.Create(id, name, move, apl, wounds, save);
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Move must be greater than zero. (Parameter 'move')");
        }

        [Fact]
        public void ThrowExceptionWhenCreatingOperativeWithInvalidAPL()
        {
            // Arrange
            int id = 1;
            string name = "Operative Name";
            int move = 5;
            int apl = -1;
            int wounds = 3;
            int save = 4;
            // Act
            Action act = () => Operative.Create(id, name, move, apl, wounds, save);
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("APL cannot be negative. (Parameter 'apl')");
        }

        [Fact]
        public void ThrowExceptionWhenCreatingOperativeWithInvalidWounds()
        {
            // Arrange
            int id = 1;
            string name = "Operative Name";
            int move = 5;
            int apl = 2;
            int wounds = 0;
            int save = 4;
            // Act
            Action act = () => Operative.Create(id, name, move, apl, wounds, save);
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Wounds must be greater than zero. (Parameter 'wounds')");
        }

        [Fact]
        public void ThrowExceptionWhenCreatingOperativeWithInvalidSave()
        {
            // Arrange
            int id = 1;
            string name = "Operative Name";
            int move = 5;
            int apl = 2;
            int wounds = 3;
            int save = -1;
            // Act
            Action act = () => Operative.Create(id, name, move, apl, wounds, save);
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Save must be between 0 and 6. (Parameter 'save')");
        }

        [Fact]
        public void ShouldAddWeaponToOperative()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            var weapon = Weapon.Create(1, "Weapon Name", Enums.WeaponType.Ranged, 3, 3, 3, 4);
            // Act
            operative.AddWeapon(weapon);
            // Assert
            operative.Weapons.Should().Contain(weapon);
        }

        [Fact]
        public void ShouldSelectWeapon()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            var weapon = Weapon.Create(1, "Weapon Name", Enums.WeaponType.Ranged, 3, 3, 3, 4);
            operative.AddWeapon(weapon);
            // Act
            operative.SelectWeapon(weapon);
            // Assert
            operative.SelectedWeapon.Should().Be(weapon);
        }

        [Fact]
        public void ShouldTakeDamage()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            int damage = 2;
            // Act
            operative.TakeDamage(damage);
            // Assert
            operative.Wounds.Should().Be(1);
        }

        [Fact]
        public void ShouldKaput()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            int damage = 3;
            // Act
            operative.TakeDamage(damage);
            // Assert
            operative.Wounds.Should().Be(0);
        }


        [Fact]
        public void ShouldDeepClone()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            var weapon = Weapon.Create(1, "Weapon Name", Enums.WeaponType.Ranged, 3, 3, 3, 4);
            operative.AddWeapon(weapon);
            // Act
            var clonedOperative = operative.DeepClone();
            // Assert
            clonedOperative.Should().NotBeNull();
            clonedOperative.Id.Should().Be(operative.Id);
            clonedOperative.Name.Should().Be(operative.Name);
            clonedOperative.Move.Should().Be(operative.Move);
            clonedOperative.APL.Should().Be(operative.APL);
            clonedOperative.Wounds.Should().Be(operative.Wounds);
            clonedOperative.Save.Should().Be(operative.Save);
            clonedOperative.Weapons.Should().ContainSingle();
            clonedOperative.Weapons[0].Id.Should().Be(weapon.Id);
            clonedOperative.Weapons[0].Name.Should().Be(weapon.Name);
            clonedOperative.Weapons[0].Type.Should().Be(weapon.Type);
            clonedOperative.Weapons[0].Attacks.Should().Be(weapon.Attacks);
            clonedOperative.Weapons[0].HitThreshold.Should().Be(weapon.HitThreshold);
            clonedOperative.Weapons[0].NormalDamage.Should().Be(weapon.NormalDamage);
            clonedOperative.Weapons[0].CriticalDamage.Should().Be(weapon.CriticalDamage);
            clonedOperative.Weapons[0].Traits.Should().BeEmpty();
            clonedOperative.SelectedWeapon.Should().BeNull();
            clonedOperative.ActiveEffects.Should().BeEmpty();
        }

        [Fact]
        public void ThrowExceptionWhenAddingNullWeapon()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            Weapon? nullWeapon = null;
            
            // Act
            #pragma warning disable CS8604 // Possible null reference argument.
            Action act = () => operative.AddWeapon(nullWeapon);
            #pragma warning restore CS8604 // Possible null reference argument.
            
            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("Weapon cannot be null. (Parameter 'weapon')");
        }

        [Fact]
        public void ThrowExceptionWhenSelectingWeaponNotOwnedByOperative()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            var weapon = Weapon.Create(1, "Weapon Name", Enums.WeaponType.Ranged, 3, 3, 3, 4);
            // Not adding the weapon to the operative
            
            // Act
            Action act = () => operative.SelectWeapon(weapon);
            
            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Weapon not owned by this operative.");
        }

        [Fact]
        public void ThrowExceptionWhenTakingNegativeDamage()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            int negativeDamage = -1;
            
            // Act
            Action act = () => operative.TakeDamage(negativeDamage);
            
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Damage cannot be negative. (Parameter 'damage')");
        }

        [Fact]
        public void HaveZeroWoundsAfterKaput()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            
            // Act
            operative.Kaput();
            
            // Assert
            operative.Wounds.Should().Be(0);
        }

        [Fact]
        public void NotGoLowerThanZeroWoundsAfterTakingExcessiveDamage()
        {
            // Arrange
            var operative = Operative.Create(1, "Operative Name", 5, 2, 3, 4);
            int excessiveDamage = 10; // More than the operative's wounds
            
            // Act
            operative.TakeDamage(excessiveDamage);
            
            // Assert
            operative.Wounds.Should().Be(0);
        }

    }
}
