using CitasClientes.DA.Interfaces;
using CitasClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClientes.DA
{
    public class TipoCitaRepository : ITipoCita
    {
        private readonly Context context;

        public TipoCitaRepository(Context context)
        {
            this.context = context;
        }

        public IEnumerable<TipoCita> GetTiposCitas()
        {
            return context.TiposCitas;
        }
    }
}
