namespace Wincubate.WorkshopA.Utility.Logging
{
    public class ConsoleLoggerFactory : ILoggerFactory
    {
        public ILogger Create( string name ) => new ConsoleLogger( name );
    }
}
