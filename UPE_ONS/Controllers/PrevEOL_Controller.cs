using System;
using System.Collections.Generic;
using System.IO;
using UPE_ONS.DAO;
using UPE_ONS.Model;
using UPE_ONS.Util;

namespace UPE_ONS.Controllers
{
    class PrevEOL_Controller
    {
        public List<ParqueEolicoImportacaoPrevEOL> getDadosImportados(int idParqueEolico, int limite, 
            bool verTodosOsAtributos, string intervalo)
        {
            return FactoryDAO.getInstance().PrevEOLDAO.getDadosImportados(idParqueEolico, limite, 
                verTodosOsAtributos, intervalo);
        }
    }
}
