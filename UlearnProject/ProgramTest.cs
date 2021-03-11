using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnProject
{
    class ProgramTest
    {


        //  Пользователь должен ввести исходные данные с консоли — три числа через пробел: 
        //  исходную сумму, процентную ставку (в процентах) и срок вклада в месяцах.
        //  Программа должна вывести накопившуюся сумму на момент окончания вклада.
        public static double Calculate(string userInput)
        {
            string[] dataString = userInput.Split(new char[] { ' ' });
            double summa = double.Parse(dataString[0], CultureInfo.InvariantCulture);
            double percent = double.Parse(dataString[1]);
            double month = double.Parse(dataString[2]);

            double result =summa * Math.Pow((1 + percent / 1200), month);
            return result;
        }

        public static void OutPutCalculate()
        {
            string userString = Console.ReadLine();
            Console.WriteLine(Calculate(userString));
            Console.ReadKey();
        }

        //  Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5.
        public static void SearchSumNumber()
        {
            Console.WriteLine("\n\t Находим сумму всех положительных чисел меньше 1000 кратных 3 и 5");
            
            //  Заданное число.
            int number = 1000;
            //  Искомое число (т.е. сумма чисел)
            int result = 0;
            int serialNumber = 1;

            for (int i = 1; i < number; i++)
            {
                if (i % 3 == 0)
                {
                    if (i % 5 == 0)
                    {
                        
                        Console.WriteLine("--Число №{0}: = {1}", serialNumber, i);
                        result += i;
                        serialNumber++;
                    }
                }
            }
        }

        //  Дано время в часах и минутах. Найти угол от часовой к минутной стрелке на обычных часах.
        public static void AngleBetweenHoursAndMinutes()
        {
            double hours = 0;
            double minutes = 0;
            double angel = 0;
            bool signAngel = false;

            Console.WriteLine("\n\t Введите количество часов от 0 до 12: ");
            hours = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\t Введите количество минут от 0 до 60: ");
            minutes = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\t Результат выводить со знаком '+' ?  '1' - да; '0' - нет ");
            if (Console.ReadLine().Equals("1"))
            {
                signAngel = true;
            }
            //  Формула нахождения угла: угол между стрелками = (час+(минуты /60))*30 -минуты*6.
            angel = (hours + (minutes / 60)) * 30 - (minutes * 6);

            //  Перевод отрицательного числа в положительный.
            if (angel < 0 && signAngel)
            {
                angel -= 2 * angel;
            }
            Console.WriteLine("\t Ответ: Угол между стрелками в {0} часов {1} минут: равен {2}", hours, minutes, angel);
        }

        static void Main()
        {
            int indexLoop = -1;            

            while (indexLoop != 0) {

                Console.WriteLine("\n\n\t Ввыберите варинат задачи: \n" +
                                "\t 1. Задача - про проценты в банке. \n" +
                                "\t 2. Задача - Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5. \n" +
                                "\t 3. Дано время в часах и минутах. Найти угол от часовой к минутной стрелке на обычных часах. \n" +
                                "\t 4. \n" +
                                "\t 0. Выход. \n");
                indexLoop = int.Parse(Console.ReadLine());

                switch (indexLoop)
                {
                    case 1:
                        OutPutCalculate();
                        break;
                    case 2:
                        SearchSumNumber();
                        break;
                    case 3:
                        AngleBetweenHoursAndMinutes();
                        break;
                    case 4:
                        Console.WriteLine("Решения данной задачи пока нет.");
                        break;
                    case 0:
                        Console.WriteLine("Завершение работы программы. Нажмите любую клавишу.");
                        Console.ReadKey();
                        break;

                    default: break;
                }
            }
            

        }
    }
}
