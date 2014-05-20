using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AAventura.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public float Custo { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Aventura> Aventuras { get; set; }

    }
}