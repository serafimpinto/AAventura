using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAventura.Models
{
    public class PerguntaViewModel
    {
        public PerguntaViewModel(Pergunta p, Zona z, int conquistada)
        {
            this.PerguntaId = p.PerguntaId;
            this.Descricao = p.Descricao;
            this.Hipotese1 = p.Hipoteses.ElementAt(0).Resposta;
            this.Hipotese2 = p.Hipoteses.ElementAt(1).Resposta;
            this.Hipotese3 = p.Hipoteses.ElementAt(2).Resposta;
            this.Hipotese4 = p.Hipoteses.ElementAt(3).Resposta;
            this.Hipotese1Descricao = p.Hipoteses.ElementAt(0).Descricao;
            this.Hipotese2Descricao = p.Hipoteses.ElementAt(1).Descricao;
            this.Hipotese3Descricao = p.Hipoteses.ElementAt(2).Descricao;
            this.Hipotese4Descricao = p.Hipoteses.ElementAt(3).Descricao;
            this.Imagem = p.Path;
            this.AjudaPergunta = p.Ajuda;
            this.ZonaNome = z.Nome;
            this.Conq = conquistada;
        }

        public int PerguntaId { get; set; }
        public int Conq { get; set; }
        public string Descricao { get; set; }
        public string Hipotese1 { get; set; }
        public string Hipotese2 { get; set; }
        public string Hipotese3 { get; set; }
        public string Hipotese4 { get; set; }
        public string Hipotese1Descricao { get; set; }
        public string Hipotese2Descricao { get; set; }
        public string Hipotese3Descricao { get; set; }
        public string Hipotese4Descricao { get; set; }
        public string Imagem { get; set; }
        public string ZonaNome { get; set; }
        public string AjudaPergunta { get; set; }
    }
}