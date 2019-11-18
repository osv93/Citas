using CitasClientes.Contratos;
using CitasClientes.DA;
using CitasClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClientes.Repository
{
    public class TipoCitaRepository : RepositoryBase<TipoCita>, ITipoCitaRepository
    {
        public TipoCitaRepository(Context repositoryContext) : base(repositoryContext)
        {
        }
    }
}
