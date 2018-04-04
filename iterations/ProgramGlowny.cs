using System;
using System.Collections;
using System.Linq;
using System.IO;


namespace iterations
{
    class ProgramGlowny
    {
        static void Main(string[] args)
        {
            int[] losowanie = new int[6];
            LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
            ArrayList listaLosowan = new ArrayList();
            ArrayList duplikatListyLosowan = new ArrayList();
            var czasStart = DateTime.Now;
            
            Console.WriteLine("Start aplikacji: " + czasStart);
            
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
            SzukanieDuplikatowLosowan(listaLosowan, licznikPetli, czasWykonywanaPetli, duplikatListyLosowan,
                listaPowtorzonuchLosowan, liczknikDuplikat);
            Console.WriteLine("Czas wykonania calosci programu: " + (DateTime.Now - czasStart));
        }

        private static void SzukanieDuplikatowLosowan(ArrayList listaLosowan, int licznikPetli,
            DateTime czasWykonywanaPetli,
            ArrayList duplikatListyLosowan, ArrayList listaPowtorzonuchLosowan, int liczknikDuplikat)
        {
            //var kontrolkaNazwyPliku = DateTime.Now;
            var sciezkaPlik = @"C:\Users\programowanie\Desktop\testy\pliczek";
            var sciezkaNumerator = Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) +
                                   Convert.ToString(DateTime.Now.Second);
            var sciezkaRozszerzenie = ".txt";
            var sciezka = sciezkaPlik + sciezkaNumerator + sciezkaRozszerzenie;
            string[] separatorNowejLiniit = new string [1];
            separatorNowejLiniit[0] = string.Empty;
            var iteracja = 1;
            //double procent = (Convert.ToDouble(licznikPetli * iteracja)) / (Convert.ToDouble(duplikatListyLosowan.Count));
            Console.WriteLine("Mam wystarczająco danych. Zaczynam porównania. Dam znac co 1k wykonanych iteracji.");

            foreach (Array obiekt in listaLosowan)
            {

                if (licznikPetli == 1111)
                {

                    Console.WriteLine(
                        "Wykonałem już {0} porównań ze {3} losowań ({4}%). Minęło {1}. Znalazłem {2} duplikatów.",
                        (licznikPetli * iteracja),
                        (DateTime.Now - czasWykonywanaPetli), liczknikDuplikat, duplikatListyLosowan.Count,
                        Math.Round((Convert.ToDouble(licznikPetli * iteracja) / 14000000) * 100, 5));
                    iteracja++;
                    licznikPetli = 0;


                }

                #region Sprawdzanie funkcjonalności listowania znalezionych duplikatów

                ////Test, czy znajdowanie obiektów działa
                //duplikatListyLosowan.Clear();
                //duplikatListyLosowan.Insert(0, obiekt);

                #endregion

                var ciekawe = duplikatListyLosowan.IndexOf(obiekt);
                //if (duplikatListyLosowan.Contains(obiekt))
                if (ciekawe != (-1))
                {
                    Console.WriteLine("znalazłem powtarzające się losowania!");
                    //Console.WriteLine(obiekt);
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

        private static void IloscLosowanNaListe(int[] losowanie, ArrayList listaLosowan, ArrayList duplikatListyLosowan,
            out int i)
        {
            var iloscLosowanDoPrzeprowadzenia = 140000;
            var iteracja = 0;
            var licznikIteracji = 1;
            var licznikPrzeprowadzonychLosowan = 0;
            var czasStart = DateTime.Now;
            Console.WriteLine("Zaczynamy losowanie. Dam znać co 111k elementów.");
            for (i = 0; i < iloscLosowanDoPrzeprowadzenia; i++)
            {
                LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
                var test1 = losowanie.ToArray().AsEnumerable();
                listaLosowan.Add(test1);
                LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
                var test2 = losowanie.ToArray().AsEnumerable();
                duplikatListyLosowan.Add(test2);
                //var spr1 = test1.Count();
                //var spr2 = test2.Count();

                double procent = Convert.ToDouble(iteracja * licznikIteracji) / iloscLosowanDoPrzeprowadzenia;

                //if (spr1 == spr2)
                //{
                    if (iteracja == 111111)
                    {
                        Console.WriteLine("Przeprowadziłem {0} z 14mln losowań --> {2}%. Minęło {1}",
                            (iteracja * licznikIteracji), (DateTime.Now - czasStart), Math.Round(procent * 100, 5));
                        licznikIteracji++;
                        iteracja = 0;
                    }
                //}
                //else
                //{
                //    Console.WriteLine("Znalazłem zduplikowane liczby w losowaniu - losuję jeszcze raz.");
                //    listaLosowan.RemoveAt(i);
                //    duplikatListyLosowan.RemoveAt(i);
                //    i--;
                //}
                iteracja++;
                licznikPrzeprowadzonychLosowan++;


            }

            Console.WriteLine("W sumie losowań: {0}", licznikPrzeprowadzonychLosowan);
            //    listaLosowan.Sort();
            //    duplikatListyLosowan.Sort();
            //listaLosowan.Sort();

        }

    }
}