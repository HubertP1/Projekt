namespace App
{
    class HelloWorld
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Suma suma = new Suma();
            int wynik = suma.Sum(2, 2);
            Console.WriteLine(wynik);
        }
    }
}
