using RectangleApp.Business;

namespace UnitTests
{
    internal class TestRectangleValidator : RectangleValidator
    {
        protected override Task DelayAsync() => Task.CompletedTask;
    }
}
