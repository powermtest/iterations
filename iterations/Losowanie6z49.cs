using System;
using System.Collections;
using System.Linq;
using System.IO;


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
            ArrayList duplikatListyLosowan = new ArrayList();
            var czasStart = DateTime.Now;


            Console.WriteLine("Start aplikacji: " + czasStart);
            #region Wyswietlanie_na_ekranie_pierwszego_losowania

            ////do usuniecia
            //for (int i = 0; i < (losowanie.Length); i++)
            //{
            //    Console.WriteLine("{0}: {1} ", i + 1, string.Join(", ", losowanie[i]));
            //    //Console.WriteLine("{0}: {1} ({2:p1})", i + 1, losowanie[i], (double)results[i] / (double)totalRolls);
            //}

            //foreach (var VARIABLE in losowanie)
            //{
            //    var i = 0;
            //    losowanieJakoTablica[i] = VARIABLE;
            //    i++;
            //} 

            #endregion
            IloscLosowanNaListe(losowanie, listaLosowan, duplikatListyLosowan, out var i);
            Console.WriteLine("Koniec obliczen: " + (DateTime.Now - czasStart) + " sekund");
            #region Wypisz_wszystkie_wyniki_losowania

            ////to pozwala wypisac wszystkie wyniki
            //Console.WriteLine("-------");
            //foreach (int[] losowanieIteracja in listaLosowan)
            //{
            //    foreach (var liczba in losowanieIteracja)
            //    {
            //        Console.Write(liczba + ", ");
            //    }

            //    Console.WriteLine();
            //}

            #endregion
            #region Testowanie czy funkcja 'distinct' działa. Jest OK!

            //var dodawanie = new int[6] { 5, 6, 7, 8, 9, 10 };
            //listaLosowan.RemoveRange(66, 4);
            //listaLosowan.Add(dodawanie);
            //listaLosowan.Add(dodawanie);
            //test = listaLosowan.ToArray().Distinct();

            //var test2 = test.Count();
            //var test3 = listaLosowan.Count;

            #endregion
            #region Testowanie czy porównanie długości ma w ogóle sens

            //var testCzyLista = test.ToList().Count;
            //var testDlugosciInnejListy = listaLosowan.Count;
            //if (testCzyLista == testDlugosciInnejListy)
            //{
            //    Console.WriteLine("Długośc jest taka sama!");
            //}
            //else
            //{
            //    Console.WriteLine("Długość się nie zgadza!");
            //} 

            #endregion
            #region Sprawdzanie czy 'Distinct' robi swoją robotę - niepotrzebne już. Mam inne metody.
            //IEnumerable<object> test = new List<object>();
            //test = listaLosowan.ToArray().Distinct();
            //var dlugoscListyTest = test.Count();
            //var dlugoscListyLosowan = listaLosowan.Count;
            //if (dlugoscListyTest != dlugoscListyLosowan)
            //{
            //    Console.WriteLine("jest roznica!!!");
            //} 
            #endregion
            var liczknikDuplikat = 0;
            var listaPowtorzonuchLosowan = new ArrayList();
            var licznikPetli = 1;
            var czasWykonywanaPetli = DateTime.Now;
            SzukanieDuplikatowLosowan(listaLosowan, licznikPetli, czasWykonywanaPetli, duplikatListyLosowan, listaPowtorzonuchLosowan, liczknikDuplikat);
            Console.WriteLine("Czas wykonania calosci programu: " + (DateTime.Now - czasStart));
        }

        private static void SzukanieDuplikatowLosowan(ArrayList listaLosowan, int licznikPetli, DateTime czasWykonywanaPetli,
            ArrayList duplikatListyLosowan, ArrayList listaPowtorzonuchLosowan, int liczknikDuplikat)
        {
            //var kontrolkaNazwyPliku = DateTime.Now;
            var sciezkaPlik = @"C:\Users\programowanie\Desktop\testy\pliczek";
            var sciezkaNumerator = Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) + Convert.ToString(DateTime.Now.Second);
            var sciezkaRozszerzenie = ".txt";
            var sciezka = sciezkaPlik + sciezkaNumerator + sciezkaRozszerzenie;
            string[] separatorNowejLiniit = new string [1];
                separatorNowejLiniit[0] = string.Empty ;
            var iteracja = 1;
            double procent = (Convert.ToDouble(licznikPetli * iteracja)) / (Convert.ToDouble(duplikatListyLosowan.Count));
            Console.WriteLine("Mam wystarczająco danych. Zaczynam porównania. Dam znac co 1k wykonanych iteracji.");
            foreach (var obiekt in listaLosowan)
            {
                
                if (licznikPetli == 1111)
                    {
                    
                    Console.WriteLine("Wykonałem już {0} porównań ze {3} losowań ({4}%). Minęło {1}. Znalazłem {2} duplikatów.", (licznikPetli*iteracja), 
                        (DateTime.Now - czasWykonywanaPetli), liczknikDuplikat, duplikatListyLosowan.Count, Math.Round(procent*100,5));
                        iteracja++;
                        licznikPetli = 0;
                    

                }
                #region Sprawdzanie funkcjonalności listowania znalezionych duplikatów
                ////Test, czy znajdowanie obiektów działa
                //duplikatListyLosowan.Clear();
                //duplikatListyLosowan.Insert(0, obiekt);

                #endregion

                if (duplikatListyLosowan.Contains(obiekt))
                {
                    Console.WriteLine("znalazłem powtarzające się losowania!");
                    listaPowtorzonuchLosowan.Clear();
                    listaPowtorzonuchLosowan.Add(obiekt);
                    liczknikDuplikat++;
                    
                    foreach (Array zduplikowaneLosowanie in listaPowtorzonuchLosowan)
                    {
                        foreach (var numerki in zduplikowaneLosowanie)
                        {
                            Console.Write(numerki + ", ");
                            File.AppendAllText(sciezka, Convert.ToString(numerki) + ", ");
                        }
                        Console.WriteLine();
                        File.AppendAllLines(sciezka, separatorNowejLiniit);
                        
                    }

                }
                licznikPetli++;
            }
            if (liczknikDuplikat == 0)
            {
                Console.WriteLine("Nic się nie powtórzyło...");
            }
            
        }

        private static void IloscLosowanNaListe(int[] losowanie, ArrayList listaLosowan, ArrayList duplikatListyLosowan, out int i)
        {
            var iteracja = 0;
            var licznikIteracji = 1;
            var licznikPrzeprowadzonychLosowan = 0;
            var czasStart = DateTime.Now;
            int[] test1 = new int [6];
            int[] test2 = new int [6];
            //var duplikatListyLosowan = new ArrayList();
            Console.WriteLine("Zaczynamy losowanie. Dam znać co 111k elementów.");
            for (i = 0; i < 14000000; i++)
            {
                LosowanieMetdaGlowna.LosowanieLiczb(test1);
                //var test1 = losowanie.AsEnumerable().ToArray();
                listaLosowan.Add(test1);
                LosowanieMetdaGlowna.LosowanieLiczb(test2);
                //var test2 = losowanie.AsEnumerable().ToArray();
               
                duplikatListyLosowan.Add(test2);
                //LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
                var rozne = losowanie.Distinct(); //do uniemozliwienia istnienia duplikatow w losowaniu
                var iloscElementowRozne = rozne.ToArray().Length;
                var iloscElementowLosowanie = losowanie.Length;
                double procent = Convert.ToDouble(iteracja * licznikIteracji) / 14000000;
                
                if (iloscElementowRozne == iloscElementowLosowanie)
                {
                    if (iteracja == 111111)
                    {
                        Console.WriteLine("Przeprowadziłem {0} z 14mln losowań --> {2}%. Minęło {1}", (iteracja * licznikIteracji), (DateTime.Now - czasStart), Math.Round(procent*100, 5));
                        licznikIteracji++;
                        iteracja = 0;
                    }
                }
               else
                {
                    Console.WriteLine("Znalazłem zduplikowane liczby w losowaniu - losuję jeszcze raz.");
                    listaLosowan.RemoveAt(i);
                    i--;
                }
                iteracja++;
                licznikPrzeprowadzonychLosowan++;


            }
            Console.WriteLine("W sumie losowań: {0}", licznikPrzeprowadzonychLosowan);
            
        }
    }
}
