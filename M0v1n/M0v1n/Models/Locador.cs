using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M0v1n.Models
{
    public class Locador
    {
        public int LocadorID { get; set; }
        public string nomeLocador { get; set; }
        public string dataNascimentoLocador { get; set; }
        public string cpfLocador { get; set; }
        public string emailLocador { get; set; }
        public string senhaLocador { get; set; }
    }
}