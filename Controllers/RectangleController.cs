using Microsoft.AspNetCore.Mvc;
using RectangleApp.Business;
using RectangleApp.Models;
using System.Text.Json;

namespace RectangleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        private const string FilePath = "Jsons/rectangle.json";
        private readonly RectangleValidator _rectangleValidator;

        public RectangleController(RectangleValidator rectangleValidator)
        {
            _rectangleValidator = rectangleValidator;
        }

        // GET api/rectangle
        [HttpGet]
        public async Task<IActionResult> GetRectangle()
        {
            try
            {
                if (!System.IO.File.Exists(FilePath))
                {
                    return NotFound("Rectangle file not found.");
                }

                string jsonString = await System.IO.File.ReadAllTextAsync(FilePath);
                Rectangle rectangle = JsonSerializer.Deserialize<Rectangle>(jsonString);

                return Ok(rectangle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/rectangle
        [HttpPut]
        public async Task<IActionResult> PutRectangle([FromBody] Rectangle rectangle)
        {
            ValidationResult validationResult = await _rectangleValidator.ValidateAndDelayAsync(rectangle);

            if (!validationResult.IsValid)
            {
                return BadRequest(new { Errors = validationResult.Errors });
            }

            try
            {
                string jsonString = JsonSerializer.Serialize(rectangle);
                await System.IO.File.WriteAllTextAsync(FilePath, jsonString);

                return Ok("Rectangle dimensions saved.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}