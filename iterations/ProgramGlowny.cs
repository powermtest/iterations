using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace iterations
{
    public class ProgramGlowny
    {
        static void Main(string[] args)
        {
            int[] losowanie = new int[6];
            LosowanieMetdaGlowna.LosowanieLiczb();
            var listaLosowan = new List <int[]>();
            var duplikatListyLosowan = new List<int[]>();
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

            var listaPowtorzonuchLosowan = new List<int[]>();
            Duplikaty(listaLosowan);

            //SzukanieDuplikatowLosowan();
            Console.WriteLine("Czas wykonania calosci programu: " + (DateTime.Now - czasStart));
        }

         static void SzukanieDuplikatowLosowan()
        {
            //var kontrolkaNazwyPliku = DateTime.Now;
            var duplikatListyLosowan = new List<int[]>();
            var listaLosowan = new List<int[]>();
            IEnumerable<Array> duplikatyListyLosowanEnumerator = duplikatListyLosowan.Cast<int[]>();
            IEnumerable<Array> listaLosowanEnumerator = listaLosowan.Cast<int[]>();
            

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


            var licznikPetli = 1;
            var liczknikDuplikat = 0;
            var czasWykonywanaPetli = DateTime.Now;

            //foreach (int[] obiekt in listaLosowan)
            foreach (int[] obiekt in listaLosowanEnumerator)

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
                if (duplikatListyLosowan.Contains(obiekt) || duplikatyListyLosowanEnumerator.Contains(obiekt))
                    Console.WriteLine("To działa lepiej...");
                if (ciekawe != (-1))
                {
                    Console.WriteLine("znalazłem powtarzające się losowania!");
                    //Console.WriteLine(obiekt);
                    //listaPowtorzonuchLosowan.Clear();
                    //listaPowtorzonuchLosowan.Add(obiekt);
                    liczknikDuplikat++;

                    foreach (var liczba in obiekt)
                    //foreach (object zduplikowaneLosowanie in listaPowtorzonuchLosowan)
                    {
                        Console.WriteLine(liczba + ", ");
                        //foreach (var numerki in tymczasowe)
                        //{
                        //    Console.Write(numerki + ", ");
                        //    File.AppendAllText(sciezka, Convert.ToString(numerki) + ", ");
                        //}
                        
                    }
                    Console.WriteLine();
                    File.AppendAllLines(sciezka, separatorNowejLiniit);
                }
                licznikPetli++;
            }
            if (liczknikDuplikat == 0)
            {
                Console.WriteLine("Nic się nie powtórzyło...");
            }

        }

         static void IloscLosowanNaListe(int[] losowanie, List<int[]> listaLosowan, List<int[]> duplikatListyLosowan,
            out int i)
         {
             var test1 = new int[6];
             var test2 = new int[6];
            var iloscLosowanDoPrzeprowadzenia = 140;
            var iteracja = 0;
            var licznikIteracji = 1;
            var licznikPrzeprowadzonychLosowan = 0;
            var czasStart = DateTime.Now;
            Console.WriteLine("Zaczynamy losowanie. Dam znać co 111k elementów.");
            for (i = 0; i < iloscLosowanDoPrzeprowadzenia; i++)
            {
                //LosowanieMetdaGlowna.LosowanieLiczb();
                //var test1 = losowanie;
                listaLosowan.Add(LosowanieMetdaGlowna.LosowanieLiczb());
                test1 = listaLosowan.ElementAt(i);//LosowanieMetdaGlowna.LosowanieLiczb();
                //var test2 = losowanie;
                duplikatListyLosowan.Add(LosowanieMetdaGlowna.LosowanieLiczb());
                test2 = duplikatListyLosowan.ElementAt(i);
                var spr1 = test1.Distinct().Count();
                var spr2 = test2.Distinct().Count();

                if (spr1 != 6 || spr2 != 6)
                {
                    listaLosowan.RemoveAt(i);
                    duplikatListyLosowan.RemoveAt(i);
                    i--;
                    continue;
                }
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
        static void Duplikaty(List<int[]>tablica)
        {
            var liczbaTozsamych = 0;
            var wszystkieIdentyczneLosowania = new List<int[]>();
            var sciezkaPlik = @"C:\Users\programowanie\Desktop\testy\pliczek";
            var sciezkaNumerator = Convert.ToString(DateTime.Now.Hour) + Convert.ToString(DateTime.Now.Minute) +
                                   Convert.ToString(DateTime.Now.Second);
            var sciezkaRozszerzenie = ".txt";
            var sciezka = sciezkaPlik + sciezkaNumerator + sciezkaRozszerzenie;
            string[] separatorNowejLiniit = new string[1];
            separatorNowejLiniit[0] = string.Empty;

            var i = 0;
            foreach (int [] tymczasowaTablica1 in tablica)
            {
                //Sort(tymczasowaTablica1);
                for (int numerDrugiejTablicy = 1; numerDrugiejTablicy < tablica.Count; numerDrugiejTablicy++)
                {
                    var tymczasowaTablica2 = tablica[numerDrugiejTablicy];
                    //Sort(tymczasowaTablica2);
                    var listaIdentycznychNumerkow = new int[6];
                    //poniższa zmienna była potrzebna do testów
                    //var kontrolnalistaIdentycznycNumerkow = new int[6];
                    liczbaTozsamych = 0;
                    

                    for (int pozycjaNumeruZLosowania = 0; pozycjaNumeruZLosowania < tymczasowaTablica1.Length; pozycjaNumeruZLosowania++)
                    {
                        if (i == numerDrugiejTablicy)
                        {
                            break;
                        }
                        var numerekZPierwszejListy = tymczasowaTablica1[pozycjaNumeruZLosowania];
                        var numerekZDrugiejListy = tymczasowaTablica2[pozycjaNumeruZLosowania];
                        if (numerekZPierwszejListy == numerekZDrugiejListy)
                        {
                            listaIdentycznychNumerkow[liczbaTozsamych] = numerekZPierwszejListy;
                            //Zmienna poniżej jest w ramach testów
                            //kontrolnalistaIdentycznycNumerkow[liczbaTozsamych] = numerekZDrugiejListy;
                            liczbaTozsamych++;
                        }
                        else
                        {
                            pozycjaNumeruZLosowania = 0;
                            liczbaTozsamych = 0;
                            listaIdentycznychNumerkow = new int [6];
                            //poniższa zmienna była potrzebna do testów
                            //kontrolnalistaIdentycznycNumerkow = new int [6];
                            break;
                        }
                        if (liczbaTozsamych == 6)
                        {
                            Console.WriteLine("Pieknie! Mamy komplet!");
                            foreach (var VARIABLE in listaIdentycznychNumerkow)
                            {
                                Console.Write(VARIABLE + ", ");
                                File.AppendAllText(sciezka, Convert.ToString(VARIABLE) + ", ");
                            }

                            File.AppendAllLines(sciezka, separatorNowejLiniit);
                            wszystkieIdentyczneLosowania.Add(listaIdentycznychNumerkow);
                            //Console.Write(wszystkieIdentyczneLosowania.Count());
                        }

                    }

                }

                i++;

            }
            Console.WriteLine("Identycznych losowań było: {0}", wszystkieIdentyczneLosowania.Count());

        }

    }
}