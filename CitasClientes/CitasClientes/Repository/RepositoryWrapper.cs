using CitasClientes.Contratos;
using CitasClientes.DA;
using System.Threading.Tasks;

namespace CitasClientes.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly Context _context;
        private ICitaRepository _citaRepo;
        private ITipoCitaRepository _tipoCitaRepo;

        public RepositoryWrapper(Context context)
        {
            _context = context;
        }

        public ICitaRepository CitaRepo
        {
            get
            {
                if (_citaRepo == null)
                {
                    _citaRepo = new CitaRepository(_context);
                }

                return _citaRepo;
            }
        }

        public ITipoCitaRepository TipoCitaRepo
        {
            get
            {
                if (_tipoCitaRepo == null)
                {
                    _tipoCitaRepo = new TipoCitaRepository(_context);
                }

                return _tipoCitaRepo;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
