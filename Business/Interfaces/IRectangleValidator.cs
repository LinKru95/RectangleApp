using RectangleApp.Business;
using RectangleApp.Models;

namespace Business.Interfaces
{
    public interface IRectangleValidator
    {
        Task<ValidationResult> ValidateAndDelayAsync(Rectangle rectangle);
    }
}
