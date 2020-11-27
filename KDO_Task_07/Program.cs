using System;

namespace KDO_Task_07
{
    class Program
    {
        //заполнение массива случайными значениями
        static void Rand(int[] mass)
        {
            Random random = new Random();

            for (int i = 0; i < mass.Length; ++i)
            {
                mass[i] = random.Next();
            }
        }

        // вывода массива
        static void Out(int[] mass)
        {
            for (int i = 0; i < mass.Length; ++i)
            {
                Console.WriteLine(i + " : " + mass[i]);
            }
        }

        // перемешивание элементов
        static int[] Shuffle(int[] mass)
        {
            Random random = new Random();

            // TE - временное хранилище перемещаемого элемента
            // RP - случайно вычисляемый индекс второго элемента
            int TE, RP;

            // с конца до начала
            for (int i = mass.Length - 1; i > 0; i--)
            {
                RP = random.Next(i);
                TE = mass[i];
                mass[i] = mass[RP];
                mass[RP] = TE;
            }

            // Возвращает массив
            return mass;
        }

        static void Main(string[] args)
        {
            // Ввод размерности массива
            Console.WriteLine("Введите размерность массива!");
            uint Size = Convert.ToUInt32(Console.ReadLine());

            // Заполнение массива случайными числами
            int[] mass = new int[Size]; // Первоначальный массив
            Rand(mass);

            // Вывод исходного массива до перемешивания
            Console.WriteLine("\nИсходный массив: ");
            Out(mass);

            // Перемешивание элементов массива
            Shuffle(mass);

            // Вывод перемешанного массива
            Console.WriteLine("\nПеремешанный массив: ");
            Out(mass);

            Console.ReadKey();
        }
    }
}