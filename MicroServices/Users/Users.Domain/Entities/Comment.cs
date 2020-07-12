using System;

namespace Users.Domain.Entities
{
    public partial class Comment
    {
        public int id { get; set; }
        public Nullable<int> id_post { get; set; }
        public string body { get; set; }
    }
}