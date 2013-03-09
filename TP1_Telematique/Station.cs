using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_Telematique
{
    class Station
    {
        Trame[] tamponEnvoie;
        private readonly frmMain _main;

        public Station(frmMain main, int tailleTampon)
        {
            //utiliser afin de faire afficher les données envoyés ou reçues
            _main = main;
            _main.imprimer("Initialisation des stations");
            //une trame réseau de « N » octets
            int N = 5;

            Trame trame = new Trame(N);
            //taille correspondante au premier paramètre entré dans le programme multiplié par « N » octets 
            tamponEnvoie = new Trame[tailleTampon];
        }

        public void emettre()
        {
            _main.imprimer("L'émettion est démarré");
            while (true)
            {
                if (tamponEnvoie.Length > 0)
                {

                }
            }

        }
        public void recevoir()
        {
            _main.imprimer("La réception est démarré");
            while (true)
            {
                if (tamponEnvoie.Length > 0)
                {

                }
            }

        }

    }
}
