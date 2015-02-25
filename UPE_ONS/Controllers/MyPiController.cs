using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPE_ONS.Util;

namespace UPE_ONS.Controllers
{
    class MyPiController
    {

         String tag;
        String initialDate;
        String endDate;

        String fileName;
        String command;
        private string p;
        private DateTime time1;
        private DateTime time2;

        public MyPiController()
        {
        }

        public void setTag(String tag)
        {
            this.tag =tag;
        }

        public void setInitialDate(String initDate)
        {
            this.initialDate =initDate;
        }

        public  void setEndDate(String endDate)
        {
            this.endDate = endDate;
        }

        public MyPiController(String tag , String  iDate, String eDate)
        {
            this.tag = tag;
            this.initialDate = iDate;
            this.endDate = eDate;

            SQL_Util sqlHelper = new SQL_Util();

            this.fileName = sqlHelper.createSQLfile(tag, initialDate, endDate);
            this.command = buildGetCommand(fileName);
            //Console.WriteLine(command);
        }

        public MyPiController(string p, DateTime time1, DateTime time2)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.time1 = time1;
            this.time2 = time2;
        }

        public void run()
        {
            this.runPICommand(command);
        }

        public bool runPICommand(String command)
        {
            bool success = true;

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            startInfo.WorkingDirectory = NeuroEOLParameters.PIpath;
            startInfo.UseShellExecute = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c " + command;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();

            return success;
        }

        public String buildGetCommand(String sqlFile)
        {
            //Split file name and extension
            String[] tag = sqlFile.Split('.');

            //Build command 'Mypisql -s RBSH01.REGER.ONS -u "PIDEMO" -p "" -t 2400 -i uepm_f.sql > \\uepm_f.txt'
            String command = String.Format(@NeuroEOLParameters.PIGetCommand, new object[] { NeuroEOLParameters.serverName, NeuroEOLParameters.userName, NeuroEOLParameters.serverPass });
            command += sqlFile + " > " + tag[0] + ".txt";
            return command;
        }

    }
}
