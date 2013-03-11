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
        private int tailleFenetre = Properties.Settings.Default.TAILLE_FENETRE; //une trame réseau de « N » octets
        private Reseau reseau;
        CodeCorrecteur codeCorrecteur;


        public Station(frmMain main, int tailleTampon, Reseau _reseau)
        {
            //utiliser afin de faire afficher les données envoyés ou reçues
            _main = main;
            _main.imprimer("Initialisation des stations");
            reseau = _reseau;

            tailleTampon = 100;
            //taille correspondante au premier paramètre entré dans le programme multiplié par « N » octets 
            tampon = new TamponCirculaire(tailleTampon);
            codeCorrecteur = new CodeCorrecteur();
        }

        public void emettre()
        {
            int dernierACK = 0;
            int prochaineTrameNumero = 0;
            Trame prochaineTrame;
            Trame trameManquante;


            _main.imprimer("L'émettion est démarré");
            string fichierSource = @"C:\Users\keven\Documents\ift585\test.txt";
            FileStream fs = new FileStream(fichierSource, FileMode.Open, FileAccess.Read);

            bool lectureFichierTermine = false;

            while (true)
            {
                trameManquante = tampon.TrouverTrame(dernierACK + 1);
                if ( trameManquante != null && trameManquante.EstExpire()) /*timout*/
                {
                    reseau.recevoir(trameManquante);
                    trameManquante.DemarrerHorlogeDeGarde();
                }
                else if (reseau.estRecuDestinationReponse) //si le reseau est prêt
                {
                    Trame reponse = reseau.donnerReponse();

                    if (reponse.EstNAK())
                    {
                        trameManquante = tampon.TrouverTrame(reponse.numeroTrame);
                        reseau.recevoir(trameManquante);
                        trameManquante.DemarrerHorlogeDeGarde();
                    }
                    else if (reponse.EstACK())
                    {
                        tampon.Affecter(reponse.numeroTrame, reponse);
                       
                        if (reponse.numeroTrame == dernierACK + 1)
                        {
                            dernierACK = reponse.numeroTrame;
                            int positionDernierACK = tampon.TrouverTramePositionSelonNumero(dernierACK);
                            Trame trameDernierACK = tampon.TrouverTrame(positionDernierACK);

                            while (trameDernierACK.EstACK())
                            {
                                tampon.Consommer();
                                dernierACK++;
                                positionDernierACK = tampon.TrouverTramePositionSelonNumero(dernierACK);
                                trameDernierACK = tampon.TrouverTrame(positionDernierACK);
                            }

                        }

                        //reponse du réseau, on s'est fait owné en terro
                        /*
                            * In the absence of a communication error, the transmitter soon receives 
                            * an acknowledgment for all the packets it has sent, leaving na equal to nt. 
                            * If this does not happen after a reasonable delay, 
                            * the transmitter must retransmit the packets between na and nt.
                            */
                    }

                }
                else if (reseau.estPretEmettre && tampon.EstVide() == false) //si le reseau est prêt
                {
                    //envoi les trames entre dernierACK && dernierACK + fenetreDisponible
                    //for ( int i=dernierACK+1; i < dernierACK + fenetreDisponible; i++)

                    while (prochaineTrameNumero <= dernierACK + tailleFenetre)
                    {
                        prochaineTrame = tampon.TrouverTrame(prochaineTrameNumero);
                        if (prochaineTrame != null)
                        {
                            reseau.recevoir(prochaineTrame);
                            prochaineTrameNumero++;
                        }
                        else
                            break;
                    }

                    //Trame trameAEnvoyer = tampon.
                    //    reseau.recevoir(tampon.TrouverTrame();
                }
                else if (lectureFichierTermine == false && tampon.EstPlein() == false)
                {
                    Trame trame = new Trame();

                    fs.Position += fs.Read(trame.donnees, 0, Constantes.TAILLE_DONNEE_TRAME);

                    trame.donnees = codeCorrecteur.ajouterCode(trame.donnees);

                    tampon.Ajouter(trame);
                    if (fs.Position >= fs.Length)
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


            int trameNonRecue=0;
            int teteFenetre=0;
            int highest_sequence_number_not_yet_received=0;


            int fenetreTete = 0;
            int fenetreQueue = tailleFenetre;

            /*
             * is one more than the sequence number of the highest sequence number received. 
             * For simple receivers that only accept packets in order (wr = 1), this is the same as nr, 
             * but can be greater if wr > 1. Note the distinction: all packets below nr have been received, 
             * no packets above ns have been received, and between nr and ns, some packets have been received.
             */


            while (true)
            {
                if (reseau.estRecuDestination && tampon.EstPlein() == false) //si le reseau est prêt
                {
                    Trame trame = reseau.donner();

                    fenetreQueue = fenetreTete + tailleFenetre;

                    //receiver checks to see if it falls in the receive window
                    if ( trame.numeroTrame >= fenetreTete && trame.numeroTrame < fenetreQueue )
                    {

                        if (fenetreTete == trame.numeroTrame)
                        {
                            if (codeCorrecteur.detecterCode(ref trame.donnees)) //if NAK
                            {
                                Trame trameNak = new Trame(trame.numeroTrame, Constantes.TYPE_NAK);
                                reseau.recevoirReponse(trameNak);
                            }
                            else // if ACK
                            {
                                Trame trameAck = new Trame(trame.numeroTrame, Constantes.TYPE_ACK);
                                reseau.recevoirReponse(trameAck);

                                for (int i = 0; i < Constantes.TAILLE_DONNEE_TRAME; i++)
                                {
                                    if (trame.donnees[i] == 0)
                                    {
                                        fs.Close();
                                        _main.imprimer("La station réceptrice à terminé la réception et l'écriture du fichier.");
                                        return;
                                    }
                                    fs.WriteByte(trame.donnees[i]);
                                }
                                fenetreTete++;


                                while ( tampon.TrouverTramePositionSelonNumero(fenetreTete) > -1 )
                                {
                                    Trame trameAEcrire = tampon.TrouverTrameSelonNumero(fenetreTete);
                                    for (int i = 0; i < Constantes.TAILLE_DONNEE_TRAME; i++)
                                    {
                                        if (trameAEcrire.donnees[i] == 0)
                                        {
                                            fs.Close();
                                            _main.imprimer("La station réceptrice à terminé la réception et l'écriture du fichier.");
                                            return;
                                        }
                                        fs.WriteByte(trameAEcrire.donnees[i]);
                                    }
                                    fenetreTete++;
                                }
                            }
                        }
                    }

                    //reponse du réseau, on s'est fait owné en terro

                }
                else if (tampon.EstVide() == false)
                {
                    Trame trame = tampon.Consommer();
                    for (int i = 0; i < Constantes.TAILLE_DONNEE_TRAME; i++)
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
