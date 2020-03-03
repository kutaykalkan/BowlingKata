using System;
using SimpleInjector;

namespace BowlingKata
{
    class Program
    {
        private static readonly Container Container = new Container();
        static void Main(string[] args)
        {
            RegisterServices();
            Console.WriteLine("Hello World!");
        }
        
        private static void RegisterServices()
        {
            //Container.Register<>();
            
            Container.Verify();
        }
    }
}