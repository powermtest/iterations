using System;
using System.Collections.Generic;
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
            LosowanieLiczb(losowanie);
            const int totalRolls = 66;
            int[][] wynikiLosowania = {new int[totalRolls], losowanie};
            //Console.WriteLine("wylosowane liczby:");
            //Console.WriteLine(string.Join(", ", losowanie));
            //Console.WriteLine("jaka jest length dla losowanie? --> {0}", losowanie.Length);
            
            //Sprawdzamy czy w losowaniu nie ma zduplikowanych liczb
            for (int k = 0; k < losowanie.Length - 1; k++)
            {
                if (losowanie[k] == losowanie[k + 1]) //spr czy w nastepnej iteracji nie pojawia sie taka sama liczba
                {
                    //Console.WriteLine("znalazlem duplikaty, losujemy powtornie");
                    LosowanieLiczb(losowanie);
                    //Console.WriteLine("nowe wylosowane liczby to: {0}", string.Join(", ", losowanie));
                }

            }

            for (int i = 0; i < wynikiLosowania.Length; i++)
            {
                for (int j = 0; j < wynikiLosowania[i].Length; j++)
                {
                    Console.WriteLine("\t" + wynikiLosowania[i][j].ToString());
                }
            }

            //Console.WriteLine(string.Join(", ", losowanie));
            //int[] results = new int [totalRolls];
            //for (int x = 0; x < totalRolls; x++)
            //{
            //    wynikiLosowania = LosowanieLiczb(losowanie);
            //    Console.WriteLine(string.Join(", ", wynikiLosowania));


            //    //problem: jak woyszczeglne losowania do tablicy, aby pozniej sprawdzic jej zawartosc
            //    //pod katem powtafzania sie losowan?

            //    //bool isEqual = Enumerable.SequenceEqual(losowanie, wynikiLosowania);
            //    //Console.WriteLine(isEqual);
            //}

            for (int i = 0; i < (losowanie.Length); i++)
            {
                Console.WriteLine("{0}: {1} ", i + 1, string.Join(", ", losowanie[i]));
                //Console.WriteLine("{0}: {1} ({2:p1})", i + 1, losowanie[i], (double)results[i] / (double)totalRolls);
            }
            

        }

        public static int [] LosowanieLiczb(int [] losowanie)
        {
            int k = 0;
            for (int i = 0; i < 6; i++)//stworzenie tablicy dla wyniku losowania
            {
                losowanie[i] = RandNumber(1, 49);                
            }
            Array.Sort(losowanie);
            if (losowanie[k] == losowanie[k + 1])
            {
                //Console.WriteLine("*metoda* znalazlem duplikaty, losujemy powtornie");
                LosowanieLiczb(losowanie);
                //Console.WriteLine("*metoda* nowe wylosowane liczby to: {0}", string.Join(", ", losowanie));
            }
            return losowanie;
        }
    }
}
