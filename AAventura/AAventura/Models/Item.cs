using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAventura.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Path { get; set; }
        public float Custo { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Aventura> Aventuras { get; set; }
        [NotMapped]
        public string imagem { get; set; }
    }
}