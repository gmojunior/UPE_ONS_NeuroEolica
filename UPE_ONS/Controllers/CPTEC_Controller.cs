using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPE_ONS.DAO;
using UPE_ONS.Model;

namespace UPE_ONS.Controllers
{
    class CPTEC_Controller
    {
        public void importarArquivoNovo(string caminho, int idParqueEolico)
        {
            FactoryDAO.getInstance().CPTECDAO.importarArquivoNovo(caminho, idParqueEolico);
        }

        public List<ParqueEolicoImportacaoCPTEC> getDadosImportados(int idParqueEolico, int limit)
        {
            return FactoryDAO.getInstance().CPTECDAO.SelectDataImported(idParqueEolico, limit);
        }
    }
}
