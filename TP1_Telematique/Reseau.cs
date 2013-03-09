using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  

namespace TP1_Telematique
{
    class Reseau
    {
        bool estPretEmettre { get; private set; }
        bool estRecuDestination { get; private set; }
        Trame trmEnvoieSource;
        Trame trmReceptionDestination;

        void Reseau()
        {
            int N = Properties.Settings.Default.TAILLE_FENETRE;

            trmEnvoieSource = new Trame(N);
            trmReceptionDestination = new Trame(N);
        }


        public void demarrer()
        {
            estPretEmettre = true;
            estRecuDestination = false;
            while (true)
            {
                if(estPretEmettre == false && estRecuDestination == false)
                {
                    estPretEmettre = true;
                    estRecuDestination = true;
                    trmReceptionDestination = trmEnvoieSource;
                    trmEnvoieSource = null;
                }
            }
        }
        
        //Reception d'une trame
        public void recevoir(Trame trm)
        {
            trmEnvoieSource = trm;
            estPretEmettre = false;
        }
         
        public Trame donner()
        {
            estPretEmettre = false;
            return trmReceptionDestination;
        }
    }
}
