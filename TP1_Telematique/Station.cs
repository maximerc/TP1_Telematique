using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TP1_Telematique
{
    class Station
    {
        private readonly frmMain _main;
        TamponCirculaire tampon;
        private int N = Properties.Settings.Default.TAILLE_FENETRE; //une trame réseau de « N » octets
        private Reseau reseau;

        public Station(frmMain main, int tailleTampon, Reseau _reseau)
        {
            //utiliser afin de faire afficher les données envoyés ou reçues
            _main = main;
            _main.imprimer("Initialisation des stations");
            reseau = _reseau;

            tailleTampon = 100;
            //taille correspondante au premier paramètre entré dans le programme multiplié par « N » octets 
            tampon = new TamponCirculaire(tailleTampon);
        }

        public void emettre()
        {
            _main.imprimer("L'émettion est démarré");
            string fichierSource = @"C:\Users\keven\Documents\ift585\test.txt";
            FileStream fs = new FileStream(fichierSource, FileMode.Open, FileAccess.Read);

            int longueur = (int)fs.Length;
            int position = 0;
            bool lectureFichierTermine = false;

            while (true)
            {
                if (reseau.estPretEmettre && tampon.EstVide() == false) //si le reseau est prêt
                {
                    reseau.recevoir(tampon.Consommer());
                    //reponse du réseau, on s'est fait owné en terro
                    
                }
                else if (lectureFichierTermine == false && tampon.EstPlein() == false)
                {
                    Trame trame = new Trame(N);
                    fs.Read(trame.donnees, position, N);
                    position += N;
                    tampon.Ajouter(trame);
                    if (position >= longueur)
                    {
                        lectureFichierTermine = true;
                        fs.Close();
                        _main.imprimer("La station émettrice à terminé la lecture du fichier.");
                    }
                }
                else if (tampon.EstVide() && lectureFichierTermine)
                {
                    _main.imprimer("La station émettrice à terminé l'envoi du fichier.");
                    return;
                }
            }
        }

        public void recevoir()
        {
            _main.imprimer("La réception est démarré");
            string fichierDestination = @"C:\Users\keven\Documents\ift585\destination_miaw.txt";
            FileStream fs = new FileStream(fichierDestination, FileMode.Create, FileAccess.Write);

            while (true)
            {
                if (reseau.estRecuDestination && tampon.EstPlein() == false) //si le reseau est prêt
                {
                    tampon.Ajouter( reseau.donner() );
                    //reponse du réseau, on s'est fait owné en terro

                }
                else if (tampon.EstVide() == false)
                {
                    Trame trame = tampon.Consommer();
                    for (int i = 0; i < N; i++)
                    {
                        if (trame.donnees[i] == 0)
                        {
                            fs.Close();
                            _main.imprimer("La station réceptrice à terminé la réception et l'écriture du fichier.");
                            return;
                        }
                        fs.WriteByte(trame.donnees[i]);
                    }
                }
            }
        }
    }
}
