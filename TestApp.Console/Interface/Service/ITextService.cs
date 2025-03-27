namespace TestApp.Console.Interface.Service;

public interface ITextService
{
    Task<string> RedactPii(Exception ex);
}
