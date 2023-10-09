namespace Application.Features.Processos.Editar;

public record EditarProcessoCommandRequest(string Tema, double ValorCausa, string Descricao, int AdvogadoId);
