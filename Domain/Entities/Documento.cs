using Domain.Entities.Abstract;

namespace Domain.Entities;

public class Documento : Entity
{
    public string? Nome { get; set; } 
    public string? Caminho { get; set; } 
    public string? Extensao { get; set; }

    public int ProcessoId { get; set; }

    public ProcessoJudicial? Processo { get; set; }

    public Documento(string nome, string caminho, string extensao)
    {
        Nome = nome;
        Caminho = caminho;
        Extensao = extensao;
    }
}
