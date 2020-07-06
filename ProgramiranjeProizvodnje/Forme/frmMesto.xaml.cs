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
    /// Interaction logic for frmMesto.xaml
    /// </summary>
    public partial class frmMesto : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmMesto()
        {
            InitializeComponent();
            txtNazivMesta.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if(MainWindow.azuriraj)
                {
                    if (txtNazivMesta.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv mesta.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNazivMesta.Focus();

                    }
                    else if (!Regex.IsMatch(txtNazivMesta.Text, @"^[a-zA-Z ]+$"))
                    {
                        MessageBox.Show("Naziv može da sadrži samo slova.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNazivMesta.Focus();
                    } else if(!Regex.IsMatch(txtPostanskiBroj.Text, @"^[0-9]+$"))
                    {
                        MessageBox.Show("Naziv može da sadrži samo brojeve.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtPostanskiBroj.Focus();
                    }
                    else
                    {
                        DataRowView red = (DataRowView)MainWindow.pomocni;
                        string update = @"Update tblMesto 
                                       set NazivM = '" + txtNazivMesta.Text + "',PostanskiBroj=" + txtPostanskiBroj.Text + " where MestoID=" + red["MestoID"];
                        SqlCommand cmd = new SqlCommand(update, konekcija);
                        cmd.ExecuteNonQuery();
                        MainWindow.pomocni = null;
                        this.Close();
                    }

                } else
                {
                    if (txtNazivMesta.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv mesta.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNazivMesta.Focus();

                    }
                    else if (!Regex.IsMatch(txtNazivMesta.Text, @"^[a-zA-Z ]+$"))
                    {
                        MessageBox.Show("Naziv može da sadrži samo slova.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNazivMesta.Focus();
                    }
                    else if (!Regex.IsMatch(txtPostanskiBroj.Text, @"^[0-9]+$"))
                    {
                        MessageBox.Show("Naziv može da sadrži samo brojeve.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtPostanskiBroj.Focus();
                    }
                    else
                    {
                        string insert = @"insert into tblMesto(NazivM,PostanskiBroj)" +
                        "values('" + txtNazivMesta.Text + "', " + txtPostanskiBroj.Text + ");";
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
