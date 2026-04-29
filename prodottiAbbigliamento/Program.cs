using System;
using System.Collections.Generic;

namespace prodottiAbbigliamento
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string file = "prodotti_abbigliamento.csv";
            string[] f = File.ReadAllLines(file);
            List<double> Prezzi = new List<double>();
            List<string> Categorie = new List<string>();
            List<string> CategorieF = new List<string>();

            double somma = 0;
            int k = 0;
            bool trovato = false;
            for (int i = 1; i < f.Length; i++) //leggo i prezzi
            {
                string[] riga = f[i].Split(',');
                Prezzi.Add(Convert.ToDouble(riga[3].Replace(".", ",")));


            }
            foreach (double i in Prezzi) // faccio la somma e la media dei prezzi
            {
                somma = somma + i;
            }
            double media = somma / Prezzi.Count;
            Console.WriteLine("La somma dei vari prezzi e: " + somma + " la media e: " + media);

            for (int i = 1; i < f.Length; i++) //Leggo le  categorie non disponibili
            {
                string[] riga = f[i].Split(',');
                if (riga[4] == "Non disponibile")
                {
                    k++;
                }
            }
            Console.WriteLine("I prodotti non disponibili sono: " + k);


            for (int i = 1; i < f.Length; i++)
            {
                string[] riga = f[i].Split(',');
                Categorie.Add(riga[2]);
            }
            foreach (string cate in Categorie)
            {
                trovato = false;
                foreach (string i in CategorieF)
                {
                    if (cate == i)
                    {
                        trovato = true;
                    }
                }
                if (trovato == false)
                {
                    CategorieF.Add(cate);
                }


            }
            Console.WriteLine("Le categorie sono: " + CategorieF.Count);

        }
    }
}
