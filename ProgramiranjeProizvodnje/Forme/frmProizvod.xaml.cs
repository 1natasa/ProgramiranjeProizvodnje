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
    /// Interaction logic for frmProizvod.xaml
    /// </summary>
    public partial class frmProizvod : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmProizvod()
        {
            InitializeComponent();
            txtNaziv.Focus();
            try
            {
                konekcija.Open();
                string vratiPlanProizvodnje = "select PlanProizvodnjeID,OznakaP as 'Plan proizvodnje' from tblPlanProizvodnje";
                DataTable dtPlanProizvodnje = new DataTable();
                SqlDataAdapter daPlanProizvodnje = new SqlDataAdapter(vratiPlanProizvodnje, konekcija);
                daPlanProizvodnje.Fill(dtPlanProizvodnje);
                cbxPlanProizvodnje.ItemsSource = dtPlanProizvodnje.DefaultView;
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
                    DataRowView red = (DataRowView)MainWindow.pomocni;
                    
                    string update=@"update tblProizvod set VrstaProizvoda='" + txtVrsta.Text +"', NazivP='"+txtNaziv.Text + "', Cena=" + txtCena.Text +", Boja= '"+ txtBoja.Text +"', PlanProizvodnjeID="+cbxPlanProizvodnje.SelectedValue +" where ProizvodID=" + red["ProizvodID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                }
                else
                {
                    string insert = @"insert into tblProizvod(VrstaProizvoda, NazivP,Cena, Boja, PlanProizvodnjeID) values('"+ txtVrsta.Text +"', '"+txtNaziv.Text +"', "+txtCena.Text+", '"+txtBoja.Text +"', '"+cbxPlanProizvodnje.SelectedValue +"')";
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih podataka nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
