using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace ProgramiranjeProizvodnje.Forme
{
    /// <summary>
    /// Interaction logic for frmRadnoMesto.xaml
    /// </summary>
    public partial class frmRadnoMesto : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmRadnoMesto()
        {
            InitializeComponent();
            txtNazivRadnogMesta.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj)
                {
                    if (txtNazivRadnogMesta.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv radnog mesta.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNazivRadnogMesta.Focus();

                    }
                    else
                    {
                        DataRowView red = (DataRowView)MainWindow.pomocni;
                        string update = @"Update tblRadnoMesto
                                       set NazivRM='" + txtNazivRadnogMesta.Text + "' where RadnoMestoID = " + red["RadnoMestoID"];
                        SqlCommand cmd = new SqlCommand(update, konekcija);
                        cmd.ExecuteNonQuery();
                        MainWindow.pomocni = null;
                        this.Close();
                    }
                    

                } else
                {
                    if (txtNazivRadnogMesta.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv radnog mesta.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNazivRadnogMesta.Focus();

                    }
                    else
                    {
                        string insert = @"insert into tblRadnoMesto(NazivRM) values('" + txtNazivRadnogMesta.Text + "');";
                        SqlCommand cmd = new SqlCommand(insert, konekcija);
                        cmd.ExecuteNonQuery();
                        this.Close();
                    }
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("Unos određenih podataka nije validan!", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }

        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
