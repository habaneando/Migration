namespace Migration.Domain;

public class InvalidJobIdCreationException : DomainException
{
    public InvalidJobIdCreationException()
        : base("Guid should not be empty.")
    {
    }
}
