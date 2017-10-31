using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class CategoriaServicio
    {
        public int ID { get; set; }
        [Require]
        [StringLength(15, MinimumLength =3, ErrorMessage ="El nombre de la categoria no debe superar los 15 caracteres.")]
        [Display(Name = "Categoría")]
        public string NCategoria { get; set; }
        [Require]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "La descripción de la categoria no debe superar los 40 caracteres.")]
        public string Descripcion { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public Servicio Servicio { get; set; }
    }
}
