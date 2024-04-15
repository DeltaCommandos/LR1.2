using System;
using System.Globalization;
using System.Text;
using LR1._2;

//  Вывод


class Program
{
    static void Main(string[] args)
    {
        Printer europeanPrinter = new EuPrinter();
        Printer americanPrinter = new AmPrinter();

        Printer decoratedEuPrinter = new PostDecorator(new PreDecorator(europeanPrinter, "    Euro ||  "), "   ||Spar");
        Printer decoratedAmPrinter = new PostDecorator(new PreDecorator(americanPrinter, "American <<  "), " >> Boy");

        Console.WriteLine("\nEuropean Style: " + decoratedEuPrinter.Print());
        Console.WriteLine("\nAmerican Style: " + decoratedAmPrinter.Print());
    }
}
