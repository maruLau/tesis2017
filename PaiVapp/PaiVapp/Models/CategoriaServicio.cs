using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class CategoriaServicio
    {
        public int ID { get; set; }
        [Require]
        public string NCategoria { get; set; }
        [Require]
        public Boolean Estado { get; set; }

        public Servicio Servicio { get; set; }
    }
}
