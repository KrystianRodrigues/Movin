using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M0v1n.Models
{
    public class Anuncio
  
    {
        public int AnuncioID { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public string Genero { get; set; }
        public string Cidade { get; set; }
    }
}