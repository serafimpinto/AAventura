using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AAventura.Models
{
    public class Aventura
    {
        [Key]
        public int AventuraId { get; set; }
        public int Moedas { get; set; }
        public int Exploradores { get; set; }
        public int Dificuldade { get; set; }
        public virtual Utilizador Utilizador { get; set; }
        public virtual ICollection<Item> Itens { get; set; }
        public virtual ICollection<Zona> Zonas { get; set; }


    }
}