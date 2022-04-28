﻿using System;
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
        public int maxemelet{get {return Math.Max(induloszint,celszint);} }
        public int minemelet { get { return Math.Min(induloszint, celszint); } }
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

            //3.feladat
            Console.WriteLine("\n3.feladat");
            Console.WriteLine($"A lift a {lista.Last().celszint}. szinten áll az utolsó igény teljesítése után.");

            //4.feladat
            Console.WriteLine("\n4.feladat");
            /*int max = int.MinValue, min = int.MaxValue;
            foreach (var i in lista)
            {
                if (max<i.maxemelet)
                {
                    max = i.maxemelet;
                }
                if (min > i.minemelet)
                {
                    min = i.minemelet;
                }
            }*/
            var max = lista.OrderByDescending(x => x.maxemelet);
            var min = lista.OrderBy(x => x.minemelet);
            Console.WriteLine($"A legmagasabb sorszámú emelet a {Math.Max(max.ElementAt(0).maxemelet,liftkezdet)} emelet.");
            Console.WriteLine($"A legkisebb sorszámú emelet a {Math.Min(min.ElementAt(0).minemelet, liftkezdet)} emelet.");

            //5.feladat
            Console.WriteLine("\n5.feladat");
            int emberrel_felefele = 0;
            for (int i = 0;i<lista.Count()-1;i++)
            {
                if (lista[i].induloszint < lista[i].celszint)
                {
                    emberrel_felefele++;
                }
            }
            Console.WriteLine($"A lift emberrel felefelé {emberrel_felefele}-szer ment!");
            Console.ReadKey();
        }
    }
}
