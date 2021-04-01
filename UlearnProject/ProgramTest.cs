using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UlearnProject
{
    using static TaskChessBoard;

    class ProgramTest
    {   //  Task 1 Условие ---------------------------------------------------------------------------------------
        //  Пользователь должен ввести исходные данные с консоли — три числа через пробел: 
        //  исходную сумму, процентную ставку (в процентах) и срок вклада в месяцах.
        //  Программа должна вывести накопившуюся сумму на момент окончания вклада.
        // -------------------------------------------------------------------------------------------------------
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
        //  Task 2 Условие ---------------------------------------------------------------------------------------
        //  Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5.
        // -------------------------------------------------------------------------------------------------------
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

        //  Task 3 Условие ---------------------------------------------------------------------------------------
        //  Дано время в часах и минутах. Найти угол от часовой к минутной стрелке на обычных часах.
        // -------------------------------------------------------------------------------------------------------
        public static void AngleBetweenHoursAndMinutes()
        {
            double hours;
            double minutes;
            double angel;
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

        //  Task 4 Условие ---------------------------------------------------------------------------------------
        // Дана начальная и конечная клетки на шахматной доске. 
        // Корректный ли это ход на пустой доске для: слона, коня, ладьи, ферзя, короля?
        // -------------------------------------------------------------------------------
        // Решение задания реализованно в классе "TaskChessBoard.cs".
        // -------------------------------------------------------------------------------------------------------

        //  Task 5 Условие ---------------------------------------------------------------------------------------
        // Дан номер трамвайного билета, в котором суммы первых трёх цифр и последних трёх цифр отличаются на 1 
        // (но не сказано, в какую сторону). Правда ли, что предыдущий или следующий билет счастливый?
        // -------------------------------------------------------------------------------------------------------

        // Функция разбиения целого числа на десятичные числа и возвращение суммы этих чисел.
        public static int SummChangeRightNumber(int temp)
        {
            int[] tempArrayNumber = new int[3];
            tempArrayNumber[0] = temp / 100;
            tempArrayNumber[1] = (temp / 10) % 10;
            tempArrayNumber[2] = temp % 10;
            // Проверка конвертации из целого числа в отдельные числа.
            Console.WriteLine("Проверка конвертации из целого числа в отдельные числа. Было: " + temp + ". Стало: {0}{1}{2}", tempArrayNumber[0], tempArrayNumber[1], tempArrayNumber[2]);
            temp = tempArrayNumber[0] + tempArrayNumber[1] + tempArrayNumber[2];
            return temp;
        }

        public static void TiketSix()
        {
            Console.WriteLine("Введите шестизначное число: ");
            char[] tiketChar = Console.ReadLine().ToCharArray();
            int[] tiketInt = new int[6];

            // Переводим введенные символы цифр записанные в Юникоде в числовые значения.
            for (int i = 0; i < tiketChar.Length; i++)
            {                
                tiketInt[i] = int.Parse(tiketChar[i].ToString());
                Console.WriteLine("{0}. '{1}'", i, tiketInt[i]);
            }

            int rightNumber = int.Parse(tiketInt[3].ToString() + tiketInt[4].ToString() + tiketInt[5].ToString());
            int leftSumm = tiketInt[0] + tiketInt[1] + tiketInt[2];
            int rightSumm = tiketInt[3] + tiketInt[4] + tiketInt[5];
            int difference = leftSumm - rightSumm;

            if (difference == -1)
            {
                Console.WriteLine("Левая часть числа на 1 меньше чем правая.");
                int temp = rightNumber - 1;
                
                if (leftSumm == SummChangeRightNumber(temp))
                {
                    Console.WriteLine("Предыдущий билет был счастливым!\t YES");
                }
                else Console.WriteLine("Предыдущий билет НЕ был счатсливым\t NO");
            }
            else if (difference == 1)
            {
                Console.WriteLine("Правая часть числа на 1 меньше чем правая.");
                int temp = rightNumber + 1;
                
                if (leftSumm == SummChangeRightNumber(temp))
                {
                    Console.WriteLine("Следующий билет будет счастливым!\t YES");
                }
                else Console.WriteLine("Следущий билет НЕ будет счатсливым\t NO");
            }
            else
            {
                Console.WriteLine("Введенное число не является аргументом решения задачи! NONONONO MFK");
            }
        }

        //  Task 6 Условие ---------------------------------------------------------------------------------------
        // Найдите минимальную степень двойки, превосходящую заданное число.
        // Более формально: для заданного числа nn найдите x > nx>n, такой, что x = 2^k
        // для некоторого натурального k.
        // -------------------------------------------------------------------------------------------------------

        public static void GetMinPowerOfTwoLargerThan()
        {
            int result = 0;
            double two;
            Console.WriteLine("Введите любое число: ");
            int numberInput = int.Parse(Console.ReadLine());
            while (true)
            {                
                two = Math.Pow(2,result);
                result++;
                if (two > numberInput)
                    break;
            }
            Console.WriteLine("Результат вычислений - \t1. Введенное число: {0}\n" +
                                "\t\t\t2. Итоговое число: {1}\n" +
                                "\t\t\t3. Степень двойки: {2}\n",
                                numberInput, two, result);
        }

        //  Task 7 Условие ---------------------------------------------------------------------------------------
        /*  
         *  Враги вставили в начало каждого полезного текста целую кучу бесполезных пробельных символов!
         *  Вася смог справиться с ситуацией, когда такой пробел был один, но продвинуться дальше ему не удается.
         *  Помогите ему с помощью цикла while.
        */
        // -------------------------------------------------------------------------------------------------------
        public static void RemoveStartSpaces()
        {
            int i = 0;
            string text = Console.ReadLine();
            while (char.IsWhiteSpace(text[i]))
            {
                if (text.Length == i+1)
                {
                    string str = "";
                    Console.WriteLine("Итоговый текст:" + str);
                    break;
                }
                if (!(char.IsWhiteSpace(text[i+1])))
                {
                    text = text.Substring(i+1);
                    break;
                }
                i++;
            }
            Console.WriteLine("Итоговый текст:" + text);
        }

        //  Task 8 Условие ---------------------------------------------------------------------------------------
        //  Напишите функцию, которая принимает на вход строку текста и печатает ее на экран в рамочке 
        //  из символов +, - и |. Для красоты текст должен отделяться от рамки слева и справа пробелом.
        // -------------------------------------------------------------------------------------------------------
        public static void OutPutBorder(string textIn)
        {
            Console.Write("+-");
            for (int i = 0; i < textIn.Length; i++)
            {
                Console.Write("-");
            }            
            Console.Write("-+\n");           
        }

        public static void WriteTextWithBorder()
        {
            Console.WriteLine("Ведите пожалуйста желаемый текст для вывода: ");
            string textIn = Console.ReadLine();

            OutPutBorder(textIn);
            Console.WriteLine("| " + textIn + " |");
            OutPutBorder(textIn);
        }

        //  Task 9 Условие ---------------------------------------------------------------------------------------
        //  Помогите Васе переделать этот код так, чтобы он умел выводить доску любого заданного размера.
        // -------------------------------------------------------------------------------------------------------
        private static void WriteBoard()
        {
            Console.WriteLine("Введите размер шахматной доски: ");
            int size = int.Parse(Console.ReadLine());
            int row = 0;

            while (row < size)
            {
                if (row % 2 == 0)
                {
                    for (int i = 0; i < size; i++)
                    {   
                        if (i % 2 == 0)
                        {
                            Console.Write("#");
                        }
                        else Console.Write(".");

                        if (i == size - 1)
                            Console.Write("\n");
                    }
                    row++;
                }
                else 
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write(".");
                        }
                        else Console.Write("#");

                        if (i == size - 1)
                            Console.Write("\n");
                    }
                    row++;
                }
            }
        }

        // Альтернативное решение.
        //  private static void WriteBoard(int size)
        //  {
        //      for (int i = 0; i < size; i++)
        //      {
        //          var j = 0;
        //          while (j < size)
        //          {
        //              Console.Write((j + i) % 2 == 0 ? "#" : ".");
        //              j++;
        //          }
        //          Console.WriteLine();
        //      }
        //      Console.WriteLine();
        //  }

        //  Task 10 Условие ---------------------------------------------------------------------------------------
        //  Написать метод поиска индекса максимального элемента. То есть такого числа i,
        //  что array[i] — это максимальное из чисел в массиве.
        // -------------------------------------------------------------------------------------------------------- 
        public static int MaxIndex()
        {
            Random random = new Random();
            double[] array = new double[15];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.NextDouble() * 100;
            }

            foreach (double temp in array)
            {
                Console.WriteLine(temp);
            }
            Console.WriteLine("Максимальное значение: ");
            Console.WriteLine(array.Max());
            int index = -1;

            if (array == null)
            {
                Console.WriteLine("Масив пуст " + index); ;
            } 

            for (int i = 0; i < array.Length; i++)
            {                
                if (array.Max() == array[i])
                {
                    if (index == -1)
                    {
                        index = i;
                    }                    
                    Console.WriteLine("Найдено максимальное значение под индексом: " + index);
                }                
            }
            return 1;
        }






        static void Main()
        {
            int indexLoop = -1;            

            while (indexLoop != 0) {

                Console.WriteLine("\n\n\t Ввыберите варинат задачи: \n" +
                                    "\t 1. Задача - про проценты в банке. \n" +
                                    "\t 2. Задача - Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5. \n" +
                                    "\t 3. Дано время в часах и минутах. Найти угол от часовой к минутной стрелке на обычных часах. \n" +
                                    "\t 4. Дана начальная и конечная клетки на шахматной доске. \n" +
                                    "\t 5. Правда ли, что предыдущий или следующий билет счастливый? \n" +
                                    "\t 6. Найдите минимальную степень двойки, превосходящую заданное число. \n" +
                                    "\t 7. Вася смог справиться с ситуацией, когда такой пробел был один\n" +
                                            " но продвинуться дальше ему не удается. Помогите ему с помощью цикла while. \n" +
                                    "\t 8. Напишите функцию, которая принимает на вход строку текста и печатает ее на экран в рамочке из символов. \n" +
                                    "\t 9. Помогите Васе переделать этот код так, чтобы он умел выводить доску любого заданного размера. \n" +
                                    "\t 10. Написать метод поиска индекса максимального элемента. То есть такого числа i, " +
                                            "что array[i] — это максимальное из чисел в массиве. \n" +
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
                        TaskChessBoard.ChessBoard();
                        break;
                    case 5:
                        TiketSix();
                        break;
                    case 6:
                        GetMinPowerOfTwoLargerThan();
                        break;
                    case 7:
                        RemoveStartSpaces();
                        break;
                    case 8:
                        WriteTextWithBorder();
                        break;
                    case 9:
                        WriteBoard();
                        break;
                    case 10:
                        MaxIndex();
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
