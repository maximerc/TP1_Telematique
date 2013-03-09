using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace TP1_Telematique
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
           
            InitializeComponent();
        }

        private void btnEmettre_Click(object sender, EventArgs e)
        {
            int tailleTampon, horlogeDeGarde;
            string fichierACopier = "";
            string destinationFichier = "";

            //Validation des paramètres
                if (!Int32.TryParse(txtTailleTampon.Text, out tailleTampon))
                {
                    MessageBox.Show("La taille du tampon doit être un entier");
                    return;
                }
                else if (!Int32.TryParse(txtDelaiTemporisation.Text, out horlogeDeGarde))
                {
                    MessageBox.Show("Le délai de temporisation doit être un entier");
                    return;
                }
                else if(!File.Exists(txtFichierSource.Text))
                {
                    MessageBox.Show("Le fichier source est invalide");
                    fichierACopier = txtFichierSource.Text;
                    return;
                }
 
//                else if(!Directory.Exists(txtFichierDestination.Text))
//                {
//                    MessageBox.Show("Le chemin de destination est invalide");
                    destinationFichier = txtFichierDestination.Text;
 //                   return;
 //               }

                Run(tailleTampon, horlogeDeGarde, fichierACopier, destinationFichier);
            }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            frmConfiguration frm = new frmConfiguration();
            frm.ShowDialog();
        }

        private void Run(int tailleTampon, int horlogeDeGarde, string fichierACopier, string destinationFichier)
        {
            var station = new Station(this,tailleTampon);
            var reseau = new Reseau(this);


            var threadReseau = new Thread(new ThreadStart(reseau.demarrer));
            var threadRecepteur = new Thread(new ThreadStart(station.recevoir));
            var threadEmetteur = new Thread(new ThreadStart(station.emettre));

            threadReseau.Start();
            threadRecepteur.Start();
            threadEmetteur.Start();

            Thread.Sleep(1);
        }

        public void imprimer(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(imprimer), new object[] { message });
                return;
            }
            textBox.Text += "(" + DateTime.Now + ")   - " + message + Environment.NewLine;
        }
    }
}
