namespace Migration.Domain;

public class JobMetadata
{
    public string? Description { get; set; }

    public string? Source { get; set; }

    public string? Target { get; set; }

    public int Priority { get; set; }

    public List<string> Tags { get; set; }
}
