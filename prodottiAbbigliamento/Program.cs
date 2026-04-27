namespace prodottiAbbigliamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "prodotti_abbigliamento.csv";
            string[] f = File.ReadAllLines(file);
            List<double> lista = new List<double>();
            int somma = 0;
            for(int i = 1;  i < f.Length; i++)
            {
                string[] riga = f[i].Split(',');
                lista.Add(Convert.ToInt32(riga[3]));
               
               
            }
            foreach(double i in  lista)
            {
                Console.WriteLine(i);
            }

        }
    }
}
