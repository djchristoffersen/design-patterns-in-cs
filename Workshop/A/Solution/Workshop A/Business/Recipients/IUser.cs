namespace Wincubate.WorkshopA.Business
{
    /// <summary>
    /// Interface describing a single user recipient of
    /// <see cref="IMessage"/> instances.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets the name of the recipient.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Gets the phone number of the user, if specified.
        /// </summary>
        string Phone { get; }
    }
}
