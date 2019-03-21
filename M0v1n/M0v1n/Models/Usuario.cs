using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M0v1n.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string NomeUsuario { get; set; }
        public string DataNascimentoUsuario { get; set; }
        public string CpfUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
    }
}