using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Authentication.ExtendedProtection;
using System.Windows;
using System.Globalization;

namespace Kryptologia
{

    public class Sifrovanie
    {
        public static int nezapornostKluca(int kluc)
        {
            if (kluc < 0)
            {
                kluc = kluc * (-1);
            }
            return kluc;
        }


        public static bool nesoudelnost(double a)
        {
            double b = 26;

            if (a == 0)
            {
                MessageBox.Show("Klúč a sa nesmie rovnať nule", "Chyba!");
                return false;
            }

            if (a < 0)
            {
                a = a * (-1);
            }


            if (a > b)
            {
                double x = a;
                a = b;
                b = x;
            }

            double q = 1;
            double r = 1;

            while (r != 0)
            {
                if (((b / a) % 1) == 0 && a != 1)
                {
                    MessageBox.Show("Cislo je sudelne prosim zadajte ine cislo", "Chyba!");
                    return false;
                }

                q = (b / a);
                q = Math.Floor(q);

                r = b - (q * a);

                if (r == 0)
                {
                    return true;
                }
                b = a;
                a = r;
            }
            return true;
        }
        public static string sifrovat(decimal kluc_a, decimal kluc_b, string vstupnyText)
        {
            char[] abeceda = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] text = vstupnyText.ToCharArray();
            char[] zasifrovanyText = new char[text.Length];
            decimal indexPismena = 0;
            decimal zasifrovanyIndex;
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < abeceda.Length; j++)
                {
                    if (text[i] == abeceda[j])
                    {
                        indexPismena = j; 
                        break;
                    }
                }

                zasifrovanyIndex = (kluc_a * indexPismena + kluc_b)%26;
                zasifrovanyText[i] = abeceda[Convert.ToInt32(zasifrovanyIndex)];

            }
            string zasifrovanyTextstring = new string(zasifrovanyText);
            

            return zasifrovanyTextstring;
        }
     
    }
}
