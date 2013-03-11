using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TP1_Telematique
{
    class Trame
    {
        public static int idTrame = 0;
        public DateTime horlogeDeGarde = DateTime.MinValue;
        public int numeroTrame;
        public byte[] donnees;
        public int total_de_controle;

        public Trame(int _numeroTrame=-1, byte type = Constantes.TYPE_DONNEES)
        {
            if (_numeroTrame == -1) 
            {
                    numeroTrame = idTrame++;
                    donnees = new byte[Constantes.TAILLE_DONNEE_TRAME];
            }
            else
            {
                numeroTrame = _numeroTrame;
                donnees = new byte[1];
                donnees[0] = type;
            }
        }

        public bool EstACK()
        {
            return donnees.Length == 1 && donnees[0] == Constantes.TYPE_ACK;
        }

        public bool EstNAK()
        {
            return donnees.Length == 1 && donnees[0] == Constantes.TYPE_NAK;
        }

        public void DemarrerHorlogeDeGarde()
        {
            horlogeDeGarde = DateTime.Now.AddSeconds(10);
        }

        public bool EstExpire()
        {
            return DateTime.Now.CompareTo(horlogeDeGarde) > 0;
        }

        public void InsererDonnees(byte[] _donnees)
        {
            donnees = _donnees;
            total_de_controle = CheckSum();
        }

        public bool VerifierTotalDeControle()
        {
            return ( CheckSum() == total_de_controle );
        }

        public int CheckSum()
        {
            int total = 0;
            unchecked
            {
                foreach (byte donnee in donnees)
                    total += donnee;   // a essayer ? checksum = checksum ^ donnee;
            }
            return total;
        }

    }
}
