using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using UPE_ONS.DAO;
using UPE_ONS.Model;
using UPE_ONS.Util;

namespace UPE_ONS.Controllers
{
    class PrevisorController
    {
        public enum PREVISAO_TIPO
        {
            POTENCIA_POTENCIA,
            VENTO_POTENCIA,
            TEMPO_REAL
        }

        private const string CAMINHO_DE_DISCO = "CaminhoDisco.txt";
        private const string PASTA_ENTRADAS = "/Entradas";
        private const string PASTA_TRABALHO = "/TRABALHO";
        private const string PASTA_PESOS_OTIMOS = "/PesosOtimos";
        private const string PREVISOR_ENTRADA_NOME = "NEURO_EOLICA_PREVISOR_ENTRADAS_0";
        private const int PREVISOR_PP_NUMERO_ENTRADAS = 6;
        private const int PREVISOR_TR_NUMERO_ENTRADAS = 18;
        

        private const string PREVISOR_PP_DIRECTORY_NAME = "PrevisorPP";
        private const string PREVISOR_PP_EXE = PREVISOR_PP_DIRECTORY_NAME + @"\" + PREVISOR_PP_DIRECTORY_NAME + ".exe";

        private const string PREVISOR_TR_DIRECTORY_NAME = "PrevisorTR";
        private const string PREVISOR_TR_EXE = PREVISOR_TR_DIRECTORY_NAME + @"\" + PREVISOR_TR_DIRECTORY_NAME  + ".exe";

        private const string PREVISOR_VP_DIRECTORY_NAME = "PrevisorVP";
        private const string PREVISOR_VP_EXE = PREVISOR_VP_DIRECTORY_NAME + @"\" + PREVISOR_VP_DIRECTORY_NAME + ".exe";

