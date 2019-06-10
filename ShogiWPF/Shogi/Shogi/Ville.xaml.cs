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
    /// Logique d'interaction pour Ville.xaml
    /// </summary>
    public partial class Ville : Window
    {
        private DAO dao = new DAO();
        PAYS paysHote;
        public Ville(PAYS monPays)
        {
            InitializeComponent();
            foreach (var item in dao.GetVille(monPays))
            {
                listeVille.Items.Add(item);
            }
            paysHote = monPays;
        }

        private void ButPaysAjouter_Click(object sender, RoutedEventArgs e)
        {
            dao.AjoutVille(txtAjoutVille.Text, paysHote.nomPays);
            List<VILLE> listeDbVille = dao.GetAllVille(paysHote);
            foreach (var item in listeDbVille)
            {
                listeVille.Items.Remove(item);
            }
            foreach (var item in listeDbVille)
            {
                listeVille.Items.Add(item);
            }
        }

        private void ButExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButPaysValider_Click(object sender, RoutedEventArgs e)
        {
            if(listeVille.SelectedItem!=null)
            {
                Club club = new Club(listeVille.SelectedItem as VILLE);
                club.Show();

            }
        }

        private void TxtAjoutVille_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MaGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Hand;
        }

        private void MaGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }
    }
}
