namespace Wincubate.WorkshopA.Utility.Logging
{
    public class NullLoggerFactory : ILoggerFactory
    {
        public ILogger Create( string name ) => new NullLogger();
    }
}
