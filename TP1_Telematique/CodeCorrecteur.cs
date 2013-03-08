using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace TP1_Telematique
{
    class CodeCorrecteur
    {
        public string ajouterCode(byte[] donnees)
        {
            string donneesBin = "";

            foreach (byte octet in donnees)
            {
                donneesBin += Convert.ToString(octet, 2).PadLeft(8, '0');
            }

            string bitsCorrecteurs = "";

        }
    }
}
