using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_Telematique
{
    class TamponCirculaire
    {
        private Trame[] tampon;
        private int tete;
        private int queue;
        private int longueur;

        public TamponCirculaire(int l)
        {
            tampon = new Trame[l];
            tete = 0;
            queue = 0;
            longueur = 0;
        }

        public void Ajouter(Trame t)
        {
            tampon[queue] = t;
            longueur++;
            queue = (queue + 1) % tampon.Length;
        }

        public Trame Consommer()
        {
            Trame trame = tampon[tete];
            
            
            longueur--;
            return trame;
        }

        public bool EstVide()
        {
            return (longueur == 0);
        }

        public bool EstPlein()
        {
            return (longueur == tampon.Length);
        }
    }
}


