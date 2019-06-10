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
    /// Logique d'interaction pour Club.xaml
    /// </summary>
    public partial class Club : Window
    {
        private DAO dao = new DAO();
        VILLE maVilleHote;
        public Club(VILLE maVille)
        {
            InitializeComponent();
            maVilleHote = maVille;
            foreach (var item in dao.GetAllClub(maVilleHote))
            {
                listeClub.Items.Add(item);
            }
        }

        private void ButAjoutClub_Click(object sender, RoutedEventArgs e)
        {
            if(txtNom.Text !="" && txtRue.Text !="" && txtTel.Text !="")
            {
                CLUB club = new CLUB();
                club.nomClub = txtNom.Text;
                club.numClub = Convert.ToInt32(txtTel.Text); // ATTENTION BLOQUER LES LETTRES
                club.rueClub = txtRue.Text;
                dao.AjoutClub(club, maVilleHote.nomVille);

                List<CLUB> listeDbClub = dao.GetAllClub(maVilleHote);
                foreach (var item in listeDbClub)
                {
                    listeClub.Items.Remove(item);
                }
                foreach (var item in listeDbClub)
                {
                    listeClub.Items.Add(item);
                }
            }
        }

        private void ButExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtValid_Click(object sender, RoutedEventArgs e)
        {
            Joueur joueur = new Joueur(listeClub.SelectedItem as CLUB);
            joueur.Show();
        }

        private void ListeClub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            maGrid.DataContext = listeClub.SelectedItem;
        }
    }
}
