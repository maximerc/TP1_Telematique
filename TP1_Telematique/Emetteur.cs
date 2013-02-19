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
            Trame tamponEnvoie = new Trame(N, tailleTampon);
        }
    }
}
