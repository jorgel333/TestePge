using Domain.Entities.Abstract;

namespace Domain.Entities;

public class ProcessoJudicial
{
    public int NumeroProcesso { get; private set; }
    public string? Tema { get; private set; }
    public double ValorCausa { get; private set; }

    public string Descricao { get; set; }

    public int ClienteId { get; set; }
    public int AdvogadoId { get; set; }

    public  Cliente? Parte { get; set; }
    public Advogado? AdvogadoResponsavel { get; set; }
    public IEnumerable<Documento>? Documentos { get; set; }


    public ProcessoJudicial(string tema, double valorCausa, string descricao)
    {
        Tema = tema;
        ValorCausa = valorCausa;
        Descricao = descricao;
    }

    public void AtualizarDados(string tema, double valorCausa, string descricao, int advogadoId)
    {
        Tema = tema;
        ValorCausa = valorCausa;
        Descricao = descricao;
        AdvogadoId = advogadoId;
    }
}
