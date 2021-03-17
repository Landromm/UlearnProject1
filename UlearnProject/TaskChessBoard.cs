using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UlearnProject
{
    class TaskChessBoard
    {
        // Проверка вводимых значений.
        public static void InfoInputСoordinates(int xPS, int yPS, int xPF, int yPF, string nameFigure)
        {
            Console.WriteLine("\nНачальная координата 'X' = " + xPS);
            Console.WriteLine("Начальная координата 'Y' = " + yPS);
            Console.WriteLine("\nКонечная координата 'Х' = " + xPF);
            Console.WriteLine("Конечная координта 'Y' = " + yPF);
            Console.WriteLine("Наименование фигуры = " + nameFigure);
        }

        // Вывод сообщения если ход верный.
        public static void OutoutInfoYes(int xPointStart, int yPointStart, int xPointFinish, int yPointFinish, string nameChessFigure)
        {
            Console.WriteLine("Указанная фигура '{0}' МОЖЕТ передвигатся по заданным координатам\n" +
                    "из точки '{1}':'{2}' в точку '{3}':{4}.", nameChessFigure, xPointStart, yPointStart, xPointFinish, yPointFinish);
        }
        // Выаод сообщения если ход не верный.
        public static void OutoutInfoNo(int xPointStart, int yPointStart, int xPointFinish, int yPointFinish, string nameChessFigure)
        {
            Console.WriteLine("Указанная фигура '{0}' НЕ МОЖЕТ передвигатся по заданным координатам\n" +
                                "из точки '{1}':'{2}' в точку '{3}':{4}.", nameChessFigure, xPointStart, yPointStart, xPointFinish, yPointFinish);
        }
        // Функция проверки хода для фигуры СЛОН.
        public static void StepElephant(int xPointStart, int yPointStart, int xPointFinish, int yPointFinish, string nameChessFigure)
        {
            int tempX = xPointStart - xPointFinish;
            int tempY = yPointStart - yPointFinish;
            double differenceXY = tempX / tempY;

            if (differenceXY == -1 || differenceXY == 1)
            {
                OutoutInfoYes(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else
            {
                OutoutInfoNo(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
        }

        // Функция проверки хода для фигуры КОНЬ.
        public static void StepHorse(int xPointStart, int yPointStart, int xPointFinish, int yPointFinish, string nameChessFigure)
        {
            int tempX = xPointFinish - xPointStart;
            int tempY = yPointFinish - yPointStart;
            double differenceXY = Convert.ToDouble(tempX) / Convert.ToDouble(tempY);

            Console.WriteLine("Проверка конвертации в double = " + differenceXY);

            if (differenceXY == 0.5 || differenceXY == -0.5 || differenceXY == 2.0 || differenceXY == -2.0)
            {
                OutoutInfoYes(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else
            {
                OutoutInfoNo(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
        }

        // Функция проверки хода для фигуры ЛАДЬЯ.
        public static void StepRook(int xPointStart, int yPointStart, int xPointFinish, int yPointFinish, string nameChessFigure)
        {
            int tempX = xPointFinish - xPointStart;
            int tempY = yPointFinish - yPointStart;


            if ((tempX == 0 && tempY != 0) || (tempX != 0 && tempY == 0))
            {
                OutoutInfoYes(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else
            {
                OutoutInfoNo(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
        }

        // Функция проверки хода для фигуры КОРОЛЬ.
        public static void StepKing(int xPointStart, int yPointStart, int xPointFinish, int yPointFinish, string nameChessFigure)
        {
            int tempX = xPointFinish - xPointStart;
            int tempY = yPointFinish - yPointStart;


            if (((tempX == 1 || tempX == -1) && tempY == 0) || ((tempX == 0) && (tempY == -1 || tempY == 1)))
            {
                OutoutInfoYes(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else
            {
                OutoutInfoNo(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
        }

        // Функция проверки хода для фигуры ФЕРЗЬ.
        public static void StepQueen(int xPointStart, int yPointStart, int xPointFinish, int yPointFinish, string nameChessFigure)
        {
            int tempX = xPointStart - xPointFinish;
            int tempY = yPointStart - yPointFinish;
            double differenceXY = tempX / tempY;

            if (differenceXY == -1 || differenceXY == 1)
            {
                OutoutInfoYes(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else if ((tempX == 0 && tempY != 0) || (tempX != 0 && tempY == 0))
            {
                OutoutInfoYes(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else if (((tempX == 1 || tempX == -1) && tempY == 0) || ((tempX == 0) && (tempY == -1 || tempY == 1)))
            {
                OutoutInfoYes(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else
            {
                OutoutInfoNo(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
        }

        // Функция реальзации проверки правильности хода выбраной фигуры.
        public static void FinishInfoStepSelectedFigure(int xPointStart, int yPointStart, int xPointFinish, int yPointFinish, string nameChessFigure)
        {
            if (nameChessFigure.Equals("слон"))
            {
                StepElephant(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else if (nameChessFigure.Equals("конь"))
            {
                StepHorse(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else if (nameChessFigure.Equals("ладья"))
            {
                StepRook(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else if (nameChessFigure.Equals("король"))
            {
                StepKing(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else if (nameChessFigure.Equals("ферзь"))
            {
                StepQueen(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            }
            else Console.WriteLine("Данные введены не корректно. Или праильного решения не существует.");
        }

        public static void ChessBoard()
        {
            int xPointStart;
            int yPointStart;
            int xPointFinish;
            int yPointFinish;
            string nameChessFigure;

            // Шахматная доска размера 8х8; начальные координаты x=1, y=1.
            Console.WriteLine("Введите координаты позиций от 1:1 до 8:8 .");
            Console.WriteLine("Введите начальные координаты: ");
            string readLineStart = Console.ReadLine();
            Console.WriteLine("Введите конечные координаты: ");
            string readLineFinish = Console.ReadLine();
            Console.WriteLine("Введите наименование фигуры: ");
            nameChessFigure = Console.ReadLine().ToLower();

            string[] dataStringStart = readLineStart.Split(new char[] { ' ' });
            xPointStart = int.Parse(dataStringStart[0]);
            yPointStart = int.Parse(dataStringStart[1]);

            string[] dataStringFinish = readLineFinish.Split(new char[] { ' ' });
            xPointFinish = int.Parse(dataStringFinish[0]);
            yPointFinish = int.Parse(dataStringFinish[1]);

            InfoInputСoordinates(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
            FinishInfoStepSelectedFigure(xPointStart, yPointStart, xPointFinish, yPointFinish, nameChessFigure);
        }
    }
}
