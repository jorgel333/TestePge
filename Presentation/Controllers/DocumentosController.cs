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

        [HttpGet("id{id:int}/baixar-documento")]
        public async Task<IActionResult> Baixar(int id, CancellationToken cancellationToken)
        {
            var request = new BaixarDocumentoQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendDownloadResponse(result);
            
        }

        [HttpPost]
        public async Task<IActionResult> Anexar([FromForm] AnexarDocumentosCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
            
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Desanexar(int id, CancellationToken cancellationToken)
        {
            var request = new DesanexarDocumentoCommand(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
