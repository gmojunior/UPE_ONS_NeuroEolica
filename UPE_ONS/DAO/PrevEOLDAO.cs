using System.Data.SqlClient;
using ScriptDB.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using UPE_ONS.Model;

namespace UPE_ONS.DAO
{
    public class PrevEOLDAO
    {
        public String dia;
        public String mes;
        public String ano;
        public String hora;
        public String minuto;
        public String segundo;
        public String nMaqMedia;
        public String nMaqDesv_Pad;
        public String nMaqMinimo;
        public String nMaqMaximo;
        public String nMaqN_Validos;
        public String PotenciaMedia;
        public String PotenciaDesv_Pad;
        public String PotenciaMinimo;
        public String PotenciaMaximo;
        public String PotenciaN_Validos;
        public String VelocidadeMedia;
        public String VelocidadeDesv_Pad;
        public String VelocidadeMinimo;
        public String VelocidadeMaximo;
        public String VelocidadeN_Validos;
        public String TemperaturaMedia;
        public String TemperaturaDesv_Pad;
        public String TemperaturaMinimo;
        public String TemperaturaMaximo;
        public String TemperaturaN_Validos;
        public String PressaoMedia;
        public String PressaoDesv_Pad;
        public String PressaoMinimo;
        public String PressaoMaximo;
        public String PressaoN_Validos;
        public String DirecaoMedia;
        public String DirecaoDesv_Pad;
        public String DirecaoMinimo;
        public String DirecaoMaximo;
        public String DirecaoN_Validos;

        public void importarArquivoPrevEOL(String path, int parqueEolico, String intervalo)
        {
            string[] lines = File.ReadAllLines(path);

            SqlConnection connection = (SqlConnection)Database.openConnection();

            SqlCommand command = connection.CreateCommand();
            SqlTransaction myTrans = connection.BeginTransaction();
            command.Transaction = myTrans;

            try
            {
                foreach (string line in lines)
                {
                    String[] fields = line.Split(';');

                    this.ExtractFields(fields);

                    this.RoundHour59MinTo00();

                    String insert = "INSERT INTO parque_eolico_importacao(idParque, dia, mes, ano, hora, minuto, segundo, nMaqMedia, " +
                    "nMaqDesv_Pad, nMaqMinimo, nMaqMaximo, nMaqN_Validos, PotenciaMedia, PotenciaDesv_Pad, PotenciaMinimo, " +
                    "PotenciaMaximo, PotenciaN_Validos, VelocidadeMedia, VelocidadeDesv_Pad, VelocidadeMinimo, VelocidadeMaximo, " +
                    "VelocidadeN_Validos, TemperaturaMedia, TemperaturaDesv_Pad, TemperaturaMinimo, TemperaturaMaximo, " +
                    "TemperaturaN_Validos, PressaoMedia, PressaoDesv_Pad, PressaoMinimo, PressaoMaximo, PressaoN_Validos, " +
                    "DirecaoMedia, DirecaoDesv_Pad, DirecaoMinimo, DirecaoMaximo, DirecaoN_Validos, intervalo) VALUES(" + parqueEolico + ", " + dia + "," + mes
                        + "," + ano + "," + hora + "," + minuto + "," + segundo + "," + nMaqMedia + "," + nMaqDesv_Pad + "," + nMaqMinimo + "," + nMaqMaximo + "," + nMaqN_Validos + "," +
                        PotenciaMedia + "," + PotenciaDesv_Pad + "," + PotenciaMinimo + "," + PotenciaMaximo + "," + PotenciaN_Validos + "," + VelocidadeMedia + "," +
                        VelocidadeDesv_Pad + "," + VelocidadeMinimo + "," + VelocidadeMaximo + "," + VelocidadeN_Validos + "," + TemperaturaMedia + "," +
                        TemperaturaDesv_Pad + "," + TemperaturaMinimo + "," + TemperaturaMaximo + "," + TemperaturaN_Validos + "," + PressaoMedia + "," +
                        PressaoDesv_Pad + "," + PressaoMinimo + "," + PressaoMaximo + "," + PressaoN_Validos + "," + DirecaoMedia + "," + DirecaoDesv_Pad + "," +
                        DirecaoMinimo + "," + DirecaoMaximo + "," + DirecaoN_Validos + " , '" + intervalo + "' )";

                    command.CommandText = insert;

                    command.ExecuteNonQuery();
                }
                myTrans.Commit();
            }
            catch (Exception e)
            {
                myTrans.Rollback();

            }
            connection.Close();
        }

