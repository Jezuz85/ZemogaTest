using System;

namespace Gateway.Domain.Dto
{
    /// <summary>
    /// class that handles the transaction entity
    /// </summary>
    public partial class Post
    {
        public int id { get; set; }
        public string state { get; set; }
        public Nullable<System.DateTime> datePublish { get; set; }
        public string body { get; set; }
    }
}