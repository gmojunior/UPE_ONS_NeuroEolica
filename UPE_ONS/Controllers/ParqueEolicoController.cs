using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPE_ONS.DAO;
using UPE_ONS.Model;

namespace UPE_ONS.Controllers
{
    // Classe controladora da parte de gerenciamento de parques eólicos.
    class ParqueEolicoController
    {
        private ParqueEolicoDAO ParqueEolicoDAO;

        public ParqueEolicoController()
        {
            this.ParqueEolicoDAO = FactoryDAO.getInstance().ParqueEolicoDAO;
        }

        public void cadastrar(ParqueEolico parque)
        {
            if (!ParqueEolicoDAO.Exists(parque))
                ParqueEolicoDAO.Insert(parque);
            else
                throw new Exception("Já existe um parque eólico cadastrado com o nome ou código informado.");
        }

        public void atualizar(ParqueEolico parque)
        {
            if (!ParqueEolicoDAO.Exists(parque))
                ParqueEolicoDAO.Update(parque);
            else
                throw new Exception("Já existe um parque eólico cadastrado com o nome ou código informado.");
        }

        public void Delete(ParqueEolico parque)
        {
            ParqueEolicoDAO.Delete(parque);
        }

        public List<ParqueEolico> getAll()
        {
            return ParqueEolicoDAO.SelectAll();
        }

        internal IEnumerable<ParqueEolico> getAll_LEFT(string tipo)
        {
            return ParqueEolicoDAO.SelectAll_LEFT(tipo);
        }

        internal IEnumerable<ParqueEolico> getParquesCalibrados(string tipo)
        {
            return ParqueEolicoDAO.getParquesCalibrados(tipo);
        }
    }
}