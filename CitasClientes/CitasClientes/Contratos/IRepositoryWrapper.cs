using CitasClientes.Repository;
using System.Threading.Tasks;

namespace CitasClientes.Contratos
{
    public interface IRepositoryWrapper
    {
        ICitaRepository CitaRepo { get; }
        ITipoCitaRepository TipoCitaRepo { get; }
        Task Save();
    }
}
