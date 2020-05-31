﻿using ProgramiranjeProizvodnje.Forme;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgramiranjeProizvodnje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public static bool azuriraj;
        public static object pomocni;
        public MainWindow()
        {
            InitializeComponent();
            PocetniDataGrid(dataGridCentralni);
        }

        private void PocetniDataGrid(DataGrid dg)
        {
            try
            {
                string upit = "select PlanProizvodnjeID, Datum, Kolicina, Napomena, r.RadnikID as 'Radnik' " +
                    "from tblPlanProizvodnje pp" +
                    " inner join tblRadnik r on pp.RadnikID=r.RadnikID ";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("tblPlanProizvodnje");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnRadnoMesto_Click(object sender, RoutedEventArgs e)
        {
            btnDodajRadnoMesto.Visibility = Visibility.Visible;
            btnIzmeniRadnoMesto.Visibility = Visibility.Visible;
            btnObrisiRadnoMesto.Visibility = Visibility.Visible;

            btnDodajRadnika.Visibility = Visibility.Collapsed;
            btnIzmeniRadnika.Visibility = Visibility.Collapsed;
            btnObrisiRadnika.Visibility = Visibility.Collapsed;

            btnDodajMesto.Visibility = Visibility.Collapsed;
            btnIzmeniMesto.Visibility = Visibility.Collapsed;
            btnObrisiMesto.Visibility = Visibility.Collapsed;

            btnDodajPogon.Visibility = Visibility.Collapsed;
            btnIzmeniPogon.Visibility = Visibility.Collapsed;
            btnObrisiPogon.Visibility = Visibility.Collapsed;

            btnDodajTehnoloskiSistem.Visibility = Visibility.Collapsed;
            btnIzmeniTehnoloskiSistem.Visibility = Visibility.Collapsed;
            btnObrisiTehnoloskiSistem.Visibility = Visibility.Collapsed;

            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;

            btnDodajDeo.Visibility = Visibility.Collapsed;
            btnIzmeniDeo.Visibility = Visibility.Collapsed;
            btnObrisiDeo.Visibility = Visibility.Collapsed;

            btnDodajMaterijal.Visibility = Visibility.Collapsed;
            btnIzmeniMaterijal.Visibility = Visibility.Collapsed;
            btnObrisiMaterijal.Visibility = Visibility.Collapsed;

            btnDodajSkaldiste.Visibility = Visibility.Collapsed;
            btnIzmeniSkladiste.Visibility = Visibility.Collapsed;
            btnObrisiSkladiste.Visibility = Visibility.Collapsed;


            konekcija.Open();
            try
            {
                string upit = "select RadnoMestoID, NazivRM from tblRadnoMesto";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("tblRadnoMesto");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }






        }

        private void btnRadnik_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMesto_Click(object sender, RoutedEventArgs e)
        {
            btnDodajRadnoMesto.Visibility = Visibility.Collapsed;
            btnIzmeniRadnoMesto.Visibility = Visibility.Collapsed;
            btnObrisiRadnoMesto.Visibility = Visibility.Collapsed;

            btnDodajRadnika.Visibility = Visibility.Collapsed;
            btnIzmeniRadnika.Visibility = Visibility.Collapsed;
            btnObrisiRadnika.Visibility = Visibility.Collapsed;

            btnDodajMesto.Visibility = Visibility.Visible;
            btnIzmeniMesto.Visibility = Visibility.Visible;
            btnObrisiMesto.Visibility = Visibility.Visible;

            btnDodajPogon.Visibility = Visibility.Collapsed;
            btnIzmeniPogon.Visibility = Visibility.Collapsed;
            btnObrisiPogon.Visibility = Visibility.Collapsed;

            btnDodajTehnoloskiSistem.Visibility = Visibility.Collapsed;
            btnIzmeniTehnoloskiSistem.Visibility = Visibility.Collapsed;
            btnObrisiTehnoloskiSistem.Visibility = Visibility.Collapsed;

            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;

            btnDodajDeo.Visibility = Visibility.Collapsed;
            btnIzmeniDeo.Visibility = Visibility.Collapsed;
            btnObrisiDeo.Visibility = Visibility.Collapsed;

            btnDodajMaterijal.Visibility = Visibility.Collapsed;
            btnIzmeniMaterijal.Visibility = Visibility.Collapsed;
            btnObrisiMaterijal.Visibility = Visibility.Collapsed;

            btnDodajSkaldiste.Visibility = Visibility.Collapsed;
            btnIzmeniSkladiste.Visibility = Visibility.Collapsed;
            btnObrisiSkladiste.Visibility = Visibility.Collapsed;


            konekcija.Open();
            try
            {
                string upit = "select MestoID, NazivM as 'Naziv mesta', PostanskiBroj as 'Postanski broj' from tblMesto";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("tblMesto");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnPogon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTehnoloskiSistem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlanProizvodnje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnProizvod_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMaterijal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSkladiste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodajRadnoMesto_Click(object sender, RoutedEventArgs e)
        {
            frmRadnoMesto prozor = new frmRadnoMesto();
            prozor.ShowDialog();
            string upit = "select RadnoMestoID, NazivRM from tblRadnoMesto";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("tblRadnoMesto");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;

        }

        private void btnIzmeniRadnoMesto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmRadnoMesto prozor = new frmRadnoMesto();
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "select * from tblRadnoMesto where RadnoMestoID= " + red["RadnoMestoID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while(citac.Read())
                {
                    prozor.txtNazivRadnogMesta.Text = citac["NazivRM"].ToString();
                    prozor.ShowDialog();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

                //PocetniDataGrid(dataGridCentralni);
                btnRadnoMesto_Click(sender, e);
               
                azuriraj = false;
            }

        }

        private void btnObrisiRadnoMesto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from tblRadnoMesto where RadnoMestoID= " + red["RadnoMestoID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Radno mesto?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");

            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguce obrisati red.", "Obavestenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                //PocetniDataGrid(dataGridCentralni);
                btnRadnoMesto_Click(sender, e);
            }
        }

        private void btnDodajRadnika_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniRadnika_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiRadnika_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodajMesto_Click(object sender, RoutedEventArgs e)
        {

            frmMesto prozor = new frmMesto();
            prozor.ShowDialog();
            string upit = "select MestoID, NazivM as 'Naziv mesta' , PostanskiBroj as 'Postanski broj' from tblMesto";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("tblMesto");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniMesto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmMesto prozor = new frmMesto();
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from tblMesto where MestoID= " + red["MestoID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while(citac.Read())
                {
                    prozor.txtNazivMesta.Text = citac["NazivM"].ToString();
                    prozor.txtPostanskiBroj.Text = citac["PostanskiBroj"].ToString();
                    prozor.ShowDialog();

                }
            }

            catch (Exception)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");

            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

                btnMesto_Click(sender, e);
                azuriraj = false;

            }
        }

        private void btnObrisiMesto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from tblMesto where MestoID=" + red["MestoID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Kartu?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red.", "Obavestenje");


            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugoj tabeli. Nije moguce obrisati red.", "Obavestenje");
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnMesto_Click(sender, e);
            }
        }

        private void btnDodajPogon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniPogon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiPogon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodajTehnoloskiSistem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniTehnoloskiSistem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiTehnoloskiSistem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodajPlanProizvodnje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniPlanProizvodnje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiPlanProizvodnje_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodajProizvod_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniProizvod_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiProizvod_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodajDeo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniDeo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiDeo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodajMaterijal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniMaterijal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiMaterijal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDodajSkaldiste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzmeniSkladiste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnObrisiSkladiste_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}