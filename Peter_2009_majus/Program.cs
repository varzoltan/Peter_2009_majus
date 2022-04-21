using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Peter_2009_majus
{
    class Adat
    {
        public int ora { get; set; }
        public int perc { get; set; }
        public int masodperc { get; set; }
        public int csapat { get; set; }
        public int induloszint { get; set; }
        public int celszint { get; set; }
        public Adat(string sor)//Konstruktor
        {
            string[] db = sor.Split();
            ora = int.Parse(db[0]);
            perc = int.Parse(db[1]);
            masodperc = int.Parse(db[2]);
            csapat = int.Parse(db[3]);
            induloszint = int.Parse(db[4]);
            celszint = int.Parse(db[5]);
        }
    }
    internal class Program
    {
        static List<Adat> lista = new List<Adat>();
        static void Main(string[] args)
        {

            //1.feladat: Beolvasás
            Console.WriteLine("1.feladat: Beolvasás kész!");
            foreach (var i in File.ReadLines("igeny.txt").Skip(3))
            {
                lista.Add(new Adat(i));
            }

            //2.feladat
            Console.WriteLine("\n2.feladat");
            Console.Write("Kérem adja meg hol áll a lift a megfigyelés kezedetén: ");
            int liftkezdet = int.Parse(Console.ReadLine());

            Console.ReadKey();
        }
    }
}
