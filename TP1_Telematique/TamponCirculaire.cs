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
            tete = (tete + 1) % tampon.Length;
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

        public int FenetreDisponible()
        {
            return tampon.Length - longueur;
        }
        
        public int Length()
        {
            return tampon.Length;
        }

        public int TrouverTramePositionSelonNumero(int numeroTrame)
        {
            for (int i = 0; i < Length(); i++)
                if (tampon[i] != null && tampon[i].numeroTrame == numeroTrame)
                    return i;
            return -1;
        }

        public Trame TrouverTrameSelonNumero(int numeroTrame)
        {
            return TrouverTrame(TrouverTramePositionSelonNumero(numeroTrame));
        }

        public Trame TrouverTrame(int positionTrame)
        {
            return (positionTrame != -1) ? tampon[positionTrame] : null;
        }

        public void Affecter(int numeroTrame, Trame trame)
        {
            int position = TrouverTramePositionSelonNumero(numeroTrame);
            tampon[position] = trame;
        }

    }
}


