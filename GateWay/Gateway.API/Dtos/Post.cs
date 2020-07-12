using System;

namespace Gateway.API.Dto
{
    /// <summary>
    /// class that handles the post
    /// </summary>
    public class Post
    {
        /// <summary>
        /// post id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        ///  post status (Pending, approved, rejected)
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// post publication date
        /// </summary>
        public Nullable<System.DateTime> datePublish { get; set; }

        /// <summary>
        /// post body message
        /// </summary>
        public string body { get; set; }
    }
}