using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpPuissance4
{
    class Joueur
    {
        protected string nom;
        public string Nom { get => nom; set => nom = value; }
        protected char jeton;
        public char Jeton { get => jeton; set => jeton = value; }
        public Joueur()
        {}
        public int GetColonne()
        {
            int result;
            do
            {
                Console.WriteLine("Choisir la colonne où placer votre jeton (entre 1 et 7) : ");
                result = Puissance4.GetChoix(1, 7);
                if (result == -1)
                {
                    Console.WriteLine("Ligne invalide, veuillez en choisir une autre.");
                }
            } while (result == -1);
            return result - 1;
        }
        public virtual bool Jouer(Grille grid)
        {
            return false;
        }
    }
}
