using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_Telematique
{
    class Station
    {
        Trame[] tamponEnvoie;

        public Station(int tailleTampon)
        {
            //une trame réseau de « N » octets
            int N = 5;

            Trame trame = new Trame(N);
            //taille correspondante au premier paramètre entré dans le programme multiplié par « N » octets 
            tamponEnvoie = new Trame[tailleTampon];
        }

        public void emettre()
        {
            while (true)
            {
                if (tamponEnvoie.Length > 0)
                {

                }
            }

        }
        public void recevoir()
        {
            while (true)
            {
                if (tamponEnvoie.Length > 0)
                {

                }
            }

        }

    }
}
