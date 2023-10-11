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

        /// <summary>
        /// Busca todos processos judiciais cadastrados
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>
        /// Retorna uma lista com todos os processos judiciais cadastrados
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarTodos(CancellationToken cancellationToken)
        {
            var request = new BuscarTodosProcessosQuery();
            var response = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(response);
        }

        /// <summary>
        /// Busca dados de um único processo
        /// </summary>
        /// <param name="id">Número do processo</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>
        /// Retorna detalhes de um processo, incluindo uma lista com os nomes dos arquivos anexados ao mesmo
        /// </returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarDetalhes(int id, CancellationToken cancellationToken)
        {
            var request = new BuscarDetalhesProcessoQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Cadastro de um processo judicial
        /// </summary>
        /// <param name="request">Dados do processo</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>Retorna o numero do processo cadastrado</returns>
        [HttpPost("criar-processo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Cadastrar(CriarProcessoJudicialCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Atualiza dados de um processo 
        /// </summary>
        /// <param name="id">Número do processo cadastrado</param>
        /// <param name="request">Dados a serem enviados para atualização</param>
        /// <param name="cancellationToken"></param>
        /// <response code="204">NoContent</response>
        /// <response code="400">BadRequest</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">InternalServerError</response>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar(int id, EditarProcessoCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new EditarProcessoCommand(id, request.Tema, request.ValorCausa, request.Descricao, request.AdvogadoId);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        /// <summary>
        /// Exclui o cadastro de um processo
        /// </summary>
        /// <param name="id">Número do processo cadastrado</param>
        /// <param name="cancellationToken"></param>
        /// <response code="204">NoContent</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Excluir(int id, CancellationToken cancellationToken)
        {
            var command = new ExcluirProcessoJudicialCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
