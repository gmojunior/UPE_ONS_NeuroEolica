using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPE_ONS.Util
{
    class MyPiFileUtil
    {
        public ArrayList readTagFile()
        {
            ArrayList tags = new ArrayList();

            String path = NeuroEOLParameters.tagFileName;
            String lineOfText = "";

            //Open file in the following PATH
            var filestream = new FileStream(path,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite);
            var file = new StreamReader(filestream, Encoding.UTF8, true, 128);

            //For each line read the ones with data
            while ((lineOfText = file.ReadLine()) != null)
            {
                if(!String.IsNullOrEmpty(lineOfText))
                {
                    String[] objects = lineOfText.Split(',');
                    String tag = objects[1];
                    tags.Add(tag);
                }
            }

            return tags;
        }

        public ArrayList readUsinasFile()
        {
            ArrayList tags = new ArrayList();

            String path = NeuroEOLParameters.tagFileName;
            String lineOfText = "";

            //Open file in the following PATH
            var filestream = new FileStream(path,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite);
            var file = new StreamReader(filestream, Encoding.UTF8, true, 128);

            //For each line read the ones with data
            while ((lineOfText = file.ReadLine()) != null)
            {
                if(!String.IsNullOrEmpty(lineOfText))
                {
                    String[] objects = lineOfText.Split(',');
                    String tag = objects[0];
                    tags.Add(tag);
                }
            }

            return tags;
        }

        //Insert New item on tags file
        internal void addUsina(string name, string tag)
        {

            String path = NeuroEOLParameters.tagFileName;
            String lineOfText = name + " , " + tag;

            //Open file in the following PATH
            var filestream = new FileStream(path,
                            FileMode.Append,
                            FileAccess.Write,
                            FileShare.ReadWrite);

            StreamWriter writer = new StreamWriter(filestream);

            writer.Write("\n");
            writer.Write(lineOfText);

            writer.Close();
        }

        internal string getTag(string name)
        {
            String tag = "";

            ArrayList tags = new ArrayList();

            String path = NeuroEOLParameters.tagFileName;
            String lineOfText = "";

            //Open file in the following PATH
            var filestream = new FileStream(path,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite);
            var file = new StreamReader(filestream, Encoding.UTF8, true, 128);

            //For each line read the ones with data
            while ((lineOfText = file.ReadLine()) != null)
            {
                String[] objects = lineOfText.Split(',');
                String readName = objects[0];

                if(readName.Equals(name))
                {
                    tag = objects[1];
                    break;
                }
            }

            return tag;

        }

        internal void replaceNameAndTag(string name, string nName, string tag)
        {
            String path = NeuroEOLParameters.tagFileName;
            String lineOfText = "";
            String text = "";

            //Open file in the following PATH
            var filestream = new FileStream(path,
                            FileMode.Open,
                            FileAccess.ReadWrite,
                            FileShare.ReadWrite);
            var file = new StreamReader(filestream, Encoding.UTF8, true, 128);

            //For each line read the ones with data
            while ((lineOfText = file.ReadLine()) != null)
            {
                String[] objects = lineOfText.Split(',');
                String readName = objects[0];

                if(!readName.Equals(name) && !String.IsNullOrEmpty(lineOfText))
                {
                    text += lineOfText + "\n";
                }
            }
            file.Close();
            filestream.Close();

            File.WriteAllText(path, text + nName + " , " + tag);
        }

        public void removeNameAndTag(string name)
        {
            String path = NeuroEOLParameters.tagFileName;
            String lineOfText = "";
            String text = "";

            //Open file in the following PATH
            var filestream = new FileStream(path,
                            FileMode.Open,
                            FileAccess.ReadWrite,
                            FileShare.ReadWrite);
            var file = new StreamReader(filestream, Encoding.UTF8, true, 128);

            //For each line read the ones with data
            while ((lineOfText = file.ReadLine()) != null)
            {
                String[] objects = lineOfText.Split(',');
                String readName = objects[0];

                if (!readName.Equals(name))
                {
                    text += lineOfText + "\n";
                }
            }
            file.Close();
            filestream.Close();

            File.WriteAllText(path, text);
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public ArrayList readPotRequestFile(String tag, int numeroEntradas)
        {
            ArrayList integralizedPowerList = new ArrayList();
            //Esse index depende da quantidade de entradas de cada previsor
            int limitIndex = 0;
            //Previsor PP são dados de 30 em 30 minutos. Como o PI retorna valores de 30 em 30 segundos
            //São necessários 60 valores para representar os 30 minutos
            //Em 3 horas teremos 6 valores
            if (numeroEntradas == 6)
            {
                limitIndex = 60;
            }

            //Previsor PP são dados de 10 em 10 minutos. Como o PI retorna valores de 30 em 30 segundos
            //São necessários 20 valores para representar os 30 minutos
            //Em 3 horas, teremos 18 valores
            if (numeroEntradas == 18)
            {
                limitIndex = 20;
            }

            String[] tags = tag.Split('.');
            string path = NeuroEOLParameters.PIDrive + "\\" + NeuroEOLParameters.PIDirectory + "\\" + tags[0] + ".txt";

            String lineOfText = "";

            //Open file in the following PATH
            var filestream = new FileStream(path,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite);
            var file = new StreamReader(filestream, Encoding.UTF8, true, 128);
            int index = 0;
            List<Double> pot = new List<double>();

            //For each line read the ones with data
            while ((lineOfText = file.ReadLine()) != null)
            {
                String[] objects = lineOfText.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                if (objects.Length == NeuroEOLParameters.potResponseFileObjects)
                {
                    pot.Add(Convert.ToDouble(objects[6]));
                    index++;

                    if (index == limitIndex)
                    {
                        //integralizedPowerList.Add(Math.Round((pot / limitIndex), 2));
                        integralizedPowerList.Add(calculateMediaValidValues(pot));
                        index = 0;
                        pot = new List<Double>();
                    }
                }
            }

            return integralizedPowerList;
        }

        private double calculateMediaValidValues(List<Double> pot)
        {
            int validValuesCount = 0;
            double sumPot = 0;
            for (int i = 0; i < pot.Count(); i++)
            {
                if (pot[i] == -9990000.0)
                {
                    continue;
                }
                else
                {
                    validValuesCount++;
                    sumPot += pot[i];
                }
            }

            if (validValuesCount != 0)
            {
                return Math.Round((sumPot / validValuesCount), 2);
            }
            else
            {
                return 0.001;
            }

        }

        public void writeFile(ArrayList data, String tag, String path)
        {
            DateTime date = DateTime.Now;
            Double hour = date.Hour;
            Double minute = date.Minute;

            Double sin = Math.Round(Math.Sin(((hour + (minute / 60)) / 24) * 2 * Math.PI), 4);
            Double cos = Math.Round(Math.Cos(((hour + (minute / 60)) / 24) * 2 * Math.PI), 4);

            //Build SQL request using tag and dates FROM and TO
            String filePath = path + "entradas.txt";
            
            //Get current date
            string format = "dd/MM/yyyy HH:mm";
            DateTime time2 = DateTime.Now;
            String currentDateTime = time2.ToString(format);

            string text = currentDateTime + " \n " + sin + "\t" + cos + "\t";

            foreach (Double num in data)
            {
                text += num + "\t";
            }

            String path1 = Directory.GetCurrentDirectory();

            if (!Directory.Exists(path1 + "\\" + path + "\\"))
            {
                Directory.CreateDirectory(path1 + "\\" + path + "\\");
            }

            FileStream fs = new FileStream(path1 + "\\" + path + "\\NEURO_EOLICA_PREVISOR_ENTRADAS.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(text.Replace(',', '.'));

            writer.Close();
            fs.Close();

            //TextWriter tw = new StreamWriter(path, false);
            //tw.WriteLine(text);
            //tw.Close();

        }
    }
}
