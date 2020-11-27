using System;
using System.IO;

public class Map
{
    // Конструктор с параметрами
    public Map(string mapName)
    {
        // Считываем карту из файла
        Read(mapName);
        // Задаём начальное здоровье = 7
        HP = 7;

        // Рисуем в самом начале карту и показатель здоровья
        DrawM();
        Bar();

        bX = Console.CursorLeft + 7; // положение по Х
        bY = Console.CursorTop - 1;   // положение по Y
    }

    // Чтение карты из файла map.txt
    private void Read(string mapName)
    {
        pX = 0;
        pY = 0;

        string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
        map = new char[newFile.Length, newFile[0].Length];

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = newFile[i][j];

                // U - символ персонажа
                if (map[i, j] == 'U')
                {
                    // начальная позиция
                    pX = i;
                    pY = j;
                }
            }
        }
    }

    // рисование карты
    private void DrawM()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }

    // рисование здоровья
    private void Bar()
    {
        // Здоровье
        // (♥♥♥♥______)
        Console.Write("Здоровье" +
            "\n(");

        for (byte i = 0; i < HP; i++)
        {
            Console.Write('♥');
        }

        Console.WriteLine(')');
    }

    // Если персонаж на выходе
    private void CheckExit(int Y, int X)
    {
        if (map[Y, X] == '→')
        {
            Console.WriteLine("      ВЫ ПОБЕДИЛИ!     ");
            Console.ReadKey();
            System.Environment.Exit(0);
        }
    }

    // Что происходит при попадании героя на врага
    private void CheckEnemy(int Y, int X)
    {
        // Если на положении, куда двигается персонаж, стоит враг - убавляется здоровье на 1 единицу
        if (map[Y, X] == '&')
        {
            HP--;
            Console.SetCursorPosition(bX--, bY);
            Console.Write('_');
        }
    }
    public bool Var()
    {

        // Если у персонажа закончилось здоровье
        if (HP <= 0)
        {
            return false;
        }

        // Если персонаж встал на символ → (выход)
        if (map[pY, pX] == '→')
        {
            return false;
        }

        // передвижение персонажа
        Move();

        return true;
    }

    // Обработка нажатия стрелок вниз, вверх, влево, вправо
    private void Move()
    {
        ConsoleKeyInfo key;

        key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.DownArrow:

                if (map[pY + 1, pX] != '■')
                {
                    CheckEnemy(pY + 1, pX);

                    Console.SetCursorPosition(pX, pY);
                    Console.Write('*');
                    map[pY, pX] = '*';
                    Console.SetCursorPosition(pX, ++pY);
                    Console.Write('U');

                    CheckExit(pY, pX);
                }
                break;

            case ConsoleKey.UpArrow:
                if (map[pY - 1, pX] != '■')
                {
                    CheckEnemy(pY - 1, pX);

                    Console.SetCursorPosition(pX, pY);
                    Console.Write('*');
                    map[pY, pX] = '*';
                    Console.SetCursorPosition(pX, --pY);
                    Console.Write('U');

                    CheckExit(pY, pX);
                }
                break;

            case ConsoleKey.LeftArrow:

                if (map[pY, pX - 1] != '■')
                {
                    CheckEnemy(pY, pX - 1);

                    Console.SetCursorPosition(pX, pY);
                    Console.Write('*');
                    map[pY, pX] = '*';
                    Console.SetCursorPosition(--pX, pY);
                    Console.Write('U');

                    CheckExit(pY, pX);

                }
                break;

            case ConsoleKey.RightArrow:

                if (map[pY, pX + 1] != '■')
                {
                    CheckEnemy(pY, pX + 1);

                    Console.SetCursorPosition(pX, pY);
                    Console.Write('*');
                    map[pY, pX] = '*';
                    Console.SetCursorPosition(++pX, pY);
                    Console.Write('U');

                    CheckExit(pY, pX);
                }
                break;

            case ConsoleKey.Escape:
                Console.Clear();
                Console.WriteLine("Всего доброго! Спасибо за игру!"); // я не понимаю, почему он удаляет первую буку :/
                Environment.Exit(0);
                break;

            default:
                break;
        }
    }


    // Карта
    private char[,] map;
    // Положение персонажа
    private int pX, pY;
    // Положение здоровья
    private int bX, bY;
    // Здоровье персонажа
    private int HP;
}

namespace KDO_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            // Правила игры
            Console.WriteLine("*                              ПРАВИЛА ИГРЫ 'ЛАБИРИНТ'                                          *" +
                            "\n*                       Ваш персонаж обозначается символом U                                    *" +
                            "\n*                   Стены обозначаются - ■, ловушки - &, а свободные пути - @                   *" +
                            "\n*                   У вас имеется здоровье, которое обозначается символом ♥                     *" +
                            "\n*                   Так же, ваш персонаж может оставлять за собой след - *                      *" +
                            "\n*                   Ваша задача - дойти до конца лабиринта, то есть до →                        *" +
                            "\n*                   Двигайте персонажа на клавиши стрелок                                       *" +
                            "\n*                   Если вы потеряете всё здоровье - игра будет окончена                        *" +
                            "\n*                   При нажатии Esc, можно выйти из игры                                        *"+
                            "\n*                                       УДАЧИ!                                                  *" +
                            "\n\n                        Нажмите ENTER, чтобы начать игру  ");

            Console.ReadKey();
            Console.Clear();

            Map map = new Map("map");

            // Цикл выполнения игры
            while (map.Var()) ;
            // Если здоровье героя опуститься до 0, то игра завершится
            Console.Clear();
            Console.WriteLine("Вы проиграли!");

            Console.ReadKey();
        }
    }
}


/*
             Карта:
    ■■■■■■■■■■■■■■■■■■■■■■■■■
    ■U■■■■■■■■@&&@■■■@@&@@■■■
    ■@■■@@@■■■@■■@■■■@■■■@■■■
    ■@■■@■@■■■@■■@■■■@■■■@■■■
    ■@@@@■@■■■@@@@@■■@■■@@■■■
    ■■■■■■@■■■@■■■@■■@■■@■■■■
    ■@&&&@@■■■@■■■@■■@■■@@■■■
    ■@■■■■@■■■@■■■@@@@■■■@■■■
    ■@■■■■@■■■@@@■■■■■■■■@■@■
    ■■@@@@@■■■■■@■@@@&@@■@■&■
    ■■@■■■■■■■■■@■■■■■■@@@■&■
    ■■@■■■■■■■■■@@@@@■■■@■&&■
    ■■&■■@@@@@■■■■■■@■■■@■@■■
    ■■@■■@■■■@■@@@@■@■■■@■@@■
    ■■@■■@■■■@■@■■@■@■■■@■■&■
    ■■@■■@■■■@■@■■■■@■■■@■■@■
    ■■@@@@■■■@■@@@■■@■■■@■■&■
    ■■■■■■■■■@■■■@■■@■■■@■■@■
    ■@&&&@■■■@■■■@■■@■■■@@@@■
    ■■■■■@■■■@■■■@■■@■■@@■■■■
    ■■@@@@@@@@@@@■■■@■■@■■■@■
    ■■@■■■■■@■■■■■■■@■@@■■■@■
    ■■@■■■■■@@@&&@■■@■@■■@@@■
    ■■@■■■■■■■■■■■■■@■@■■@■■■
    ■■@@@@@@@&@@@@@@@■@@&@@@→
    ■■■■■■■■■■■■■■■■■■■■■■■■■
*/