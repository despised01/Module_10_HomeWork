using System;

namespace MyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface ICalculator
    {
        double Sum(double Num1, double Num2);

        double ReadNum();

        void Calculate(double Result);
    }

    public class Calculator: ICalculator
    {
        double ICalculator.Sum(double Num1, double Num2)
        {
            return Num1 + Num2;
        }

        double ICalculator.ReadNum()
        {
            return Convert.ToDouble(Console.ReadLine());
        }

        void ICalculator.Calculate(double result)
        {
            Console.WriteLine($"Ваш результат: {result}");
        }
    }
}
