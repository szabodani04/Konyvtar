using System;
using System.Collections.Generic;
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
using System.IO;

namespace Konyvtar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Konyvek> Konyv = new List<Konyvek>();
        List<Tagok> Tag = new List<Tagok>();
        List<Kolcsonzes> Kolcson = new List<Kolcsonzes>();
        public MainWindow()
        {
            InitializeComponent();
            ReadAllLines("konyvek.txt");
            Tagok("tagok.txt");
            Rents("kolcsonzesek.txt");
        }
        public void ReadAllLines(string fajlnev)
        {
            DataGridXAML.ItemsSource = Konyv;
            foreach (var item in File.ReadAllLines(fajlnev))
            {
                Konyv.Add(new Konyvek(item));
            }
        }
        public void Tagok(string fajlnev) //tagbeolvasás
        {
            DataGridXAMLMembers.ItemsSource = Tag;

            foreach (var item in File.ReadAllLines(fajlnev))
            {
                Tag.Add(new Tagok(item));
            }
        }
        public void Rents(string fajlnev)//tagbeolvasás a kölcsönzesnel
        {
            DataGridXAMLRent.ItemsSource = Kolcson;
            foreach (var item in File.ReadAllLines(fajlnev))
            {
                Kolcson.Add(new Kolcsonzes(item));
            }
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)//kereses ami megkulonboztei a kis és nagybetuket
        {
            if (Search.Text == "")
                DataGridXAML.ItemsSource = Konyv;
            var szures = Konyv.Where(book => book.Szerzo.StartsWith(Search.Text) || book.Kiadas.StartsWith(Search.Text) || book.Cim.StartsWith(Search.Text) || book.Kiado.StartsWith(Search.Text));
            DataGridXAML.ItemsSource = szures;
        }
        private void UjKonyv_Click(object sender, RoutedEventArgs e)
        {
            Konyvek UjKonyv = new Konyvek("");
            UjKonyv.KonyvID = Konyv.Count + 1;
            UjKonyv.Szerzo = SzerzoText.Text;
            UjKonyv.Kiadas = DatumText.Text;
            UjKonyv.Cim = KonyvText.Text;
            UjKonyv.Kiado = KiadoText.Text;
            UjKonyv.Vanekolcsonben = true;
            Konyv.Add(UjKonyv);
            DataGridXAML.ItemsSource = Konyv;
        }
        private void KonyvTorles_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAML.ItemsSource = Konyv;
            var asdasd = DataGridXAML;
            if (asdasd.SelectedIndex >= 0)
            {
                Konyv.RemoveAt(asdasd.SelectedIndex);
                asdasd.Items.Refresh();
            }
        }
        private void KolcsonTorles_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAMLRent.ItemsSource = Kolcson;
            var asdasd = DataGridXAMLRent;
            if (asdasd.SelectedIndex >= 0)
            {
                Kolcson.RemoveAt(asdasd.SelectedIndex);
                asdasd.Items.Refresh();
            }
        }
        private void UjTag_Click(object sender, RoutedEventArgs e)
        {
            var asd = Konyv.Where(book => book.Szerzo.StartsWith(Search.Text) || book.Kiadas.StartsWith(Search.Text) || book.Cim.StartsWith(Search.Text) || book.Kiado.StartsWith(Search.Text));
            DataGridXAMLRent.ItemsSource = asd;
            Kolcsonzes UjKolcsonzes = new Kolcsonzes("");
            try
            {
                UjKolcsonzes.KolcsonID = Kolcson.Count + 1;
                UjKolcsonzes.KolcsonKonyvID = int.Parse(KonyvCim.Text);
                UjKolcsonzes.KolcsonTagID = int.Parse(TagCim.Text);
                UjKolcsonzes.Kezdes = Kivetel.Text;
                UjKolcsonzes.Visszahozta = Visszahozas.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Hát ez nem jó");
                return;
            }
            Kolcson.Add(UjKolcsonzes);
            DataGridXAMLRent.ItemsSource = Kolcson;
        }
        private void SearchMember_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchMember.Text == "")
            {
                DataGridXAMLMembers.ItemsSource = Tag;
            }
            var szures = Tag.Where(member => member.Nev.StartsWith(SearchMember.Text) || member.Utca.StartsWith(SearchMember.Text) || member.Varos.StartsWith(SearchMember.Text) || member.Iranyitoszam.StartsWith(SearchMember.Text));
            DataGridXAMLMembers.ItemsSource = szures;
        }
        private void AddMemberBT_Click(object sender, RoutedEventArgs e)
        {
            var Solution = Konyv.Where(book => book.Szerzo.StartsWith(Search.Text) || book.Kiadas.StartsWith(Search.Text) || book.Cim.StartsWith(Search.Text) || book.Kiado.StartsWith(Search.Text));
            DataGridXAMLMembers.ItemsSource = Solution;
            Tagok UjTag = new Tagok("");
            UjTag.Tag = Tag.Count + 1;
            UjTag.Utca = UtcaText.Text;
            UjTag.Varos = VarosText.Text;
            UjTag.Iranyitoszam = IranyitoszamText.Text;
            UjTag.Szul = SzulText.Text;
            UjTag.Nev = NevText.Text;
            Tag.Add(UjTag);
            DataGridXAMLMembers.ItemsSource = Tag;
        }

        private void TagTorles_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAMLMembers.ItemsSource = Tag;
            var asdasd = DataGridXAMLMembers;
            if (asdasd.SelectedIndex >= 0)
            {
                Tag.RemoveAt(asdasd.SelectedIndex);
                asdasd.Items.Refresh();
            }
        }


    }
}
