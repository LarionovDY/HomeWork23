using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork23
{
    class Program
    {
        //Разработать асинхронный метод для вычисления факториала числа.
        //В методе Main выполнить проверку работы метода.
        static void Main(string[] args)
        {
            int n = ReadPosValue("Введите число, факториал которого хотите вычислить:");
            ulong result = FactorialResultAsync(n).Result;
            if (result > 0)
            {
                Console.WriteLine($"Результат выполнения операции: {result}");
            }
            else 
            {
                Console.WriteLine("Ошибка, слишком большое число");
            }            
            Console.ReadKey();
        }
        static int ReadPosValue(string text)   //метод проверяющий корректность ввода данных
        {
            int value;
            while (true)
            {
                Console.WriteLine(text);
                if (Int32.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ввод некорректен");
                }
            }
        }
        static ulong Factorial(int n)       //метод, вычисляющий факториал
        {
            try
            {
                checked
                {
                    ulong factorial = 1;
                    for (int i = 1; i <= n; i++)
                    {
                        factorial *= (ulong)i;
                        Console.Write($"Факториал числа {i} : {factorial}\n");
                        Thread.Sleep(200);
                    }
                    return factorial;
                }
            }
            catch (System.OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        static async Task<ulong> FactorialResultAsync(int n)        //метод, ожидающий результата вычисления факториала
        {
            Console.WriteLine("Начало выполнения вычисления факториала");
            ulong x = await Task.Run(() => Factorial(n));
            Console.WriteLine("Факториал вычислен");
            return x;            
        }
    }
}
