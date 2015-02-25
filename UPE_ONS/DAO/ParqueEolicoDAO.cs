using System.Data.SqlClient;
using ScriptDB.DAO;
using System;
using System.Collections.Generic;
using UPE_ONS.Model;

namespace UPE_ONS.DAO
{
    public class ParqueEolicoDAO
    {
        enum ParqueEolicoAtributos
        {
            ID,
            NOME,
            SIGLA_CPTEC,
            SIGLA_PrevEOL,
            SIGLA_GETOT,
            NUM_MAQUINAS,
            POTENCIA
        }

        public ParqueEolicoDAO()
        {
        }

        public void Insert(ParqueEolico parque)
        {
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO parque (nome, siglaCPTEC, siglaPrevEOL, siglaGETOT, numMaquinas, potenciaMaxima) VALUES (@Nome, @SiglaCPTEC, @SiglaPrevEOL, @SiglaGETOT, @NumMaquinas, @PotenciaMaxima)";
                command.Parameters.AddWithValue("Nome", parque.Nome);
                command.Parameters.AddWithValue("SiglaCPTEC", parque.SiglaCPTEC);
                command.Parameters.AddWithValue("SiglaPrevEOL", parque.SiglaPrevEOL);
                command.Parameters.AddWithValue("SiglaGETOT", parque.SiglaGETOT);
                command.Parameters.AddWithValue("NumMaquinas", parque.NumMaquinas);
                command.Parameters.AddWithValue("PotenciaMaxima", parque.PotenciaMaxima);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(ParqueEolico parque)
        {
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE parque SET nome = @Nome, siglaCPTEC = @SiglaCPTEC, siglaPrevEOL = @SiglaPrevEOL, siglaGETOT = @SiglaGETOT, numMaquinas = @NumMaquinas, " +
                "potenciaMaxima = @PotenciaMaxima WHERE id = @Id";
                command.Parameters.AddWithValue("Id", parque.Id);
                command.Parameters.AddWithValue("Nome", parque.Nome);
                command.Parameters.AddWithValue("SiglaCPTEC", parque.SiglaCPTEC);
                command.Parameters.AddWithValue("SiglaPrevEOL", parque.SiglaPrevEOL);
                command.Parameters.AddWithValue("SiglaGETOT", parque.SiglaGETOT);
                command.Parameters.AddWithValue("NumMaquinas", parque.NumMaquinas);
                command.Parameters.AddWithValue("PotenciaMaxima", parque.PotenciaMaxima);
                int numRowsUpdated = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(ParqueEolico parque)
        {
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM parque WHERE id = @Id";
                command.Parameters.AddWithValue("Id", parque.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(ParqueEolico parque)
        {
            bool ret = false;
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT count(*) FROM parque WHERE (nome = @Nome OR siglaPrevEOL = @SiglaPrevEOL AND siglaCPTEC= @SiglaCPTEC) AND id != @Id;";
                command.Parameters.AddWithValue("Id", parque.Id);
                command.Parameters.AddWithValue("Nome", parque.Nome);
                command.Parameters.AddWithValue("SiglaCPTEC", parque.SiglaCPTEC);
                command.Parameters.AddWithValue("SiglaPrevEOL", parque.SiglaPrevEOL);
                SqlDataReader reader = command.ExecuteReader();
                
                // Corresponde ao count(*)
                reader.Read();
                if (reader.GetInt32(0) > 0)
                    ret = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }

        internal static IEnumerable<ParqueEolico> getParquesCalibrados(string tipo)
        {
            List<ParqueEolico> ret = new List<ParqueEolico>();
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT p.id, p.nome, p.siglaCPTEC, p.siglaPrevEOL, p.siglaGETOT, p.numMaquinas, p.potenciaMaxima, "
                    + " c.foiCalibrado, c.data FROM parque p INNER JOIN calibracao c ON p.id = c.idParque WHERE c.tipo = '" + tipo + "'";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Object datetimeStr = reader.GetValue(8);
                    DateTime? data = null;
                    if (!datetimeStr.ToString().Equals(""))
                        data = Convert.ToDateTime(datetimeStr);

                    int foiCalibrado = 0;
                    if (!reader.GetValue(7).ToString().Equals(""))
                        foiCalibrado = reader.GetInt32(7);

                    ret.Add(new ParqueEolico(reader.GetInt32((int)ParqueEolicoAtributos.ID),
                        reader.GetString((int)ParqueEolicoAtributos.NOME),
                        reader.GetString((int)ParqueEolicoAtributos.SIGLA_CPTEC),
                        reader.GetString((int)ParqueEolicoAtributos.SIGLA_PrevEOL),
                        reader.GetString((int)ParqueEolicoAtributos.SIGLA_GETOT),
                        reader.GetInt32((int)ParqueEolicoAtributos.NUM_MAQUINAS),
                        reader.GetFloat((int)ParqueEolicoAtributos.POTENCIA),
                        new Calibracao(0, foiCalibrado, data, tipo)));
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }

        internal static IEnumerable<ParqueEolico> SelectAll_LEFT(string tipo)
        {
            List<ParqueEolico> ret = new List<ParqueEolico>();
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT p.id, p.nome, p.siglaCPTEC, p.siglaPrevEOL, p.siglaGETOT, p.numMaquinas, p.potenciaMaxima, "
                    + " c.foiCalibrado, c.data, c.id FROM parque p LEFT JOIN calibracao c ON p.id = c.idParque AND c.tipo = '" + tipo + "'";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int foiCalibrado = 0;
                    if (!reader.GetValue(7).ToString().Equals(""))
                        foiCalibrado = reader.GetInt32(7);

                    Object datetimeStr = reader.GetValue(8);
                    DateTime? data = null;
                    if (!datetimeStr.ToString().Equals(""))
                        data = Convert.ToDateTime(datetimeStr);

                    int calibracaoId = 0;
                    if (!reader.GetValue(9).ToString().Equals(""))
                        calibracaoId = (int)reader.GetInt64(9);

                    ret.Add(new ParqueEolico(reader.GetInt32((int)ParqueEolicoAtributos.ID),
                        reader.GetString((int)ParqueEolicoAtributos.NOME),
                        reader.GetString((int)ParqueEolicoAtributos.SIGLA_CPTEC),
                        reader.GetString((int)ParqueEolicoAtributos.SIGLA_PrevEOL),
                        reader.GetString((int)ParqueEolicoAtributos.SIGLA_GETOT),
                        reader.GetInt32((int)ParqueEolicoAtributos.NUM_MAQUINAS),
                        reader.GetFloat((int)ParqueEolicoAtributos.POTENCIA),
                        new Calibracao(calibracaoId, foiCalibrado, data, tipo)));
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }

        public List<ParqueEolico> SelectAll()
        {
            List<ParqueEolico> ret = new List<ParqueEolico>();
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT p.id, p.nome, p.siglaCPTEC, p.siglaPrevEOL, p.siglaGETOT, p.numMaquinas, p.potenciaMaxima "
                    + " FROM parque p WHERE 1 = 1";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(new ParqueEolico(reader.GetInt32((int)ParqueEolicoAtributos.ID),
                        reader.GetString((int)ParqueEolicoAtributos.NOME),
                        reader.GetString((int)ParqueEolicoAtributos.SIGLA_CPTEC),
                        reader.GetString((int)ParqueEolicoAtributos.SIGLA_PrevEOL),
                        reader.GetString((int)ParqueEolicoAtributos.SIGLA_GETOT),
                        reader.GetInt32((int)ParqueEolicoAtributos.NUM_MAQUINAS),
                        reader.GetFloat((int)ParqueEolicoAtributos.POTENCIA),
                        new Calibracao()));
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return ret;
        }

        internal void atualizarParqueFoiCalibrado(ParqueEolico p)
        {
            try
            {
                SqlConnection connection = (SqlConnection)Database.openConnection();
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "SELECT COUNT(*) FROM calibracao WHERE idParque = " + p.Id + " AND tipo = '" + p.Calibracao.Tipo + "'";
                int? count = int.Parse(command.ExecuteScalar().ToString());

                if (count != null && count != 0)
                    command.CommandText = "UPDATE calibracao SET data = GetDate() WHERE idParque = " + p.Id + ";";
                else
                    command.CommandText = "INSERT INTO calibracao (foiCalibrado, data, idParque, tipo) VALUES (1,GetDate(), "+p.Id+", '"+p.Calibracao.Tipo+"')";

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Ops, não foi possível atualizar o status de calibrado do parque eólico." + e.Data);
            }
        }
    }
}
