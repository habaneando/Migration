namespace Migration.Domain;

public sealed record JobMetadataDto
{
    public string? Description { get; set; }

    public string? Source { get; set; }

    public string? Target { get; set; }

    public int Priority { get; set; }

    public List<string> Tags { get; set; } = [];
}
