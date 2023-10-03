namespace Domain.Entities.Abstract;

public class Pessoa : Entity
{
    public string? Nome { get; protected set; }
    public string? Cpf { get; protected set; }

    public Pessoa(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
    }
}
