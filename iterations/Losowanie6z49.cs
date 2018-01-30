using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace iterations
{
    public static class Losowanie6Z49 //zwracana jest macierz z 6 liczbami od 1 do 49
    {
        
        public static int RandNumber(int low, int high)
        {
            Random rndNum = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rnd = rndNum.Next(low, high);
            return rnd;
        }

        static void Main(string[] args)
        {
            int[] losowanie = new int[6];
            LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
            ArrayList listaLosowan = new ArrayList();
            var losowanieJakoTablica = new int[6];

            

            //Sprawdzamy czy w losowaniu nie ma zduplikowanych liczb -- nieskuteczne
            #region Prawdopodobnie_zbedne_do_usuniecia
            //!!!nieskuteczna metoda usuwania duplikatow
            //for (int k = 0; k < losowanie.Length - 1; k++)
            //{
            //    if (losowanie[k] == losowanie[k + 1]) //spr czy w nastepnej iteracji nie pojawia sie taka sama liczba
            //    {
            //        //Console.WriteLine("znalazlem duplikaty, losujemy powtornie");
            //        LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
            //        k = 0;
            //        //Console.WriteLine("nowe wylosowane liczby to: {0}", string.Join(", ", losowanie));
            //    }

            //} 
            #endregion
            
            #region Wyswietlanie_na_ekranie_pierwszego_losowania
            //do usuniecia
            for (int i = 0; i < (losowanie.Length); i++)
            {
                Console.WriteLine("{0}: {1} ", i + 1, string.Join(", ", losowanie[i]));
                //Console.WriteLine("{0}: {1} ({2:p1})", i + 1, losowanie[i], (double)results[i] / (double)totalRolls);
            }

            foreach (var VARIABLE in losowanie)
            {
                var i = 0;
                losowanieJakoTablica[i] = VARIABLE;
                i++;
            } 
            #endregion


            //losowanie odpowiedniej ilosci liczb
            //uniemozliwienie istnienia duplikatow w losowaniu (ponownie)
            for (int i = 0; i < 100; i++)
            {
                var test = losowanie.AsEnumerable().ToArray();
                listaLosowan.Add(test);
                LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
                var rozne = losowanie.Distinct();//do uniemozliwienia istnienia duplikatow w losowaniu
                if (rozne.ToArray().Length == losowanie.Length)
                {
                    
                    continue;
                }
                else
                {
                    listaLosowan.RemoveAt(i);
                    i--;
                }

            }

            #region Wypisz_wszystkie_wyniki_losowania
            //to pozwala wypisac wszystkie wyniki
            Console.WriteLine("-------");
            foreach (int[] VARIABLE in listaLosowan)
            {
                foreach (var i in VARIABLE)
                {
                    Console.Write(i + ", ");
                }

                Console.WriteLine();
            } 
            #endregion


        }
    }
}
