namespace Gateway.API.Dto
{
    /// <summary>
    /// class representing the request only for login
    /// </summary>
    public class WritterLoginRequest
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

    public class CreatePostRequest
    {
        /// <summary>
        /// post body message
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// id user writter
        /// </summary>
        public int idWritter { get; set; }
    }
}