using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
            //File.OpenWrite(sciezka);

            //var pliczek = File.Create(sciezka);

            //pliczek.Name.Insert(0, Convert.ToString(DateTime.Now));
            var iteracja = 1;

            foreach (var obiekt in listaLosowan)
            {
                
                if (licznikPetli == 1000)
                    {
                    
                    Console.WriteLine("Wykonałem już {0} porównań. Minęło {1}", (licznikPetli*iteracja), (DateTime.Now - czasWykonywanaPetli));
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
                    //var separator = "------------------";
                    //var sciezkaPlikuZDuplikatami = sciezka + liczknikDuplikat;
                    
                    foreach (Array zduplikowaneLosowanie in listaPowtorzonuchLosowan)
                    {
                        foreach (var numerki in zduplikowaneLosowanie)
                        {
                            Console.Write(numerki + ", ");
                            File.AppendAllText(sciezka, Convert.ToString(numerki) + ", ");
                            //zduplikowaneLosowanie.SetValue(0, 0);
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
            
            //var duplikatListyLosowan = new ArrayList();
            for (i = 0; i < 155000; i++)
            {
                LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
                var test1 = losowanie.AsEnumerable().ToArray();
                listaLosowan.Add(test1);
                LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
                var test2 = losowanie.AsEnumerable().ToArray();
                duplikatListyLosowan.Add(test2);
                //LosowanieMetdaGlowna.LosowanieLiczb(losowanie);
                var rozne = losowanie.Distinct(); //do uniemozliwienia istnienia duplikatow w losowaniu
                var iloscElementowRozne = rozne.ToArray().Length;
                var iloscElementowLosowanie = losowanie.Length;
                if (iloscElementowRozne == iloscElementowLosowanie)
                {
                    switch (i)
                    {
                        case 50000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;
                        case 100000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;
                        case 150000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;
                        case 250000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;
                                
                        case 500000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 750000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 900000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 1250000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 1750000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 2500000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 3500000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 5000000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 7500000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 9000000:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 11111111:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 12222222:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 13333333:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                            break;

                        case 14444444:
                            Console.WriteLine("Przeprowadziłem już {0} losowań!", i);
                           break;
                    }
                }
                else
                {
                    Console.WriteLine("Znalazłem zduplikowane liczby w losowaniu - losuję jeszcze raz.");
                    listaLosowan.RemoveAt(i);
                    i--;
                }
               
                
            }
            //skoro mam dwie osobno generowane listy, to poniższe jest nieaktualne...
            //if (listaLosowan.Equals(duplikatListyLosowan))
            //{
            //    Console.WriteLine("listy są identyczne");
            //}
        }
    }
}
