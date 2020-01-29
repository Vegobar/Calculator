namespace Calculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            if (calc.Add(20, 10) == 30)
            {
                System.Console.WriteLine("Det forventede resultat af 20 + 10 er " + calc.Add(20, 10) + " hvilket er korrekt");
            }
            else
            {
                System.Console.WriteLine("Man fik IKKE det forventede resultat af 20 + 10, hvilket burde give 30");
            }
        }
    }
}