namespace Migration.Common;

public class InvalidCreationException : DomainException
{
    public InvalidCreationException(string serviceType)
        : base($"Service of type {serviceType} could not be resolved from the service provider.")
    {
    }
}
