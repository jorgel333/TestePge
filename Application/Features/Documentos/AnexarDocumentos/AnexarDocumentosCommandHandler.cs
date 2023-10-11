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
        var documentosCadastrados = await _documentoRepository.BuscarDocumentos(request.NumeroProcesso, cancellationToken);
        
        var documentosCadastradosNomes = documentosCadastrados.Select(x => x.Nome);

        var fileNames = request.Documentos.Select(file => file.FileName);

        var duplicateFileNames = fileNames.GroupBy(fileName => fileName)
                                          .Where(group => group.Count() > 1)
                                          .Select(group => group.Key);

        var nomesJaCadastradosNoBanco = fileNames.Intersect(documentosCadastradosNomes);

        if (duplicateFileNames.Any())
            return Result.Fail(new ApplicationError($"O(s) seguinte(s) arquivo(s) está(ão) duplicado(s): {string.Join(", ", duplicateFileNames)}"));

        if (nomesJaCadastradosNoBanco.Any())
            return Result.Fail(new ApplicationError($"Já existe registro do(s) seguinte(s) nome(s) de arquivo(s) anexados ao processo : {string.Join(", ", nomesJaCadastradosNoBanco)}"));

        foreach (var formFile in request.Documentos)
        {
            if (formFile.Length > 0)
            {
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), "Documentos", formFile.FileName);

                var documento = new Documento(formFile.FileName, caminho, formFile.ContentType, request.NumeroProcesso);
                _documentoRepository.Anexar(documento);

                using var stream = new FileStream(caminho, FileMode.Create);
                {
                    await formFile.CopyToAsync(stream, cancellationToken);
                } 
            }
        };
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
