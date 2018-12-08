public class Neo4jSettings
{
    private string connectionString;
    public string ConnectionString
    {
        get
        {
            if (IsDockerized)
            {
                return ContainerConnectionString;
            }
            return connectionString;
        }
        set
        {
            connectionString = value;
        }
    }
    public string ContainerConnectionString { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsDockerized { get; set; }
}