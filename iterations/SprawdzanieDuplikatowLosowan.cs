using System;
using System.Collections;

namespace iterations
{
    public static class SprawdzanieDuplikatowLosowan
    {
        public static void NewMethod(ArrayList duplikatListyLosowan, ref int liczknikDuplikat, ArrayList listaPowtorzonuchLosowan, ref int licznikPetli, object obiekt)
        {
            if (duplikatListyLosowan.Contains(obiekt))
            {
                Console.WriteLine("znalazłem powtarzające się losowania!");
                listaPowtorzonuchLosowan.Add(obiekt);
                liczknikDuplikat++;
                foreach (Array zduplikowaneLosowanie in listaPowtorzonuchLosowan)
                {
                    foreach (var numerki in zduplikowaneLosowanie)
                    {
                        Console.Write(numerki + ", ");
                    }
                    Console.WriteLine();
                }

            }
            licznikPetli++;
        }
    }
}