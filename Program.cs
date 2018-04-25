using System;
using System.IO;
using System.Globalization;

namespace Tapahtumat
{
    class Program
    {

        public static string LueValinta() //Funktio jolla luetaan valinta
        {
            string valinta;
            valinta = Console.ReadLine();
            return valinta;
        }

        public static string LueTapahtuma() //Funktio jolla luetaan käyttäjän input + add timestamp
        {
            string tapahtuma;
            tapahtuma = Console.ReadLine(); //luetaan input

            return tapahtuma; // palautetaan tapahtuma
        }
        public static void TallennaTapahtuma(string a, string tapahtuma, string aika)
        {
            StreamWriter tallennin;
            tallennin = File.AppendText(a);
            tallennin.WriteLine(aika+": "+ tapahtuma);
            tallennin.Close();

        }
        public static void PoistaTapahtumat(string a)
        {

            string tyhja ="";
            StreamWriter Poistaja; //syötteen lukija

            Poistaja = File.CreateText(a);
            Poistaja.Write(tyhja);
            Poistaja.Close();

        }
        public static void TulostaTapahtumat(string a)
        {
            //Tulostetaan kaikki tähän mennessä annetut syötteet
            StreamReader Tulostaja; //listan tulostus
            String tapahtumat;
            Tulostaja = File.OpenText(a);
            tapahtumat = File.ReadAllText(a);
            Console.Write(tapahtumat);
            Tulostaja.Close();
        }



        public static void Main(string[] args)
        {
            //muuttujia
            string aika = DateTime.Now.ToString(CultureInfo.GetCultureInfo("fi-FI")); //Kellonaika
            string tied = @"Z:\Tiedosto.txt";

            while (true)
            {
                //valintavalikon tulostus
                Console.Write("Anna valintasi: ");

                string i = LueValinta();

                if (i == "l")//täs vissii luetaa ja tallennetaa tiedostoon käyttäjän syöte
                {
                    Console.Write("Anna tapahtumarivi: ");

                    string jotain;
                    jotain = LueTapahtuma();
                    TallennaTapahtuma(tied, jotain, aika);

                }
                else if (i == "t")//Unrelated: Jos on vaan 1 kpl = niin ei skulaa, käytä aina ==
                {
                    //Tulostetaan kaikki tähän mennessä annetut syötteet
                    TulostaTapahtumat(tied);
                }
                else if (i == "p")//poistetaan kaikki tapahtumat
                    PoistaTapahtumat(tied);

                else if (i == "")
                {
                    Environment.Exit(0);
                }
            }







        }
    }
}