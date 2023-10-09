using Application.Erros;
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

        var fileNames = request.Documentos.Select(file => file.FileName).ToList();

        var duplicateFileNames = fileNames.GroupBy(fileName => fileName)
                                          .Where(group => group.Count() > 1)
                                          .Select(group => group.Key)
                                          .ToList();

        if (duplicateFileNames.Any())
            return Result.Fail(new ApplicationError($"Os seguintes nomes de arquivo são duplicados: {string.Join(", ", duplicateFileNames)}"));
        
        foreach (var formFile in request.Documentos)
        {
            if (formFile.Length > 0)
            {
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), "Documentos", formFile.FileName);

                using var stream = new FileStream(caminho, FileMode.Create);
                {
                    await formFile.CopyToAsync(stream, cancellationToken);

                    var documento = new Documento(formFile.FileName, caminho, formFile.ContentType, request.NumeroProcesso);
                    _documentoRepository.Anexar(documento);
                } 
            }
        };
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
