using Application.Features.Processos.BuscarDetalhes;
using Application.Features.Processos.Cadastrar;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}:int")]
        public async Task<IActionResult> BuscarDetalhes(int id, CancellationToken cancellationToken)
        {
            var request = new BuscarDetalhesProcessoQuery(id);
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProcesso(CriarProcessoJudicialCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request);
            return SendResponseService.SendResponse(result);
        }

    }
}
