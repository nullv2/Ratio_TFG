using FluentAssertions;
using System;
using System.IO;

namespace Ratio.Domain.Tests
{
    public class CombatLogShould
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOut;
        
        public CombatLogShould()
        {
            // Setup - redirect console output to StringWriter for testing
            _originalOut = Console.Out;
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
            
            // Ensure logging is enabled for tests
            CombatLog.IsEnabled = true;
        }
        
        public void Dispose()
        {
            // Cleanup - restore original console output
            Console.SetOut(_originalOut);
            _stringWriter.Dispose();
        }
        
        [Fact]
        public void WriteMessageToConsoleWhenEnabled()
        {
            // Arrange
            string message = "Test message";
            CombatLog.IsEnabled = true;
            
            // Act
            CombatLog.Write(message);
            
            // Assert
            _stringWriter.ToString().Should().Contain(message);
        }
        
        [Fact]
        public void NotWriteMessageToConsoleWhenDisabled()
        {
            // Arrange
            string message = "Test message";
            CombatLog.IsEnabled = false;
            
            // Act
            CombatLog.Write(message);
            
            // Assert
            _stringWriter.ToString().Should().BeEmpty();
        }
        
        [Fact]
        public void WriteHeaderWithFormattingWhenEnabled()
        {
            // Arrange
            string header = "Test Header";
            CombatLog.IsEnabled = true;
            
            // Act
            CombatLog.WriteHeader(header);
            
            // Assert
            _stringWriter.ToString().Should().Contain($"==== {header} ====");
        }
        
        [Fact]
        public void NotWriteHeaderToConsoleWhenDisabled()
        {
            // Arrange
            string header = "Test Header";
            CombatLog.IsEnabled = false;
            
            // Act
            CombatLog.WriteHeader(header);
            
            // Assert
            _stringWriter.ToString().Should().BeEmpty();
        }
    }
}
