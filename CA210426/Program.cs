using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210426
{
    class Program
    {
        static int pontszam = 0;
        static List<TesztKerdes> kerdesek;
        static Random rnd = new Random();
        static void Main()
        {
            Feladatismertetes();
            Teszt();
            Eredmeny();
        }

        private static void Feladatismertetes()
        {
            Console.CursorVisible = false;
            var sr = new StreamReader(@"..\..\RES\feladat.txt", Encoding.UTF8);
            Console.WriteLine("Szókincs\n\n");
            //TODO: szavak mentén való sortörés
            Console.WriteLine(sr.ReadLine());
            sr.Close();
            Tovabb("Kezdéshez nyomja meg az ENTER-t!");
        }
        private static void Teszt()
        {
            Inicializalas();
            foreach (var k in kerdesek)
            {
                Console.WriteLine(k.Kerdes);

                foreach (var vl in k.ValaszLehetosegek)
                {
                    Console.WriteLine($"\t{vl}");
                }
                
                Console.Write("\n\nhelyes válasz betűjele: ");
                var tipp = Console.ReadKey(false).KeyChar;

                if (tipp == k.Megoldas)
                {
                    Console.WriteLine("\n\tHelyes válasz!");
                    pontszam++;
                }
                else Console.WriteLine("\n\tRossz válasz. =(");

                if (kerdesek.IndexOf(k) != kerdesek.Count - 1)
                {
                    Tovabb("Következő kérdéshez nyomjon ENTER-t!");                  
                }
                else Tovabb("Kiértékeléshez nyomjon ENTERT-t!");
            }
        }
        private static void Eredmeny()
        {
            //TODO: adatok rögzítése
            Console.WriteLine($"Helyes válaszok száma: {pontszam}/{kerdesek.Count}");

            Console.Write("\n\nSzertné menteni az eredményit (y/n)? ");
            if(Console.ReadKey().KeyChar == 'y')
            {
                var sw = new StreamWriter(@"..\..\RES\eredmeny.txt", true, Encoding.UTF8);
                Console.Write("\n\nNeve: ");
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd")};{Console.ReadLine()};{pontszam}");
                sw.Close();
                Console.WriteLine("\nRögzítés megtörtént!");
            }
            Tovabb("Bezáráshoz nyomjon ENTER-t!");
        }
        private static void Inicializalas()
        {
            kerdesek = new List<TesztKerdes>();

            var srTeszt = new StreamReader(@"..\..\RES\teszt.txt", Encoding.UTF8);
            var srMegoldas = new StreamReader(@"..\..\RES\megoldas.txt", Encoding.UTF8);

            while (!srMegoldas.EndOfStream && !srTeszt.EndOfStream)
            {
                var kerdes = srTeszt.ReadLine();
                var valaszLehetosegek = new string[]
                {
                    /*A: */ srTeszt.ReadLine(),  
                    /*B: */ srTeszt.ReadLine(),  
                    /*C: */ srTeszt.ReadLine(),
                };
                var megoldas = char.Parse(srMegoldas.ReadLine().ToLower());
                kerdesek.Add(new TesztKerdes(kerdes, valaszLehetosegek, megoldas));
            }

            srMegoldas.Close();
            srTeszt.Close();
            /*
            for (int i = 0; i < kerdesek.Count / 2; i++)
            {
                int x = rnd.Next(kerdesek.Count);
                int y = rnd.Next(kerdesek.Count);

                var s = kerdesek[x];
                kerdesek[x] = kerdesek[y];
                kerdesek[y] = s;
            }
            */
        }
        private static void Tovabb(string szoveg)
        {
            Console.Write($"\n\n{szoveg}");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter);
            Console.Clear();
        }
    }
}
