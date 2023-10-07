namespace MaterialAllergenManagementApp;

public record HttpErrorBody(string Message)
{
    public HttpErrorBody(Exception e) : this(e.Message)
    {
    }
}
