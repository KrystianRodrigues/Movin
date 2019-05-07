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
        public int QuartoSolteiro { get; set; }
        public int QuartoCasal { get; set; }
        public int QuartoComunitario { get; set; }
        public int QtdCama { get; set; }
        public int QtdBanheiro { get; set; }
        public int NumHospedes { get; set; }
        public decimal ValorDiaria { get; set; }

        //Endereço
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public string Foto1 { get; set; }
        public string Foto2 { get; set; }

        //Detalhes da acomodação
        public bool ArCondicionado { get; set; }
        public bool Ventilador { get; set; }
        public bool Banheira { get; set; }
        public bool Internet { get; set; }
        public bool TvCabo { get; set; }
        public bool Animais { get; set; }
        public bool Fumante { get; set; }
        public bool Ativo { get; set; } = true;

        public string Problemas { get; set; }

        public int LocadorID { get; set; }
        public virtual Locador Locador { get; set; }

        public virtual ICollection<Avaliar> Avalicoes { get; set; }
    }
}