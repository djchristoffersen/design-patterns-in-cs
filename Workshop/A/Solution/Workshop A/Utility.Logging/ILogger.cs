﻿namespace Wincubate.WorkshopA.Utility.Logging
{
    public interface ILogger
    {
        void Info( string message, params object[] additional );
        void Warn( string message, params object[] additional );
        void Error( string message, params object[] additional );
    }
}
