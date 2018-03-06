using System.Collections.Generic;

namespace Wincubate.WorkshopA.Business
{
    /// <summary>
    /// Implementation class for messages to be resolved
    /// and sent using the <see cref="Messenger"/>.
    /// </summary>
    public class Message : IMessage
    {
        /// <summary>
        /// Gets or sets the recipient of the <see cref="IMessage"/>.
        /// </summary>
        public IUser Recipient { get; set; }


        /// <summary>
        /// Gets or sets the Id of the
        /// <see cref="Data.MessageTemplate"/> to use.
        /// </summary>
        public int MessageTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the parameters to be substituted
        /// into the <see cref="Data.MessageTemplate"/>.
        /// </summary>
        public IEnumerable<object> Parameters { get; set; }
    }
}
