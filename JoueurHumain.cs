using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpPuissance4
{
    class JoueurHumain : Joueur
    {
        public JoueurHumain(string nom, char jeton)
        {
            this.nom = nom;
            this.jeton = jeton;
        }
        public override bool Jouer(Grille grid)
        {
            int line;
            int column;
            do
            {
                column = base.GetColonne();
                line = grid.GetLigne(column);
                if (line == -1)
                    Console.WriteLine("La ligne insérée est invalide veuillez la ressaisir.");
            } while (line == -1); 
            grid.Positionner(line, column, jeton);
            return grid.TestGagner(line, column, jeton);
        }
    }
}
