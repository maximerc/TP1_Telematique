using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  

namespace TP1_Telematique
{
    class Reseau
    {
        private readonly frmMain _main;

        public bool estPretEmettre { get; private set; }
        public bool estRecuDestination { get; private set; }
        Trame trmEnvoieSource;
        Trame trmReceptionDestination;

        public bool estPretEmettreReponse { get; private set; }
        public bool estRecuDestinationReponse { get; private set; }
        Trame trmEnvoieSourceReponse;
        Trame trmReceptionDestinationReponse;

        public Reseau(frmMain frm)
        {
            _main = frm;
        }

        public void demarrer()
        {
            estPretEmettreReponse = estPretEmettre = true;
            estRecuDestinationReponse = estRecuDestination = false;
            while (true)
            {
                if(estPretEmettre == false && estRecuDestination == false)
                {
                    estPretEmettre = true;
                    estRecuDestination = true;
                    trmReceptionDestination = trmEnvoieSource;
                    trmEnvoieSource = null;
                }
                if (estPretEmettreReponse == false && estRecuDestinationReponse == false)
                {
                    estPretEmettreReponse = true;
                    estRecuDestinationReponse = true;
                    trmReceptionDestinationReponse = trmEnvoieSourceReponse;
                    trmEnvoieSourceReponse = null;
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

        //Reception d'une réponse
        public void recevoirReponse(Trame trm)
        {
            trmEnvoieSourceReponse = trm;
            estPretEmettreReponse = false;
        }

        public Trame donnerReponse()
        {
            estPretEmettreReponse = false;
            return trmReceptionDestinationReponse;
        }
    }
}
