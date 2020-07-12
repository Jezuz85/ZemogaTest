using System;

namespace Editor.API.Dto
{
    /// <summary>
    /// class that handles the user entity
    /// </summary>
    public class Post
    {
        public int id { get; set; }
        public string state { get; set; }
        public Nullable<System.DateTime> datePublish { get; set; }
        public string body { get; set; }
    }
}