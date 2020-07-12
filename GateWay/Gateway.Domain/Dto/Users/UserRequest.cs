using System;

namespace Gateway.Domain.Dto
{
    /// <summary>
    /// class representing the request only for login
    /// </summary>
    public class UserLoginRequest
    {
        /// <summary>
        /// user password for login
        /// </summary>
        public string password_login { get; set; }

        /// <summary>
        /// user account for login
        /// </summary>
        public string user_login { get; set; }
    }

    public class CommentSaveRequest
    {
        public Nullable<int> id_post { get; set; }
        public string body { get; set; }
    }
}