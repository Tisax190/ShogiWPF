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
    /// Logique d'interaction pour Joueur.xaml
    /// </summary>
    public partial class Joueur : Window
    {
        private DAO dao = new DAO();
        private CLUB clubHote;
        public Joueur(CLUB club)
        {
            InitializeComponent();
            clubHote = club;
            foreach (var item in dao.GetAllJoueur(clubHote))
            {
                listeJoueur.Items.Add(item);
            }
        }

        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListeJoueur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            maGrid.DataContext = listeJoueur.SelectedItem;
        }

        private void BtAjout_Click(object sender, RoutedEventArgs e)
        {
            JOUEUR joueur = new JOUEUR();
            joueur.nomJoueur = txtNom.Text;
            joueur.prenomJoueur = txtPrenom.Text;
            joueur.nbrMatch = Convert.ToInt32(txtMatch.Text);
            joueur.nbrVictoire = Convert.ToInt32(txtVictoire.Text);
            joueur.nbrDefaire = Convert.ToInt32(txtDefaite.Text);
            joueur.elo = Convert.ToInt32(txtElo.Text);
            dao.AjoutJoueur(joueur,clubHote.nomClub);
            List<JOUEUR> listeDbJoueur = dao.GetAllJoueur(clubHote);
            foreach (var item in listeDbJoueur)
            {
                listeJoueur.Items.Remove(item);
            }
            foreach (var item in listeDbJoueur)
            {
                listeJoueur.Items.Add(item);
            }
        }

        private void BtValider_Click(object sender, RoutedEventArgs e)
        {
            if(listeJoueur.SelectedItem!=null)
            {
                StatJoueur joueur = new StatJoueur(listeJoueur.SelectedItem as JOUEUR);
                joueur.Show();

            }
        }

        private void TxtElo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) e.Handled = true; // nouveautée 1
            else e.Handled = false;
        }

        private void TxtDefaite_KeyDown(object sender, KeyEventArgs e)
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

        private void MaGrid_MouseEnter(object sender, MouseEventArgs e) // nouveautée 2
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        private void MaGrid_MouseLeave(object sender, MouseEventArgs e) // nouveautée 2
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
