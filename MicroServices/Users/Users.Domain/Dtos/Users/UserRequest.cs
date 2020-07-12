using System;

namespace Users.Domain.Dto
{
    /// <summary>
    /// class representing the request only for save
    /// </summary>
    public class CommentSaveRequest
    {
        public Nullable<int> id_post { get; set; }
        public string body { get; set; }
    }
}