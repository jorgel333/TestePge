using Domain.Entities.Abstract;

namespace Domain.Entities;

public class Cliente : Pessoa
{
    public IEnumerable<ProcessoJudicial>? Processos { get; set; }
    public IEnumerable<Advogado>? Advogados { get; set; }

    public Cliente(string nome, string cpf) : base(nome, cpf)
    {
    }
}
