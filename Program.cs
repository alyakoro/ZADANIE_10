using System;

namespace ZADANIE_10
{
    internal class Program
    {
        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                InputFigure();

                Console.WriteLine("Print 'exit' for end:");
                string exitWord = Console.ReadLine();
                if (exitWord == "exit")
                    exit = true;
            }
        }

        // Функция рисования шахматной доски.
        static void DrawChessboard(int oneX, int oneY, int twoX, int twoY)
        {
            Console.WriteLine();
            Console.WriteLine("  a b c d e f g h");
            for (int i = 8; i >= 1; i--)
            {
                Console.Write(i + " ");
                for (int j = 1; j <= 8; j++)
                {
                    if ((j == oneX && i == oneY) || (j == twoX && i == twoY))
                        Console.Write((j == oneX && i == oneY) ? "Y " : "B ");
                    else
                        Console.Write((j + i) % 2 == 0 ? "- " : "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Ввод и последующие функции.
        static void InputFigure()
        {
            bool inputCorrect;
            do
            {
                Console.Write("Enter the figure name and its position" + Environment.NewLine +
                    "1. rook" + Environment.NewLine + "2. knight" +
                    Environment.NewLine + "3. bishop" +
                    Environment.NewLine + "4. queen" +
                    Environment.NewLine + "5. king" +
                    Environment.NewLine + "Example: queen b3: ");
                string[] coordinates = Console.ReadLine()?.Split(' ');

                inputCorrect = coordinates?.Length == 2
                               && CorrectPosition(coordinates[1])
                               && CorrectFigure(coordinates[0]);

                if (inputCorrect)
                    CompareCoordinates(coordinates[1], coordinates[0]);

            } while (!inputCorrect);
        }

        // Сравнение 1 и 2 позиции фигур
        static void CompareCoordinates(string first, string figure)
        {
            Random random = new Random();
            int firstX = first[0] - 'a' + 1;
            int firstY = first[1] - '0';
            int secondX = random.Next('a', 'h');
            int secondY = random.Next(1, 9);

            char indexX = ((char)secondX);
            secondX = secondX - 'a' + 1;

            DrawChessboard(firstX, firstY, secondX, secondY);

            int xDiff = Math.Abs(firstX - secondX);
            int yDiff = Math.Abs(firstY - secondY);

            bool isValid = false;

            switch (figure)
            {
                case "rook":
                    isValid = secondX == firstX || secondY == firstY;
                    break;
                case "knight":
                    isValid = (xDiff == 1 && yDiff == 2) || (xDiff == 2 && yDiff == 1);
                    break;
                case "bishop":
                    isValid = xDiff == yDiff;
                    break;
                case "queen":
                    isValid = (xDiff == yDiff) || (secondX == firstX || secondY == firstY);
                    break;
                case "king":
                    isValid = xDiff <= 1 && yDiff <= 1;
                    break;
            }

            ConsoleWrite(first, figure, $"{indexX}{secondY}", isValid);
        }

        // Вывод итого решения на консоль.
        static void ConsoleWrite(string xy, string figure, string x2y2, bool isValid)
        {
            if (isValid)
                Console.WriteLine($"If the {figure} is at {xy}, it can move to {x2y2} in one move.");
            else
                Console.WriteLine($"If the {figure} is at {xy}, it cannot kill {x2y2}.");
        }

        // Функция проверки вводных данных (кооридинат).
        static bool CorrectPosition(string position)
        {
            if (position.Length != 2)
                return false;

            char letter = position[0];
            char number = position[1];

            return letter >= 'a' && letter <= 'h' && number >= '1' && number <= '8';
        }

        // Функция проверки вводных данных (фигура)
        static bool CorrectFigure(string figure)
        {
            string[] figures = { "rook", "knight", "bishop", "queen", "king" };

            foreach (string fig in figures)
            {
                if (fig == figure)
                    return true;
            }
            return false;
        }
    }
}
