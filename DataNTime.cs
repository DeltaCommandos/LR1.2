using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1._2
{
    abstract class Printer
    {
        public abstract string Print();
    }

    class EuPrinter : Printer
    {
        public override string Print()
        {
            DateTime ddT = DateTime.Now;
            CultureInfo cultureInfo = new CultureInfo("en-GB");
            return ddT.ToString(cultureInfo);
        }
    }

    class AmPrinter : Printer
    {
        public override string Print()
        {
            DateTime ddT = DateTime.Now;
            CultureInfo cultureInfo = new CultureInfo("en-US");
            return ddT.ToString(cultureInfo);
        }
    }


    //  Декорация
    abstract class Decorator : Printer
    {
        protected Printer printer;

        public Decorator(Printer printer)
        {
            this.printer = printer;
        }

        public override string Print()
        {
            string ddT_BAZA = printer.Print();
            return DecorateDateTime(ddT_BAZA);
        }

        protected abstract string DecorateDateTime(string ddT);
    }

    // Декоратор, добавляющий чето в начало строки 
    class PreDecorator : Decorator
    {
        private string prosvistit;  //перед ддт

        public PreDecorator(Printer printer, string prosvistit) : base(printer)
        {
            this.prosvistit = prosvistit;
        }

        protected override string DecorateDateTime(string ddT)
        {
            return prosvistit + ddT;
        }
    }

    // Декоратор, добавляющий чето в конец строки 
    class PostDecorator : Decorator
    {
        private string prosvistela; //после ддт

        public PostDecorator(Printer printer, string prosvistela) : base(printer)
        {
            this.prosvistela = prosvistela;
        }

        protected override string DecorateDateTime(string ddT)
        {
            return ddT + prosvistela;
        }
    }
}
