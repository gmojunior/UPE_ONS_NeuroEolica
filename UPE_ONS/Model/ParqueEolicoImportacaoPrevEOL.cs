using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPE_ONS.Model
{
    public class ParqueEolicoImportacaoPrevEOL
    {
        public enum EnumCampos
        {
            DIA, MES, ANO, HORA, MINUTO, SEGUNDO, VELOCIDADE_MEDIA, DIRECAO_MEDIA, POTENCIA,
            NUM_MAQ_MED, NUM_MAQ_DESV_P, NUM_MAQ_MIN, NUM_MAQ_MAX, NUM_MAQ_VAL,
            POTENCIA_DESV_P, POTENCIA_MIN, POTENCIA_MAX, POTENCIA_VAL,
            VELOCIDADE_DESV_P, VELOCIDADE_MIN, VELOCIDADE_MAX, VELOCIDADE_VAL,
            TEMPERATURA_MED, TEMPERATURA_MAX, TEMPERATURA_MIN, TEMPERATURA_DESV_P, TEMPERATURA_VAL,
            PRESSAO_MEDIA, PRESSAO_MAX, PRESSAO_MIN, PRESSAO_DESV_P, PRESSAO_VAL,
            DIRECAO_DESV_P, DIRECAO_MIN, DIRECAO_MAX, DIRECAO_VAL
        }

        // Atributos úteis
        public int Dia { get; internal set; }
        public int Mes { get; internal set; }
        public int Ano { get; internal set; }
        public int Hora { get; internal set; }
        public int Minuto { get; internal set; }
        public int Segundo { get; internal set; }
        public double VelocidadeMedia { get; internal set; }
        public double DirecaoMedia { get; internal set; }
        public double Potencia { get; internal set; }

        // Todos os demais atributos
        public double NumMaquinaMed { get; internal set; }
        public double NumMaquinaDesvP { get; internal set; }
        public double NumMaquinaMin { get; internal set; }
        public double NumMaquinaMax { get; internal set; }
        public double NumMaquinaN_Validos { get; internal set; }

        public double PotenciaDesvP { get; internal set; }
        public double PotenciaMin { get; internal set; }
        public double PotenciaMax { get; internal set; }
        public double PotenciaN_Validos { get; internal set; }

        public double VelocidadeDesvP { get; internal set; }
        public double VelocidadeMin { get; internal set; }
        public double VelocidadeMax { get; internal set; }
        public double VelocidadeN_Validos { get; internal set; }

        public double TemperaturaMedia { get; internal set; }
        public double TemperaturaDesvP { get; internal set; }
        public double TemperaturaMin { get; internal set; }
        public double TemperaturaMax { get; internal set; }
        public double TemperaturaN_Validos { get; internal set; }

        public double PressaoMedia { get; internal set; }
        public double PressaoDesvP { get; internal set; }
        public double PressaoMin { get; internal set; }
        public double PressaoMax { get; internal set; }
        public double PressaoN_Validos { get; internal set; }

        public double DirecaoDesvP { get; internal set; }
        public double DirecaoMin { get; internal set; }
        public double DirecaoMax { get; internal set; }
        public double DirecaoN_Validos { get; internal set; }

        public ParqueEolicoImportacaoPrevEOL()
        {

        }

        public ParqueEolicoImportacaoPrevEOL(int dia, int mes, int ano, int hora, int minuto, int segundo,
            double velocidadeMedia, double direcaoMedia, double potencia)
        {
            this.Dia = dia;
            this.Mes = mes;
            this.Ano = ano;
            this.Hora = hora;
            this.Minuto = minuto;
            this.Segundo = segundo;
            this.VelocidadeMedia = velocidadeMedia;
            this.DirecaoMedia = direcaoMedia;
            this.Potencia = potencia;
        }

        public ParqueEolicoImportacaoPrevEOL(int dia, int mes, int ano, int hora, int minuto, int segundo,
            double velocidadeMedia, double direcaoMedia, double potencia, double NumMaquinaMed, double NumMaquinaDesvP,
            double NumMaquinaMin, double NumMaquinaMax, double NumMaquinaN_Validos, double PotenciaDesvP, double PotenciaMin,
            double PotenciaMax, double PotenciaN_Validos, double VelocidadeDesvP, double VelocidadeMin, double VelocidadeMax,
            double VelocidadeN_Validos, double TemperaturaMedia, double TemperaturaDesvP, double TemperaturaMin, double TemperaturaMax,
            double TemperaturaN_Validos, double PressaoMedia, double PressaoDesvP, double PressaoMin, double PressaoMax,double PressaoN_Validos,
            double DirecaoDesvP, double DirecaoMin, double DirecaoMax, double DirecaoN_Validos)
        {
            this.Dia = dia;
            this.Mes = mes;
            this.Ano = ano;
            this.Hora = hora;
            this.Minuto = minuto;
            this.Segundo = segundo;
            this.VelocidadeMedia = velocidadeMedia;
            this.DirecaoMedia = direcaoMedia;
            this.Potencia = potencia;

            this.NumMaquinaMed = NumMaquinaMed;
            this.NumMaquinaDesvP = NumMaquinaDesvP;
            this.NumMaquinaMin = NumMaquinaMin;
            this.NumMaquinaMax = NumMaquinaMax;
            this.NumMaquinaN_Validos = NumMaquinaN_Validos;

            this.PotenciaDesvP = PotenciaDesvP;
            this.PotenciaMax = PotenciaMax;
            this.PotenciaMin = PotenciaMin;
            this.PotenciaN_Validos = PotenciaN_Validos;

            this.VelocidadeDesvP = VelocidadeDesvP;
            this.VelocidadeMax = VelocidadeMax;
            this.VelocidadeMin = VelocidadeMin;
            this.VelocidadeN_Validos = VelocidadeN_Validos;

            this.TemperaturaDesvP = TemperaturaDesvP;
            this.TemperaturaMax = TemperaturaMax;
            this.TemperaturaMin = TemperaturaMin;
            this.TemperaturaN_Validos = TemperaturaN_Validos;

            this.PressaoN_Validos = PressaoN_Validos;
            this.PressaoMin = PressaoMin;
            this.PressaoMedia = PressaoMedia;
            this.PressaoMax = PressaoMax;
            this.PressaoDesvP = PressaoDesvP;

            this.DirecaoDesvP = DirecaoDesvP;
            this.DirecaoMax = DirecaoMax;
            this.DirecaoMedia = direcaoMedia;
            this.DirecaoMin = DirecaoMin;
            this.DirecaoN_Validos = DirecaoN_Validos;
        }
    }
}
