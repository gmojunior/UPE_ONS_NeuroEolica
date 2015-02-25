using System;
using UPE_ONS.Util;
namespace UPE_ONS.Model
{
    public class EntradaVentoPotencia
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Hora { get; set; }
        public string Velocidade { get; set; }
        public string Direcao { get; set; }
        public string PotenciaMedia { get; set; }

        public ParqueEolico ParqueEolico { get; set; }

        public EntradaVentoPotencia(ParqueEolico parque, int dia, int mes, int ano, int hora, string velocidade,
            string direcao, string potenciaMedia)
        {
            this.ParqueEolico = parque;

            this.Dia = dia;
            this.Mes = mes;
            this.Ano = ano;
            this.Hora = hora;
            this.Velocidade = velocidade;
            this.Direcao = direcao;
            this.PotenciaMedia = potenciaMedia;
        }

        public double GetSenHora()
        {
            return Math.Round(Math.Sin(2 * Constants.PI * ((double)Hora/24)), 3);
        }

        public double GetCosHora()
        {
            return Math.Round(Math.Cos(2 * Constants.PI * ((double)Hora / 24)), 3);
        }

        public double GetSenDirecao()
        {
            return Math.Round(Math.Sin(2 * Constants.PI * (Double.Parse(Direcao.Replace('.', ',')) / 180)), 3);
        }

        public double GetCosDirecao()
        {
            return Math.Round(Math.Cos(2 * Constants.PI * (Double.Parse(Direcao.Replace('.', ',')) / 180)), 3);
        }
    }
}