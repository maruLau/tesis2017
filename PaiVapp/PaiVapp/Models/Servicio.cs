using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Servicio
    {
        [Key]
        public int ServicioID { get; set; }

        [Require]
        [Range(0, 20)]
        [Display(Name = "Cod Servicio")]
        public int CodServicio { get; set; }

        [Require]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El nombre ser servicio no debe superar los 50 caracteres")]
        [Display(Name = "Servicio")]
        public string NServicio { get; set; }

        [Require]
        public Boolean Cabecera { get; set;}

        [Require]
        [Range(0,1)]
        [Display(Name = "Tipo Servicio")]
        public int TipoServicio { get; set; }

        [Range(100,1000000)]
        [Display(Name = "Población Menores")]
        public int PoblacionMenor { get; set; }

        [Range(0, 500)]
        [Display(Name = "Distancia a R.S.")]
        public int DistanciaRS { get; set; }

        [Require]
        public Boolean Estado { get; set; }

        [ForeignKey("Distrito")]
        public int DistritoID { get; set; }

        [ForeignKey("Reg. Sanitaria")]
        public int? RegionSanitariaID { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaServicioID { get; set; }

        public RegionSanitaria RegionSanitaria { get; set; }
        public Distrito Distrito { get; set; }
        public CategoriaServicio CategoriaServicio { get; set; }
    }
}
