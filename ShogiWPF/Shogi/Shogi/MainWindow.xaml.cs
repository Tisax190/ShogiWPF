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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shogi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DAO dao = new DAO();
        public MainWindow()
        {
            InitializeComponent();
            List<PAYS> listeDbPays = dao.GetAllPays();
            foreach (var item in listeDbPays)
            {
                listePays.Items.Add(item);
            }
        }

        private void ButExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtAjoutVille_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButPaysAjouter_Click(object sender, RoutedEventArgs e)
        {
            dao.AjoutPays(txtAjoutPays.Text);
            List<PAYS> listeDbPays = dao.GetAllPays();
            foreach (var item in listeDbPays)
            {
                listePays.Items.Remove(item);
            }
            foreach (var item in listeDbPays)
            {
                listePays.Items.Add(item);
            }

        }

        private void ButPaysValider_Click(object sender, RoutedEventArgs e)
        {
            if(listePays.SelectedItem!=null)
            {
                Ville fenetre = new Ville(listePays.SelectedItem as PAYS);
                fenetre.Show();

            }
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
