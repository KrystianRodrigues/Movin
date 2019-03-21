using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M0v1n.Models
{
    public class Locador
    {
        public int LocadorID { get; set; }
        public string NomeLocador { get; set; }
        public string DataNascimentoLocador { get; set; }
        public string CpfLocador { get; set; }
        public string EmailLocador { get; set; }
        public string SenhaLocador { get; set; }
    }
}