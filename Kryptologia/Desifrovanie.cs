using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kryptologia
{
    class Desifrovanie
    {
        public static int multiplikarna_inverzia(decimal kluc_a)
        {
            for (int i = 1; i < 26; i++) 
            { decimal calculation = (kluc_a * i) % 26; 
                if (calculation == 1) 
                { 
                    return i; 
                } 
            } 
            return 0;
        }
        public static string desifrovanie(decimal inverzia, decimal kluc_b, string zasifrovanyText)
        {
            char[] abeceda = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] text = zasifrovanyText.ToCharArray();
            char[] desifrovanyText = new char[text.Length];
            decimal indexPismena = 0;

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

                decimal desifrovanyIndex = ((indexPismena - kluc_b)*inverzia)%26;


                if (desifrovanyIndex < 0)
                {
                    desifrovanyIndex = 26 + desifrovanyIndex;
                }

                desifrovanyText[i] = abeceda[Convert.ToInt32(desifrovanyIndex)];

            }
            string desifrovanyTextstring = new string(desifrovanyText);

            return desifrovanyTextstring;
        }



    }
}
