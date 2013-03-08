using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_Telematique
{
    class Emetteur
    {
        public Emetteur(int tailleTampon)
        {
            //une trame réseau de « N » octets
            int N = 5;

            Trame trame = new Trame(N);
            //taille correspondante au premier paramètre entré dans le programme multiplié par « N » octets 
            Trame[] tamponEnvoie = new Trame[tailleTampon];
        }

        public int emettre()
        {
            return 0;
        }
    }
}
