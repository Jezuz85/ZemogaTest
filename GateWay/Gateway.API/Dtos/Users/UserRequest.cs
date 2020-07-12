using System;

namespace Gateway.API.Dto
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

    /// <summary>
    /// class representing the request only for delete and get
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// user id
        /// </summary>
        public string id { get; set; }
    }

    public class CommentSaveRequest
    {
        /// <summary>
        /// post id
        /// </summary>
        public Nullable<int> id_post { get; set; }

        /// <summary>
        /// post body message
        /// </summary>
        public string body { get; set; }
    }
}