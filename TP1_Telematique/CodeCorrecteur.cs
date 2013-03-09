using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace TP1_Telematique
{
    class CodeCorrecteur
    {
        public byte[] ajouterCode(byte[] donnees)
        {
            string donneesBin = "";

            // Conversion de byte[] (Ex: {0,254} en string binaire (Ex: "0000000011111110")
            foreach (byte octet in donnees)
            {
                donneesBin += Convert.ToString(octet, 2).PadLeft(8, '0');
            }

            int nbParite = (int)Math.Ceiling(Math.Log(donneesBin.Length, 2) + 1); // nb de bits de parites
            // Tableau contenant les bits de donnes et de parité
            bool[] donneesCode = new bool[donneesBin.Length + nbParite];
            int compteurSurDonnesBin = 0;

            // On place les bits de donnes dans le tableau
            for (int i = 1; i <= donneesCode.Length; i++)
            {
                // Si cette position est une position de bit de donnée
                if(Math.Log(i, 2) % 1 != 0)
                {
                    donneesCode[i - 1] = (donneesBin[compteurSurDonnesBin] == '1') ? true : false;
                    compteurSurDonnesBin++;
                }
            }

            // On génère les bits de parité
            bool[] parite = new bool[nbParite];
            int valeurBitTraite = 1;

            for (int i = 0; i < nbParite; i++)
            {
                int sommeBit = 0;
                valeurBitTraite = (int) Math.Pow(2,i);
                int j = valeurBitTraite + 1;

                if (valeurBitTraite == 1)
                {
                    j++;
                }

                while(j <= donneesCode.Length)
                {
                    if (donneesCode[j - 1] == true)
                    {
                        sommeBit++;
                    }

                    j++;

                    if (j % valeurBitTraite == 0)
                    {
                        j = j + valeurBitTraite;
                    }
                }

                donneesCode[valeurBitTraite - 1] = sommeBit % 2 == 1;
            }
            /*
            donneesCode[0] = parite[0];
            int compteurSurParite = 1;

            for (int i = 1; i < donneesCode.Length; i *= 2)
            {
                donneesCode[i] = parite[compteurSurParite];
                compteurSurParite++;
            }
            */
            // Conversion du tableau de bool en string
            string strCode = "";

            foreach (bool bit in donneesCode)
            {
                strCode += (bit) ? "1" : "0";
            }

            return stringToByteArray(strCode);
        }

        // Conversion de byte[] (Ex: {0,254} en string binaire (Ex: "0000000011111110")
        public string byteArrayToString(byte[] array)
        {
            string donneesBin = "";

            foreach (byte octet in array)
            {
                donneesBin += Convert.ToString(octet, 2).PadLeft(8, '0');
            }

            return donneesBin;
        }


        // Conversion de string binaire (Ex: "0000000011111110") en byte[] (Ex: {0,254}
        public byte[] stringToByteArray(string str)
        {
            byte[] donnees = new byte[(int) Math.Ceiling((double) str.Length / 8)];
            int valeurOctet = 0;
            double j = 128;

            for (int i = 0; i < str.Length; i++)
            {
                if (i % 8 == 0)
                {
                    if (i != 0)
                    {
                        donnees[(i - 8) / 8] = (byte)valeurOctet;
                    }
                    
                    valeurOctet = 0;
                    j = 128;
                }

                valeurOctet += Int32.Parse(str[i].ToString()) * (int)j;

                j /= 2;
            }

            donnees[(int) Math.Ceiling((double) (str.Length - 8) / 8)] = (byte)valeurOctet;

            return donnees;
        }
    }
}
