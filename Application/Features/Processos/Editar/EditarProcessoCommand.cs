﻿using FluentResults;
using MediatR;

namespace Application.Features.Processos.Editar;

public record EditarProcessoCommand(int NumeroProcesso, string Tema, double ValorCausa) : IRequest<Result>;
