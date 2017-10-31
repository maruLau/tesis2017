using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Distrito
    {
        public int ID { get; set; }
        [Require]
        [Range(0,100)]
        [Display(Name = "Cod Distrito")]
        public int CodDistrito { get; set; }
        [Require]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El nombre del Distrito no puede ser menor a 4 caracteres ni mayor a 50")]
        [Display(Name = "Distrito")]
        public string NDistrito { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public  Departamento Departamento {get;set;}
    }
}
