using System;

namespace Gateway.API.Dto
{
    /// <summary>
    /// class that handles the user
    /// </summary>
    public class User
    {
        /// <summary>
        /// id user
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// user login
        /// </summary>
        public string user_login { get; set; }

        /// <summary>
        /// user password
        /// </summary>
        public string password_login { get; set; }

        /// <summary>
        /// field that identifies if a user is an editor
        /// </summary>
        public Nullable<bool> isEditor { get; set; }
    }
}