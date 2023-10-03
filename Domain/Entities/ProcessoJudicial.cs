using Domain.Entities.Abstract;

namespace Domain.Entities;

public class ProcessoJudicial : Entity
{
    public string? NumeroProcesso { get; private set; }
    public string? Tema { get; private set; }
    public double ValorCausa { get; private set; }
    public DateTime DataDeAbertura { get; private set; }

    public int ClienteId { get; set; }
    public int AdvogadoId { get; set; }

    public  Cliente? Parte { get; set; }
    public Advogado? AdvogadoResponsavel { get; set; }
    public IEnumerable<Documento>? Documentos { get; set; }

    public ProcessoJudicial(string numeroProcesso, string tema, double valorCausa, DateTime dataDeAbertura)
    {
        NumeroProcesso = numeroProcesso;
        Tema = tema;
        ValorCausa = valorCausa;
        DataDeAbertura = dataDeAbertura;
    }
}
