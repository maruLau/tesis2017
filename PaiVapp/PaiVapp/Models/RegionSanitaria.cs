using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class RegionSanitaria
    {
        public int ID { get; set; }
        [Require]
        public int CodRS { get; set; }
        [Require]
        public string NRegionS { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public Departamento Departamento { get; set; }
        public ICollection<Servicio> Servicio { get; set; }
    }
}
