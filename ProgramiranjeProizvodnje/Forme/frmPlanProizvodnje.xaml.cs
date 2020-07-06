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
    /// Interaction logic for frmPlanProizvodnje.xaml
    /// </summary>
    public partial class frmPlanProizvodnje : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmPlanProizvodnje()
        {
            InitializeComponent();
            txtOznaka.Focus();

            try
            {
                konekcija.Open();
                string vratiRadnika = "select RadnikID, ImeR + ' ' + PrezimeR as 'Radnik' from tblRadnik";
                DataTable dtRadnik = new DataTable();
                SqlDataAdapter daRadnik = new SqlDataAdapter(vratiRadnika, konekcija);
                daRadnik.Fill(dtRadnik);
                cbxRadnik.ItemsSource = dtRadnik.DefaultView;
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
                    if (txtOznaka.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv oznake.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtOznaka.Focus();

                    }
                    else if (!Regex.IsMatch(txtKolicina.Text, @"^[0-9]+$"))
                    {
                        MessageBox.Show("Količina može da sadrži samo brojeve.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtKolicina.Focus();
                    }
                    else
                    {
                        DataRowView red = (DataRowView)MainWindow.pomocni;
                        string update = @"Update tblPlanProizvodnje
                                    set OznakaP='" + txtOznaka.Text + "', Datum= '" + dpDatum.SelectedDate + "', Kolicina=" + txtKolicina.Text + ", Napomena='" + txtNapomena.Text + "', RadnikID=" + cbxRadnik.SelectedValue + " where PlanProizvodnjeID=" + red["PlanProizvodnjeID"];
                        SqlCommand cmd = new SqlCommand(update, konekcija);
                        cmd.ExecuteNonQuery();
                        MainWindow.pomocni = null;
                        this.Close();
                    }

                }
                else
                {
                    if (txtOznaka.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv oznake.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtOznaka.Focus();

                    }
                    else if (!Regex.IsMatch(txtKolicina.Text, @"^[0-9]+$"))
                    {
                        MessageBox.Show("Količina može da sadrži samo brojeve.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtKolicina.Focus();
                    }
                    else
                    {
                        string insert = @"insert into tblPlanProizvodnje (OznakaP, Datum, Kolicina, Napomena, RadnikID) values('" + txtOznaka.Text + "','" + dpDatum.SelectedDate + "', " + txtKolicina.Text + ", '" + txtNapomena.Text + "', " + cbxRadnik.SelectedValue + ")";
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
