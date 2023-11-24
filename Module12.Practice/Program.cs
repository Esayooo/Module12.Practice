using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module12.Practice
{
    // Создаем делегат для арифметических операций
    delegate double MathOperation(double x, double y);
        class Program
        {
            // Статические методы для выполнения арифметических операций
            static double Add(double x, double y) => x + y;
            static double Subtract(double x, double y) => x - y;
            static double Multiply(double x, double y) => x * y;
            static double Divide(double x, double y)
            {
                if (y != 0)
                    return x / y;
                else
                {
                    Console.WriteLine("Деление на ноль невозможно.");
                    return double.NaN;
                }
            }
            // Метод для выполнения операции, представленной делегатом
            static double PerformOperation(double x, double y, MathOperation operation)
            {
                return operation(x, y);
            }
            static void Main()
            {
                // Создаем экземпляры делегата и инициализируем их методами
                MathOperation addOperation = Add;
                MathOperation subtractOperation = Subtract;
                MathOperation multiplyOperation = Multiply;
                MathOperation divideOperation = Divide;

                // Используем метод PerformOperation с разными операциями
                double result1 = PerformOperation(5, 3, addOperation);
                Console.WriteLine($"Результат сложения: {result1}");

                double result2 = PerformOperation(5, 3, subtractOperation);
                Console.WriteLine($"Результат вычитания: {result2}");

                double result3 = PerformOperation(5, 3, multiplyOperation);
                Console.WriteLine($"Результат умножения: {result3}");

                double result4 = PerformOperation(5, 3, divideOperation);
                Console.WriteLine($"Результат деления: {result4}");

                // Используем анонимный метод для инициализации делегата
                MathOperation powerOperation = delegate (double x, double y) { return Math.Pow(x, y); };

                // Используем лямбда-выражение для инициализации делегата
                MathOperation squareRootOperation = (x, y) => Math.Pow(x, 1 / y);

                // Используем цепочку делегатов для выполнения нескольких операций подряд
                MathOperation chainedOperation = addOperation + multiplyOperation + powerOperation;
                double result5 = PerformOperation(2, 3, chainedOperation);
                Console.WriteLine($"Результат цепочки операций: {result5}");
            }
        }
}
