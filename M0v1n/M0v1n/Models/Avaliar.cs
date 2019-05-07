using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace M0v1n.Models
{
    public class Avaliar
    {
        [Key]
        public int AvaliarID { get; set; }
        [DisplayName("De:")]
        public string From { get; set; }
        [Required(ErrorMessage = "Por favor digite o email do profissional")]
        [DisplayName("Para:")]
        public string To { get; set; }

        [DisplayName("Título:")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Por favor digite uma breve descrição")]
        [DisplayName("Descrição:")]
        public string Body { get; set; }

        public int AnuncioID { get; set; }
        public virtual Anuncio anuncio { get; set; }

    }
}