using FluentAssertions;
using Ratio.Domain.Entities;

namespace Ratio.Domain.Tests.Entities
{
    public class KillTeamShould
    {
        [Fact]
        public void BeAbleToCreateKillTeam()
        {
            // Arrange
            var id = 1;
            var killTeamName = "Test Kill Team";
            // Act
            var killTeam = KillTeam.Create(id, killTeamName);

            // Assert
            killTeam.Should().NotBeNull();
            killTeam.Id.Should().Be(id);
            killTeam.Name.Should().Be(killTeamName);
        }

        [Fact]
        public void ThrowExceptionWhenNameIsEmpty()
        {
            // Arrange
            var id = 1;
            var emptyName = string.Empty;
            // Act
            Action act = () => KillTeam.Create(id, emptyName);
            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("Name cannot be empty.*")
                .And.ParamName.Should().Be("name");
        }

        [Fact]
        public void THrowExceptionWhenIdIsZeroOrNegative()
        {
            // Arrange
            var negativeId = -1;
            var name = "Test Kill Team";
            // Act
            Action act = () => KillTeam.Create(negativeId, name);
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage("Id must be greater than zero.*")
                .And.ParamName.Should().Be("id");
        }

    }
}
