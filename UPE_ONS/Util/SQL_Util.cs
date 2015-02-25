using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPE_ONS.Util
{
    class SQL_Util
    {
        public String createSQLfile(String tag, String date1, String date2)
        {
            //String tag = "CEUEPM";
            //String date1 = "06/08/2014 13:00:00";
            //String date2 = "06/08/2014 13:00:00";

            String[] objects = tag.Split('_');
            String name = objects[0];

            //Build SQL request using tag and dates FROM and TO
            string path = NeuroEOLParameters.PIDrive + "\\" + NeuroEOLParameters.PIDirectory + "\\" + tag + ".sql";
            string result2 = String.Format(NeuroEOLParameters.sqlCommandPot, new object[] { tag+".v", date1, date2, ""+NeuroEOLParameters.sqlTimeStepInSeconds });

            //Create SQL file at PI directory
            if (!File.Exists(path))
            {
                TextWriter tw = new StreamWriter(path, true);
                tw.WriteLine(result2);
                tw.Close();
            }

            //return file name
            return tag + ".sql";
        }
    }    
}
