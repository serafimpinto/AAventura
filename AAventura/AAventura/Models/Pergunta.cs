using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AAventura.Models
{
    public class Pergunta
    {
        [Key]
        public int PerguntaId { get; set; }
        public int Dificuldade { get; set; } // 1-Fácil 2-Intermédio 3-Dificil
        public string Descricao { get; set; }
        public int Tipo { get; set; } //0-Texto 1-Imagem 2-Video
        public string Ajuda { get; set; }
        public string Resposta { get; set; } 
        public float Tempo { get; set; }
        public virtual Zona Zona { get; set; }
        public virtual ICollection<Hipotese> Hipoteses { get; set; }

    }
}