using Domain.Entities.Abstract;

namespace Domain.Entities;

public class Documento : Entity
{
    public string? Nome { get; set; } 
    public string? Caminho { get; set; } 
    public string? Tipo { get; set; }

    public int NumeroProcesso { get; set; }

    public ProcessoJudicial? Processo { get; set; }


    public Documento(string nome, string caminho, string tipo, int numeroProcesso)
    {
        Nome = nome;
        Caminho = caminho;
        Tipo = tipo;
        NumeroProcesso = numeroProcesso;
    }
}
