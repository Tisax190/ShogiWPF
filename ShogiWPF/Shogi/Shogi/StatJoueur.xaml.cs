using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Shogi
{
    /// <summary>
    /// Logique d'interaction pour StatJoueur.xaml
    /// </summary>
    public partial class StatJoueur : Window
    {
        private DAO dao = new DAO();
        public StatJoueur(JOUEUR joueur)
        {
            InitializeComponent();
            maGrid.DataContext = joueur;

        }

        private void ButExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButModifier_Click(object sender, RoutedEventArgs e)
        {
            if(txtDefaite.Text!="" && txtElo.Text!="" && txtMatch.Text!="" && txtNom.Text!=""&& txtPrenom.Text!=""&&txtVictoire.Text!="")
            {
                JOUEUR tmp = new JOUEUR();
                tmp = maGrid.DataContext as JOUEUR;
                tmp.elo = Convert.ToInt32(txtElo.Text);
                tmp.nbrDefaire = Convert.ToInt32(txtDefaite.Text);
                tmp.nbrMatch = Convert.ToInt32(txtMatch.Text);
                tmp.nbrVictoire = Convert.ToInt32(txtVictoire.Text);
                tmp.nomJoueur = txtNom.Text;
                tmp.prenomJoueur = txtPrenom.Text;
                dao.modifJoueur(tmp);
                maGrid.DataContext = tmp;
            }
        }

        private void ButSupprimer_Click(object sender, RoutedEventArgs e)
        {
            dao.deleteJoueur(maGrid.DataContext as JOUEUR);
            this.Close();
        }
    }
}
