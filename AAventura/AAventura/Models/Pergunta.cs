using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAventura.Models
{
    public class Pergunta
    {
        [Key]
        public int PerguntaId { get; set; }
        public int Dificuldade { get; set; } // 1-Fácil 2-Intermédio 3-Dificil
        public string Descricao { get; set; }
        public string Path { get; set; }
        public string Ajuda { get; set; }
        public string Resposta { get; set; } 
        public float Tempo { get; set; }
        public virtual Zona Zona { get; set; }
        public virtual ICollection<Hipotese> Hipoteses { get; set; }
        [NotMapped]
        public int ZonaId {get; set;}
        [NotMapped]
        public string Ha { get; set; }
        [NotMapped]
        public string Hb { get; set; }
        [NotMapped]
        public string Hc { get; set; }
        [NotMapped]
        public string Hd { get; set; }
        [NotMapped]
        public string imagem { get; set; }
    }
}