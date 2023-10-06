using Application.Features.Advogados.Cadastrar;
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

        [HttpPost]
        public async Task<IActionResult> CadastrarAdvogado(CadastrarAdvogadoCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
