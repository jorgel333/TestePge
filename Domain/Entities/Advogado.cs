using Domain.Entities.Abstract;

namespace Domain.Entities;

public class Advogado : Pessoa
{
    public string? Oab { get; private set; }

    public IEnumerable<ProcessoJudicial>? Processos { get; set; }
    public IEnumerable<Cliente>? Clientes { get; set; }

    public Advogado(string nome, string cpf, string oab) : base(nome, cpf)
    {
        Oab = oab;
    }
}
