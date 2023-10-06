namespace Application.Features.Processos.BuscarDetalhes;

public record BuscarDetalhesProcessoQueryResponse(int NumeroProcesso, 
    string Tema, 
    double ValorCausa, 
    string AdvogadoResponsavel,
    string Parte,
    IEnumerable<string> Documentos);