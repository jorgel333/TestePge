using Application.Features.Advogados.Buscar;
using Application.Features.Advogados.BuscarTodos;
using Application.Features.Advogados.Cadastrar;
using Application.Features.Advogados.Editar;
using Application.Features.Advogados.Excluir;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.PresentationUntils.ResponseDapter;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvogadosController : ControllerBase
    {
        private readonly ISender _sender;

        public AdvogadosController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
        {
            var request = new BuscarTodosAdvogadosQuery();
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarAdvogado(int id, CancellationToken cancellationToken)
        {
            var response = new BuscarAdvogadoQuery(id);
            var result = await _sender.Send(response, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPost("cadastrar-advogado")]
        public async Task<IActionResult> CadastrarAdvogado(CadastrarAdvogadoCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPut("{id:int}/atualizar-advogado")]
        public async Task<IActionResult> AtualizarAdvogado(int id, AtualizarDadosAdvogadoCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new AtualizarDadosAdvogadoCommand(id, request.Nome, request.Cpf, request.Oab);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpDelete("{id:int}/excluir-advogado")]
        public async Task<IActionResult> ExcluirAdvogado(int id, CancellationToken cancellationToken)
        {
            var request = new ExcluirAdvogadoCommand(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
