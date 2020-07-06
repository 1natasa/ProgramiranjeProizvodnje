using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for frmMaterijal.xaml
    /// </summary>
    public partial class frmMaterijal : Window
    {

        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmMaterijal()
        {
            InitializeComponent();
            try
            {
                    konekcija.Open();
                    string vratiSkladiste = "select SkladisteID, OznakaS + ', ' + LokacijaS as 'Skladiste' from tblSkladiste";
                    DataTable dtSkladiste = new DataTable();
                    SqlDataAdapter daSkladiste = new SqlDataAdapter(vratiSkladiste, konekcija);
                    daSkladiste.Fill(dtSkladiste);
                    cbxSkladiste.ItemsSource = dtSkladiste.DefaultView;

            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //.Text stavimo kad imamo broj
                //

                konekcija.Open();

                if (MainWindow.azuriraj)
                {
                    if (txtVrstaM.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv vrste.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtVrstaM.Focus();

                    }
                    else if (!Regex.IsMatch(txtVrstaM.Text, @"^[a-zA-Z ]+$"))
                    {
                        MessageBox.Show("Naziv može da sadrži samo slova.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtVrstaM.Focus();
                    }
                    else
                    {
                        DataRowView red = (DataRowView)MainWindow.pomocni;

                        string update = @"Update tblMaterijal set VrstaM='" + txtVrstaM.Text + "', SkladisteID=" + cbxSkladiste.SelectedValue + " where MaterijalID=" + red["MaterijalID"];
                        SqlCommand cmd = new SqlCommand(update, konekcija);
                        cmd.ExecuteNonQuery();
                        MainWindow.pomocni = null;
                        this.Close();
                    }
                    
                }
                else
                {
                    if (txtVrstaM.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv vrste.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtVrstaM.Focus();

                    }
                    else if (!Regex.IsMatch(txtVrstaM.Text, @"^[a-zA-Z ]+$"))
                    {
                        MessageBox.Show("Naziv može da sadrži samo slova.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtVrstaM.Focus();
                    }
                    else
                    {
                        string insert = @"insert into tblMaterijal(VrstaM, SkladisteID) values('" + txtVrstaM.Text + "', " + cbxSkladiste.SelectedValue + " )";
                        SqlCommand cmd = new SqlCommand(insert, konekcija);
                        cmd.ExecuteNonQuery();
                        this.Close(); //ovo zatvara formu
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
