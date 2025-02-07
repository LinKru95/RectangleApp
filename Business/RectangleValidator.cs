using Business.Interfaces;
using RectangleApp.Models;

namespace RectangleApp.Business
{
    public class RectangleValidator : IRectangleValidator
    {
        private const int ValidationDelayMilliseconds = 10000;

        protected virtual Task DelayAsync() => Task.Delay(ValidationDelayMilliseconds);

        public async Task<ValidationResult> ValidateAndDelayAsync(Rectangle rectangle)
        {
            var result = new ValidationResult();

            await DelayAsync();

            if (rectangle.Width <= 0 || rectangle.Height <= 0)
            {
                result.AddError("Width and Height must be greater than 0.");
            }

            if (rectangle.Width > rectangle.Height)
            {
                result.AddError("Width cannot exceed Height.");
            }

            if (result.Errors.Count == 0)
            {
                result.SetValid();
            }

            return result;
        }
    }
}
