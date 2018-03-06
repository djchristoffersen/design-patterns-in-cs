using System.Collections.Generic;

namespace Wincubate.WorkshopA.Business
{
    /// <summary>
    /// General interface for messages to be resolved and sent
    /// using the <see cref="Messenger"/>.
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Gets the recipient of the <see cref="IMessage"/>.
        /// </summary>
        IUser Recipient { get; }

        /// <summary>
        /// Gets the Id of the <see cref="Data.MessageTemplate"/>
        /// to use.
        /// </summary>
        int MessageTemplateId { get; }

        /// <summary>
        /// Gets the parameters to be substituted into the
        /// <see cref="Data.MessageTemplate"/>.
        /// </summary>
        IEnumerable<object> Parameters { get; }
    }
}
