using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System;



namespace ComplexNumbers

{
    public class Number

    {
     private int real;
     public Number(int real)
     {
       this.real = real;
     }

public override string ToString()

        {
     return $"Number = {real}";
        }

    }
     public class ComplexNumber : Number

    {
      private int imaginary;
      public ComplexNumber(int real, int imaginary) : base(real)

        {
        this.imaginary = imaginary;
        }
      public static ComplexNumber Add(ComplexNumber num1, ComplexNumber num2)

        {
        return new ComplexNumber(num1.real + num2.real, num1.imaginary + num2.imaginary);
        }

      public static ComplexNumber Subtract(ComplexNumber num1, ComplexNumber num2)

        {
        return new ComplexNumber(num1.real - num2.real, num1.imaginary - num2.imaginary);
        }

      public static ComplexNumber Multiply(ComplexNumber num1, ComplexNumber num2)

        {
            int real = num1.real num2.real - num1.imaginary num2.imaginary;
         int imaginary = num1.real num2.imaginary + num1.imaginary num2.real;
        return new ComplexNumber(real, imaginary);

        }
        public static ComplexNumber Divide(ComplexNumber num1, ComplexNumber num2)

        {

            int denominator = num2.real num2.real + num2.imaginary num2.imaginary;
            int real = (num1.real num2.real + num1.imaginary num2.imaginary) / denominator;
            int imaginary = (num1.imaginary num2.real - num1.real num2.imaginary) / denominator;
            return new ComplexNumber(real, imaginary);

        }



        public override string ToString()

        {
         return $"ComplexNumber = {real} + {imaginary}i";

        }

    }
 class Program

    {
         static void Main(string[] args)

        {
             ComplexNumber num1 = new ComplexNumber(3, 4);
             ComplexNumber num2 = new ComplexNumber(5, -2);

            Console.WriteLine($"Первое число: {num1}");
            Console.WriteLine($"Второе число: {num2}");

          ComplexNumber sum = ComplexNumber.Add(num1, num2);
          ComplexNumber difference = ComplexNumber.Subtract(num1, num2);
            ComplexNumber product = ComplexNumber.Multiply(num1, num2);
            ComplexNumber quotient = ComplexNumber.Divide(num1, num2);

          Console.WriteLine($"Сумма: {sum}");
           Console.WriteLine($"Разность: {difference}");
       Console.WriteLine($"Произведение: {product}");
        Console.WriteLine($"Частное: {quotient}");

        }

    }

}