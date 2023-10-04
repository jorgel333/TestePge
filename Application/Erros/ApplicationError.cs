using FluentResults;

namespace Application.Erros;

public class ApplicationError : Error
{
    public ApplicationError(string erro) : base(erro)
    {    
    }
}
