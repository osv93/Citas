using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasClientes.Model
{
    public class TipoCita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TipoCitaID { get; set; }

        public string TipoCitaNombre { get; set; }
    }
}
