using FluentAssertions;
using Ratio.Domain.Combat.Simulator;

namespace Ratio.Domain.Tests.Combat.Simulator
{
    public class HitPoolShould
    {
        [Fact]
        public void InitializeWithCorrectValues()
        {
            // Arrange
            int crits = 3;
            int normals = 5;
            
            // Act
            var hitPool = new HitPool(crits, normals);
            
            // Assert
            hitPool.Crits.Should().Be(crits);
            hitPool.Normals.Should().Be(normals);
        }
        
        [Fact]
        public void ReturnTrueForHasHitsWhenCriticalHitsExist()
        {
            // Arrange
            var hitPool = new HitPool(2, 0);
            
            // Act
            var result = hitPool.HasHits();
            
            // Assert
            result.Should().BeTrue();
        }
        
        [Fact]
        public void ReturnTrueForHasHitsWhenNormalHitsExist()
        {
            // Arrange
            var hitPool = new HitPool(0, 3);
            
            // Act
            var result = hitPool.HasHits();
            
            // Assert
            result.Should().BeTrue();
        }
        
        [Fact]
        public void ReturnTrueForHasHitsWhenBothHitTypesExist()
        {
            // Arrange
            var hitPool = new HitPool(1, 2);
            
            // Act
            var result = hitPool.HasHits();
            
            // Assert
            result.Should().BeTrue();
        }
        
        [Fact]
        public void ReturnFalseForHasHitsWhenNoHitsExist()
        {
            // Arrange
            var hitPool = new HitPool(0, 0);
            
            // Act
            var result = hitPool.HasHits();
            
            // Assert
            result.Should().BeFalse();
        }
        
        [Fact]
        public void AllowModifyingHitValues()
        {
            // Arrange
            var hitPool = new HitPool(2, 3);
            
            // Act
            hitPool.Crits = 4;
            hitPool.Normals = 1;
            
            // Assert
            hitPool.Crits.Should().Be(4);
            hitPool.Normals.Should().Be(1);
        }
    }
}
