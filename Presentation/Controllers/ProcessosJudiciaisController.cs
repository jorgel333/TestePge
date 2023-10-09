using Application.Features.Processos.BuscarDetalhes;
using Application.Features.Processos.BuscarTodos;
using Application.Features.Processos.Cadastrar;
using Application.Features.Processos.Editar;
using Application.Features.Processos.Excluir;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.PresentationUntils.ResponseDapter;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessosJudiciaisController : ControllerBase
    {
        private readonly ISender _sender;

        public ProcessosJudiciaisController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
        {
            var request = new BuscarTodosProcessosQuery();
            var response = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarDetalhes(int id, CancellationToken cancellationToken)
        {
            var request = new BuscarDetalhesProcessoQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPost("criar-processo")]
        public async Task<IActionResult> Cadastrar(CriarProcessoJudicialCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request);
            return SendResponseService.SendResponse(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, EditarProcessoCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new EditarProcessoCommand(id, request.Tema, request.ValorCausa);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir(int id, CancellationToken cancellationToken)
        {
            var command = new ExcluirProcessoJudicialCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
