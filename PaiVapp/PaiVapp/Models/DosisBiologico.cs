using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiVapp.Models
{
    public class DosisBiologico
    {
        public int ID { get; set; }
        public int EdadID { get; set; }
        public int BiologicoID { get; set; }
        public int DosisID { get; set; }
        public string Descripcion { get; set; }

        public Edad Edad { get; set; }
        public Biologico Biologico{get;set;}
    public Dosis Dosis { get; set; }

    }
}
