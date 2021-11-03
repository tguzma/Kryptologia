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

namespace Kryptologia
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click_Zasifrovat(object sender, RoutedEventArgs e)
        {
            
            string text = nezasifrovanyText.Text;
            text = UpravaTextu.upravTextPredSifrovanim(text);

            string vstupnePole = text.Replace("XQW", " ");
            nezasifrovanyText.Text = vstupnePole;

            bool kluc_a_Ok = UpravaTextu.kontrola_kluca(kluc_a.Text);
            bool kluc_b_Ok = UpravaTextu.kontrola_kluca(kluc_b.Text);
            if (kluc_a_Ok == false || kluc_b_Ok == false)
            {
                goto end;
            }
            int kluc_A = Convert.ToInt32(kluc_a.Text);
            int kluc_B = Convert.ToInt32(kluc_b.Text);

            bool jeNesoudelne = Sifrovanie.nesoudelnost(kluc_A);
                if (jeNesoudelne == true)
                {
                    string zasifrovanyText = Sifrovanie.sifrovat(kluc_A, kluc_B,text);
                    zasifrovanyText = UpravaTextu.vlozit_medzeri(zasifrovanyText);
                    vystupZasifrovanehoADesifrovaneho.Text = zasifrovanyText;

                    string zasifrovanaAbeceda = UpravaTextu.zasifrovanaAbeceda(kluc_A,kluc_B);
                    zobrazenieAbeciedAVyfiltrovanéhoTextu.Text = "Pôvodná abeceda: ABCDEFGHIJKLMNOPQRSTUVWXYZ\n";
                    zobrazenieAbeciedAVyfiltrovanéhoTextu.Text += zasifrovanaAbeceda + "\n";
                    zobrazenieAbeciedAVyfiltrovanéhoTextu.Text += "Zadaný text, upravený pred šifrovaním: " + text;
                }
            end:;
        }
        private void Button_Click_Desifrovat(object sender, RoutedEventArgs e)
        {
            string text = sifrovanyText.Text;
            text = UpravaTextu.upravTextPredDesifrovanim(text);

            bool kluc_a_Ok = UpravaTextu.kontrola_kluca(kluc_a.Text);
            bool kluc_b_Ok = UpravaTextu.kontrola_kluca(kluc_b.Text);

            if (kluc_a_Ok == false || kluc_b_Ok == false)
            {
                goto end;
            }

            int kluc_A = Convert.ToInt32(kluc_a.Text);
            int kluc_B = Convert.ToInt32(kluc_b.Text);
            string zasifrovanaAbeceda = UpravaTextu.zasifrovanaAbeceda(kluc_A, kluc_B);

            zobrazenieAbeciedAVyfiltrovanéhoTextu.Text = "Pôvodná abeceda: ABCDEFGHIJKLMNOPQRSTUVWXYZ\n";
            zobrazenieAbeciedAVyfiltrovanéhoTextu.Text += zasifrovanaAbeceda + "\n";
            zobrazenieAbeciedAVyfiltrovanéhoTextu.Text += "Zadaný text, upravený pred dešifrovaním: " + text;

            int inverzia = Desifrovanie.multiplikarna_inverzia(kluc_A);
            text = Desifrovanie.desifrovanie(inverzia,kluc_B,text);


            text = text.Replace("XQW", " ");
            vystupZasifrovanehoADesifrovaneho.Text = text;
            
            end:;
        }

        private void Button_Click_Pomoc(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Do okna pre šifrovanie/dešifrovanie zadajte text, diaktritika bude ignorovaná, čísla a iné špeciálne znaky budú zmazané.\n" +
                            "Do okna pre Kľúč A a Kľúč B zadávajte iba celé čísla!\n" +
                            "Ako kľúč zadajte číslo do 2,147,483,647"
                            , "Pomoc");
        }

        private void desifrovanyText_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            nezasifrovanyText.Text = "";
        }

        private void sifrovanyText_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            sifrovanyText.Text = "";
        }

        private void kluc_a_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            kluc_a.Text = "";
        }

        private void kluc_b_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            kluc_b.Text = "";
        }
    }
}
