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

        private void TxtElo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; // nouveautée 1
            else e.Handled = false;
        }

        private void TxtMatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; // nouveautée 1
            else e.Handled = false;
        }

        private void TxtVictoire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; // nouveautée 1
            else e.Handled = false;
        }

        private void TxtDefaite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; // nouveautée 1
            else e.Handled = false;
        }
        private void MaGrid_MouseEnter(object sender, MouseEventArgs e) // nouveautée 2
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        private void MaGrid_MouseLeave(object sender, MouseEventArgs e)// nouveautée 2
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void MaGrid_MouseEnter_1(object sender, MouseEventArgs e)
        {

        }

        private void MaGrid_MouseLeave_1(object sender, MouseEventArgs e)
        {

        }
    }
}
