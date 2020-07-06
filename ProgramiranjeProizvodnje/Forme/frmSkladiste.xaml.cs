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
    /// Interaction logic for frmSkladiste.xaml
    /// </summary>
    public partial class frmSkladiste : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmSkladiste()
        {
            InitializeComponent();
            txtOznakaS.Focus();

            try
            {
                konekcija.Open();
                string vratiMesto = "select MestoID, NazivM as Mesto from tblMesto";
                DataTable dtMesto = new DataTable();
                SqlDataAdapter daMesto = new SqlDataAdapter(vratiMesto, konekcija);
                daMesto.Fill(dtMesto);
                cbxMesto.ItemsSource = dtMesto.DefaultView;

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
                if(MainWindow.azuriraj)
                {
                    if (txtOznakaS.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite oznaku skladišta.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtOznakaS.Focus();

                    } else if(txtLokacijaS.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite lokaciju skladišta.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtLokacijaS.Focus();
                    } 
                    else
                    {
                        DataRowView red = (DataRowView)MainWindow.pomocni;

                        string update = @"Update tblSkladiste set OznakaS= '" + txtOznakaS.Text + "', LokacijaS='" + txtLokacijaS.Text + "', MestoID=" + cbxMesto.SelectedValue + " where SkladisteID=" + red["SkladisteID"];
                        SqlCommand cmd = new SqlCommand(update, konekcija);
                        cmd.ExecuteNonQuery();
                        MainWindow.pomocni = null;
                        this.Close();

                    }
                    

                } else
                {
                    if (txtOznakaS.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite oznaku skladišta.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtOznakaS.Focus();

                    }
                    else if (txtLokacijaS.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite lokaciju skladišta.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtLokacijaS.Focus();
                    }
                    else
                    {
                        string insert = @"insert into tblSkladiste(OznakaS, LokacijaS, MestoID) values('" + txtOznakaS.Text + "', '" + txtLokacijaS.Text + "', " + cbxMesto.SelectedValue + ");";
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
