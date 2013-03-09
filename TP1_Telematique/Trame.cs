using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_Telematique
{
    class Trame
    {
        int numeroTrame;
        int codeDetecteur; //code detectuer ou correcteur


       //--------8//-------------6//-------------26//TypeOuLong//------0-1500//-----------0-46//----4
      //||preambule    adresse de       adr source              || données    || remplisage      total de controle
       //              destination 
        public Trame(int taille)
        {
        }

        public Trame(int taille, int tailleTableau)
        {
        }
    }
}
