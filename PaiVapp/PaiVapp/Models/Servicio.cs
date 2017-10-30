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
        public int CodServicio { get; set; }
        [Require]
        [StringLength(50, MinimumLength = 18, ErrorMessage = "El nombre ser servicio no debe superar los 50 caracteres")]
        public string NServicio { get; set; }
        [Require]
        public Boolean Cabecera { get; set;}
        [Require]
        [Range(1,2)]
        public int TipoServicio { get; set; }
        [Range(100,10000)]
        public int PoblacionMenor { get; set; }
        [Range(1, 500)]
        public int DistanciaRS { get; set; }

        public RegionSanitaria RegSanitaria { get; set; }
        public Distrito Distrito { get; set; }
       public ICollection<CategoriaServicio> CatServicio { get; set; }
    }
}
