using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;

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
            List<string> nome = new List<string>();
            List<string> categorietot = new List<string>();

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


            List<double> inflazione = new List<double>();
            List<string> disponibilità = new List<string>();

            for(int i = 1; i < f.Length; i++)
            {
                string[] riga = f[i].Split(",");
                riga[3] = riga[3].Replace(".", ",");
                inflazione.Add(Convert.ToDouble(riga[3]));
                nome.Add(riga[1]);
                categorietot.Add(riga[2]);
                disponibilità.Add(riga[4]);

            }

            string fileSec = "prodotti_abbligliamento_aggiornati.csv";

            if (!File.Exists(fileSec))
            {
                File.Create(fileSec);
            }

            double percentuale = 0;
            for(int i = inflazione.Count - 1; i >= 0; i--)
            {
                percentuale = (inflazione[i] * 10) / 100;
                inflazione[i] += percentuale;
                
            }
            using(StreamWriter sw =  new StreamWriter(fileSec))
            {
                sw.WriteLine("ID,Nome,Categoria,Prezzo,Disponibilita");
                for(int i = 0; i < Prezzi.Count; i++)
                {
                    sw.WriteLine((i + 1) + "," + nome[i] + "," + categorietot[i] + "," + inflazione[i] + "," + disponibilità[i]);
                }
            }

            foreach(string c in categorietot)
            {
                using(StreamWriter sw = new StreamWriter(c + ".txt"))
                {

                }
            }
            
        }
    }
}
