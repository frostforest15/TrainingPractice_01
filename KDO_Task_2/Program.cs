using System;

namespace KDO_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово: ");
            string message = Console.ReadLine();

            while (!message.Contains("exit"))
            {
                if (message != "exit")
                {
                    Console.WriteLine("Повторите операцию или введите 'exit' для выхода");
                    message = Console.ReadLine();
                }
            }
        }
    }
}