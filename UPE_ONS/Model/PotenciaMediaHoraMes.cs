using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPE_ONS.Model
{
    public class PotenciaMediaHoraMes
    {
        public enum EnumCampos
        {
            QTD_DIAS,
            POTENCIA_MEDIA,
            HORA,
            MES,
            ANO,
            DESVIO_PADRAO
        }

        public int QtdDias { get; internal set; }
        public String PontenciaMedia { get; internal set; }
        public int Hora { get; internal set; }
        public int Mes { get; internal set; }
        public int Ano { get; internal set; }

        public String DesvioPadrao { get; internal set; }
        private double DesvioPadraoSomatorioParcial { get; set; }        
        
        public PotenciaMediaHoraMes()
        {

        }

        public PotenciaMediaHoraMes(int qtdDias, String potenciaMedia, int hora, int mes, int ano, String desvioPadrao)
        {
            this.QtdDias = qtdDias;
            this.PontenciaMedia = potenciaMedia;
            this.Hora = hora;
            this.Mes = mes;
            this.Ano = ano;
            this.DesvioPadrao = desvioPadrao;
        }

        public void processarDesvioPadraoPotenciaSomatorioParcial(String potencia)
        {
            this.DesvioPadraoSomatorioParcial += Math.Pow((Double.Parse(potencia.Replace(".",",")) 
                - Double.Parse(PontenciaMedia.Replace(".",","))), 2);
        }

        public void calcularDesvioPadrao()
        {
            this.DesvioPadrao = Math.Round(Math.Sqrt(DesvioPadraoSomatorioParcial / QtdDias - 1), 4).ToString();
        }
    }
}
