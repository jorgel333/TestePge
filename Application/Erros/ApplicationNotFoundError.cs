using FluentResults;

namespace Application.Erros;

public class ApplicationNotFoundError : Error
{
    public ApplicationNotFoundError(string erro) : base(erro)
    {
    }
}
