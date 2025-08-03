namespace Migration.Domain;

public class InvalidJobItemIdCreationException : DomainException
{
    public InvalidJobItemIdCreationException()
        : base("Guid should not be empty.")
    {
    }
}
