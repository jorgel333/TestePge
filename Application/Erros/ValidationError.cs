using FluentResults;

namespace Application.Erros;

public class ValidationError : Error
{
    public Dictionary<string, string[]> ErrorMessageDictionary { get; }
    public ValidationError(Dictionary<string, string[]> errorMessageDictionary) : base("Um ou mais erros de validação ocorreram!")
    {
        ErrorMessageDictionary = errorMessageDictionary;
    }
}
