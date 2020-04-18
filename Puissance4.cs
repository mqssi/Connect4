using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpPuissance4
{
    class Puissance4 : Jeu
    {
        private Joueur joueur1;
        private Joueur joueur2;
        public Puissance4(string nom)
        {
            this.nom = nom;
        }
        public static int GetChoix(int min, int max)
        {
            string choix;
            int choixParsed;
            do
            {
                Console.Write("Choix : ");
                choix = Console.ReadLine();
                if (Int32.TryParse(choix, out choixParsed))
                {
                    choixParsed = Int32.Parse(choix);
                    if (choixParsed < min || choixParsed > max)
                    {
                        Console.WriteLine("Entrée invalide");
                    }
                }
                else
                {
                    Console.WriteLine("Entrée invalide");
                    choixParsed = -1;
                }
            } while (choixParsed < min || choixParsed > max || choixParsed == -1);
            return choixParsed;
        }
        public void Demarrer()
        {
            int choixParsed;
            do
            {
                Console.Clear();
                Console.WriteLine("\t" + nom + "\n");
                Console.WriteLine(" 1. Jouer");
                Console.WriteLine(" 2. Quitter");
                Console.WriteLine("\nQue souhaitez-vous faire ?");
                choixParsed = GetChoix(1,2);
                if (choixParsed == 1)
                {
                    Console.WriteLine("Voulez-vous jouer contre un autre personne (1) ou contre un bot (2) ? ");
                    Jeu(GetChoix(1,2));
                }
            } while (choixParsed != 2);
            Console.WriteLine("Au revoir ! ");
            Console.ReadLine();
        }
        private void Jeu(int choix)
        {
            bool end = false;
            Console.Write("Veuillez saisir le nom du joueur 1 : ");
            joueur1 = new JoueurHumain(Console.ReadLine(), 'O');
            Console.Write("Veuillez saisir le nom du joueur 2 : ");
            string name = Console.ReadLine();
            if (choix == 1)
            {
                joueur2 = new JoueurHumain(name, 'X');
            }
            else
            {
                joueur2 = new JoueurIA(name, 'X');
            }
            Grille grid = new Grille();
            grid.Init();
            int nbJeton = 21;
            do
            {
                Console.Clear();
                grid.Afficher();
                Console.WriteLine("Au tour de " + joueur1.Nom);
                end = joueur1.Jouer(grid);
                grid.Afficher();
                if (end)
                {
                    Console.WriteLine($"\tBravo ! {joueur1.Nom} a gagné !!");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Au tour de " + joueur2.Nom);
                    end = joueur2.Jouer(grid);
                    if (end)
                    {
                        grid.Afficher();
                        Console.WriteLine($"\tBravo ! {joueur2.Nom} a gagné !!");
                        Console.ReadLine();
                    }
                    else
                    {
                        nbJeton--;
                        Console.WriteLine($"Il vous reste {nbJeton} jetons chacun.");
                    }
                }
            } while (!end && nbJeton > 0);
        }
    }
}
