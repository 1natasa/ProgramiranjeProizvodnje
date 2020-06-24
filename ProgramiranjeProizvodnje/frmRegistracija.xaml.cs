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

namespace ProgramiranjeProizvodnje
{
    /// <summary>
    /// Interaction logic for frmRegistracija.xaml
    /// </summary>
    public partial class frmRegistracija : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmRegistracija()
        {
            InitializeComponent();
            txtIme.Focus();
        
        }

        public void Reset()
        {
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtTelefon.Text = "";
            txtAdresa.Text = "";
            txtEmail.Text = "";
            txtJMBG.Text = "";
            txtUsername.Text = "";
            txtPassword.Password = "";
            txtPotvrdiPassword.Password = "";
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Unesite e-adresu.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmail.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("Unesite validnu e-adresu.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();
            }
            else if (txtUsername.Text.Length == 0)
            {
                MessageBox.Show("Unesite korisničko ime.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUsername.Focus(); 
            }
            else if (txtTelefon.Text.Length == 0)
            {
                MessageBox.Show("Unesite telefon.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtTelefon.Focus();
            }
            else
            {
                if (txtPassword.Password.Length == 0)
                {

                    MessageBox.Show("Unesite lozinku.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Focus();
                }
                else if (txtPotvrdiPassword.Password.Length == 0)
                {
                    MessageBox.Show("Potvrdite lozinku.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPotvrdiPassword.Focus();
                }
                else if (txtPassword.Password != txtPotvrdiPassword.Password)
                {
                    MessageBox.Show("Lozinke se ne poklapaju.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPotvrdiPassword.Focus();
                }

                else
                {
                    string encusr = AesCryp.Encrypt(txtUsername.Text);
                    string encpass = AesCryp.Encrypt(txtPassword.Password);
                    konekcija.Open();
                    SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [tblRadnik] WHERE ([Username] = @encusr)", konekcija);
                    check_User_Name.Parameters.AddWithValue("@encusr", encusr);
                    int UserExist = (int)check_User_Name.ExecuteScalar();

                    if (UserExist > 0)
                    {
                        MessageBox.Show("Korisničko ime već postoji.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtUsername.Focus();
                        konekcija.Close();
                    }
                    else
                    {
                        message.Text = "";
                        SqlCommand cmd2 = new SqlCommand("Insert into tblRadnik (ImeR,PrezimeR,Username, Password, JMBG_R,TelefonR, AdresaR, Email, RadnoMestoID, MestoID, PogonID, Status) values('" + txtIme.Text + "','" + txtPrezime.Text + "','" + encusr + "','" + encpass + "','" + txtJMBG.Text + "','" + txtTelefon.Text + "','" + txtAdresa.Text + "','" + txtEmail.Text +"', 1,1,1,0)", konekcija);
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                        konekcija.Close();
                        message.Text = "Uspešna registracija. " + "Dobrodošli, " + txtIme.Text + "!";
                        Reset();
                    }
                }
            }
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            frmPrijava prijava = new frmPrijava();
            prijava.Show();
            Close();
        }

        private void btnPrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            frmPrijava prijava = new frmPrijava();
            prijava.Show();
            Close();
        }
    }
}
