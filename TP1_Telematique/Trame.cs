using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_Telematique
{
    class Trame
    {
        public int numeroTrame;
        //    int codeDetecteur;  //code detectuer ou correcteur
        public int addrDestination;
        public int addrSource;
        public byte[] donnees;

        public int preambule;//wtf
        public int remplissage;//?
        public int total_de_controle;//?




        //--------8//-------------6//-------------26//TypeOuLong//------0-1500//-----------0-46//----4
        //||preambule    adresse de       adr source              || données    || remplisage      total de controle
        //              destination 
        public Trame(int taille)
        {
            donnees = new byte[taille];
        }
    }
}
