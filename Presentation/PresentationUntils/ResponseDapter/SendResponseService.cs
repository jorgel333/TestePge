using Application.Erros;
using Application.Features.Documentos.Baixar;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.PresentationUntils.ResponseDapter;

public static class SendResponseService
{
    public static IActionResult SendDownloadResponse(Result<BaixarDocumentoQueryResponse> result)
    {
        if (result.IsSuccess)
        {
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "Documentos", result.Value.Documento.Nome!);
            
            var dataBytes = System.IO.File.ReadAllBytes(caminho);

            return new FileContentResult(dataBytes, result.Value.Documento.Tipo!);
        }

        return HandleError(result.ToResult());
    }
        public static IActionResult SendResponse<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result.Value); 

        return HandleError(result.ToResult());
    }

    public static IActionResult SendResponse(Result result)
    {
        if (result.IsSuccess)
            return new NoContentResult(); 

        return HandleError(result);
    }

    public static IActionResult Created<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return new ObjectResult(result.Value)
            {
                StatusCode = 201,
            };

        return HandleError(result.ToResult());
    }

    public static IActionResult HandleError(Result result)
    {
        var error = result.Errors.FirstOrDefault();

        if (error is ValidationError validationError)
        {
            return new BadRequestObjectResult(new ProblemDetails
            {
                Status = 400,
                Title = "Validation Error",
                Detail = validationError.Message,
                Extensions = { { nameof(validationError.ErrorMessageDictionary), validationError.ErrorMessageDictionary } }
            });
        }

        if (error is ApplicationNotFoundError applicationNotFoundError)
        {
            return new NotFoundObjectResult(new ProblemDetails
            {
                Status = 404,
                Title = "O item requisitado não foi encontrado",
                Detail = applicationNotFoundError.Message
            });
        }

        if (error is ApplicationError applicationError)
        {
            return new ObjectResult(new ProblemDetails
            {
                Status = 403,
                Title = "O servidor entendeu sua requisição mas a recusou.",
                Detail = applicationError.Message,
            })
            {
                StatusCode = 403 
            };
        }

        return new ObjectResult(new ProblemDetails
        {
            Status = 500,
            Title = "Erro desconhecido"
        })
        {
            StatusCode = 500 
        };
    }
}
