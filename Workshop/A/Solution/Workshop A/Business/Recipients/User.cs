using System.Collections;
using System.Collections.Generic;

namespace Wincubate.WorkshopA.Business
{
    /// <summary>
    /// Implementation class describing a single user recipient of
    /// <see cref="IMessage"/> instances.
    /// </summary>
    public class User : IUser
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user, if specified.
        /// </summary>
        public string Phone { get; set; }

        //#region IEnumerable<IUser> Members

        //public IEnumerator<IUser> GetEnumerator()
        //{
        //    yield return this;
        //}

        //IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //#endregion

        /// <summary>
        /// Creates a default instance of <see cref="User"/>.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="User"/> with the specified
        /// parameters.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="email">The email address of the user.</param>
        /// <param name="phone">The phone number of the user, if specified.</param>
        public User( string name, string email, string phone = null )
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
