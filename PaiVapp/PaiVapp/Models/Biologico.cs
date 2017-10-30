using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Biologico
    {
        public int ID { get; set; }
        [Require]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El nombre del Biologico no debe ser menor a 5 caracteres ni superior a 20")]
        public string NBiologico { get; set; }
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La descripción del no debe ser menor a 5 caracteres ni superior a 50")]
        public string Descripcion { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public ICollection<DosisBiologico> DosisBiologico { get; set; }
    }
}
