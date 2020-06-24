﻿using System;
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
    /// Interaction logic for frmRadnik.xaml
    /// </summary>
    public partial class frmRadnik : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmRadnik()
        {
            InitializeComponent();
            txtImeRadnika.Focus();

            try
            {
                konekcija.Open();
                string vratiMesto = "select MestoID, NazivM as 'Grad' from tblMesto";
                DataTable dtMesto = new DataTable();
                SqlDataAdapter daMesto = new SqlDataAdapter(vratiMesto, konekcija);
                daMesto.Fill(dtMesto);
                cbxMesto.ItemsSource = dtMesto.DefaultView;

                string vratiRadnoMesto = "select RadnoMestoID, NazivRM as 'Radno mesto' from tblRadnoMesto";
                DataTable dtRadnoMesto = new DataTable();
                SqlDataAdapter daRadnoMesto = new SqlDataAdapter(vratiRadnoMesto, konekcija);
                daRadnoMesto.Fill(dtRadnoMesto);
                cbxRadnoMesto.ItemsSource = dtRadnoMesto.DefaultView;

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
                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string update = @"Update tblRadnik set ImeR='" + txtImeRadnika.Text + "', PrezimeR= '" + txtPrezimeRadnika.Text + "', JMBG_R='" + txtJMBGRadnika.Text + "', TelefonR='" + txtTelefonRadnika.Text + "', AdresaR='" + txtAdresaRadnika.Text + "', MestoID=" + cbxMesto.SelectedValue + ", RadnoMestoID=" + cbxRadnoMesto.SelectedValue + ", PogonID=" + cbxPogon.SelectedValue + ", Status = '" + Convert.ToInt32(chkStatus.IsChecked) + "' where RadnikID=" + red["RadnikID"];

                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                    


                } else
                {
                    string insert = @"insert into tblRadnik(ImeR, PrezimeR, JMBG_R, TelefonR, AdresaR, MestoID, RadnoMestoID, PogonID, Status)" +
                        "values('"+ txtImeRadnika.Text +"'," +
                        " '"+ txtPrezimeRadnika.Text + "'," +
                        " '"+ txtJMBGRadnika.Text +"', '"+ txtTelefonRadnika.Text + "'," +
                        " '"+ txtAdresaRadnika.Text +"', "+ cbxMesto.SelectedValue +"," +
                        " "+ cbxRadnoMesto.SelectedValue +", "+ cbxPogon.SelectedValue +", 1 ); ";
                    lblStatus.Visibility = Visibility.Collapsed;
                    chkStatus.Visibility = Visibility.Collapsed;

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
