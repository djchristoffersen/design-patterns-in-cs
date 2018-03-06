namespace Wincubate.WorkshopA.Utility.Logging
{
    public interface ILoggerFactory
    {
        ILogger Create( string name );
    }
}
