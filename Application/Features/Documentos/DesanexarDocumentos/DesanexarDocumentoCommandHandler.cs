using Domain.Interfaces.Repositories;
using Application.Erros;
using FluentResults;
using MediatR;
using Domain.Interfaces;

namespace Application.Features.Documentos.DesanexarDocumentos;

public class DesanexarDocumentoCommandHandler : IRequestHandler<DesanexarDocumentoCommand, Result>
{
    public readonly IDocumentoRepository _documentoRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DesanexarDocumentoCommandHandler(IDocumentoRepository documentoRepository, IUnityOfWork unityOfWork) 
    {
        _documentoRepository = documentoRepository;
        _unityOfWork = unityOfWork;
    }


    public async Task<Result> Handle(DesanexarDocumentoCommand request, CancellationToken cancellationToken)
    {
        var documento = await _documentoRepository.BuscarDocumento(request.Id, cancellationToken);

        if (documento is null)
            return Result.Fail(new ApplicationNotFoundError("Documento não encontrado"));

        var caminho = Path.Combine(Directory.GetCurrentDirectory(), "Documentos", documento.Nome!);

        if (File.Exists(caminho))
            File.Delete(caminho);

        _documentoRepository.Desanexar(documento);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
        
    }
}
