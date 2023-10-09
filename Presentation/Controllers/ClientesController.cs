using Presentation.PresentationUntils.ResponseDapter;
using Application.Features.Clientes.Cadastrar;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Advogados.Editar;
using Application.Features.Advogados.Excluir;
using Application.Features.Clientes.Excluir;
using Application.Features.Clientes.Editar;
using Application.Features.Clientes.Buscar;
using Application.Features.Clientes.BuscarTodos;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ISender _sender;

        public ClientesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
        {
            var request = new BuscarTodosClientesQuery();
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarCliente(int id, CancellationToken cancellationToken)
        {
            var request = new BuscarClienteQuery(id);
            var result = await _sender.Send(request);
            return SendResponseService.SendResponse(result);
        }

        [HttpPost("cadastrar-cliente")]
        public async Task<IActionResult> CadastrarCliente(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPut("{id:int}/atualizar-cliente")]
        public async Task<IActionResult> AtualizarCliente(int id, AtualizarDadosAdvogadoCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new AtualizarDadosClienteCommand(id, request.Nome, request.Cpf);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpDelete("{id:int}/exluir-cliente")]
        public async Task<IActionResult> ExcluirCliente(int id, CancellationToken cancellationToken)
        {
            var request = new ExcluirClienteCommand(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
