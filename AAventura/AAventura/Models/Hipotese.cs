using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAventura.DAL
{
    public class Hipotese
    {
        public int HipoteseId { get; set; }
        public string Resposta { get; set; }
        public string Descricao { get; set; }
        public virtual Pergunta Pergunta { get; set; }
    }
}