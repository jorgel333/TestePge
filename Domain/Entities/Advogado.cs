using Domain.Entities.Abstract;

namespace Domain.Entities;

public class Advogado : Usuario
{
    public string? Oab { get; private set; }

    public IEnumerable<ProcessoJudicial>? Processos { get; set; }

    public Advogado(string nome, string cpf, string oab) : base(nome, cpf)
    {
        Oab = oab;
    }

    public void AtualizarDados(string nome, string cpf, string oab)
    {
        AtualizarDados(nome, cpf);
        Oab = oab;
    }
}
