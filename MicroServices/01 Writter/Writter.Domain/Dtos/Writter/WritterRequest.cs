namespace Writter.Domain.Dto
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
        public string body { get; set; }
        public int idWritter { get; set; }
    }
}