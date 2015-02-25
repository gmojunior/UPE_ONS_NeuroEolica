using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPE_ONS.DAO;
using UPE_ONS.Model;
using UPE_ONS.Util;

namespace UPE_ONS.Controllers
{
    // Classe controladora responsável pela calibração dos modelos da rede neural.
    class CalibradorController
    {
        private const string ARQUIVO_PARQUES_CALIBRADOS = "/ParquesCalibrados.txt";
        private const string PASTA_TRABALHO = "/PASTA_TRABALHO.TXT";
        private const string CAMINHO_DE_DISCO   = "CaminhoDisco.txt";
        private const string PASTA_PESOS_OTIMOS = "PesosOtimos";
        private const string ENTRADA_NOME       = "NEURO_EOLICA_ENTRADAS_0";

        private const string CALIBRADOR_TR_DIRECTORY_NAME = "CalibradorTR";
        private const string CALIBRADOR_TR_EXE = CALIBRADOR_TR_DIRECTORY_NAME + @"\" + CALIBRADOR_TR_DIRECTORY_NAME + ".exe";

        private const string CALIBRADOR_PP_DIRECTORY_NAME = "CalibradorPP";
        private const string CALIBRADOR_PP_EXE = CALIBRADOR_PP_DIRECTORY_NAME + @"\" + CALIBRADOR_PP_DIRECTORY_NAME + ".exe";

        private const string CALIBRADOR_VP_DIRECTORY_NAME = "CalibradorVP";
        private const string CALIBRADOR_VP_EXE = CALIBRADOR_VP_DIRECTORY_NAME + @"\" + CALIBRADOR_VP_DIRECTORY_NAME + ".exe";
        

        public CalibradorController()
        {

        }

        #region VentoPotencia

        public void gerarArquivoTreinamentoVentoPotencia(ParqueEolico parqueEolico, DateTime dataInicial, DateTime dataFinal, String intervalo)
        {
            DirectoryInfo directoryInfoCalibrador = Util.Util.GetOrCreateIfNotExistsDiretoriosCalibracao(CALIBRADOR_VP_DIRECTORY_NAME + "/" + parqueEolico.SiglaPrevEOL);
            DirectoryInfo directoryInfoPotenciaMedia = Util.Util.GetOrCreateIfNotExistsDiretorioPotenciaMedia();
            FactoryDAO.getInstance().PotenciaMediaHoraMesDAO.gerarArquivosPotenciaMedia(parqueEolico, directoryInfoPotenciaMedia.FullName, intervalo);
            FactoryDAO.getInstance().CPTECDAO.gerarArquivoTreinamentoVentoPotencia(parqueEolico, directoryInfoCalibrador.FullName + Util.Util.getEntradaPath(),
                directoryInfoPotenciaMedia.FullName, dataInicial, dataFinal, intervalo);
            this.criarAtualizarArquivoParquesCalibrados(parqueEolico, PrevisorController.PREVISAO_TIPO.VENTO_POTENCIA);
        }

        #endregion

        #region PotenciaPotencia

