using System.Data.SqlClient;
using ScriptDB.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using UPE_ONS.Model;

namespace UPE_ONS.DAO
{
    public class PotenciaMediaHoraMesDAO
    {
        /// <summary>
        /// A chave é hora;mes;ano concatenados como string. Só existe uma chave para cada elemento.
        /// Exemplo:
        /// hora = 1
        /// mes = 8
        /// ano = 2012
        /// A chave será 1;8;2012
        /// </summary>
        private Dictionary<String, Object> dictionary;

        public PotenciaMediaHoraMesDAO()
        {
            this.dictionary = new Dictionary<String, Object>();
        }

        private bool temPotenciaMediaCalculada(int idParque)
        {
            SqlConnection connection = (SqlConnection)Database.openConnection();
            SqlCommand command = connection.CreateCommand();

            String query = "SELECT count(*) FROM Potencia_Media_Hora_Mes WHERE idParque = " + idParque +
                " AND  ano >= " + (DateTime.Now.Year - 1) + ";";

            command.CommandText = query;

            SqlDataReader reader = command.ExecuteReader();

            Boolean temPotenciaMediaCalculada = false;
            while (reader.Read())
            {
                if (!reader.GetString(0).Equals("0"))
                    temPotenciaMediaCalculada = true;
            }

            reader.Close();
            connection.Close();

            return temPotenciaMediaCalculada;
        }

        public void gerarArquivosPotenciaMedia(ParqueEolico parqueEolico, string caminhoArquivo,
            String intervalo)
        {
            StreamWriter arquivo = new StreamWriter(caminhoArquivo + "\\" + parqueEolico.Nome + ".txt");
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();

                
                for (int mes = 1; mes <= 12; mes++)
                    queryAgregarMesesCalcularMedia(command, parqueEolico, arquivo, mes.ToString(), intervalo);

                arquivo.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                arquivo.Close();
                throw e;
            }
        }

        private static void queryAgregarMesesCalcularMedia(SqlCommand command, ParqueEolico parque, 
            StreamWriter file, String padraoMeses, String intervalo)
        {
            String query = "SELECT count(*), AVG(potenciaMedia), hora FROM parque_eolico_importacao WHERE mes in (" +
                padraoMeses + ") AND idParque = " + parque.Id + " AND minuto = 0 AND ano >= 2012 AND potenciaMedia != '-999' " +
                " AND intervalo = '"+ intervalo +"' GROUP BY  hora;";

            command.CommandText = query;

            SqlDataReader reader = command.ExecuteReader();

            int contadorDeMeses = 1;
            while (reader.Read())
            {
                file.Write(Math.Round(Double.Parse(reader.GetString((int)PotenciaMediaHoraMes.EnumCampos.POTENCIA_MEDIA)), 4).ToString().Replace(",", ".") + " ");
                contadorDeMeses++;
            }
            // Se o contador de meses for menor que 24 é porque está faltando 
            // a média de uma determinada hora do dia, em um determinado mês...
            if (contadorDeMeses < 25)
            {
                throw new Exception("Erro. Desculpe, está faltando importar dados para geração correta do arquivo de potência média...");
            }

            file.WriteLine();
            reader.Close();
        }

        public Dictionary<String, Object> carregarArquivoPotenciaMedia(String path, string nomeParque)
        {
            try
            {
                this.dictionary.Clear();

                string[] lines = File.ReadAllLines(path + "\\" + nomeParque + ".txt");

                int mes = 1;
                foreach (string line in lines)
                {
                    string[] potencia = line.Split(' ');
                    for (int hora = 0; hora < 24; hora++)
                    {
                        dictionary.Add(hora + ";" + mes, potencia[hora]);
                    }
                    mes++;
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("Erro! O processo de previsão foi interrompido. Por favor, calibre o parque " + nomeParque + 
                    " utilizando o modelo Vento Potência.");
            }
            return dictionary;
        }
    }
}