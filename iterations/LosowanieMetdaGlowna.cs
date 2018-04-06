using System;

namespace iterations
{
    public static class LosowanieMetdaGlowna
    {
        public static int[] LosowanieLiczb()
        {
            //var test = new int[6] {4, 5, 3, 4, 5,14};
            var losowanie = new int[6];
            //var k = 0;
            for (var i = 0; i < 6; i++) //stworzenie tablicy dla wyniku losowania
                losowanie[i] = Losowanie6Z49Poprawione.RandNumber(1, 50);

            //losowanie = test;
            //Array.Sort(losowanie);
            Duplikaty(losowanie);
            //Sort(losowanie);


            


            return losowanie;
        }
        //nie sortujemy - to fałszuje wyniki!
        static void Sort(int[] tablica)
        {
            int n = tablica.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (tablica[i] > tablica[i + 1])
                    {
                        int tmp = tablica[i];
                        tablica[i] = tablica[i + 1];
                        tablica[i + 1] = tmp;
                    }
                }
                n--;
            } while (n > 1);
        }

        static void Duplikaty(int[] tablica)
        {
            for (int i = 0; i < tablica.Length; i++)
            {
                for (int j = i; j < tablica.Length - 1; j++)
                {
                    if (tablica[i] == tablica[j + 1])
                    {
                        var ponownie = Losowanie6Z49Poprawione.RandNumber(1, 50);
                        tablica[j + 1] = ponownie;
                        j = j - 1;
                        continue;
                    }
                    //if (tablica[5] == tablica[4])
                    //{
                    //    var ponownie = Losowanie6Z49Poprawione.RandNumber(40, 50);
                    //    tablica[5] = ponownie;
                    //    j = -1;
                    //    i = -1;
                    //    continue;
                    //}
                }
            }
        }
    }
}