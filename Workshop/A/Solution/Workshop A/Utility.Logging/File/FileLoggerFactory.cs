using System;
using System.IO;

namespace Wincubate.WorkshopA.Utility.Logging
{
    public class FileLoggerFactory : ILoggerFactory
    {
        public FileLoggerFactory()
        {
        }

        public ILogger Create( string name ) =>
            new FileLogger(
                name, 
                Path.Combine(
                    Environment.CurrentDirectory,
                    $"{name}.log"
                    )
                );
    }
}
