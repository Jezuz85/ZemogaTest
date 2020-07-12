using System;

namespace Writter.API.Dto
{
    /// <summary>
    /// class that handles the user entity
    /// </summary>
    public class User
    {
        public int id { get; set; }
        public string user_login { get; set; }
        public string password_login { get; set; }
        public Nullable<bool> isEditor { get; set; }
    }
}