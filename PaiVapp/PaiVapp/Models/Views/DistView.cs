using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models.Views
{
    public class DistView
    {
        [Display(Name = "Cod")]
        public int DistritoID { get; set; }
        [Display(Name = "Cod Distrito")]
        public int CodDistrito { get; set; }
        [Display(Name = "Distrito")]
        public string NDistrito { get; set; }

        [Display(Name = "ID Departamento")]
        public int DepartamentoID { get; set; }
        [Display(Name = "Cod Departamento")]
        public int CodDepartamento { get; set; }
        [Display(Name = "Departamento")]

        public string NDepartamento { get; set; }
        [Display(Name = "Estado")]
        public Boolean Estado { get; set; }
        [Display (Name = "Pais")]
        public string NPais { get; set; }
    }
}
