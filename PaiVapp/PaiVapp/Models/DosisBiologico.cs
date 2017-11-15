using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class DosisBiologico
    {
        public int DosisBiologicoID { get; set; }
        [Require]
        public int EdadID { get; set; }
        [Require]
        public int BiologicoID { get; set; }
        [Require]
        public int DosisID { get; set; }
        [Require]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La descripcion no debe ser menor a 5 caracteres ni mayor a 50.")]
        public string Descripcion { get; set; }

        public Edad Edad { get; set; }
        public Biologico Biologico{get;set;}
        public Dosis Dosis { get; set; }

    }
}