        public List<ParqueEolicoImportacaoPrevEOL> GetList(ParqueEolico parqueEolico, 
            DateTime dataInicial, DateTime dataFinal, String intervalo)
        {
            SqlConnection connection = (SqlConnection)Database.openConnection();
            SqlCommand command = connection.CreateCommand();

            List<ParqueEolicoImportacaoPrevEOL> listaCompleta = new List<ParqueEolicoImportacaoPrevEOL>();


            List<ParqueEolicoImportacaoPrevEOL> listaMesAtual = new List<ParqueEolicoImportacaoPrevEOL>();
            /*
            command.CommandText = "SELECT dia, mes, ano, hora, minuto, segundo, velocidademedia," +
                "direcaomedia, PotenciaMedia FROM parque_eolico_importacao WHERE idParque = " + parqueEolico.Id +
                " AND CONVERT(DATETIME,(CONCAT(ano,'-',mes,'-',dia)),102) >= '" + String.Format("{0:yyyy-M-d}", dataInicial) + "' " +
                " AND CONVERT(DATETIME,(CONCAT(ano,'-',mes,'-',dia)),102) <= '" + String.Format("{0:yyyy-M-d}", dataFinal) + "' " +
                " AND intervalo = '" + intervalo + "'"
                +" ORDER BY ano, mes, dia, hora, minuto LIMIT 18000;" ;// Tamanho máximo de instâncias para o treinamento
            */
            command.CommandText = "SELECT TOP 18000 dia, mes, ano, hora, minuto, segundo, velocidademedia," +
                "direcaomedia, PotenciaMedia FROM parque_eolico_importacao WHERE idParque = " + parqueEolico.Id +
                " AND CONVERT(DATETIME,(CONCAT(ano,'-',mes,'-',dia)),102) >= '" + String.Format("{0:yyyy-M-d}", dataInicial) + "' " +
                " AND CONVERT(DATETIME,(CONCAT(ano,'-',mes,'-',dia)),102) <= '" + String.Format("{0:yyyy-M-d}", dataFinal) + "' " +
                " AND intervalo = '" + intervalo + "'"
                + " ORDER BY ano, mes, dia, hora, minuto;";// Tamanho máximo de instâncias para o treinamento

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                listaMesAtual.Add(new ParqueEolicoImportacaoPrevEOL(reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIA),
                    reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.MES), reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.ANO),
                    reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.HORA), reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.MINUTO),
                    reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.SEGUNDO),
                    Double.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.VELOCIDADE_MEDIA).Replace(".", ",")),
                    Double.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIRECAO_MEDIA).Replace(".", ",")),
                    Double.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.POTENCIA).Replace(".", ","))));
            }
            reader.Close();

            //listaCompleta.AddRange(ajustarTamanhoLista(listaMesAtual, 1200));
            listaCompleta.AddRange(listaMesAtual);

            connection.Close();

            return listaCompleta;
        }

        private List<ParqueEolicoImportacaoPrevEOL> ajustarTamanhoLista(List<ParqueEolicoImportacaoPrevEOL> lista, int maxRegistrosPorMes)
        {
            Random randon = new Random();
            while (lista.Count > maxRegistrosPorMes)
            {
                int randonIndex = (randon.Next(0, lista.Count - 1));
                lista.RemoveAt(randonIndex);
            }
            return lista;
        }

        public void ExtractFields(String[] fields)
        {
            dia = fields[0];
            mes = fields[1];
            ano = fields[2];
            hora = fields[3];
            minuto = fields[4];
            segundo = fields[5];
            nMaqMedia = fields[6];
            nMaqDesv_Pad = fields[7];
            nMaqMinimo = fields[8];
            nMaqMaximo = fields[9];
            nMaqN_Validos = fields[10];
            PotenciaMedia = fields[11];
            PotenciaDesv_Pad = fields[12];
            PotenciaMinimo = fields[13];
            PotenciaMaximo = fields[14];
            PotenciaN_Validos = fields[15];
            VelocidadeMedia = fields[16];
            VelocidadeDesv_Pad = fields[17];
            VelocidadeMinimo = fields[18];
            VelocidadeMaximo = fields[19];
            VelocidadeN_Validos = fields[20];
            TemperaturaMedia = fields[21];
            TemperaturaDesv_Pad = fields[22];
            TemperaturaMinimo = fields[23];
            TemperaturaMaximo = fields[24];
            TemperaturaN_Validos = fields[25];
            PressaoMedia = fields[26];
            PressaoDesv_Pad = fields[27];
            PressaoMinimo = fields[28];
            PressaoMaximo = fields[29];
            PressaoN_Validos = fields[30];
            DirecaoMedia = fields[31];
            DirecaoDesv_Pad = fields[32];
            DirecaoMinimo = fields[33];
            DirecaoMaximo = fields[34];
            DirecaoN_Validos = fields[35];
        }

        /// <summary>
        /// Esse arredondamento é feito para auxiliar no processo de join entre a tabela relativa a
        /// 30 minutos do prevEOL e a tabela com os dados do CPTEC para geração do arquivo de treinamento para
        /// a rede Velocidade x Direção.
        /// </summary>
        public void RoundHour59MinTo00()
        {
            if (minuto.Equals("59"))
            {
                minuto = "00";
                if (hora.Equals("23"))
                {
                    hora = "00";

                    DateTime dateTime = new DateTime(Int16.Parse(ano), Int16.Parse(mes), Int16.Parse(dia));
                    dateTime = dateTime.AddDays(1);

                    dia = dateTime.Day.ToString();
                    mes = dateTime.Month.ToString();
                    ano = dateTime.Year.ToString();
                }
                else
                {
                    hora = (Int16.Parse(hora) + 1).ToString();
                }
            }
        }

        public List<ParqueEolicoImportacaoPrevEOL> getDadosImportados(int idParqueEolico, int limite, 
            bool verTodosOsAtributos, string intervalo)
        {
            List<ParqueEolicoImportacaoPrevEOL> listaCompleta = new List<ParqueEolicoImportacaoPrevEOL>();
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();

                if (verTodosOsAtributos)
                    command.CommandText = "SELECT dia, mes, ano, hora, minuto, segundo, velocidademedia," +
                        "direcaomedia, PotenciaMedia, nMaqMedia, nMaqDesv_Pad, nMaqMinimo, nMaqMaximo, nMaqN_Validos,  " +
                        "PotenciaDesv_Pad, PotenciaMinimo, PotenciaMaximo, PotenciaN_Validos, " + 
                        " VelocidadeDesv_Pad, VelocidadeMinimo, VelocidadeMaximo, VelocidadeN_Validos, " +
                        "TemperaturaMedia, TemperaturaMaximo, TemperaturaMinimo, TemperaturaDesv_Pad, TemperaturaN_Validos, " +
                        "PressaoMedia, PressaoMaximo, PressaoMinimo, PressaoDesv_Pad, PressaoN_Validos," +
                        "DirecaoDesv_Pad, DirecaoMinimo, DirecaoMaximo, DirecaoN_Validos FROM parque_eolico_importacao WHERE idParque = " + idParqueEolico +
                        " AND intervalo = '" + intervalo + "'ORDER BY ano DESC, mes DESC, dia DESC, hora DESC, minuto DESC SET ROWCOUNT " + limite + ";";
                else
                    command.CommandText = "SELECT dia, mes, ano, hora, minuto, segundo, velocidademedia," +
                        "direcaomedia, PotenciaMedia FROM parque_eolico_importacao WHERE idParque = " + idParqueEolico +
                        " AND intervalo = '" + intervalo + "' ORDER BY ano DESC, mes DESC, dia DESC, hora DESC, minuto DESC SET ROWCOUNT " + limite + ";";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (verTodosOsAtributos)
                        listaCompleta.Add(new ParqueEolicoImportacaoPrevEOL(reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIA),
                                reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.MES),
                                reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.ANO),
                                reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.HORA),
                                reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.MINUTO),
                                reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.SEGUNDO),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.VELOCIDADE_MEDIA).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIRECAO_MEDIA).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.POTENCIA).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.NUM_MAQ_MED).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.NUM_MAQ_DESV_P).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.NUM_MAQ_MIN).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.NUM_MAQ_MAX).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.NUM_MAQ_VAL).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.POTENCIA_DESV_P).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.POTENCIA_MIN).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.POTENCIA_MAX).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.POTENCIA_VAL).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.VELOCIDADE_DESV_P).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.VELOCIDADE_MIN).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.VELOCIDADE_MAX).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.VELOCIDADE_VAL).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.TEMPERATURA_MED).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.TEMPERATURA_MAX).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.TEMPERATURA_MIN).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.TEMPERATURA_DESV_P).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.TEMPERATURA_VAL).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.PRESSAO_MEDIA).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.PRESSAO_MAX).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.PRESSAO_MIN).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.PRESSAO_DESV_P).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.PRESSAO_VAL).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIRECAO_DESV_P).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIRECAO_MIN).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIRECAO_MAX).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIRECAO_VAL).Replace(".", ","))));
                    else
                        listaCompleta.Add(new ParqueEolicoImportacaoPrevEOL(reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIA),
                                reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.MES), reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.ANO),
                                reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.HORA), reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.MINUTO),
                                reader.GetInt32((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.SEGUNDO),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.VELOCIDADE_MEDIA).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.DIRECAO_MEDIA).Replace(".", ",")),
                                float.Parse(reader.GetString((int)ParqueEolicoImportacaoPrevEOL.EnumCampos.POTENCIA).Replace(".", ","))));
                }
                reader.Close();

                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return listaCompleta;
        }
    }
}