using System;

namespace Users.Domain.Dto
{
    public partial class Comment
    {
        public int id { get; set; }
        public Nullable<int> id_post { get; set; }
        public string body { get; set; }
    }
}