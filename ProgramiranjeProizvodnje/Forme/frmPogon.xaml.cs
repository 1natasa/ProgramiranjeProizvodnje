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
    /// Interaction logic for frmPogon.xaml
    /// </summary>
    public partial class frmPogon : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmPogon()
        {
            InitializeComponent();
            txtOznakaPogona.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if(MainWindow.azuriraj)
                {
                    if (txtOznakaPogona.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv oznake.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtOznakaPogona.Focus();

                    }
                    
                    else
                    {
                        DataRowView red = (DataRowView)MainWindow.pomocni;
                        string update = @"Update tblPogon set OznakaP='" + txtOznakaPogona.Text + "' where PogonID=" + red["PogonID"];
                        SqlCommand cmd = new SqlCommand(update, konekcija);
                        cmd.ExecuteNonQuery();
                        MainWindow.pomocni = null;
                        this.Close();
                    }

                } else
                {
                    if (txtOznakaPogona.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv oznake.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtOznakaPogona.Focus();

                    }

                    else
                    {
                        string insert = "insert into tblPogon(OznakaP) values('" + txtOznakaPogona.Text + "')";
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
