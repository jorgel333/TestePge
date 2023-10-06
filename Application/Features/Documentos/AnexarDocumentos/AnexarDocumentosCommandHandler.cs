using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace Application.Features.Documentos.AnexarDocumentos;

public class AnexarDocumentosCommandHandler : IRequestHandler<AnexarDocumentosCommand, Result>
{
    private readonly IDocumentoRepository _documentoRepository;
    private readonly IUnityOfWork _unityOfWork;

    public AnexarDocumentosCommandHandler(IDocumentoRepository documentoRepository, IUnityOfWork unityOfWork)
    {
        _documentoRepository = documentoRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(AnexarDocumentosCommand request, CancellationToken cancellationToken)
    {
        foreach (var formFile in request.Documentos)
        {
            if (formFile.Length > 0)
            {
                var caminho = Path.Combine(@"C:\Users\Usuário\source\repos\TestePge\Infra.DataBase\Storage", formFile.FileName);

                using var stream = new FileStream(caminho, FileMode.Create);
                {
                    await formFile.CopyToAsync(stream, cancellationToken);

                    var documento = new Documento(formFile.FileName, caminho, formFile.ContentType)
                    {
                        ProcessoId = request.Id
                    };
                    _documentoRepository.Anexar(documento);
                } 
            }
        };
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
