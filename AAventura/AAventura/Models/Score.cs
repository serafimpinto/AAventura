using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AAventura.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        public int NrRespostasCertas { get; set; }
        public float Tempo { get; set; }

        public virtual Utilizador Utilizador { get; set; }
    }
}