using Application.Features.Documentos.AnexarDocumentos;
using Application.Features.Documentos.Baixar;
using Application.Features.Documentos.DesanexarDocumentos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.PresentationUntils.ResponseDapter;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly ISender _sender;

        public DocumentosController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Buscar um documento e disponibilizar para baixar
        /// </summary>
        /// <param name="id">Número identificador do documento anexado</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        /// <returns>Link para download</returns>
        [HttpGet("id{id:int}/baixar-documento")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Baixar(int id, CancellationToken cancellationToken)
        {
            var request = new BaixarDocumentoQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendDownloadResponse(result);
            
        }

        /// <summary>
        /// Anexar documento a um processo
        /// </summary>
        /// <param name="request">Arquivo e numero do processo que o arquivo será anexado</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Success</response>
        /// <response code="400">BadRequest</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">InternalServerError</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Anexar([FromForm] AnexarDocumentosCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
            
        }

        /// <summary>
        /// Desanexa e exclui o registro de um arquivo de um processo
        /// </summary>
        /// <param name="id">Número identificador do documento anexado</param>
        /// <param name="cancellationToken"></param>
        /// <response code="204">NoContent</response>
        /// <response code="404">NotFound</response>
        /// <response code="500">InternalServerError</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Desanexar(int id, CancellationToken cancellationToken)
        {
            var request = new DesanexarDocumentoCommand(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
