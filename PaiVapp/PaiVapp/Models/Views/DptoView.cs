using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models.Views
{
    public class DptoView
    {
        [Display(Name = "Cod")]
        public int DepartamentoID { get; set; }
        [Display(Name = "Cod Departamento")]
        public int CodDeparamento { get; set; }
        [Display(Name = "Departamento")]
        public string NDepartamento { get; set; }
        [Display(Name = "Cod Pais")]
        public int PaisID { get; set; }
        [Display(Name = "Pais")]
        public string NPais { get; set; }
        [Display(Name = "Estado")]
        public Boolean Estado { get; set; }
    }
}

