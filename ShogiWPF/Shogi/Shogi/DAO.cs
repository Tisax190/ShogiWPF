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
        // PAYS
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
        public PAYS GetPays(string nom)
        {
            return bdd.PAYS.Where(x => x.nomPays == nom).FirstOrDefault();
        }
        // VILLE
        public List<VILLE> GetAllVille(PAYS monPays)
        {
            return bdd.VILLE.Where(x => x.PAYS.nomPays == monPays.nomPays).ToList();
        }
        public List<VILLE> GetVille(PAYS pays)
        {
            return bdd.VILLE.Where(x => x.PAYS.nomPays == pays.nomPays).ToList();
        }
        public VILLE GetVille(string pays)
        {
            return bdd.VILLE.Where(x => x.PAYS.nomPays == pays).FirstOrDefault();
        }
        public VILLE GetVilleNom(string nomVille)
        {
            return bdd.VILLE.Where(x => x.nomVille == nomVille).FirstOrDefault();
        }
        public bool AjoutVille(string nomVille , string nomPays)
        {
            VILLE monVille = new VILLE();
            monVille.nomVille = nomVille;
            monVille.PAYS = this.GetPays(nomPays);
            try
            {
                bdd.VILLE.Add(monVille);
                bdd.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        // méthode génrique aurait été plus simple , CLUB
        public CLUB GetCLUB(string nom)
        {
            return bdd.CLUB.Where(x => x.nomClub == nom).FirstOrDefault();
        }
        public bool AjoutClub(CLUB monCLUB, string nomVille)
        {
            monCLUB.VILLE = this.GetVilleNom(nomVille);
            monCLUB.idVille = monCLUB.VILLE.idVille;
            try
            {
                bdd.CLUB.Add(monCLUB);
                bdd.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public List<CLUB> GetAllClub(VILLE monVille)
        {
            return bdd.CLUB.Where(x => x.VILLE.idVille == monVille.idVille).ToList();
        }
        // JOUEURS
        public JOUEUR GetJoueur(string nom)
        {
            return bdd.JOUEUR.Where(x => x.nomJoueur == nom).FirstOrDefault();
        }
        public bool AjoutJoueur(JOUEUR monJoueur, string nomClub)
        {
            monJoueur.CLUB = this.GetCLUB(nomClub);
            monJoueur.idClub = monJoueur.CLUB.idClub;
            try
            {
                bdd.JOUEUR.Add(monJoueur);
                bdd.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public List<JOUEUR> GetAllJoueur(CLUB monClub)
        {
            return bdd.JOUEUR.Where(x => x.CLUB.idClub == monClub.idClub).ToList();
        }
        // Stat joueur
        public bool modifJoueur(JOUEUR joueur)
        {
            try
            {
                JOUEUR tmp = bdd.JOUEUR.Where(x => x.idJoueur == joueur.idJoueur).FirstOrDefault();
                tmp.nbrDefaire = joueur.nbrDefaire;
                tmp.nbrMatch = joueur.nbrVictoire + joueur.nbrDefaire;
                tmp.nbrVictoire = joueur.nbrVictoire;
                tmp.nomJoueur = joueur.nomJoueur;
                tmp.prenomJoueur = joueur.prenomJoueur;
                tmp.elo = joueur.elo;
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteJoueur(JOUEUR joueur)
        {
            try
            {
                bdd.JOUEUR.Remove(GetJoueur(joueur.nomJoueur));
                bdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

