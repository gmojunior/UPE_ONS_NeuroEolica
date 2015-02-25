using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPE_ONS.Util
{
    static class NeuroEOLParameters
    {
        //Path parameters
        public static String PIDrive = @"D:";
        public static String PIpath = @"D:\\PI";
        public static String PIDirectory = "PI";

        //tags file
        public static String tagFileName = "Tags Eólica.txt";

        public static int potResponseFileObjects = 7;
        public static int potResponsePotIndex = 6;

        //MyPiSQL command
        public static String serverName = "RBSH01.REGER.ONS";
        public static String userName = "PIDEMO";
        public static String serverPass = "";

        public static String PIGetCommand = "Mypisql -s {0} -u \"{1}\" -p \"{2}\" -t 2400 -i ";

        public static String sqlCommand = "SELECT format(a.time,'dd   MM   yyyy   HH   mm   ss') \"Data \" ," +
            "Case When e.value+x.value >= 0 Then format(e.value+x.value,'#####') ELSE '-999' END \"N MAQ \", " +
            "Case When a.value >= 0 Then format(a.value,'####.####') ELSE '-999.0000' END \"GERACAO  \", " +
            "Case When f.value >= 0 Then format(f.value,'####.####') ELSE '-999.0000' END \"VELOC    \", " +
            "Case When b.value >= -10 Then format(b.value,'####.####') ELSE '-999.0000' END \"TEMP     \", " +
            "Case When h.value >= 0 Then format(h.value,'####.####') ELSE '-999.0000' END \"PRESS    \", " +
            "Case When g.value >= 0 Then format(g.value,'####.####') ELSE '-999.0000' END \"DIREC    \" " +
            "FROM piarchive..piinterp a, piarchive..piinterp e, piarchive..piinterp f, " +
            "piarchive..piinterp g, piarchive..piinterp h, piarchive..piinterp b, piarchive..piinterp x " +
            "WHERE e.time=a.time AND f.time=a.time AND g.time=a.time AND h.time=a.time AND b.time=a.time AND" +
            "x.time=a.time	AND a.tag='{0}_GE_TOT_MW.v' AND b.tag='{0}_D_EOLICOS_TEMP.v' AND " +
            "e.tag='{0}_34P5_UG1_NUM.v' AND f.tag='{0}_D_EOLICOS_VV.v' AND g.tag='{0}_D_EOLICOS_DV.v' AND " +
            "h.tag='{0}_D_EOLICOS_PATM.v' AND x.tag='{0}_34P5_UG2_NUM.v'	" +
            " AND a.time BETWEEN '{1}' AND '{2}' AND a.timestep = '4s'";

        //public static String sqlCommandPot = "SELECT format(a.time,'dd   MM   yyyy   HH   mm   ss') \"Data \" ," +
        //        "Case When e.value+x.value >= 0 Then format(e.value+x.value,'#####') ELSE '-999' END \"N MAQ \", " +
        //        "Case When a.value >= 0 Then format(a.value,'####.####') ELSE '-999.0000' END \"GERACAO  \" " +
        //        "FROM piarchive..piinterp a, piarchive..piinterp e, piarchive..piinterp x " +
        //       "WHERE e.time=a.time AND " +
        //       "x.time=a.time	AND a.tag='{0}' AND " +
        //         "e.tag='{1}_34P5_UG1_NUM.v' AND " +
        //        "x.tag='{1}_34P5_UG2_NUM.v'	" +
        //        " AND a.time BETWEEN '{2}' AND '{3}' AND a.timestep = '4s'";

        public static String sqlCommandPot = "SELECT format(a.time,'dd   MM   yyyy   HH   mm   ss') \"Data \" ," +
               "Case When a.value >= 0 Then format(a.value,'####.####') ELSE '-999.0000' END \"GERACAO  \" " +
               "FROM piarchive..piinterp a " +
               "WHERE a.tag='{0}' " +
               "AND a.time BETWEEN '{1}' AND '{2}' AND a.timestep = '{3}s'";

        public static int sqlTimeStepInSeconds = 30 ;
    }
}
