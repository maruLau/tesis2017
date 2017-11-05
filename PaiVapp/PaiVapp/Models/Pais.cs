using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Pais
    {
        public int ID { get; set; }
        [Require]
        [StringLength(50, MinimumLength = 4, ErrorMessage="El nombre del Pais no puede ser menor a 4 caracteres ni mayor a 50")]
        [Display(Name = "Pais")]
        public string NPais { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public ICollection<Departamento> Departamentos { get; set; }
    }
}
