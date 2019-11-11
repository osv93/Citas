using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasClientes.Model
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PacienteID { get; set; }

        public string PacienteFullName { get; set; }

    }
}
