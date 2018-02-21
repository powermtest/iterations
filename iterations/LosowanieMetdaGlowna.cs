using System;

namespace iterations
{
    public static class LosowanieMetdaGlowna
    {
        public static int [] LosowanieLiczb(int [] losowanie)
        {
            //var test = new int[6] {4, 5, 3, 4, 5,14};
            int k = 0;
            for (int i = 0; i < 6; i++)//stworzenie tablicy dla wyniku losowania
            {
                losowanie[i] = Losowanie6Z49.RandNumber(1, 49);                
            }
            //losowanie = test;
            Array.Sort(losowanie);
            foreach (var liczba in losowanie)
            {
                
                if (k < 5 && losowanie[k] == losowanie[k + 1])
                {
                    LosowanieLiczb(losowanie);
                }
                k++;
            }
            

            return losowanie;
        }

        
    }
}