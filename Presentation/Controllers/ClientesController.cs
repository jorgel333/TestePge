using Presentation.PresentationUntils.ResponseDapter;
using Application.Features.Clientes.Cadastrar;
using Microsoft.AspNetCore.Mvc;
using MediatR;

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
        [HttpPost]
        public async Task<IActionResult> CadastrarCliente(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(request, cancellationToken);
            return SendResponseService.SendResponse(result);
        }
    }
}
