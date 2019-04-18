namespace M0v1n.Migrations
{
    using M0v1n.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<M0v1n.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(M0v1n.Models.Context context)
        {
            IList<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario() { NomeUsuario = "Dumb", DataNascimentoUsuario = "01/02/1998", CpfUsuario = "12345678900", EmailUsuario = "dumb@email.com", SenhaUsuario = "123" });
            usuarios.Add(new Usuario() { NomeUsuario = "Dumber", DataNascimentoUsuario = "02/03/1999", CpfUsuario = "12345678901", EmailUsuario = "dumb3r@email.com", SenhaUsuario = "456" });

            foreach (Usuario usuario in usuarios)
            {
                context.Usuarios.AddOrUpdate(x => x.UsuarioID, usuario);
            }

            IList<Locador> locadors = new List<Locador>();
            locadors.Add(new Locador() { NomeLocador = "Ventura", DataNascimentoLocador = "03/04/1991", CpfLocador = "12345678902", EmailLocador = "ventura@email.com", SenhaLocador = "789" });
            locadors.Add(new Locador() { NomeLocador = "Fletcher", DataNascimentoLocador = "05/06/1992", CpfLocador = "12345678903", EmailLocador = "reede@email.com", SenhaLocador = "1011" });

            foreach (Locador locador in locadors)
            {
                context.Locadores.AddOrUpdate(x => x.LocadorID, locador);
            }

            IList<Cliente> clientes = new List<Cliente>();
            clientes.Add(new Cliente() { Email = "krystian@email.com", Senha = "1234" });
            clientes.Add(new Cliente() { Email = "ronidigital@hotmail.com", Senha = "5340" });

            foreach (Cliente cliente in clientes)
            {
                context.Clientes.AddOrUpdate(x => x.ClienteID, cliente);
            }
        }
    }
}
