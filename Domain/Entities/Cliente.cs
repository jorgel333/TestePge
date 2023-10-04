﻿using Domain.Entities.Abstract;

namespace Domain.Entities;

public class Cliente : Usuario
{
    public IEnumerable<ProcessoJudicial>? Processos { get; set; }
    public IEnumerable<AdvogadoCliente>? Advogados { get; set; }

    public Cliente(string nome, string cpf) : base(nome, cpf)
    {
    }
}