        public void gerarArquivosTreinamentoPotenciaPotencia(ParqueEolico parqueEolico, int numeroDeEntradas, 
            DateTime dataInicial, DateTime dataFinal, String intervalo, bool isTempoReal)
        {
            String parque = parqueEolico.Nome.Replace(' ', '_');
            String nomeArquivo = "";
            try
            {
                List<ParqueEolicoImportacaoPrevEOL> listaCompleta = FactoryDAO.getInstance().PrevEOLDAO.GetList(parqueEolico, 
                    dataInicial, dataFinal, intervalo);

                DirectoryInfo directoryInfo;
                if(isTempoReal)
                    directoryInfo = Util.Util.GetOrCreateIfNotExistsDiretoriosCalibracao(CALIBRADOR_TR_DIRECTORY_NAME + "/" + parqueEolico.SiglaPrevEOL);
                else
                    directoryInfo = Util.Util.GetOrCreateIfNotExistsDiretoriosCalibracao(CALIBRADOR_PP_DIRECTORY_NAME + "/" + parqueEolico.SiglaPrevEOL);

                if (intervalo.Equals(Util.Util.DEZ_MINUTOS))
                {
                    nomeArquivo = parque + "_10_min_full_" + (2 + numeroDeEntradas) + "_36.txt";
                    this.gerarArquivoPotenciaPotenciaCompleto(directoryInfo.FullName + Util.Util.getEntradaPath(),
                        numeroDeEntradas, nomeArquivo, 1, 36, listaCompleta);
                    this.gerarArquivosPotenciaPotenciaDiarios10min(directoryInfo.FullName + Util.Util.getEntradaPath(),
                        numeroDeEntradas, nomeArquivo, parque);
                }
                else if (intervalo.Equals(Util.Util.TRINTA_MINUTOS))
                {
                    nomeArquivo = parque + "_30_min_full_" + (2 + numeroDeEntradas) + "_48.txt";
                    this.gerarArquivoPotenciaPotenciaCompleto(directoryInfo.FullName + Util.Util.getEntradaPath(),
                        numeroDeEntradas, nomeArquivo, 5, 48, listaCompleta);
                    this.gerarArquivosPotenciaPotenciaDiarios30min(directoryInfo.FullName + Util.Util.getEntradaPath(),
                        numeroDeEntradas, nomeArquivo, parque);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }

        private void gerarArquivosPotenciaPotenciaDiarios10min(string caminho, int defazagemNumEntradas, 
            string nomeArquivo, string parque)
        {
            string[] dadosArquivo = File.ReadAllLines(caminho + nomeArquivo);

            int qtdEntradas = (2 + defazagemNumEntradas);

            int dia01 = 36 * 1;

            gerarArquivoPotenciaDiario(1, dadosArquivo, qtdEntradas, 0, dia01, caminho);
        }

        private void gerarArquivosPotenciaPotenciaDiarios30min(string caminho, int defazagemNumEntradas,
            String nomeArquivo, String parque)
        {
            string[] dadosArquivo = File.ReadAllLines(caminho + nomeArquivo);

            int qtdEntradas = (2 + defazagemNumEntradas);
            // 48 saídas - potência de meia em meia hora - 1 dia de potência
            int dia01 = 48 * 1;
            int dia02 = 48 * 2;
            int dia03 = 48 * 3;
            int dia04 = 48 * 4;
            int dia05 = 48 * 5;

            gerarArquivoPotenciaDiario(1, dadosArquivo, qtdEntradas, 0, dia01, caminho);
            gerarArquivoPotenciaDiario(2, dadosArquivo, qtdEntradas, dia01, dia02, caminho);
            gerarArquivoPotenciaDiario(3, dadosArquivo, qtdEntradas, dia02, dia03, caminho);
            gerarArquivoPotenciaDiario(4, dadosArquivo, qtdEntradas, dia03, dia04, caminho);
            gerarArquivoPotenciaDiario(5, dadosArquivo, qtdEntradas, dia04, dia05, caminho);
        }

        private void gerarArquivoPotenciaPotenciaCompleto(string caminho, int numberOfInputs, String fileName,
            int qtdDias, int qtdSaidas, List<ParqueEolicoImportacaoPrevEOL> listaCompleta)
        {
            StreamWriter file = new StreamWriter(caminho + fileName);
            this.criarCabecalhoArquivo(file, numberOfInputs, qtdDias, qtdSaidas);
            this.criarCorpoArquivo(listaCompleta, file, numberOfInputs);
            file.Close();
        }

        private void criarCabecalhoArquivo(StreamWriter file, int numeroDeEntradas, int qtdDias, int qtdSaidas)
        {
            file.Write("sen(2PIn/T);Cos(2PIn/T);");
            for (int i = 1; i <= numeroDeEntradas; i++)
            {
                file.Write(i + ";");
            }
            for (int i = 0; i < 5; i++)
            {
                for (int k = 1; k <= 48; k++)
                {
                    file.Write(k + ";");
                }
            }
            file.WriteLine();
        }

        private void criarCorpoArquivo(List<ParqueEolicoImportacaoPrevEOL> list, StreamWriter file, int numberOfInputs)
        {
            int count = 0;
            int count2 = 0;
            try
            {
                for (int k = 0; k < list.Count; k++)
                {
                    file.Write(Math.Round(Math.Sin(2 * Constants.PI *
                        (((ParqueEolicoImportacaoPrevEOL)list[k]).Hora + (double)((ParqueEolicoImportacaoPrevEOL)list[k]).Minuto / 60) / 24), 3) + ";");
                    file.Write(Math.Round(Math.Cos(2 * Constants.PI *
                        (((ParqueEolicoImportacaoPrevEOL)list[k]).Hora + (double)((ParqueEolicoImportacaoPrevEOL)list[k]).Minuto / 60) / 24), 3) + ";");
                    if (count < numberOfInputs)
                    {
                        for (int i = count; i < numberOfInputs; i++)
                        {
                            file.Write(";");
                        }

                        for (int i = 0; i < (count + (48 * 5)); i++)
                        {
                            file.Write(((ParqueEolicoImportacaoPrevEOL)list[i]).Potencia + ";");
                        }
                        count++;
                    }
                    else
                    {
                        for (int i = 0; i < (numberOfInputs + (48 * 5)); i++)
                        {
                            if (i + count2 >= list.Count)
                                file.Write(";");
                            else
                                file.Write(((ParqueEolicoImportacaoPrevEOL)list[i + count2]).Potencia + ";");
                        }
                        count2++;
                    }
                    file.WriteLine();
                }
            }
            catch (Exception e)
            {
                file.Close();
                Console.WriteLine("ERROR: " + e.Message);
            }
        }

        private void gerarArquivoPotenciaDiario(int dia, string[] dadosArquivo,
            int qtdEntradas, int intervaloInferior, int intervaloSuperior, string caminho)
        {
            StreamWriter arquivo = new StreamWriter(caminho + ENTRADA_NOME + dia + ".txt");

            for (int k = 1; k < dadosArquivo.Length; k++)
            {
                String inputLine = "";
                String outputLine = "";

                String[] fields = dadosArquivo[k].Split(';');
                Boolean isValidInput = true;
                for (int i = 0; i < qtdEntradas && isValidInput; i++)
                    if (fields[i].Equals("-999") || fields[i].Equals(""))
                        isValidInput = false;
                    else
                        inputLine += (Math.Round(Decimal.Parse(fields[i]), 3).ToString().Replace(",", ".") + " ");
                for (int i = (qtdEntradas + intervaloInferior); i < (qtdEntradas + intervaloSuperior) && isValidInput; i++)
                    if (fields[i].Equals("-999") || fields[i].Equals(""))
                        isValidInput = false;
                    else
                        outputLine += (Math.Round(Decimal.Parse(fields[i]), 3).ToString().Replace(",", ".") + " ");

                if (isValidInput)
                    arquivo.WriteLine(inputLine + outputLine);
            }
            arquivo.Close();
        }

        #endregion

        public void CalibrarPotenciaPotencia(ParqueEolico parqueEolico, bool isTempoReal)
        {
            try
            {
                if (isTempoReal)
                {
                    this.criarCaminhoDeDiscoCalibrador(Path.GetFullPath(CALIBRADOR_TR_DIRECTORY_NAME));
                    this.criarPastaDeTrabalhoCalibrador(CALIBRADOR_TR_DIRECTORY_NAME + PASTA_TRABALHO, parqueEolico);
                    var process = Process.Start(CALIBRADOR_TR_EXE);
                    process.WaitForExit();

                    FactoryController.getInstance().PrevisorController.montarEstruturaParaPrevisao(parqueEolico.SiglaPrevEOL, PrevisorController.PREVISAO_TIPO.TEMPO_REAL);
                    this.copiarPesosOtimos(parqueEolico, PrevisorController.PREVISAO_TIPO.TEMPO_REAL);
                    this.criarAtualizarArquivoParquesCalibrados(parqueEolico, PrevisorController.PREVISAO_TIPO.TEMPO_REAL);
                }
                else
                {
                    this.criarCaminhoDeDiscoCalibrador(Path.GetFullPath(CALIBRADOR_PP_DIRECTORY_NAME));
                    this.criarPastaDeTrabalhoCalibrador(CALIBRADOR_PP_DIRECTORY_NAME + PASTA_TRABALHO, parqueEolico);
                    var process = Process.Start(CALIBRADOR_PP_EXE);
                    process.WaitForExit();

                    FactoryController.getInstance().PrevisorController.montarEstruturaParaPrevisao(parqueEolico.SiglaPrevEOL, PrevisorController.PREVISAO_TIPO.POTENCIA_POTENCIA);
                    this.copiarPesosOtimos(parqueEolico, PrevisorController.PREVISAO_TIPO.POTENCIA_POTENCIA);
                    this.criarAtualizarArquivoParquesCalibrados(parqueEolico, PrevisorController.PREVISAO_TIPO.POTENCIA_POTENCIA);
                }
                FactoryDAO.getInstance().ParqueEolicoDAO.atualizarParqueFoiCalibrado(parqueEolico);
                
            }
            catch (Exception e)
            {
                throw new Exception("Ops, ocorreu um erro na calibração dos dados.");
            }
        }

        private void copiarPesosOtimos(ParqueEolico p, PrevisorController.PREVISAO_TIPO tipo)
        {
            if (tipo == PrevisorController.PREVISAO_TIPO.POTENCIA_POTENCIA)
            {
                DirectoryInfo dir = new DirectoryInfo(CALIBRADOR_PP_DIRECTORY_NAME + "/" + p.SiglaPrevEOL + "/" + PASTA_PESOS_OTIMOS);
                FileInfo[] fileInfo = dir.GetFiles();
                if (fileInfo.Length != 0)
                {
                    foreach (FileInfo file in fileInfo)
                    {
                        FactoryController.getInstance().PrevisorController.importarPesoOtimo(file,
                            PrevisorController.PREVISAO_TIPO.POTENCIA_POTENCIA, p.SiglaPrevEOL);
                    }
                }
            }
            else if (tipo == PrevisorController.PREVISAO_TIPO.TEMPO_REAL)
            {
                DirectoryInfo dir = new DirectoryInfo(CALIBRADOR_TR_DIRECTORY_NAME + "/" + p.SiglaPrevEOL + "/" + PASTA_PESOS_OTIMOS);
                FileInfo[] fileInfo = dir.GetFiles();
                if (fileInfo.Length != 0)
                {
                    foreach (FileInfo file in fileInfo)
                    {
                        FactoryController.getInstance().PrevisorController.importarPesoOtimo(file,
                            PrevisorController.PREVISAO_TIPO.TEMPO_REAL, p.SiglaPrevEOL);
                    }
                }
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(CALIBRADOR_VP_DIRECTORY_NAME + "/" + p.SiglaPrevEOL + "/" + PASTA_PESOS_OTIMOS);
                FileInfo[] fileInfo = dir.GetFiles();
                if (fileInfo.Length != 0)
                {
                    foreach (FileInfo file in fileInfo)
                    {
                        FactoryController.getInstance().PrevisorController.importarPesoOtimo(file,
                            PrevisorController.PREVISAO_TIPO.VENTO_POTENCIA, p.SiglaPrevEOL);
                    }
                }
            }
        }

        private void criarAtualizarArquivoParquesCalibrados(ParqueEolico parqueEolico, PrevisorController.PREVISAO_TIPO tipo)
        {
            if (parqueEolico.Calibracao.FoiCalibrado == 0)
            {
                StreamWriter file = File.AppendText(Path.GetFullPath("Arquivos") + ARQUIVO_PARQUES_CALIBRADOS);
                file.WriteLine(parqueEolico.SiglaPrevEOL + "_" + tipo);
                file.Close();
            }
        }

        public void calibrarVentoPotencia(ParqueEolico parqueEolico)
        {
            try
            {
                this.criarCaminhoDeDiscoCalibrador(Path.GetFullPath(CALIBRADOR_VP_DIRECTORY_NAME));
                this.criarPastaDeTrabalhoCalibrador(CALIBRADOR_VP_DIRECTORY_NAME + PASTA_TRABALHO, parqueEolico);
                var process = Process.Start(CALIBRADOR_VP_EXE);
                process.WaitForExit();

                FactoryDAO.getInstance().ParqueEolicoDAO.atualizarParqueFoiCalibrado(parqueEolico);
                FactoryController.getInstance().PrevisorController.montarEstruturaParaPrevisao(parqueEolico.SiglaPrevEOL, PrevisorController.PREVISAO_TIPO.VENTO_POTENCIA);
                this.copiarPesosOtimos(parqueEolico, PrevisorController.PREVISAO_TIPO.VENTO_POTENCIA);
            }
            catch(Exception ex)
            {
                throw new Exception("Ops, ocorreu um erro durante a calibração dos dados.");
            }
        }

        private void criarPastaDeTrabalhoCalibrador(string caminhoCalibrador, ParqueEolico parqueEolico)
        {
            StreamWriter file = new StreamWriter(caminhoCalibrador);
            file.WriteLine(parqueEolico.SiglaPrevEOL);
            file.WriteLine(parqueEolico.PotenciaMaxima);
            file.WriteLine("6");
            file.WriteLine("5");
            file.Close();
        }

        private void criarCaminhoDeDiscoCalibrador(string caminho)
        {
            StreamWriter file = new StreamWriter(CAMINHO_DE_DISCO);
            file.Write(caminho + "\\");
            file.Close();
        }
    }
}