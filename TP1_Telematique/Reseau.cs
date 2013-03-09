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
            _main.imprimer("Démarrage du réseau");
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
                    System.Threading.Thread.Sleep(100);
                }
                if (estPretEmettreReponse == false && estRecuDestinationReponse == false)
                {
                    estPretEmettreReponse = true;
                    estRecuDestinationReponse = true;
                    trmReceptionDestinationReponse = trmEnvoieSourceReponse;
                    trmEnvoieSourceReponse = null;
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
        
        //Reception d'une trame
        public void recevoir(Trame trm)
        {
            _main.imprimer("Le réseau reçoit une trame de données");
            trmEnvoieSource = trm;
            estPretEmettre = false;
        }
         
        public Trame donner()
        {
            _main.imprimer("Le réseau done une trame de données");
            estPretEmettre = false;
            return trmReceptionDestination;
        }

        //Reception d'une réponse
        public void recevoirReponse(Trame trm)
        {
            _main.imprimer("Le réseau reçoit une réponse");
            trmEnvoieSourceReponse = trm;
            estPretEmettreReponse = false;
        }

        public Trame donnerReponse()
        {
            _main.imprimer("Le réseau donne une réponse");
            estPretEmettreReponse = false;
            return trmReceptionDestinationReponse;
        }
    }
}