using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UPE_ONS.Model
{
    public class ParqueEolico
    {
        public int Id { get; private set; }
        public String Nome { get; set; }
        public String SiglaCPTEC { get; set; }
        public String SiglaPrevEOL {get; set;}
        public String SiglaGETOT { get; set; }
        public int NumMaquinas { get; set; }
        public double PotenciaMaxima { get; set; }

        public Calibracao Calibracao { get; set; }
        public Previsao Previsao { get; set; }
        
        public ParqueEolico()
        {
        }

        public ParqueEolico(int id, String nome, String siglaCPTEC, String siglaPrevEOL, String SiglaGETOT, int numMaquinas, 
            double potenciaMaxima, Calibracao calibracao)
        {
            this.Id = id;
            this.Nome = nome;
            this.SiglaCPTEC = siglaCPTEC;
            this.SiglaPrevEOL = siglaPrevEOL;
            this.SiglaGETOT = SiglaGETOT;
            this.NumMaquinas = numMaquinas;
            this.PotenciaMaxima = potenciaMaxima;
            this.Calibracao = calibracao;
        }

        public ParqueEolico(int id, String nome, String siglaCPTEC, String siglaPrevEOL, String SiglaGETOT, int numMaquinas,
            double potenciaMaxima, Previsao previsao)
        {
            this.Id = id;
            this.Nome = nome;
            this.SiglaCPTEC = siglaCPTEC;
            this.SiglaPrevEOL = siglaPrevEOL;
            this.SiglaGETOT = SiglaGETOT;
            this.NumMaquinas = numMaquinas;
            this.PotenciaMaxima = potenciaMaxima;
            this.Previsao = previsao;
        }

        public ParqueEolico(int id, String nome, String siglaCPTEC, String siglaPrevEOL, String SiglaGETOT, int numMaquinas,
            double potenciaMaxima, Calibracao calibracao, Previsao previsao)
        {
            this.Id = id;
            this.Nome = nome;
            this.SiglaCPTEC = siglaCPTEC;
            this.SiglaPrevEOL = siglaPrevEOL;
            this.SiglaGETOT = SiglaGETOT;
            this.NumMaquinas = numMaquinas;
            this.PotenciaMaxima = potenciaMaxima;
            this.Calibracao = calibracao;
            this.Previsao = previsao;
        }

        public ParqueEolico(String nome, String siglaCPTEC, String siglaPrevEOL, int numMaquinas, 
            double potenciaMaxima, Calibracao calibracao)
        {
            this.Nome = nome;
            this.SiglaCPTEC = siglaCPTEC;
            this.SiglaPrevEOL = siglaPrevEOL;
            this.SiglaGETOT = SiglaGETOT;
            this.NumMaquinas = numMaquinas;
            this.PotenciaMaxima = potenciaMaxima;
            this.Calibracao = calibracao;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Nome) &&
                string.IsNullOrEmpty(SiglaCPTEC) &&
                string.IsNullOrEmpty(SiglaPrevEOL) &&
                string.IsNullOrEmpty(SiglaGETOT))
                return false;

            return true;
        }
    }

    public class Calibracao
    {
        public int Id { get; set; }
        public int? FoiCalibrado { get; set; }
        public DateTime? Data { get; set; }
        public String Tipo { get; set; }

        public Calibracao()
        {
        }

        public Calibracao(int? foiCalibrado, DateTime? data, String tipo)
        {
            this.FoiCalibrado = foiCalibrado;
            this.Data = data;
            this.Tipo = tipo;
        }

        public Calibracao(int id, int? foiCalibrado, DateTime? data, String tipo)
        {
            this.Id = id;
            this.FoiCalibrado = foiCalibrado;
            this.Data = data;
            this.Tipo = tipo;
        }
    }

    public class Previsao
    {
        public int Id { get; set; }
        public int? FoiPrevisto { get; set; }
        public DateTime? Data { get; set; }
        public String Tipo { get; set; }

        public Previsao()
        {
        }

        public Previsao(int? foiPrevisto, DateTime? data, String tipo)
        {
            this.FoiPrevisto = foiPrevisto;
            this.Data = data;
            this.Tipo = tipo;
        }

        public Previsao(int id, int? foiPrevisto, DateTime? data, String tipo)
        {
            this.Id = id;
            this.FoiPrevisto = foiPrevisto;
            this.Data = data;
            this.Tipo = tipo;
        }
    }
}
