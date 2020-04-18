using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpPuissance4
{
    class JoueurIA : Joueur
    {
        public JoueurIA(string nom, char jeton)
        {
            this.nom = nom;
            this.jeton = jeton;
        }
        public override bool Jouer(Grille grid)
        {
            int column;
            int line;
            do
            {
                column = GetRandomColumn(grid);
                line = grid.GetLigne(column);
            } while (line == -1);
            grid.Positionner(line, column, jeton);
            return grid.TestGagner(line, column, jeton);
        }
        private int GetRandomColumn(Grille grid)
        {
            int ligne = 0;
            Random rnd = new Random();
            int max = 0;
            int[] values = new int[grid.Colonne];
            List<int> columns = new List<int>();
            for (int i = 0; i < grid.Colonne - 1; i++)
                values[i] = 0;
            for (int colonne = 0; colonne < grid.Colonne - 1; colonne++)
            {
                ligne = 0;
                do
                {
                    if (grid.Grid[ligne, colonne] == 1)
                        values[colonne]++;
                    ligne++;
                } while (grid.Grid[ligne + 1, colonne] == 2);
                if (values[colonne] > max)
                    max = values[colonne];
            }
            if (max <= 1)
                max = rnd.Next(grid.Colonne);
            else
            {
                for (int i = 0; i < grid.Colonne - 1; i++)
                {
                    if (values[i] == max && values[i] < grid.Ligne)
                    {
                        columns.Add(i);
                    }
                }
                max = rnd.Next(columns.Count);
            }
            return max;
        }
    }
}
