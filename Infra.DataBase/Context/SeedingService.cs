using Domain.Entities;

namespace Infra.DataBase.Context;

public class SeedingService
{
    private readonly AppDbContext _context;

    public SeedingService(AppDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (_context.Advogados.Any() ||
          _context.Clientes.Any() ||
          _context.ProcessosJudiciais.Any())
        {
            return; // O banco de dados já foi populado
        }

        // Criar 10 advogados
        var advogados = new List<Advogado>
        {
            new Advogado("NomeAdvogado1", "12345678100", "OAB12345"),
            new Advogado("NomeAdvogado2", "12345678200", "OAB23456"),
            new Advogado("NomeAdvogado3", "12345678300", "OAB34567"),
            new Advogado("NomeAdvogado4", "12345678400", "OAB45678"),
            new Advogado("NomeAdvogado5", "12345678500", "OAB56789"),
            new Advogado("NomeAdvogado6", "12345678600", "OAB67890"),
            new Advogado("NomeAdvogado7", "12345678700", "OAB78901"),
            new Advogado("NomeAdvogado8", "12345678800", "OAB89012"),
            new Advogado("NomeAdvogado9", "12345678900", "OAB90123"),
            new Advogado("NomeAdvogado10", "12356781000", "OAB01234")
        };

        // Criar 10 clientes
        var clientes = new List<Cliente>
        {
            new Cliente("NomeCliente1", "11122233441"),
            new Cliente("NomeCliente2", "11122233442"),
            new Cliente("NomeCliente3", "11122233443"),
            new Cliente("NomeCliente4", "11122233444"),
            new Cliente("NomeCliente5", "11122233445"),
            new Cliente("NomeCliente6", "11122233446"),
            new Cliente("NomeCliente7", "11122233447"),
            new Cliente("NomeCliente8", "11122233448"),
            new Cliente("NomeCliente9", "11122233449"),
            new Cliente("NomeCliente10", "11222334410")
        };

        _context.Advogados.AddRange(advogados);
        _context.Clientes.AddRange(clientes);
        _context.SaveChanges();

        // Criar 25 processos judiciais
        var processos = new List<ProcessoJudicial>
        {
            new ProcessoJudicial("TemaProcesso1", 1000.0, "Descrição do Processo 1")
            {
                Parte = clientes[0],
                AdvogadoResponsavel = advogados[0]
            },

            new ProcessoJudicial("TemaProcesso2", 2000.0, "Descrição do Processo 2")
            {
                Parte = clientes[1],
                AdvogadoResponsavel = advogados[1]
            },

            new ProcessoJudicial("TemaProcesso3", 3000.0, "Descrição do Processo 3")
            {
                Parte = clientes[2],
                AdvogadoResponsavel = advogados[2]
            },

            new ProcessoJudicial("TemaProcesso4", 4000.0, "Descrição do Processo 4")
            {
                Parte = clientes[3],
                AdvogadoResponsavel = advogados[3]
            },

            new ProcessoJudicial("TemaProcesso5", 5000.0, "Descrição do Processo 5")
            {
                Parte = clientes[4],
                AdvogadoResponsavel = advogados[4]
            },

            new ProcessoJudicial("TemaProcesso6", 6000.0, "Descrição do Processo 6")
            {
                Parte = clientes[5],
                AdvogadoResponsavel = advogados[5]
            },

            new ProcessoJudicial("TemaProcesso7", 7000.0, "Descrição do Processo 7")
            {
                Parte = clientes[6],
                AdvogadoResponsavel = advogados[6]
            },

            new ProcessoJudicial("TemaProcesso8", 8000.0, "Descrição do Processo 8")
            {
                Parte = clientes[7],
                AdvogadoResponsavel = advogados[7]
            },

            new ProcessoJudicial("TemaProcesso9", 9000.0, "Descrição do Processo 9")
            {
                Parte = clientes[8],
                AdvogadoResponsavel = advogados[8]
            },

            new ProcessoJudicial("TemaProcesso10", 10000.0, "Descrição do Processo 10")
            {
                Parte = clientes[9],
                AdvogadoResponsavel = advogados[9]
            },

            new ProcessoJudicial("TemaProcesso11", 11000.0, "Descrição do Processo 11")
            {
                Parte = clientes[0],
                AdvogadoResponsavel = advogados[1]
            },

            new ProcessoJudicial("TemaProcesso12", 12000.0, "Descrição do Processo 12")
            {
                Parte = clientes[1],
                AdvogadoResponsavel = advogados[2]
            },

            new ProcessoJudicial("TemaProcesso13", 13000.0, "Descrição do Processo 13")
            {
                Parte = clientes[2],
                AdvogadoResponsavel = advogados[3]
            },

            new ProcessoJudicial("TemaProcesso14", 14000.0, "Descrição do Processo 14")
            {
                Parte = clientes[3],
                AdvogadoResponsavel = advogados[4]
            },

            new ProcessoJudicial("TemaProcesso15", 15000.0, "Descrição do Processo 15")
            {
                Parte = clientes[4],
                AdvogadoResponsavel = advogados[5]
            },

            new ProcessoJudicial("TemaProcesso16", 16000.0, "Descrição do Processo 16")
            {
                Parte = clientes[5],
                AdvogadoResponsavel = advogados[6]
            },

            new ProcessoJudicial("TemaProcesso17", 17000.0, "Descrição do Processo 17")
            {
                Parte = clientes[6],
                AdvogadoResponsavel = advogados[7]
            },

            new ProcessoJudicial("TemaProcesso18", 18000.0, "Descrição do Processo 18")
            {
                Parte = clientes[7],
                AdvogadoResponsavel = advogados[8]
            },

            new ProcessoJudicial("TemaProcesso19", 19000.0, "Descrição do Processo 19")
            {
                Parte = clientes[8],
                AdvogadoResponsavel = advogados[9]
            },

            new ProcessoJudicial("TemaProcesso20", 20000.0, "Descrição do Processo 20")
            {
                Parte = clientes[9],
                AdvogadoResponsavel = advogados[0]
            },

            new ProcessoJudicial("TemaProcesso21", 21000.0, "Descrição do Processo 21")
            {
                Parte = clientes[0],
                AdvogadoResponsavel = advogados[2]
            },

            new ProcessoJudicial("TemaProcesso22", 22000.0, "Descrição do Processo 22")
            {
                Parte = clientes[1],
                AdvogadoResponsavel = advogados[3]
            },

            new ProcessoJudicial("TemaProcesso23", 23000.0, "Descrição do Processo 23")
            {
                Parte = clientes[2],
                AdvogadoResponsavel = advogados[4]
            },

            new ProcessoJudicial("TemaProcesso24", 24000.0, "Descrição do Processo 24")
            {
                Parte = clientes[3],
                AdvogadoResponsavel = advogados[5]
            },

            new ProcessoJudicial("TemaProcesso25", 25000.0, "Descrição do Processo 25")
            {
                Parte = clientes[4],
                AdvogadoResponsavel = advogados[6]
            }
        };

        _context.ProcessosJudiciais.AddRange(processos);
        _context.SaveChanges();
    }
}
