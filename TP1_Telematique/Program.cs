using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TP1_Telematique
{
    class Program
    {
        static void Main(string[] args)
        {
            int tailleTampon, horlogeDeGarde;
            string fichierACopier, destinationFichier;


            //Validation des paramètres
            if (args.Length != 4)
            {
                System.Console.WriteLine("Le nombre d'arguments est incorrect");
                System.Console.ReadLine();
                return;
            }
            else
            {
                if (!Int32.TryParse(args[0], out tailleTampon))
                {
                    System.Console.WriteLine("La taille du tampon doit être un entier");
                    System.Console.ReadLine();
                    return;
                }
                else if (!Int32.TryParse(args[1], out horlogeDeGarde))
                {
                    System.Console.WriteLine("La valeur de l'horloge de garde doit être un entier");
                    System.Console.ReadLine();
                    return;
                }
                fichierACopier = args[2];
                destinationFichier = args[3];
            }


            var reseau = new Reseau();
            var recepteur = new Recepteur();            
            var emetteur = new Emetteur();

            var threadReseau = new Thread(new ThreadStart(reseau.Demarrer));
            var threadRecepteur = new Thread(new ThreadStart(recepteur.Recevoir));
            var threadEmetteur = new Thread(new ThreadStart(emetteur.Emettre));

            threadReseau.Start();
            threadRecepteur.Start();
            threadEmetteur.Start();

            Thread.Sleep(1);

            System.Console.ReadLine();
        }
    }
}
