namespace Gateway.API.Dto.Config
{
    /// <summary>
    /// class that handles the configuration of a user's uri
    /// </summary>
    public class UsersConfig
    {
        public string Uri { get; set; }
    }

    /// <summary>
    /// class that handles the configuration of a writter's uri
    /// </summary>
    public class WritterConfig
    {
        public string Uri { get; set; }
    }

    /// <summary>
    /// class that handles the configuration of a editor's uri
    /// </summary>
    public class EditorConfig
    {
        public string Uri { get; set; }
    }
}