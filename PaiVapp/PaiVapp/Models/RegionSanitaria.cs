using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class RegionSanitaria
    {
        public int RegionSanitariaID { get; set; }
        [Require]
        [Range(0,20)]
        [Display(Name = "Cod Región Sanitaria")]
        public int CodRS { get; set; }
        [Require]
        [StringLength(20, MinimumLength =18, ErrorMessage ="El nombre debe ser como 'IV Región Sanitaria'")]
        [Display(Name = "Región Sanitaria")]
        public string NRegionS { get; set; }
        [Require]
        public Boolean Estado { get; set; }
        public int DepartmentoID { get; set; }

        public Departamento Departamento { get; set; }
        public ICollection<Servicio> Servicios { get; set; }
    }
}
