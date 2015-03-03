using System.Data.SqlClient;
using ScriptDB.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using UPE_ONS.Model;

namespace UPE_ONS.DAO
{
    public class CPTECDAO
    {
        #region Attributes

        private String dia, mes, ano, longitude, latitude;

        // São 24 valores porque cada valor é referente a uma hora do dia.
        private List<string> velocidades = new List<string>(24);
        private List<string> direcoes = new List<string>(24);

        #endregion

        public void criarCorpoArquivo(StreamWriter file, SqlDataReader reader, Dictionary<String, Object> dic)
        {
            int hora;
            String key = "";
            try
            {
                while (reader.Read())
                {
                    dia = reader.GetString(1);
                    mes = reader.GetString(2);
                    ano = reader.GetString(3);
                    hora = Int16.Parse(reader.GetString(4));

                    key = hora + ";" + mes;
                    String linha = //dia + " " + mes + " " + ano + " " + hora + " " +
                                    Math.Round(Math.Sin(2 * 3.141516 * (double)hora / 24), 3).ToString().Replace(",", ".") + " " +
                                    Math.Round(Math.Cos(2 * 3.141516 * (double)hora / 24), 3).ToString().Replace(",", ".") + " " +
                                    Math.Round(Math.Sin(2 * 3.141516 * (Double.Parse(reader.GetString(hora + 5 + 24).Replace(".", ",")) / 180)), 3).ToString().Replace(",", ".") + " " +
                                    Math.Round(Math.Cos(2 * 3.141516 * (Double.Parse(reader.GetString(hora + 5 + 24).Replace(".", ",")) / 180)), 3).ToString().Replace(",", ".") + " " +
                                    (dic[key]) + " " +
                                    reader.GetString(hora + 5) + " " +
                                    reader.GetString(0);
                    if (!linha.Contains("-999"))
                        file.WriteLine(linha);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro! " + key + "#");
            }
        }

        public void criarCabecalhoArquivo(StreamWriter file)
        {
            file.WriteLine("dia;mes;ano;hora;sen(2PIn/T);Cos(2PIn/T);sen(2PId/180);cos(2PId/180);PotenciaMedia;Velocidade;Pontencia;");
        }

        public void setVelocities(string[] array, int start, int end)
        {
            this.velocidades.Clear();
            for (int i = start; i <= end; i++)
                this.velocidades.Add(array[i]);
        }

        public void setDirections(string[] array, int start, int end)
        {
            this.direcoes.Clear();
            for (int i = start; i <= end; i++)
                this.direcoes.Add(array[i]);
        }

        public void importOldFile(String path, int idParque)
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
                    // Removing 8 spaces
                    String str01 = line.Replace("        ", ";");
                    // Removing 10 spaces
                    String str02 = str01.Replace("          ", ";");
                    String processedLine = str02.Replace("    ", ";").Replace(",", ".");

                    String[] fields = processedLine.Split(';');

                    String data = fields[0];
                    String[] diaMesAno = data.Split('/');

                    dia = diaMesAno[0];
                    mes = diaMesAno[1];
                    ano = diaMesAno[2];

                    longitude = fields[1];
                    latitude = fields[2];

                    if (fields.Length < 243)
                    {
                        command.CommandText = "INSERT INTO velocidadevento(idParque, dia, mes, ano) VALUES (" + idParque + ", " + dia + ", " + mes + ", " + ano + ")";
                        command.ExecuteNonQuery();

                        command.CommandText = "INSERT INTO direcaovento(idParque, dia, mes, ano) VALUES (" + idParque + ", " + dia + ", " + mes + ", " + ano + ")";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        insertVelocities(command, fields, idParque);
                        insertDirections(command, fields, idParque);
                    }
                }
                myTrans.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                myTrans.Rollback();
            }
            connection.Close();
        }

        private void insertVelocities(SqlCommand command, String[] fields, int idParque)
        {
            this.setVelocities(fields, 3, 26);
            this.executarInsertQueryVelocidade(command, 0, idParque);

            this.setVelocities(fields, 27, 50);
            this.executarInsertQueryVelocidade(command, 1, idParque);
            
            this.setVelocities(fields, 51, 74);
            this.executarInsertQueryVelocidade(command, 2, idParque);

            this.setVelocities(fields, 75, 98);
            this.executarInsertQueryVelocidade(command, 3, idParque);

            this.setVelocities(fields, 99, 122);
            this.executarInsertQueryVelocidade(command, 4, idParque);
        }

        private void executarInsertQueryVelocidade(SqlCommand command, int diaPrevisto, int idParque)
        {
            command.CommandText = "INSERT INTO velocidadevento(idParque, dia, mes, ano, diaPrevisto, velocidade00, velocidade01, " +
            "velocidade02, velocidade03, velocidade04, velocidade05, velocidade06, velocidade07, velocidade08," +
            "velocidade09, velocidade10, velocidade11, velocidade12, velocidade13, velocidade14, velocidade15," +
            "velocidade16, velocidade17, velocidade18, velocidade19, velocidade20, velocidade21, velocidade22, " +
            "velocidade23) VALUES(" + idParque + ", " + dia + ", " + mes + "," + ano + ", " + diaPrevisto + ", " +
            velocidades[0] + ", " + velocidades[1] + ", " + velocidades[2] + ", " + velocidades[3] + ", " + velocidades[4] + ", " +
            velocidades[5] + ", " + velocidades[6] + ", " + velocidades[7] + ", " + velocidades[8] + ", " + velocidades[9] + ", " +
            velocidades[10] + ", " + velocidades[11] + ", " + velocidades[12] + ", " + velocidades[13] + ", " + velocidades[14] + ", " +
            velocidades[15] + ", " + velocidades[16] + ", " + velocidades[17] + ", " + velocidades[18] + ", " + velocidades[19] + ", " +
            velocidades[20] + ", " + velocidades[21] + ", " + velocidades[22] + ", " + velocidades[23] + ")";

            command.ExecuteNonQuery();
        }

        private void insertDirections(SqlCommand command, String[] fields, int idParque)
        {
            this.setDirections(fields, 123, 146);
            this.executarInsertQueryDirecao(command, 0, idParque);

            this.setDirections(fields, 147, 170);
            this.executarInsertQueryDirecao(command, 1, idParque);

            this.setDirections(fields, 171, 194);
            this.executarInsertQueryDirecao(command, 2, idParque);

            this.setDirections(fields, 195, 218);
            this.executarInsertQueryDirecao(command, 3, idParque);

            this.setDirections(fields, 219, 242);
            this.executarInsertQueryDirecao(command, 4, idParque);
        }

        private void executarInsertQueryDirecao(SqlCommand command, int diaPrevisto, int idParque)
        {
            command.CommandText = "INSERT INTO direcaovento(idParque, dia, mes, ano, diaPrevisto, direcao00, direcao01, " +
                                            "direcao02, direcao03, direcao04, direcao05, direcao06, direcao07, direcao08," +
                                            "direcao09, direcao10, direcao11, direcao12, direcao13, direcao14, direcao15," +
                                            "direcao16, direcao17, direcao18, direcao19, direcao20, direcao21, direcao22, " +
                                            "direcao23) VALUES(" + idParque + ", " + dia + ", " + mes + "," + ano + ", " +
            diaPrevisto + ", " + direcoes[0] + ", " + direcoes[1] + ", " + direcoes[2] + ", " +
            direcoes[3] + ", " + direcoes[4] + ", " + direcoes[5] + ", " + direcoes[6] + ", " + direcoes[7] + ", " + direcoes[8]
            + ", " + direcoes[9] + ", " + direcoes[10] + ", " + direcoes[11] + ", " + direcoes[12] + ", " + direcoes[13] + ", " + direcoes[14]
            + ", " + direcoes[15] + ", " + direcoes[16] + ", " + direcoes[17] + ", " + direcoes[18] + ", " + direcoes[19] + ", " +
            direcoes[20] + ", " + direcoes[21] + ", " + direcoes[22] + ", " + direcoes[23] + ")";

            command.ExecuteNonQuery();
        }

        public void gerarArquivoTreinamentoVentoPotencia(ParqueEolico parqueEolico, string caminhoArquivo, string caminhoPotenciaMedia,
            DateTime dataInicial, DateTime dataFinal, String intervalo)
        {
            SqlConnection connection = (SqlConnection)Database.openConnection();
            SqlCommand command = connection.CreateCommand();
            //command.CommandTimeout = 120;
            try
            {
                Dictionary<String, Object> dicPotenciaMedia = FactoryDAO.getInstance().PotenciaMediaHoraMesDAO.
                    carregarArquivoPotenciaMedia(caminhoPotenciaMedia, parqueEolico.Nome);

                for (int diaPrevisto = 0; diaPrevisto < 5; diaPrevisto++)
                    this.montarArquivoVentoPotencia(command, dicPotenciaMedia, diaPrevisto, parqueEolico, caminhoArquivo,
                        dataInicial, dataFinal, intervalo);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
            connection.Close(); ;
        }

        private void montarArquivoVentoPotencia(SqlCommand command, Dictionary<String, Object> dic, int diaPrevisto,
            ParqueEolico parqueEolico, string caminhoArquivo, DateTime dataInicial, DateTime dataFinal, String intervalo)
        {
            StreamWriter file = null;
            try
            {
                String fileName = caminhoArquivo + "NEURO_EOLICA_ENTRADAS_0" + (diaPrevisto + 1) + ".txt";

                command.CommandText = "SELECT parque.potenciaMedia, parque.dia, parque.mes, parque.ano, parque.hora, v.velocidade00 , v.velocidade01," +
                        "v.velocidade02, v.velocidade03, v.velocidade04, v.velocidade05, v.velocidade06, v.velocidade07, " +
                        "v.velocidade08, v.velocidade09, v.velocidade10, v.velocidade11, v.velocidade12, v.velocidade13, " +
                        "v.velocidade14, v.velocidade15, v.velocidade16, v.velocidade17, v.velocidade18, v.velocidade19, " +
                        "v.velocidade20, v.velocidade21, v.velocidade22, v.velocidade23, d.direcao00 , d.direcao01, d.direcao02, " +
                        "d.direcao03, d.direcao04, d.direcao05, d.direcao06, d.direcao07, d.direcao08, d.direcao09, d.direcao10, " +
                        "d.direcao11, d.direcao12, d.direcao13, d.direcao14, d.direcao15, d.direcao16, d.direcao17, d.direcao18, " +
                        "d.direcao19, d.direcao20, d.direcao21, d.direcao22, d.direcao23 " +
                        "FROM velocidadevento v, direcaovento d, parque_eolico_importacao parque " +
                        "WHERE v.diaPrevisto = " + diaPrevisto + " AND d.diaPrevisto = " + diaPrevisto +
                        " AND v.idParque = " + parqueEolico.Id + " AND d.idParque = " + parqueEolico.Id + " and parque.idParque = " + parqueEolico.Id +
                        " AND str_to_date(CONCAT(v.ano,'-',v.mes,'-',v.dia),'%Y-%m-%d')  = str_to_date(CONCAT(d.ano,'-',d.mes,'-',d.dia),'%Y-%m-%d')" +
                        " AND str_to_date(CONCAT(v.ano,'-',v.mes,'-',v.dia),'%Y-%m-%d')  = str_to_date(CONCAT(parque.ano,'-',parque.mes,'-',parque.dia),'%Y-%m-%d')" +
                        " AND str_to_date(CONCAT(v.ano,'-',v.mes,'-',v.dia),'%Y-%m-%d') >= '" + String.Format("{0:yyyy-M-d}", dataInicial) + "' " +
                        " AND str_to_date(CONCAT(v.ano,'-',v.mes,'-',v.dia),'%Y-%m-%d') <= '" + String.Format("{0:yyyy-M-d}", dataFinal) + "' " +
                        " AND parque.minuto = 00 AND parque.intervalo = '" + intervalo + "';";

              SqlDataReader reader = command.ExecuteReader();

                file = new StreamWriter(fileName);

                //this.criarCabecalhoArquivo(file);
                this.criarCorpoArquivo(file, reader, dic);

                reader.Close();
                file.Close();
            }
            catch (Exception e)
            {
                file.Close();
                Console.WriteLine(e.Message);
            }
        }
         
        public void importarArquivoNovo(string fileFullPath, int idParque)
        {
             SqlConnection connection = (SqlConnection)Database.openConnection();

            SqlCommand command = connection.CreateCommand();
            SqlTransaction myTrans = connection.BeginTransaction();
            command.Transaction = myTrans;
            try
            {
                StreamReader file = new StreamReader(fileFullPath);
                // 240 valores a serem lidos e armazenados no banco.
                // 120 de velocidade correspondente aos 5 dias
                // 120 de direção correspondente aos 5 dias
                int qtdValoresVelocidadeMaisDirecao = 240;
                string[] fields = new string[qtdValoresVelocidadeMaisDirecao + 3];

                int numLinhas = 120, colunaVelocidade = 4, colunaDirecao = 5;
                for (int i = 0; i < numLinhas; i++)
                {
                    string line = file.ReadLine();
                    string linePreProcessed = line.Replace("     ", ";").Replace("/", ";");
                    string[] lineProcessed = linePreProcessed.Split(';');

                    string date = lineProcessed[0];
                    ano = (date.Substring(0, 4));
                    mes = (date.Substring(4, 2));
                    dia = (date.Substring(6, 2));

                    string velocidade = lineProcessed[colunaVelocidade];
                    fields[i + 3] = velocidade;

                    string direcao = lineProcessed[colunaDirecao];
                    fields[i + 3 + numLinhas] = direcao;
                }
                insertVelocities(command, fields, idParque);
                insertDirections(command, fields, idParque);

                myTrans.Commit();

                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                myTrans.Rollback();
            }
            connection.Close();
        }

        public List<ParqueEolicoImportacaoCPTEC> SelectDataImported(int idParqueEolico, int limit)
        {
            List<ParqueEolicoImportacaoCPTEC> ret = new List<ParqueEolicoImportacaoCPTEC>();
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT dv.dia, dv.mes, dv.ano, dv.diaPrevisto, direcao00, direcao01, "+
                    "direcao02, direcao03, direcao04, direcao05, direcao06, direcao07, direcao08, " +
                    "direcao09, direcao10, direcao11, direcao12, direcao13, direcao14, direcao15, " +
                    "direcao16, direcao17, direcao18, direcao19, direcao20, direcao21, " +
                    "direcao22, direcao23, "+
                    "velocidade00, velocidade01, velocidade02, velocidade03,  velocidade04, velocidade05, " +
                    "velocidade06, velocidade07, velocidade08, velocidade09, velocidade10, velocidade11, " +
                    "velocidade12, velocidade13, velocidade14, velocidade15, " +
                    "velocidade16, velocidade17, velocidade18, velocidade19, " +
                    "velocidade20, velocidade21, velocidade22, velocidade23 " +
                    "FROM direcaovento dv, velocidadevento vv, parque p " +
                    "WHERE p.id = " + idParqueEolico + " AND p.id = dv.idParque AND p.id = vv.idParque AND dv.idParque = vv.idParque AND "+
                    "dv.diaPrevisto = vv.diaPrevisto AND dv.dia = vv.dia AND dv.mes = vv.mes AND  dv.ano = vv.ano  " +
                    " ORDER BY dv.ano DESC, dv.mes DESC, dv.dia DESC, dv.diaPrevisto SET ROWCOUNT " + limit;
                
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    List<string> direcoes = new List<string>(24);
                    for(int i = 4; i < 4+24; i++)
                        direcoes.Add(reader.GetString(i));

                    List<string> velocidades = new List<string>(24);
                    for(int i = 28; i < 28+24; i++)
                        velocidades.Add(reader.GetString(i));

                    ret.Add(new ParqueEolicoImportacaoCPTEC(reader.GetInt32(0).ToString(), reader.GetInt32(1).ToString(),
                        reader.GetInt32(2).ToString(), reader.GetInt32(3), velocidades, direcoes));
                }

                reader.Close();

                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }
    }
}