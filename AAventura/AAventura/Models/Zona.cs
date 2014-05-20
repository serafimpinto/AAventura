using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AAventura.Models
{
    public class Zona
    {
        [Key]
        public int ZonaId { get; set; }
        public string Nome { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public virtual ICollection<Pergunta> Perguntas { get; set; }
        public virtual ICollection<Aventura> Aventuras { get; set; }

    }
}