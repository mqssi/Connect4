using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpPuissance4
{
    class Grille
    {
        private const int ligne = 6;
        public int Ligne { get => ligne; }
        private const int colonne = 7;
        public int Colonne { get => colonne; }
        private int[,] grid = new int[ligne, colonne];
        public int[,] Grid { get => grid; set => grid = value; }
        public Grille()
        {
        }
        public void Init()
        {
            for (int line = 0; line < Ligne; line++)
            {
                for (int column = 0; column < Colonne; column++)
                {
                    grid[line, column] = 0;
                }
            }
        }
        public void Afficher()
        {
            Console.Write("  ");
            Console.ForegroundColor = ConsoleColor.White;
            for (int column = 0; column < Colonne; column++)
                Console.Write((column + 1) + "   ");
            Console.WriteLine("  ");
            for (int line = 0; line < Ligne; line++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("+---+");
                for (int column = 0; column < Colonne - 1; column++)
                    Console.Write("---+");
                Console.Write("\n| ");
                for (int column = 0; column < Colonne; column++)
                {
                    if (grid[line, column] == 1)    
                        Console.Write("O", Console.ForegroundColor = ConsoleColor.Yellow);
                    else if (grid[line, column] == 2)
                        Console.Write("X", Console.ForegroundColor = ConsoleColor.Red);
                    else
                        Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    if (column == Colonne - 1)
                        Console.WriteLine(" |");
                    else
                        Console.Write(" | ");
                }
            }
            Console.Write("+---+");
            for (int column = 0; column < Colonne - 1; column++)
                Console.Write("---+");
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Positionner(int ligne, int colonne, char jeton)
        {
            int point = (jeton == 'O') ? 1 : 2;
            grid[ligne, colonne] = point;
        }
        public int GetLigne(int column)
        {
            int line = 0;
            if (grid[line, column] != 0)
                return -1;
            for (line = 0; line < ligne - 1; line++)
            {
                if (grid[line + 1, column] != 0)
                    return line;
            }
            return line;
        }
        public bool TestGagner(int ligne, int colonne, char player)
        {
            int point = (player == 'O') ? 1 : 2;
            if (TestColumn(ligne, colonne, point) >= 3)
                return true;
            else
            {
                if (TestLine(ligne, colonne, point) >= 3)
                    return true;
                else
                {
                    if (TestDiagBH(ligne, colonne, point) >= 3)
                        return true;
                    else
                    {
                        if (TestDiagHB(ligne, colonne, point) >= 3)
                            return true;
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        private int TestColumn(int line, int column, int player)
        {
            int count = 0;
            int ligneActu = line;
            while (ligneActu < ligne - 1)
            {
                if (grid[ligneActu + 1, column] == player)
                {
                    count++;
                    ligneActu++;
                }
                else
                {
                    break;
                }
            }
            ligneActu = line;
            while (ligneActu > 0)
            {
                if (grid[ligneActu - 1, column] == player)
                {
                    count++;
                    ligneActu--;
                }
                else
                {
                    return count;
                }
            }
            return count;
        }
        private int TestLine(int line, int column, int player)
        {
            int count = 0;
            int colonneActu = column;
            while (colonneActu < colonne - 1)
            {
                if (grid[line, colonneActu + 1] == player)
                {
                    count++;
                    colonneActu++;
                }
                else
                    break;
            }
            colonneActu = column;
            while (colonneActu > 0)
            {
                if (grid[line, colonneActu - 1] == player)
                {
                    count++;
                    colonneActu--;
                }
                else
                    return count;
            }
            return count;
        }
        private int TestDiagBH(int line, int column, int player)
        {
            int count = 0;
            int colonneActu = column;
            int ligneActu = line;
            while (colonneActu < colonne - 1 && ligneActu < ligne - 1)
            {
                if (grid[ligneActu + 1, colonneActu + 1] == player)
                {
                    count++;
                    ligneActu++;
                    colonneActu++;
                }
                else
                    break;
            }
            colonneActu = column;
            ligneActu = line;
            while (colonneActu > 0 && ligneActu > 0)
            {
                if (grid[ligneActu - 1, colonneActu - 1] == player)
                {
                    count++;
                    colonneActu--;
                    ligneActu--;
                }
                else
                    return count;
            }
            return count;
        }
        private int TestDiagHB(int line, int column, int player)
        {
            int count = 0;
            int colonneActu = column;
            int ligneActu = line;
            while (colonneActu > 0 && ligneActu < ligne - 1)
            {
                if (grid[ligneActu + 1, colonneActu - 1] == player)
                {
                    count++;
                    ligneActu++;
                    colonneActu--;
                }
                else
                    break;
            }
            colonneActu = column;
            ligneActu = line;
            while (colonneActu < colonne - 1 && ligneActu > 0)
            {
                if (grid[ligneActu - 1, colonneActu + 1] == player)
                {
                    count++;
                    colonneActu++;
                    ligneActu--;
                }
                else
                    return count;
            }
            return count;
        }
    }
}
