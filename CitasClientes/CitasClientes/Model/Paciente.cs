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

        [StringLength(50, MinimumLength = 3)]
        public string PacienteFullName { get; set; }

    }
}
