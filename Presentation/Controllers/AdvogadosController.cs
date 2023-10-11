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

        /// <summary>
        /// Busca todos advogados cadastrados
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>
        /// Retorna uma lista com todos os advogados
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
        {
            var request = new BuscarTodosAdvogadosQuery();
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Busca dados de um único advogado
        /// </summary>
        /// <param name="id">Número identificador do advogado</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>
        /// Retorna detalhes de um advogado, incluindo uma lista com os processos que está vinculado, além do nome da parte envolvida nesse processo
        /// </returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarAdvogado(int id, CancellationToken cancellationToken)
        {
            var response = new BuscarAdvogadoQuery(id);
            var result = await _sender.Send(response, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Cadastro de um advogado
        /// </summary>
        /// <param name="request">Dados do advogado</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>Retorna o Id do cliente cadastrado</returns>
        [HttpPost("cadastrar-advogado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarAdvogado(CadastrarAdvogadoCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Atualiza dados de um advogado
        /// </summary>
        /// <param name="id">Número identificador do advogado cadastrado</param>
        /// <param name="request">Dados a serem enviados para atualização</param>
        /// <param name="cancellationToken"></param>
        /// <response code="204">NoContent</response>
        /// <response code="400">BadRequest</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">InternalServerError</response>
        /// <returns></returns>
        [HttpPut("{id:int}/atualizar-advogado")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarAdvogado(int id, AtualizarDadosAdvogadoCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new AtualizarDadosAdvogadoCommand(id, request.Nome, request.Cpf, request.Oab);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Exclui o cadastro de um advogado
        /// </summary>
        /// <param name="id">Número identificador do advogado cadastrado</param>
        /// <param name="cancellationToken"></param>
        /// <response code="204">NoContent</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns></returns>
        [HttpDelete("{id:int}/excluir-advogado")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExcluirAdvogado(int id, CancellationToken cancellationToken)
        {
            var request = new ExcluirAdvogadoCommand(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
