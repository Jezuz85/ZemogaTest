namespace Gateway.Domain.Dto
{
    public class PostRequest
    {
        /// <summary>
        /// user id
        /// </summary>
        public string id { get; set; }

        public string state { get; set; }
        public int id_Editor { get; set; }
    }

    public class PostDeleteRequest
    {
        /// <summary>
        /// user id
        /// </summary>
        public string id { get; set; }
    }
}