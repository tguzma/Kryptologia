using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kryptologia
{
    class UpravaTextu
    {
        public static string odstranenieDiakritiky(string text)
        {
            char[] pole = text.ToCharArray();
            for (int i = 0; i < pole.Length; i++)
            {
                if (pole[i] == 'Ľ' || pole[i] == 'Ĺ')
                {
                    pole[i] = 'L';
                }
                if (pole[i] == 'Š')
                { 
                    pole[i] = 'S';
                }
                if (pole[i] == 'Č')
                {
                    pole[i] = 'C';
                }
                if (pole[i] == 'Ť')
                {
                    pole[i] = 'T';
                }
                if (pole[i] == 'Ž')
                {
                    pole[i] = 'Z';
                }
                if (pole[i] == 'Ý')
                {
                    pole[i] = 'Y';
                }
                if (pole[i] == 'Á' || pole[i] == 'Ä')
                {
                    pole[i] = 'A';
                }
                if (pole[i] == 'Í')
                {
                    pole[i] = 'I';
                }
                if (pole[i] == 'É' || pole[i] == 'Ě')
                {
                    pole[i] = 'E';
                }
                if (pole[i] == 'Ô' || pole[i] == 'Ó')
                {
                    pole[i] = 'O';
                }
                if (pole[i] == 'Ř' || pole[i] == 'Ŕ')
                {
                    pole[i] = 'R';
                }
                if (pole[i] == 'Ň')
                {
                    pole[i] = 'N';
                }
                if (pole[i] == 'Ď')
                {
                    pole[i] = 'D';
                }
                if (pole[i] == 'Ú' || pole[i] == 'Ü')
                {
                    pole[i] = 'U';
                }
            }

            string textString = new string(pole);
            return textString;
        }
        public static string upravTextPredSifrovanim(string text)
        {
            text = text.Replace(" ", "XQW");
            text = text.ToUpper(); 
            text = odstranenieDiakritiky(text);

            char[] pole = text.ToCharArray();
            for (int i = 0; i < pole.Length; i++)
            {
                if (Char.IsLetter(pole[i]) == false)
                {
                    pole[i] = '\0'; 
                }
            }
            string textString = new string(pole);
            textString = textString.Replace("\0", "");
            return textString; 
        }
        public static string upravTextPredDesifrovanim(string text)
        {
            text = text.ToUpper();
            text = odstranenieDiakritiky(text);

            char[] pole = text.ToCharArray();
            for (int i = 0; i < pole.Length; i++)
            {
                if (Char.IsLetter(pole[i]) == false)
                {
                    pole[i] = '\0';
                }
            }
            string textString = new string(pole);
            textString = textString.Replace("\0", "");
            return textString;
        }
        public static bool kontrola_kluca(string kluc)
        {
            kluc.ToCharArray();
            for (int i = 0; i < kluc.Length; i++)
            {
                if (Char.IsDigit(kluc[i]) != true) 
                {
                        MessageBox.Show("Nastal problém so zadaním jedného z kľúčov.\nPrečítajte si pomoc kde nájdete kritéria pre zadanie kľúča.", "Chyba!");
                        return false;
                }
            }
            if (kluc == "")
            {
                MessageBox.Show("Kľúč nesmie byť prázdny!", "Chyba!");
                return false;
            }

            if (Int32.MaxValue < Convert.ToDecimal(kluc))
            {
                MessageBox.Show("Prosím ako kľúč zadajte číslo do 2,147,483,647", "Chyba!");
                return false;
            }
            return true;
        }

        public static string vlozit_medzeri(string text)
        {
            
            for (int i = 5; i <= text.Length; i += 5)
            {
                    text = text.Insert(i, " ");
                    i++;
            }
            return text;
        }
        public static string zasifrovanaAbeceda(decimal kluc_a, decimal kluc_b)
        {
            char[] abeceda = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for (int i = 0; i < abeceda.Length; i++)
            {
                decimal zasifroavnyIndex = (kluc_a * i + kluc_b) % 26;
                abeceda[i] = abeceda[Convert.ToInt32(zasifroavnyIndex)];
            }
            string zasifrovanaAbecedaString = new string(abeceda);
            zasifrovanaAbecedaString = zasifrovanaAbecedaString.Insert(0, "Zašifrovaná abeceda: ");
            return zasifrovanaAbecedaString;
        }
    }
}
