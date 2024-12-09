using System;

namespace DesignPatterns
{
    public static class ExecucaoObserver
    {
        public static void Executar()
        {
            var joao = new Observador("João");
            var danps = new Observador("Danilo");
            var pedro = new Observador("Pedro");

            var amazon = new PapelBovespa("Amazon", NextDecimal());
            var microsoft = new PapelBovespa("Microsoft", NextDecimal());
            
            amazon.Subscribe(joao);
            amazon.Subscribe(danps);

            microsoft.Subscribe(danps);
            microsoft.Subscribe(pedro);

            Console.WriteLine("");
            Console.WriteLine("------------------");
            Console.WriteLine("");

            for (int i = 0; i < 5; i++)
            {
                amazon.Valor = NextDecimal();
                microsoft.Valor = NextDecimal();

                if (i == 1)
                {
                    amazon.UnSubscribe(danps);
                }
            }
        }

        public static decimal NextDecimal()
        {
            var random = new Random();
            var r = random.Next(141421, 314160);
           return r / (decimal) 100000.00;
        }
    }
}