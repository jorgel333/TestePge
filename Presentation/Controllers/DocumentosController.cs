using Application.Features.Documentos.AnexarDocumentos;
using Application.Features.Documentos.Baixar;
using Application.Features.Documentos.DesanexarDocumentos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.PresentationUntils.ResponseDapter;
using System.IO;

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

        [HttpPost("id{id:int}/baixar-documento")]
        public async Task<IActionResult> Baixar(int id, CancellationToken cancellationToken)
        {
            var request = new BaixarDocumentoQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendDownloadResponse(result);
            
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> Anexar(int id, [FromForm] AnexarDocumentosCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new AnexarDocumentosCommand(id, request.Documentos);
            var result = await _sender.Send(command, cancellationToken);
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
