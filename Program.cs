using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZADANIE_10
{
    internal class Program
    {
        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                VvodFirura();

                Console.WriteLine("Введите 'exit' для выхода:");
                string exitword = Console.ReadLine();
                if (exitword == "exit")
                    exit = true;
            }
        }

        // Функция рисования шахматной доски.
        static void DrawChessboard(int oneX, int oneY, int twoX, int twoY)
        {
            Console.WriteLine("  a b c d e f g h");
            for (int i = 8; i >= 1; i--)
            {
                Console.Write(i + " ");
                for (int j = 1; j <= 8; j++)
                {
                    if ((j == oneX && i == oneY) || (j == twoX && i == twoY))
                        Console.Write((j == oneX && i == oneY) ? "Y " : "B ");
                    else
                        Console.Write((j + i) % 2 == 0 ? "- " : "/ ");
                }
                Console.WriteLine();
            }
        }

        // Функция ввода и проверки данных.
        static void VvodFirura()
        {
            bool vvod_reght;
            do
            {
                Console.Write("Введите наименование фигуры " +
                    "и ее начальную координатy" + Environment.NewLine +
                    "Например: ферзь b3: ");
                string[] coordinat = Console.ReadLine()?.Split(' ');

                vvod_reght = coordinat?.Length == 2
                    && CorrectPosition(coordinat[1])
                    && CorrectFigura(coordinat[0]);

                if (vvod_reght)
                    CoordinatsEqval(coordinat[1], coordinat[0]);

            } while (!vvod_reght);
        }

        // Функция сравнения координат 1 и 2 позиции.
        static void CoordinatsEqval(string first, string figura)
        {
            Random randon = new Random();
            int firstX = first[0] - 'a' + 1;
            int firstY = first[1] - '0';
            int secondX = randon.Next('a', 'h') - 'a' + 1;
            int secondY = randon.Next(1, 9);

            DrawChessboard(firstX, firstY, secondX, secondY);

            switch(figura)
            {
                case "ладья":
                    break;
                case "конь":
                    break;
                case "слон":
                    break;
                case "ферзь":
                    break;
                case "король":
                    break;
            }
            
        }

        // Функция проверки на правильность ввода.
        static bool CorrectPosition(string position)
        {
            if (position.Length != 2)
                return false;

            char bokva = position[0];
            char numer = position[1];

            return bokva >= 'a' && bokva <= 'h' && numer >= '1' && numer <= '8';
        }

        static bool CorrectFigura(string figura)
        {
            string[] figurs = { "ладья", "конь",
                "слон", "ферзь", "король" };
            for (int i = 0; i < figurs.Length; i++)
            {
                if (figurs[i] == figura)
                    return true;
            }
            return false;
        }
    }
}