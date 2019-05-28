using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shogi
{
    class DAO
    {
        private BddContext bdd;
        public DAO()
        {
            bdd = new BddContext();
        }
        public List<PAYS> GetAllPays()
        {
            return bdd.PAYS.ToList();
        }
        public bool AjoutPays(string nomPays)
        {
            PAYS monPays = new PAYS();
            monPays.nomPays = nomPays;
            try
            {
                bdd.PAYS.Add(monPays);
                bdd.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

