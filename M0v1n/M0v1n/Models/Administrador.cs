﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M0v1n.Models
{
    public class Administrador
    {
        public int AdministradorID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}