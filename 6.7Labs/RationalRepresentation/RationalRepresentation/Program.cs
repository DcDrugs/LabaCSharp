using System;
using System.Text;

namespace RationalRepresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational rational1, rational2, rational3;
            Rational.TryParse("2/7", out rational2);
            Rational.TryParse("4/9", out rational1);
            Rational rational4 = Rational.Parse("2/3");
            Rational.TryParse("2c/3", out rational3);
            Console.WriteLine(rational1.ToString());
            Console.WriteLine(rational2.ToString());
            Console.WriteLine(rational3.ToString());
            Console.WriteLine(rational4.ToString());
            Console.WriteLine((rational1 + rational2).ToString());
            Console.WriteLine((rational1 - rational2).ToString());
            Console.WriteLine((rational1 / rational2).ToString());
            Console.WriteLine((rational1 * rational2).ToString());
            Console.WriteLine((rational1 % rational2).ToString());
            Console.WriteLine((rational1 > rational2).ToString());
            Console.WriteLine((rational1 < rational2).ToString());
            Console.WriteLine((rational1 >= rational2).ToString());
            Console.WriteLine((rational1 <= rational2).ToString());
            Console.WriteLine((rational1 == rational2).ToString());
            Console.WriteLine((rational1 != rational2).ToString());
            Console.WriteLine((rational1++).ToString());
            Console.WriteLine((++rational1).ToString());
            Console.WriteLine((rational1--).ToString());
            Console.WriteLine((--rational1).ToString());
            Console.WriteLine((-rational1).ToString());
            Console.WriteLine((+rational1).ToString());
            Console.WriteLine(Rational.Pow(rational1, 0.5).ToString());
            rational1.Pow(2);
            Console.WriteLine(rational1.ToString());
            rational1 %= rational2;
            Console.WriteLine(rational1.ToStringFormat(6));
        }
    }
}
