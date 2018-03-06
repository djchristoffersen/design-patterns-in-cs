using System;

namespace Wincubate.WorkshopA.Business
{
    /// <summary>
    /// Class for instantiated instances, i.e. it has
    /// already been resolved and substituted from an
    /// <see cref="IMessage"/>.
    /// </summary>
    public class SingleMessageInstance
    {
        /// <summary>
        /// Message string contents.
        /// </summary>
        public string Contents { get; }

        /// <summary>
        /// Unique application-identifier for message instance.
        /// </summary>
        public Guid InstanceId { get; }

        /// <summary>
        /// Creates a new <see cref="SingleMessageInstance"/> with
        /// the message contents specified in <paramref name="contents"/>.
        /// </summary>
        /// <param name="contents">Message string contents.</param>
        public SingleMessageInstance( string contents )
        {
            Contents = contents;
            InstanceId = Guid.NewGuid();
        }
    }
}