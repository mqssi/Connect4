using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpPuissance4
{
    class Jeu
    {
        protected string nom;
        public string Nom { get => nom; set => nom = value; }
        public Jeu()
        {}
        public Jeu(string nom)
        {
            this.nom = nom;
        }
    }
}
