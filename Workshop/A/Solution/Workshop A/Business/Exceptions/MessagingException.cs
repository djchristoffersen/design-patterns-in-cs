using System;
using System.Runtime.Serialization;

namespace Wincubate.WorkshopA.Business
{
    /// <summary>
    /// Custom exception class for errors relating to messaging.
    /// </summary>
    [Serializable]
    public class MessagingException : Exception, ISerializable
    {
        /// <summary>
        /// Reason code for messaging error.
        /// </summary>
        public MessagingExceptionReason Reason { get; }

        /// <summary>
        /// Creates a new instance of <see cref="MessagingException"/>
        /// with reason code specified by <paramref name="reason"/> and
        /// inner exception specified by <paramref name="inner"/>.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        /// <param name="reason">Messaging reason code.</param>
        public MessagingException( 
            string message = null, 
            Exception inner = null, 
            MessagingExceptionReason reason = MessagingExceptionReason.InternalError )
            : base(message, inner)
        {
            Reason = reason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessagingException"/>
        /// class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds
        /// the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that
        /// contains contextual information about the source or destination.
        /// </param>
        protected MessagingException(
            SerializationInfo info, 
            StreamingContext context ) : base(info, context)
        {
        }
    }
}