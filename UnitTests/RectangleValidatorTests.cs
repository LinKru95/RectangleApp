using RectangleApp.Business;
using RectangleApp.Models;

namespace UnitTests
{
    public class RectangleValidatorTests
    {
        private readonly TestRectangleValidator _validator;

        public RectangleValidatorTests()
        {
            _validator = new TestRectangleValidator();
        }

        [Fact]
        public async Task ValidateAndDelayAsync_ShouldReturnValid_WhenRectangleIsValid()
        {
            // Arrange
            var rectangle = new Rectangle { Width = 5, Height = 10 };

            // Act
            ValidationResult result = await _validator.ValidateAndDelayAsync(rectangle);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task ValidateAndDelayAsync_ShouldReturnError_WhenWidthOrHeightIsZeroOrNegative()
        {
            // Arrange
            var rectangle = new Rectangle { Width = 0, Height = -5 };

            // Act
            ValidationResult result = await _validator.ValidateAndDelayAsync(rectangle);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains("Width and Height must be greater than 0.", result.Errors);
        }

        [Fact]
        public async Task ValidateAndDelayAsync_ShouldReturnError_WhenWidthExceedsHeight()
        {
            // Arrange
            var rectangle = new Rectangle { Width = 15, Height = 10 };

            // Act
            ValidationResult result = await _validator.ValidateAndDelayAsync(rectangle);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains("Width cannot exceed Height.", result.Errors);
        }

        [Fact]
        public async Task ValidateAndDelayAsync_ShouldReturnBothErrors_WhenBothConditionsFail()
        {
            // Arrange
            var rectangle = new Rectangle { Width = -1, Height = -2 };

            // Act
            ValidationResult result = await _validator.ValidateAndDelayAsync(rectangle);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(2, result.Errors.Count);
            Assert.Contains("Width and Height must be greater than 0.", result.Errors);
            Assert.Contains("Width cannot exceed Height.", result.Errors);
        }

        [Fact]
        public async Task ValidateAndDelayAsync_ShouldReturnError_WhenWidthIsGreaterThanHeight_ButBothArePositive()
        {
            // Arrange
            var rectangle = new Rectangle { Width = 20, Height = 10 };

            // Act
            ValidationResult result = await _validator.ValidateAndDelayAsync(rectangle);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains("Width cannot exceed Height.", result.Errors);
        }
    }
}
