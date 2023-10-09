using Application.Dtos;

namespace Application.Features.Processos.BuscarDetalhes;

public record BuscarDetalhesProcessoQueryResponse(int NumeroProcesso, 
    string Tema, 
    string ValorCausa,
    string Descricao,
    string AdvogadoResponsavel,
    string Parte,
    IEnumerable<DocumentoDto> Documentos);