        public void PreverVentoPotencia(EntradaVentoPotencia parque)
        {
            try
            {
                Dictionary<String, Object> dicPotenciaMedia = FactoryDAO.getInstance().PotenciaMediaHoraMesDAO.
                    carregarArquivoPotenciaMedia(Path.GetFullPath(Util.Util.POTENCIA_MEDIA_DIRECTORY_NAME), parque.ParqueEolico.Nome);

                List<List<EntradaVentoPotencia>> dados = FactoryDAO.getInstance().
                    PrevisorDAO.GetDadosPrevisaoPotenciaVento(parque.ParqueEolico, dicPotenciaMedia);

                gerarArquivosDeEntrada(Path.GetFullPath(PREVISOR_VP_DIRECTORY_NAME)+
                    "\\" + parque.ParqueEolico.SiglaPrevEOL + "\\Entradas", dados);

                this.atualizarParquePastaTrabalho(parque.ParqueEolico.SiglaPrevEOL, PREVISOR_VP_DIRECTORY_NAME);
                this.atualizarCaminhoDoExecutavelDoPrevisor(Path.GetFullPath(PREVISOR_VP_DIRECTORY_NAME));
                this.executarPrevisor(PREVISOR_VP_EXE);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message, Constants.WARNNING_CAPTION);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.WARNNING_CAPTION);
            }
        }

        private static void gerarArquivosDeEntrada(String path, List<List<EntradaVentoPotencia>> dados)
        {
            for (int diaPrevisto = 0; diaPrevisto < dados.Count; diaPrevisto++)
            {
                StreamWriter file = new StreamWriter(path + "/" + PREVISOR_ENTRADA_NOME + (diaPrevisto + 1) + ".txt");

                List<EntradaVentoPotencia> entrada = dados[diaPrevisto];
                for (int index = 0; index < entrada.Count; index++)
                {
                    file.WriteLine(entrada[index].GetSenHora().ToString().Replace(',', '.') + " " +
                        entrada[index].GetCosHora().ToString().Replace(',', '.') + " " +
                        entrada[index].GetSenDirecao().ToString().Replace(',', '.') + " " +
                        entrada[index].GetCosDirecao().ToString().Replace(',', '.') + " " +
                        entrada[index].PotenciaMedia.Replace(',', '.') + " " + entrada[index].Velocidade);

                    // No último valro da hora, não precisa interpolar com o valor da frente.
                    if (index != 23)
                    {
                        double velocidade = Double.Parse(entrada[index].Velocidade.Replace('.', ',')) + Double.Parse(entrada[index + 1].Velocidade.Replace('.', ','));
                        double direcao = Double.Parse(entrada[index].Direcao.Replace('.', ',')) + Double.Parse(entrada[index + 1].Direcao.Replace('.', ','));
                        double potenciaMedia = Double.Parse(entrada[index].PotenciaMedia.Replace('.', ',')) + Double.Parse(entrada[index + 1].PotenciaMedia.Replace('.', ','));
                        EntradaVentoPotencia entradaInterpolada = new EntradaVentoPotencia(null,
                            entrada[index].Dia, entrada[index].Mes, entrada[index].Ano, entrada[index].Hora,
                            ((velocidade) / 2).ToString(),
                            (direcao / 2).ToString(),
                            (potenciaMedia / 2).ToString().Replace(',', '.'));

                        file.WriteLine(entradaInterpolada.GetSenHora().ToString().Replace(',', '.') + " " +
                            entradaInterpolada.GetCosHora().ToString().Replace(',', '.') + " " +
                            entradaInterpolada.GetSenDirecao().ToString().Replace(',', '.') + " " +
                            entradaInterpolada.GetCosDirecao().ToString().Replace(',', '.') + " " +
                            entradaInterpolada.PotenciaMedia + " " +
                            entradaInterpolada.Velocidade.ToString().Replace(',', '.'));
                    }
                }
                file.Close();
            }
        }

        internal List<EntradaVentoPotencia> GetInputPrevisaoVentoPotencia()
        {
            List<EntradaVentoPotencia> ret = new List<EntradaVentoPotencia>();

            List<ParqueEolico> parquesEolicos = (List<ParqueEolico>)FactoryController.getInstance().ParqueEolicoController.getParquesCalibrados("VP");
            for (int i = 0; i < parquesEolicos.Count; i++)
            {
                EntradaVentoPotencia inVP = FactoryDAO.getInstance().PrevisorDAO.GetDadosPrevisaoPotenciaVentoVisualizar(parquesEolicos[i]);
                if(inVP != null)
                    ret.Add(inVP);
            }

            return ret;
        }

        public void montarEstruturaParaPrevisao(string parqueEolico, PREVISAO_TIPO tipoPrevisao)
        {
            string rootConfig;

            if (tipoPrevisao == PREVISAO_TIPO.POTENCIA_POTENCIA)
            {
                rootConfig = PREVISOR_PP_DIRECTORY_NAME + "/" + parqueEolico;
                DirectoryInfo pastaParque = new DirectoryInfo(rootConfig);
                if (!Directory.Exists(PREVISOR_PP_DIRECTORY_NAME + "/" + parqueEolico))
                {
                    pastaParque = Directory.CreateDirectory(rootConfig);
                }
            }
            else if (tipoPrevisao == PREVISAO_TIPO.TEMPO_REAL)
            {
                rootConfig = PREVISOR_TR_DIRECTORY_NAME + "/" + parqueEolico;
                DirectoryInfo pastaParque = new DirectoryInfo(rootConfig);
                if (!Directory.Exists(PREVISOR_TR_DIRECTORY_NAME + "/" + parqueEolico))
                {
                    pastaParque = Directory.CreateDirectory(rootConfig);
                }
            }
            else
            {
                rootConfig = PREVISOR_VP_DIRECTORY_NAME + "/" + parqueEolico;
                DirectoryInfo pastaParque = new DirectoryInfo(rootConfig);
                if (!Directory.Exists(PREVISOR_VP_DIRECTORY_NAME + "/" + parqueEolico))
                {
                    pastaParque = Directory.CreateDirectory(rootConfig);
                }
            }

            DirectoryInfo pastaTrabalho = new DirectoryInfo(rootConfig + PASTA_TRABALHO);
            if (!Directory.Exists(rootConfig + PASTA_TRABALHO))
            {
                pastaTrabalho = Directory.CreateDirectory(rootConfig + PASTA_TRABALHO);
            }

            DirectoryInfo pesosOtimos = new DirectoryInfo(rootConfig + PASTA_PESOS_OTIMOS);
            if (!Directory.Exists(rootConfig + PASTA_PESOS_OTIMOS))
            {
                pesosOtimos = Directory.CreateDirectory(rootConfig + PASTA_PESOS_OTIMOS);
            }

            DirectoryInfo pastaEntradas = new DirectoryInfo(rootConfig + PASTA_ENTRADAS);
            if (!Directory.Exists(rootConfig + PASTA_ENTRADAS))
            {
                pastaEntradas = Directory.CreateDirectory(rootConfig + PASTA_ENTRADAS);
            }
        }

        internal void realizarPrevisao(ParqueEolico parque, string tipo)
        {
            String tag = parque.SiglaGETOT;            

            String initialDate = "06/08/2014 13:00:00";
            String currentDateTime = "06/08/2014 13:00:00";

            TimeSpan span = new TimeSpan(3, 0, 0);
            string format = "dd/MM/yyyy HH:mm:ss";

            //Get current date
            DateTime time2 = DateTime.Now;
            currentDateTime = time2.ToString(format);

            //Get past date from desired time interval 
            DateTime time1 = time2.Subtract(span);
            initialDate = time1.ToString(format);

            MyPiFileUtil fileReader = new MyPiFileUtil();

            if(tipo.Equals("PP"))
            {
                this.atualizarParquePastaTrabalho(parque.SiglaPrevEOL, PREVISOR_PP_DIRECTORY_NAME);
                this.atualizarCaminhoDoExecutavelDoPrevisor(Path.GetFullPath(PREVISOR_PP_DIRECTORY_NAME));

                //Abrir PI
                MyPiController controller = new MyPiController(tag, initialDate, currentDateTime);
                controller.run();
                ArrayList integralizedPowerList = fileReader.readPotRequestFile(tag,PREVISOR_PP_NUMERO_ENTRADAS);

                String path = PREVISOR_PP_DIRECTORY_NAME + "/" + parque.SiglaPrevEOL + PASTA_ENTRADAS;

                //Escrever arquivo com entradas para previsão
                fileReader.writeFile(integralizedPowerList, tag, path);

                this.executarPrevisor(PREVISOR_PP_EXE);
            }
            else if (tipo.Equals("TR"))
            {
                this.atualizarParquePastaTrabalho(parque.SiglaPrevEOL, PREVISOR_TR_DIRECTORY_NAME);
                this.atualizarCaminhoDoExecutavelDoPrevisor(Path.GetFullPath(PREVISOR_TR_DIRECTORY_NAME));

                //Abrir PI
                MyPiController controller = new MyPiController(tag, time1, time2);
                controller.run();
                ArrayList integralizedPowerList = fileReader.readPotRequestFile(tag,PREVISOR_TR_NUMERO_ENTRADAS);

                String path = PREVISOR_TR_DIRECTORY_NAME + "/" + parque.SiglaPrevEOL + PASTA_ENTRADAS;

                //Escrever arquivo com entradas para previsão
                fileReader.writeFile(integralizedPowerList, tag, path);

                //executar previsão
                this.executarPrevisor(PREVISOR_TR_EXE);
            }
        }

        private void executarPrevisor(string exe)
        {
            var process = Process.Start(exe);
            process.WaitForExit();
        }

        private void atualizarCaminhoDoExecutavelDoPrevisor(string caminho)
        {
            StreamWriter file = new StreamWriter(CAMINHO_DE_DISCO);
            file.Write(caminho + "\\");
            file.Close();
        }

        private void atualizarParquePastaTrabalho(string parqueNome, string caminho)
        {
            StreamWriter file = new StreamWriter(caminho + "/PASTA_TRABALHO.TXT");
            file.WriteLine(parqueNome);
            file.Close();
        }

        internal void importarPesoOtimo(FileInfo file, PREVISAO_TIPO tipo, string siglaPrevEOL)
        {
            if(tipo == PREVISAO_TIPO.POTENCIA_POTENCIA)
                File.Copy(file.FullName, PREVISOR_PP_DIRECTORY_NAME + "/" + siglaPrevEOL + PASTA_PESOS_OTIMOS + "/" + file.Name, true);
            else if(tipo == PREVISAO_TIPO.TEMPO_REAL)
                File.Copy(file.FullName, PREVISOR_TR_DIRECTORY_NAME + "/" + siglaPrevEOL + PASTA_PESOS_OTIMOS + "/" + file.Name, true);
            else 
                File.Copy(file.FullName, PREVISOR_VP_DIRECTORY_NAME + "/" + siglaPrevEOL + PASTA_PESOS_OTIMOS + "/" + file.Name, true);
        }
    }
}