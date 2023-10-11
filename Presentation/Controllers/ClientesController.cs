using Presentation.PresentationUntils.ResponseDapter;
using Application.Features.Clientes.Cadastrar;
using Microsoft.AspNetCore.Mvc;
using MediatR;
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

        /// <summary>
        /// Busca todos clientes cadastrados
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>
        /// Retorna uma lista com todos os clientes
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
        {
            var request = new BuscarTodosClientesQuery();
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Busca dados de um único cliente
        /// </summary>
        /// <param name="id">Número identificador do cliente</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>
        /// Retorna detalhes de um cliente, incluindo uma lista com os processos que está vinculado, além do nome do advogado responsáve pelo processo
        /// </returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarCliente(int id, CancellationToken cancellationToken)
        {
            var request = new BuscarClienteQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Cadastro de um cliente
        /// </summary>
        /// <param name="request">Dados do cliente</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>Retorna o Id do cliente cadastrado</returns>
        [HttpPost("cadastrar-cliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarCliente(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Atualiza dados de um cliente
        /// </summary>
        /// <param name="id">Número identificador do cliente cadastrado</param>
        /// <param name="request">Dados a serem enviados para atualização</param>
        /// <param name="cancellationToken"></param>
        /// <response code="204">NoContent</response>
        /// <response code="400">BadRequest</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">InternalServerError</response>
        /// <returns></returns>
        [HttpPut("{id:int}/atualizar-cliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarCliente(int id, AtualizarDadosClienteCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new AtualizarDadosClienteCommand(id, request.Nome, request.Cpf);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Exclui o cadastro de um cliente
        /// </summary>
        /// <param name="id">Número identificador do cliente cadastrado</param>
        /// <param name="cancellationToken"></param>
        /// <response code="204">NoContent</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns></returns>
        [HttpDelete("{id:int}/exluir-cliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExcluirCliente(int id, CancellationToken cancellationToken)
        {
            var request = new ExcluirClienteCommand(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
