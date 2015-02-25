using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPE_ONS.DAO
{
    public interface IDAO
    {
        void Insert(object element);
        void Update(object element);
        void Delete(object parque);
        List<object> SelectAll();
    }
}
