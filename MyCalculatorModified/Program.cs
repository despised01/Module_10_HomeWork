using System;
using System.Threading;

namespace MyCalculatorModified
{
    class Program
    {
        private static ILogger Logger { get; set; }

        static void Main(string[] args)
        {
            while (true)
            {
                double Result = 0;

                Logger = new Logger();

                ICalculator calculator = new Calculator(Logger);

                try
                {      
                    Console.WriteLine("Введите первое число: ");
                    double Num1 = calculator.ReadNum();

                    Console.WriteLine("Введите второе число: ");
                    double Num2 = calculator.ReadNum();

                    Thread.Sleep(250);

                    Result = calculator.Sum(Num1, Num2);

                    Thread.Sleep(500);

                    calculator.Calculate(Result);
                }

                catch (FormatException FoEx)
                {
                    Logger.Error("Некорректный ввод! Повторите попытку.");
                    Logger.Error(FoEx.Message);
                }

                catch (OverflowException OfEx)
                {
                    Logger.Error("Число за пределами допустимого значения! Повторите попытку.");
                    Logger.Error(OfEx.Message);
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

    public class Calculator : ICalculator
    {
        private ILogger Logger { get; }

        public Calculator(ILogger logger)
        {
            Logger = logger;
        }

        double ICalculator.Sum(double Num1, double Num2)
        {
            Logger.Event("Выполняется операция сложения...");

            Thread.Sleep(250);

            return Num1 + Num2;
        }

        double ICalculator.ReadNum()
        {
            string NumRead = Console.ReadLine();

            Logger.Event("Обработка...");

            Thread.Sleep(500);

            return Convert.ToDouble(NumRead);
        }

        void ICalculator.Calculate(double Result)
        {
            Console.WriteLine($"Ваш результат: {Result}");
        }
    }
}
