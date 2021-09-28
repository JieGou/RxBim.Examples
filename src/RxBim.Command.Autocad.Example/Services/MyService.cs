namespace RxBim.Command.Autocad.Example.Services
{
    using Abstractions;
    using CSharpFunctionalExtensions;

    /// <inheritdoc/>
    public class MyService : IMyService
    {
        /// <inheritdoc/>
        public Result Go()
        {
            return Result.Success();
        }
    }
}