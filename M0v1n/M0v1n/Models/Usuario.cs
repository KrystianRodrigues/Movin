using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M0v1n.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string nomeUsuario { get; set; }
        public string dataNascimentoUsuario { get; set; }
        public string cpfUsuario { get; set; }
        public string emailUsuario { get; set; }
        public string senhaUsuario { get; set; }
    }
}