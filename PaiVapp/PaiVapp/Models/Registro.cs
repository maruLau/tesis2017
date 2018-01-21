using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PaiVapp.Models
{
    public class Registro
    {
        public int RegistroID { get; set; }
        public int FechaV { get; set; }
        public int CaptacionID { get; set; }
        public int DosisBiologicoID { get; set; }
        public string Lote { get; set; }
        public string Encargado { get; set; }

       public Boolean Estado { get; set; }

        public Captacion Captacion { get; set; }
        public DosisBiologico DosisBiologico { get; set; }


    }
}
