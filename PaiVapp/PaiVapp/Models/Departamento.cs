using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Departamento
    {
        public int ID { get; set; }
        [Require]
        [Range(0, 20)]
        [Display(Name = "Cod Departamento")]
        public int CodDepartamento { get; set; }
        [Require]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El nombre del Departamento no puede ser menor a 4 caracteres ni mayor a 50")]
        [Display(Name = "Departamento")]
        public string NDepartamento { get; set; }
        [Require]
        public Boolean Estado { get; set; }
       
        public Pais Pais { get; set; }
        public ICollection<Distrito> Distritos { get; set; }
    }
}
