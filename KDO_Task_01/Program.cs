using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDO_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int gold;
            int priceCrystals = 18;
            int buyCrystals;
            bool optionPurchase;          

            Link:
            Console.Write("Хотите ли вы обменять монеты на кристаллы? Ответьте только 'Да' или 'Нет'.\n");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "Да":
                    Console.Write("Сколько у вас монет?\n");
                    gold = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Цена кристалла {priceCrystals} монет. Сколько вы хотите купить кристаллов?\n");
                    buyCrystals = Convert.ToInt32(Console.ReadLine());

                    optionPurchase = gold >= priceCrystals * buyCrystals;
                    buyCrystals *= Convert.ToInt32(optionPurchase);
                    gold -= priceCrystals * buyCrystals;
                    Console.WriteLine($"У вас в сумке осталось {gold} монет и появилось {buyCrystals} кристаллов.");
                    break;

                case "Нет":
                    Console.Write("Если все же все же захотите обменять монеты на кристаллы, то я всегда к вашим услугам. Приходите еще.\n");
                    break;

                default:
                    Console.Write("Введите, пожалуйста, корректный ответ.\n\n");
                    goto Link;               
            }                    
        }
    }
}