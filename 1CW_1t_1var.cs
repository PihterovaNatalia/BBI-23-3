using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_задача
{ using System;



struct Number

{
      public int RealPart;
      public Number(int realPart)

    {
       RealPart = realPart;
     }
       public static Number Add(Number num1, Number num2)

    {
        return new Number(num1.RealPart + num2.RealPart);
     }
        public static Number Subtract(Number num1, Number num2)

     {
      return new Number(num1.RealPart - num2.RealPart);
      }
      public static Number Multiply(Number num1, Number num2)

    {
       return new Number(num1.RealPart * num2.RealPart);
     }
     
        public static Number Divide(Number num1, Number num2)

    {

        if (num2.RealPart == 0)

        {
                throw new DivideByZeroException("Деление на ноль невозможно.");
            }

        return new Number(num1.RealPart / num2.RealPart);

    }
       public void Print()

    {
      Console.WriteLine($"Number = {RealPart}");
     }

}
         class Program

    {
        static void Main()

        {
         Number num1 = new Number(10);
         Number num2 = new Number(5);
         Number sum = Number.Add(num1, num2);
         Number difference = Number.Subtract(num1, num2);

            Number product = Number.Multiply(num1, num2);

            Number quotient = Number.Divide(num1, num2);



            num1.Print();

            num2.Print();

            sum.Print();

            difference.Print();

            product.Print();
            quotient.Print();

        }
    }
}