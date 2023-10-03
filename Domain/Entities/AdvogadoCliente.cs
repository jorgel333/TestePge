using Domain.Entities.Abstract;

namespace Domain.Entities;

public class AdvogadoCliente : Entity
{
    public int ClienteId { get; set; }
    public int AdvogadoId { get; set; }

    public Cliente? Cliente { get; set; }
    public Advogado? Advogado { get; set; }
}
