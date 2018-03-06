namespace Wincubate.WorkshopA.Business
{
    /// <summary>
    /// Reason code for use with <see cref="MessagingException"/>.
    /// </summary>
    public enum MessagingExceptionReason
    {
        /// <summary>
        /// Internal error performing message-related activities.
        /// </summary>
        InternalError,

        /// <summary>
        /// Could not locate message template with specified id.
        /// </summary>
        MessageTemplateNotFound,

        /// <summary>
        /// Could not substitute parameters into the message template.
        /// </summary>
        TextSubstitutionError,

        /// <summary>
        /// Error occurred sending a message.
        /// </summary>
        MessageSendError,
    }
}
