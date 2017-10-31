using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Servicio
    {
        public int ID { get; set; }
        [Require]
        [Range(0, 20)]
        [Display(Name = "Cod Servicio")]
        public int CodServicio { get; set; }
        [Require]
        [StringLength(50, MinimumLength = 18, ErrorMessage = "El nombre ser servicio no debe superar los 50 caracteres")]
        [Display(Name = "Servicio")]
        public string NServicio { get; set; }
        [Require]
        public Boolean Cabecera { get; set;}
        [Require]
        [Range(1,2)]
        [Display(Name = "Tipo Servicio")]
        public int TipoServicio { get; set; }
        [Range(100,10000)]
        [Display(Name = "Población Menores")]
        public int PoblacionMenor { get; set; }
        [Range(1, 500)]
        [Display(Name = "Distancia a R.S.")]
        public int DistanciaRS { get; set; }

        public RegionSanitaria RegSanitaria { get; set; }
        public Distrito Distrito { get; set; }
       public ICollection<CategoriaServicio> CatServicio { get; set; }
    }
}
