namespace Editor.API.Dto
{
    /// <summary>
    /// class representing the request only for  update
    /// </summary>
    public class PostRequest
    {
        /// <summary>
        /// post id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// id status (Pending, approved, rejected)
        /// </summary>
        public bool state { get; set; }

        /// <summary>
        /// editor id
        /// </summary>
        public int id_Editor { get; set; }
    }

    public class PostDeleteRequest
    {
        /// <summary>
        /// post id
        /// </summary>
        public int id { get; set; }
    }
}