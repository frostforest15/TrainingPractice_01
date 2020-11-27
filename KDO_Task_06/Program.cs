using System;

namespace KDO_Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            short menu;

            string[] full = new string[0]; // ФИО
            string[] pos = new string[0]; // должности


            while (true)
            {
                Console.Clear();

                // вывод меню
                Menu();

                // выбор пункта меню
                menu = Convert.ToInt16(Console.ReadLine());

                // выполнение действия
                switch (menu)
                {
                    case 1:
                        Add(ref full, ref pos);
                        break;

                    case 2:
                        Print(ref full, ref pos);
                        break;

                    case 3:
                        Delete(ref full, ref pos);
                        break;

                    case 4:
                        Search(ref full, ref pos);
                        break;

                    case 5:
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Вы ввели недопустимый вариант.");
                        System.Environment.Exit(1);
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу..");
                Console.ReadKey();
            }
        }

        static void Menu()
        {
            Console.Write("\n1) Добавить досье" +
                "\n2) Вывести все досье" +
                "\n3) Удалить досье" +
                "\n4) Поиск по фамилии" +
                "\n5) Выход" +
                "\n\nВыберите пункт меню: ");
        }

        // добавления досье
        static void Add(ref string[] fulls, ref string[] pos)
        {
            // изменение размера массива
            Array.Resize(ref fulls, fulls.Length + 1);
            Array.Resize(ref pos, pos.Length + 1);

            string full = "";

            Console.WriteLine("\nДобавление досье:" +
                "\n\nВведите фамилию: ");
            full += Console.ReadLine() + ' ';

            Console.WriteLine("Введите имя: ");
            full += Console.ReadLine() + ' ';

            Console.WriteLine("Введите отчество: ");
            full += Console.ReadLine();

            Console.WriteLine("Введите должность: ");
            pos[^1] = Console.ReadLine(); 
            fulls[^1] = full;          

            Console.WriteLine("Данные занесены успешно!");
        }

        // вывод списка всех досье
        static void Print(ref string[] fulls, ref string[] pos)
        {
            if (fulls.Length <= 0)
            {
                Console.WriteLine("Отсутствуют какие-либо досье.");
                return;
            }

            Console.WriteLine("Вывод всех досье");
            for (uint i = 0; i < fulls.Length; i++)
            {
                Console.WriteLine(Convert.ToString(i + 1) + '\t' + fulls[i] + '\t' + pos[i]);
            }
        }

        // удаление определённого досье
        static void Delete(ref string[] fulls, ref string[] pos)
        {
            if (fulls.Length <= 0)
            {
                Console.WriteLine("Отсутствуют какие-либо досье.");
                return;
            }

            Console.WriteLine("Введите номер досье для удаления: ");
            int del = Convert.ToInt32(Console.ReadLine());

            if (del > fulls.Length || del < 1)
            {
                Console.WriteLine("Досье с таким номером не существует.");
                return;
            }

            del--;

            // перемещаем в массивах элементы
            Array.Copy(fulls, del + 1, fulls, del, fulls.Length - del - 1);
            Array.Copy(pos, del + 1, pos, del, pos.Length - del - 1);

            // изменяем размер массива, отсекая последний
            Array.Resize(ref fulls, fulls.Length - 1);
            Array.Resize(ref pos, pos.Length - 1);

            Console.WriteLine("Досье удалено успешно!");
        }

        // поиск по фамилии
        static void Search(ref string[] fulls, ref string[] pos)
        {
            if (fulls.Length <= 0)
            {
                Console.WriteLine("Отсутствуют какие-либо досье.");
                return;
            }

            Console.WriteLine("Введите фамилию для поиска: ");
            string full = Console.ReadLine();

            // нумерация в списке
            uint listIndex = 0;

            for (uint i = 0; i < fulls.Length; i++)
            {
                if (fulls[i].StartsWith(full))
                {
                    listIndex++;
                    Console.WriteLine(Convert.ToString(listIndex) + '\t' + fulls[i] + '\t' + pos[i]);
                }
            }
            Console.WriteLine("Количество сотрудников с фамилией " + full + ": " + listIndex);
        }
    }
}