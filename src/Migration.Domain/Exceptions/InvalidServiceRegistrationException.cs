namespace Migration.Domain;

public class InvalidServiceRegistrationException : DomainException
{
    public InvalidServiceRegistrationException(string service)
        : base($"{service} service is not registered.")
    {
    }
}
