using System;

namespace MyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    double Result = 0;

                    ICalculator calculator = new Calculator();

                    Console.WriteLine("Введите первое число: ");
                    double Num1 = calculator.ReadNum();

                    Console.WriteLine("Введите второе число: ");
                    double Num2 = calculator.ReadNum();

                    Result = calculator.Sum(Num1, Num2);

                    calculator.Calculate(Result);
                }

                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод! Повторите попытку.");
                }

                catch (OverflowException)
                {
                    Console.WriteLine("Число за пределами допустимого значения! Повторите попытку.");
                }

            }
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

        void ICalculator.Calculate(double Result)
        {
            Console.WriteLine($"Ваш результат: {Result}");
        }
    }
}
