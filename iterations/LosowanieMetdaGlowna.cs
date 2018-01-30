using System;

namespace iterations
{
    public static class LosowanieMetdaGlowna
    {
        public static int [] LosowanieLiczb(int [] losowanie)
        {
            int k = 0;
            for (int i = 0; i < 6; i++)//stworzenie tablicy dla wyniku losowania
            {
                losowanie[i] = Losowanie6Z49.RandNumber(1, 49);                
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