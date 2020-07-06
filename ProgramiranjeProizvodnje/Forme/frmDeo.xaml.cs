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
    /// Interaction logic for frmDeo.xaml
    /// </summary>
    public partial class frmDeo : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmDeo()
        {
            InitializeComponent();
            txtNaziv.Focus();

            try
            {
                konekcija.Open();
                string vratiProizvod = "select ProizvodID, NazivP + ', ' + VrstaProizvoda as 'Proizvod' from tblProizvod ";
                DataTable dtProizvod = new DataTable();
                SqlDataAdapter daProizvod = new SqlDataAdapter(vratiProizvod, konekcija);
                daProizvod.Fill(dtProizvod);
                cbxProizvod.ItemsSource = dtProizvod.DefaultView;

                
                string vratiMaterijal = "select MaterijalID, VrstaM as 'Materijal' from tblMaterijal ";
                DataTable dtMaterijal = new DataTable();
                SqlDataAdapter daMaterijal = new SqlDataAdapter(vratiMaterijal, konekcija);
                daMaterijal.Fill(dtMaterijal);
                cbxMaterijal.ItemsSource = dtMaterijal.DefaultView;
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
                konekcija.Open();
                if (MainWindow.azuriraj)
                {

                    if(txtNaziv.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNaziv.Focus();

                    } else if(!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z ]+$"))
                    {
                        MessageBox.Show("Naziv može da sadrži samo slova.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNaziv.Focus();
                    }
                    else
                    {
                        DataRowView red = (DataRowView)MainWindow.pomocni;
                        string update = @"Update tblDeo set NazivD='" + txtNaziv.Text + "', ProizvodID=" + cbxProizvod.SelectedValue + ", MaterijalID=" + cbxMaterijal.SelectedValue + " where DeoID=" + red["DeoID"];
                        SqlCommand cmd = new SqlCommand(update, konekcija);
                        cmd.ExecuteNonQuery();
                        MainWindow.pomocni = null;
                        this.Close();
                    }
                    

                }
                else
                {

                    if (txtNaziv.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNaziv.Focus();

                    }
                    else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z ]+$"))
                    {
                        MessageBox.Show("Naziv može da sadrži samo slova.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNaziv.Focus();
                    }
                    else
                    {
                        string insert = @"insert into tblDeo(NazivD, ProizvodID, MaterijalID) values('" + txtNaziv.Text + "', " + cbxProizvod.SelectedValue + ", " + cbxMaterijal.SelectedValue + ")";

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
