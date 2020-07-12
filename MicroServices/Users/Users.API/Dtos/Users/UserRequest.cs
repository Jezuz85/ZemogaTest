using System;

namespace Users.API.Dto
{
    public class CommentSaveRequest
    {
        public Nullable<int> id_post { get; set; }
        public string body { get; set; }
    }
}