namespace MAM.Shared.Domain;

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }
}