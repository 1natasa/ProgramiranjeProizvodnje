using ProgramiranjeProizvodnje.Forme;
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

            btnDodajPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnIzmeniPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnObrisiPlanProizvodnje.Visibility = Visibility.Collapsed;

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
                string upit = "select RadnoMestoID, NazivRM as 'Naziv radnog mesta' from tblRadnoMesto";
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
            btnDodajRadnoMesto.Visibility = Visibility.Collapsed;
            btnIzmeniRadnoMesto.Visibility = Visibility.Collapsed;
            btnObrisiRadnoMesto.Visibility = Visibility.Collapsed;

            btnDodajRadnika.Visibility = Visibility.Visible;
            btnIzmeniRadnika.Visibility = Visibility.Visible;
            btnObrisiRadnika.Visibility = Visibility.Visible;

            btnDodajMesto.Visibility = Visibility.Collapsed;
            btnIzmeniMesto.Visibility = Visibility.Collapsed;
            btnObrisiMesto.Visibility = Visibility.Collapsed;

            btnDodajPogon.Visibility = Visibility.Collapsed;
            btnIzmeniPogon.Visibility = Visibility.Collapsed;
            btnObrisiPogon.Visibility = Visibility.Collapsed;

            btnDodajTehnoloskiSistem.Visibility = Visibility.Collapsed;
            btnIzmeniTehnoloskiSistem.Visibility = Visibility.Collapsed;
            btnObrisiTehnoloskiSistem.Visibility = Visibility.Collapsed;

            btnDodajPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnIzmeniPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnObrisiPlanProizvodnje.Visibility = Visibility.Collapsed;

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
                string upit = "select RadnikID, ImeR as 'Ime', PrezimeR as 'Prezime', JMBG_R as 'JMBG', " +
                    "TelefonR as 'Telefon', AdresaR as 'Adresa', m.NazivM as 'Grad', " +
                    "rm.NazivRM as 'Radno mesto', p.OznakaP as 'Pogon' " +
                    " from tblRadnik r " +
                    "inner join tblRadnoMesto rm on r.RadnoMestoID = rm.RadnoMestoID " +
                    "inner join tblMesto m on r.MestoID=m.MestoID " +
                    "inner join tblPogon p on r.PogonID=p.PogonID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("tblRadnik");
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

            btnDodajPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnIzmeniPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnObrisiPlanProizvodnje.Visibility = Visibility.Collapsed;

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

            btnDodajRadnoMesto.Visibility = Visibility.Collapsed;
            btnIzmeniRadnoMesto.Visibility = Visibility.Collapsed;
            btnObrisiRadnoMesto.Visibility = Visibility.Collapsed;

            btnDodajRadnika.Visibility = Visibility.Collapsed;
            btnIzmeniRadnika.Visibility = Visibility.Collapsed;
            btnObrisiRadnika.Visibility = Visibility.Collapsed;

            btnDodajMesto.Visibility = Visibility.Collapsed;
            btnIzmeniMesto.Visibility = Visibility.Collapsed;
            btnObrisiMesto.Visibility = Visibility.Collapsed;

            btnDodajPogon.Visibility = Visibility.Visible;
            btnIzmeniPogon.Visibility = Visibility.Visible;
            btnObrisiPogon.Visibility = Visibility.Visible;

            btnDodajTehnoloskiSistem.Visibility = Visibility.Collapsed;
            btnIzmeniTehnoloskiSistem.Visibility = Visibility.Collapsed;
            btnObrisiTehnoloskiSistem.Visibility = Visibility.Collapsed;

            btnDodajPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnIzmeniPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnObrisiPlanProizvodnje.Visibility = Visibility.Collapsed;

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
                string upit = "select PogonID, OznakaP as 'Oznaka pogona' from tblPogon";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("tblPogon");
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

        private void btnTehnoloskiSistem_Click(object sender, RoutedEventArgs e)
        {
            btnDodajRadnoMesto.Visibility = Visibility.Collapsed;
            btnIzmeniRadnoMesto.Visibility = Visibility.Collapsed;
            btnObrisiRadnoMesto.Visibility = Visibility.Collapsed;

            btnDodajRadnika.Visibility = Visibility.Collapsed;
            btnIzmeniRadnika.Visibility = Visibility.Collapsed;
            btnObrisiRadnika.Visibility = Visibility.Collapsed;

            btnDodajMesto.Visibility = Visibility.Collapsed;
            btnIzmeniMesto.Visibility = Visibility.Collapsed;
            btnObrisiMesto.Visibility = Visibility.Collapsed;

            btnDodajPogon.Visibility = Visibility.Collapsed;
            btnIzmeniPogon.Visibility = Visibility.Collapsed;
            btnObrisiPogon.Visibility = Visibility.Collapsed;

            btnDodajTehnoloskiSistem.Visibility = Visibility.Visible;
            btnIzmeniTehnoloskiSistem.Visibility = Visibility.Visible;
            btnObrisiTehnoloskiSistem.Visibility = Visibility.Visible;

            btnDodajPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnIzmeniPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnObrisiPlanProizvodnje.Visibility = Visibility.Collapsed;

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
                string upit = "select TehnoloskiSistemID, OznakaTS as 'Oznaka tehnoloskog sistema', NazivTS as 'Naziv tehnoloskog sistema', p.OznakaP as 'Oznaka pogona'" +
                    "from tblTehnoloskiSistem ts inner join tblPogon p on ts.PogonID = p.PogonID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("tblTehnoloskiSistem");
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

        private void btnPlanProizvodnje_Click(object sender, RoutedEventArgs e)
        {
            btnDodajRadnoMesto.Visibility = Visibility.Collapsed;
            btnIzmeniRadnoMesto.Visibility = Visibility.Collapsed;
            btnObrisiRadnoMesto.Visibility = Visibility.Collapsed;

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

            btnDodajPlanProizvodnje.Visibility = Visibility.Visible;
            btnIzmeniPlanProizvodnje.Visibility = Visibility.Visible;
            btnObrisiPlanProizvodnje.Visibility = Visibility.Visible;

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
                string upit = "select Datum, Kolicina, Napomena, r.ImeR + ' ' + r.PrezimeR as Radnik from tblPlanProizvodnje pp inner join tblRadnik r on pp.RadnikID=r.RadnikID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("tblPlanProzivodnje");
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

        private void btnProizvod_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMaterijal_Click(object sender, RoutedEventArgs e)
        {
            btnDodajRadnoMesto.Visibility = Visibility.Collapsed;
            btnIzmeniRadnoMesto.Visibility = Visibility.Collapsed;
            btnObrisiRadnoMesto.Visibility = Visibility.Collapsed;

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

            btnDodajPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnIzmeniPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnObrisiPlanProizvodnje.Visibility = Visibility.Collapsed;

            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;

            btnDodajDeo.Visibility = Visibility.Collapsed;
            btnIzmeniDeo.Visibility = Visibility.Collapsed;
            btnObrisiDeo.Visibility = Visibility.Collapsed;

            btnDodajMaterijal.Visibility = Visibility.Visible;
            btnIzmeniMaterijal.Visibility = Visibility.Visible;
            btnObrisiMaterijal.Visibility = Visibility.Visible;

            btnDodajSkaldiste.Visibility = Visibility.Collapsed;
            btnIzmeniSkladiste.Visibility = Visibility.Collapsed;
            btnObrisiSkladiste.Visibility = Visibility.Collapsed;


            konekcija.Open();
            try
            {
                string upit = " select MaterijalID, VrstaM as 'Vrsta materijala', s.OznakaS + ',' + s.LokacijaS as 'Skladiste' from tblMaterijal m inner join tblSkladiste s on m.SkladisteID=s.SkladisteID ";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("tblMaterijal");
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

        private void btnSkladiste_Click(object sender, RoutedEventArgs e)
        {

            btnDodajRadnoMesto.Visibility = Visibility.Collapsed;
            btnIzmeniRadnoMesto.Visibility = Visibility.Collapsed;
            btnObrisiRadnoMesto.Visibility = Visibility.Collapsed;

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

            btnDodajPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnIzmeniPlanProizvodnje.Visibility = Visibility.Collapsed;
            btnObrisiPlanProizvodnje.Visibility = Visibility.Collapsed;

            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;

            btnDodajDeo.Visibility = Visibility.Collapsed;
            btnIzmeniDeo.Visibility = Visibility.Collapsed;
            btnObrisiDeo.Visibility = Visibility.Collapsed;

            btnDodajMaterijal.Visibility = Visibility.Collapsed;
            btnIzmeniMaterijal.Visibility = Visibility.Collapsed;
            btnObrisiMaterijal.Visibility = Visibility.Collapsed;

            btnDodajSkaldiste.Visibility = Visibility.Visible;
            btnIzmeniSkladiste.Visibility = Visibility.Visible;
            btnObrisiSkladiste.Visibility = Visibility.Visible;

            konekcija.Open();
            try
            {
                string upit = "select SkladisteID, OznakaS as 'Oznaka', LokacijaS as 'Lokacija', m.NazivM as 'Grad', m.PostanskiBroj as 'Postanski broj' from tblSkladiste s inner join tblMesto m on s.MestoID=m.MestoID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("tblSkladiste");
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
            frmRadnik prozor = new frmRadnik();
            prozor.ShowDialog();
            string upit = "select ImeR as 'Ime', PrezimeR as 'Prezime', JMBG_R as 'JMBG', " +
                "TelefonR as 'Telefon', AdresaR as 'Adresa', m.NazivM as 'Grad', rm.NazivRM as 'Radno Mesto', " +
                "p.OznakaP as 'Pogon'" +
                " from tblRadnik r" +
                " inner join tblMesto m on r.MestoID=m.MestoID" +
                " inner join tblRadnoMesto rm on r.RadnoMestoID=rm.RadnoMestoID" +
                " inner join tblPogon p on r.PogonID=p.PogonID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("tblRadnik");
            dataAdapter.Fill(dt);
         
            dataGridCentralni.ItemsSource = dt.DefaultView;

        }

        private void btnIzmeniRadnika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmRadnik prozor = new frmRadnik();
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = " select * from tblRadnik where RadnikID= " + red["RadnikID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    prozor.txtImeRadnika.Text = citac["ImeR"].ToString();
                    prozor.txtPrezimeRadnika.Text = citac["PrezimeR"].ToString();
                    prozor.txtJMBGRadnika.Text = citac["JMBG_R"].ToString();
                    prozor.txtTelefonRadnika.Text = citac["TelefonR"].ToString();
                    prozor.txtAdresaRadnika.Text = citac["AdresaR"].ToString();
                    prozor.cbxMesto.SelectedValue = citac["MestoID"].ToString();
                    prozor.cbxRadnoMesto.SelectedValue = citac["RadnoMestoID"].ToString();
                    prozor.cbxPogon.SelectedValue = citac["PogonID"].ToString();
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

                btnRadnik_Click(sender, e);
                azuriraj = false;
            }



        }

        private void btnObrisiRadnika_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from tblRadnik where RadnikID=" + red["RadnikID"];
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
                btnRadnik_Click(sender, e);
            }
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
            frmPogon prozor = new frmPogon();
            prozor.ShowDialog();
            string upit = "select PogonID, OznakaP as 'Oznaka pogona' from tblPogon";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("tblPogon");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniPogon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmPogon prozor = new frmPogon();
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                pomocni = red;
                string upit = "select * from tblPogon where PogonID=" + red["PogonID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while(citac.Read())
                {
                    prozor.txtOznakaPogona.Text = citac["OznakaP"].ToString();
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

                btnPogon_Click(sender, e);
                azuriraj = false;

            }
        }

        private void btnObrisiPogon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from tblPogon where PogonID= " + red["PogonID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Pogon?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                btnPogon_Click(sender, e);
            }
        }

        private void btnDodajTehnoloskiSistem_Click(object sender, RoutedEventArgs e)
        {
            frmTehnoloskiSistem prozor = new frmTehnoloskiSistem();
            prozor.ShowDialog();
            string upit = "select TehnoloskiSistemID, OznakaTS, NazivTS, p.OznakaP as 'Oznaka pogona' from tblTehnoloskiSistem ts inner join tblPogon p on ts.PogonID=p.PogonID ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("tblTehnoloskiSistem");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniTehnoloskiSistem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmTehnoloskiSistem prozor = new frmTehnoloskiSistem();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from tblTehnoloskiSistem where TehnoloskiSistemID=" + red["TehnoloskiSistemID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    prozor.txtOznakaTehnoloskogSistema.Text = citac["OznakaTS"].ToString();
                    prozor.txtNazivTehnoloskogSistema.Text = citac["NazivTS"].ToString();
                    prozor.cbxPogon.SelectedValue = citac["PogonID"].ToString();

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
                btnTehnoloskiSistem_Click(sender, e);
                azuriraj = false;
            }


        }

        private void btnObrisiTehnoloskiSistem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from tblTehnoloskiSistem where TehnoloskiSistemID= " + red["TehnoloskiSistemID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Tehnoloski sistem?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                btnTehnoloskiSistem_Click(sender, e);
            }
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
            frmMaterijal prozor = new frmMaterijal();
            prozor.ShowDialog();
            string upit = "select MaterijalID, VrstaM, s.OznakaS + ', ' + s.LokacijaS as 'Skladiste' from tblMaterijal m inner join tblSkladiste s on m.SkladisteID=s.SkladisteID ";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("tblMaterijal");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
        }

        private void btnIzmeniMaterijal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmMaterijal prozor = new frmMaterijal();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit = "select * from tblMaterijal where MaterijalID=" + red["MaterijalID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    prozor.txtVrstaM.Text = citac["VrstaM"].ToString();
                    prozor.cbxSkladiste.SelectedValue = citac["SkladisteID"].ToString();
                    

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
                btnMaterijal_Click(sender, e);
                azuriraj = false;
            }
        }

        private void btnObrisiMaterijal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from tblMaterijal where MaterijalID= " + red["MaterijalID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Materijal?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

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
                btnMaterijal_Click(sender, e);
            }
        }

        private void btnDodajSkaldiste_Click(object sender, RoutedEventArgs e)
        {
            frmSkladiste prozor = new frmSkladiste();
            prozor.ShowDialog();

            string upit = "select SkladisteID, OznakaS, LokacijaS, m.NazivM, m.PostanskiBroj from tblSkladiste s inner join tblMesto m on s.MestoID=m.MestoID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("tblSkladiste");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;

        }

        private void btnIzmeniSkladiste_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuriraj = true;
                frmSkladiste prozor = new frmSkladiste();
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;
                string upit ="select * from tblSkladiste where SkladisteID=" + red["SkladisteID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                while(citac.Read())
                {
                    prozor.txtOznakaS.Text = citac["OznakaS"].ToString();
                    prozor.txtLokacijaS.Text = citac["LokacijaS"].ToString();
                    prozor.cbxMesto.SelectedValue = citac["MestoID"].ToString();
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

                btnSkladiste_Click(sender, e);
                azuriraj = false;

            }
        }

        private void btnObrisiSkladiste_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = "Delete from tblSkladiste where SkladisteID=" + red["SkladisteID"];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisite Skladiste?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
                btnSkladiste_Click(sender, e);
            }
        }


    }
}
