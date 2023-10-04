namespace Domain.Entities.Abstract;

public abstract class Usuario : Entity
{
    public string? Nome { get; protected set; }
    public string? Cpf { get; protected set; }

    public Usuario(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }

    public void AtualizarDados(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }
}
