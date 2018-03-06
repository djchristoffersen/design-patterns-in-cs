using Wincubate.WorkshopA.Utility.Data;

namespace Wincubate.WorkshopA.Data
{
    /// <summary>
    /// POCO class capturing a single message template definition
    /// from the underlying database.
    /// </summary>
    public class MessageTemplate : IEntity
    {
        /// <summary>
        /// Gets or sets the Id of the <see cref="MessageTemplate"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the culture identifier of the
        /// <see cref="MessageTemplate"/>.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the Text template of the
        /// <see cref="MessageTemplate"/>.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Provides a string representation of the
        /// <see cref="MessageTemplate"/>.
        /// </summary>
        /// <returns>String representation of the current
        /// <see cref="MessageTemplate"/>.</returns>
        public override string ToString() =>
            $"{Id}\t{Culture}\t{Text}";
    }
}