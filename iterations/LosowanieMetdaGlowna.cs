using System;
using System.Linq;

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
                LosowanieLiczb(losowanie);
            }

            return losowanie;
        }
    }
}