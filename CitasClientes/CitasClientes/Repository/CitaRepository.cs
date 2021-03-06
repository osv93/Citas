﻿using CitasClientes.Contratos;
using CitasClientes.DA;
using CitasClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CitasClientes.Repository
{
    public class CitaRepository : RepositoryBase<Cita>, ICitaRepository
    {
        public CitaRepository(Context repositoryContext) : base(repositoryContext)
        {
        }
    }
}
