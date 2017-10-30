using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class Servicio
    {
        public int ID { get; set; }
        [Require]
        public int CodServicio { get; set; }
        [Require]
        public string NServicio { get; set; }
        [Require]
        public Boolean Cabecera { get; set;}
        [Require]
        public int TipoServicio { get; set; }
        
        public int PoblacionMenor { get; set; }
        public int DistanciaRS { get; set; }

        public RegionSanitaria RegSanitaria { get; set; }
        public Distrito Distrito { get; set; }
       public ICollection<CategoriaServicio> CatServicio { get; set; }
    }
}
