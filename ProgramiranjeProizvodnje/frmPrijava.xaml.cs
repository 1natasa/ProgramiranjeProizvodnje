using System;
using System.Collections.Generic;
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

namespace ProgramiranjeProizvodnje
{
    /// <summary>
    /// Interaction logic for frmPrijava.xaml
    /// </summary>
    public partial class frmPrijava : Window
    {
        frmRegistracija registracija = new frmRegistracija();

        SqlCommand cmd;
        public static string passingUserId;
        public static string passingPassword;

        
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmPrijava()
        {
            InitializeComponent();
            txtKorisnickoIme.Focus();
        }

        

        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            registracija.Show();
            Close();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            String message2 = "Morate popuniti sva polja!";
            String message1 = "Uneti podaci nisu odgovarajući!";
            String message3 = "Pokušajte ponovo!";

            string encusr = AesCryp.Encrypt(txtKorisnickoIme.Text);
            string encpass = AesCryp.Encrypt(txtPassword.Password.ToString());

            passingUserId = encusr;
            passingPassword = encpass;

            konekcija.Open();
            cmd = new SqlCommand("select * from tblRadnik where Username='" + encusr + "' and Password='" + encpass + "'", konekcija);
            SqlDataReader dr = cmd.ExecuteReader();

            if (txtKorisnickoIme.Text.Length == 0 || txtPassword.Password.Length == 0)
            {
                MessageBox.Show(message2, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string log = dr["Uloga"].ToString();
                    if (log == "Admin")
                    {

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        mainWindow.rola.Text = "Administrator";
                        

                        this.Close();
                    }
                    else if (log == "Korisnik" || log == "")
                    {
                        MainWindow mainWindow2 = new MainWindow();
                        mainWindow2.Show();
                        mainWindow2.btnRadnik.Visibility = Visibility.Collapsed;
                        mainWindow2.btnIzmeniRadnika.Visibility = Visibility.Collapsed;
                        mainWindow2.btnObrisiRadnika.Visibility = Visibility.Collapsed;
                        mainWindow2.btnDodajRadnika.Visibility = Visibility.Collapsed;

                        mainWindow2.rola.Text = "Zaposleni";
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(message3, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(message1, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            dr.Close();
            konekcija.Close();
        }
    }
}
