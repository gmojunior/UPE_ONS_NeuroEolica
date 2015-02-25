using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPE_ONS.Model;

namespace UPE_ONS.Util
{
    class Util
    {
        private const string ENTRADA_DIRECTORY_NAME = "Entradas";
        private const string PESOS_OTIMOS_DIRECTORY_NAME = "PesosOtimos";
        private const string TRABALHO_DIRECTORY_NAME = "TRABALHO";
        public const string POTENCIA_MEDIA_DIRECTORY_NAME = "PotenciaMedia";

        public const string TRINTA_MINUTOS  = "30min";
        public const string DEZ_MINUTOS     = "10min";

        public static string getEntradaPath()
        {
            return "\\"+ENTRADA_DIRECTORY_NAME+"\\";
        }

        public static DirectoryInfo GetOrCreateIfNotExistsDiretoriosCalibracao(string p)
        {
            DirectoryInfo ret = new DirectoryInfo(p);
            if (!Directory.Exists(p))
            {
                ret = Directory.CreateDirectory(p);
                ret.CreateSubdirectory(ENTRADA_DIRECTORY_NAME);
                ret.CreateSubdirectory(PESOS_OTIMOS_DIRECTORY_NAME);
                ret.CreateSubdirectory(TRABALHO_DIRECTORY_NAME);
            }
            return ret;
        }

        public static DirectoryInfo GetOrCreateIfNotExistsDiretorioPotenciaMedia()
        {
            DirectoryInfo ret = new DirectoryInfo(POTENCIA_MEDIA_DIRECTORY_NAME);
            if (!Directory.Exists(POTENCIA_MEDIA_DIRECTORY_NAME))
            {
                ret = Directory.CreateDirectory(POTENCIA_MEDIA_DIRECTORY_NAME);
            }
            return ret;
        }

        public static ObservableCollection<ParqueEolico> parquesPrevistos;

        public static Double[][] matrixDeValoresPrevistos;

        public static Boolean check = false;
        public static void activateGraphWindow()
        {
            if(!check)
            {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            check = true;
            }
        }
        
    }
}
