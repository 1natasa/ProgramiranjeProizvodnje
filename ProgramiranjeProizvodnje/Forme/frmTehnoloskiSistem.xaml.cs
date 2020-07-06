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
    /// Interaction logic for frmTehnoloskiSistem.xaml
    /// </summary>
    public partial class frmTehnoloskiSistem : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmTehnoloskiSistem()
        {
            InitializeComponent();
            txtOznakaTehnoloskogSistema.Focus();

            try
            {
                konekcija.Open();
                string vratiPogon = "select PogonID, OznakaP as 'Oznaka pogona' from tblPogon";
                DataTable dtPogon = new DataTable();
                SqlDataAdapter daPogon = new SqlDataAdapter(vratiPogon, konekcija);
                daPogon.Fill(dtPogon);
                cbxPogon.ItemsSource = dtPogon.DefaultView;
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
                    if (txtNazivTehnoloskogSistema.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv tehnološkog sistema.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNazivTehnoloskogSistema.Focus();

                    }
                    else if (txtOznakaTehnoloskogSistema.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite oznaku tehnološkog sistema.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtOznakaTehnoloskogSistema.Focus();
                    }
                    else
                    {
                        DataRowView red = (DataRowView)MainWindow.pomocni;
                        string update = @"Update tblTehnoloskiSistem set OznakaTS='" + txtOznakaTehnoloskogSistema.Text + "', NazivTS='" + txtNazivTehnoloskogSistema.Text + "', PogonID=" + cbxPogon.SelectedValue + " where TehnoloskiSistemID=" + red["TehnoloskiSistemID"];
                        SqlCommand cmd = new SqlCommand(update, konekcija);
                        cmd.ExecuteNonQuery();
                        MainWindow.pomocni = null;
                        this.Close();
                    }
                } else
                {
                    if (txtNazivTehnoloskogSistema.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite naziv tehnološkog sistema.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtNazivTehnoloskogSistema.Focus();

                    }
                    else if (txtOznakaTehnoloskogSistema.Text.Length == 0)
                    {
                        MessageBox.Show("Unesite oznaku tehnološkog sistema.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtOznakaTehnoloskogSistema.Focus();
                    }
                    else
                    {
                        string insert = @"insert into tblTehnoloskiSistem(OznakaTS, NazivTS, PogonID) 
                            values('" + txtOznakaTehnoloskogSistema.Text + "', '" + txtNazivTehnoloskogSistema.Text + "', " + cbxPogon.SelectedValue + ")";
                        SqlCommand cmd = new SqlCommand(insert, konekcija);
                        cmd.ExecuteNonQuery();
                        this.Close();
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos određenih podataka nije validan!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
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
