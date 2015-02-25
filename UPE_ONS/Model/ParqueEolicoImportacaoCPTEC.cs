using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPE_ONS.Model
{
    public class ParqueEolicoImportacaoCPTEC
    {
        public String dia, mes, ano, longitude, latitude;
        public int diaPrevisto;

        // São 24 valores porque cada valor é referente a uma hora do dia.
        public List<string> velocidades = new List<string>(24);
        public List<string> direcoes = new List<string>(24);

        public ParqueEolicoImportacaoCPTEC(string dia, string mes, string ano, int diaPrevisto,
            List<string> vel, List<string> dir)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
            this.diaPrevisto = diaPrevisto;
            this.velocidades = vel;
            this.direcoes = dir;
        }
    }
}
