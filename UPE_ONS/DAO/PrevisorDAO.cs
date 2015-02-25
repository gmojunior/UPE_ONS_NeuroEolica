using System.Data.SqlClient;
using ScriptDB.DAO;
using System;
using System.Collections.Generic;
using UPE_ONS.Model;

namespace UPE_ONS.DAO
{
    public class PrevisorDAO
    {
        public List<List<EntradaVentoPotencia>> GetDadosPrevisaoPotenciaVento(ParqueEolico parque, Dictionary<String, Object> dicPotenciaMedia)
        {
            List<List<EntradaVentoPotencia>> ret = new List<List<EntradaVentoPotencia>>();

            SqlConnection connection = (SqlConnection)Database.openConnection();
            SqlCommand command = connection.CreateCommand();

            for (int diaPrevisto = 0; diaPrevisto < 5; diaPrevisto++)
            {
                string query = "SELECT p.id, p.nome, vv.dia, vv.mes, vv.ano, vv.mes, vv.velocidade00, vv.velocidade01, " +
                " vv.velocidade02, vv.velocidade03, vv.velocidade04, vv.velocidade05, vv.velocidade06, vv.velocidade07, vv.velocidade08," +
                " vv.velocidade09, vv.velocidade10, vv.velocidade11, vv.velocidade12, vv.velocidade13, vv.velocidade14, vv.velocidade15," +
                " vv.velocidade16, vv.velocidade17, vv.velocidade18, vv.velocidade19, vv.velocidade20, vv.velocidade21, vv.velocidade22, " +
                " vv.velocidade23, dv.direcao00, dv.direcao01, dv.direcao02, dv.direcao03, dv.direcao04, dv.direcao05, dv.direcao06, " +
                " dv.direcao07, dv.direcao08, dv.direcao09, dv.direcao10, dv.direcao11, dv.direcao12, dv.direcao13, dv.direcao14, dv.direcao15," +
                " dv.direcao16, dv.direcao17, dv.direcao18, dv.direcao19, dv.direcao20, dv.direcao21, dv.direcao22, " +
                " dv.direcao23 FROM velocidadevento vv, direcaovento dv, parque p WHERE p.id = " + parque.Id +
                    " AND dv.idParque = " + parque.Id + " AND vv.idParque = " + parque.Id +
                    " AND vv.dia = dv.dia " +
                    " AND vv.mes = dv.mes " +
                    " AND vv.ano = dv.ano " +
                    " AND vv.diaPrevisto = " + diaPrevisto +
                    " AND str_to_date(CONCAT(vv.ano,'-',vv.mes,'-',vv.dia),'%Y-%m-%d') <= '" + String.Format("{0:yyyy-M-d}", DateTime.Now) + "'" +
                    " ORDER BY vv.ano DESC, vv.mes DESC, vv.dia DESC " +
                    " LIMIT 1;";

                command.CommandText = query;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    List<EntradaVentoPotencia> entrada = new List<EntradaVentoPotencia>();
                    // 24 valores de velocidade e direção correspondentes a 1 valor por hora.
                    int totalHorasPorDia = 24;
                    for (int hora = 0; hora < totalHorasPorDia; hora++)
                    {
                        // A chave do dictionary de potencias medias é a hora;mes
                        string key = hora + ";" + reader.GetString(3);

                        ParqueEolico p = new ParqueEolico(reader.GetInt32(0), reader.GetString(1), "", "","", 0, 0, new Calibracao());

                        entrada.Add(new EntradaVentoPotencia(p, reader.GetInt32(2), reader.GetInt32(3),
                            reader.GetInt32(4), hora, reader.GetString(6 + hora), reader.GetString(30 + hora),
                            (string)dicPotenciaMedia[key]));
                    }
                    ret.Add(entrada);
                }

                reader.Close();
            }
            return ret;
        }

        internal EntradaVentoPotencia GetDadosPrevisaoPotenciaVentoVisualizar(ParqueEolico parque)
        {
            EntradaVentoPotencia ret = null;

            SqlConnection connection = (SqlConnection)Database.openConnection();
            SqlCommand command = connection.CreateCommand();

            string query = "SELECT p.id, p.nome, p.siglaCPTEC, p.siglaPrevEOL, vv.dia, vv.mes, vv.ano, vv.mes " +
                " FROM velocidadevento vv, direcaovento dv, parque p WHERE p.id = " + parque.Id +
                " AND dv.idParque = " + parque.Id + " AND vv.idParque = " + parque.Id +
                " AND vv.dia = dv.dia " +
                " AND vv.mes = dv.mes " +
                " AND vv.ano = dv.ano " +
                " AND str_to_date(CONCAT(vv.ano,'-',vv.mes,'-',vv.dia),'%Y-%m-%d') <= '" + String.Format("{0:yyyy-M-d}", DateTime.Now) + "'" +
                " ORDER BY vv.ano DESC, vv.mes DESC, vv.dia DESC " +
                " LIMIT 1;";

            command.CommandText = query;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                ParqueEolico p = new ParqueEolico(reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2), reader.GetString(3), reader.GetString(4), -1, -1, new Calibracao());

                ret = new EntradaVentoPotencia(p, reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), -1, "", "", "");
            }

            reader.Close();

            return ret;
        }
    }
}