using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TP1_Telematique
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();

            ChargerComboBox();         
            ChargerParametres();
        }

        private void ChargerComboBox()
        {
            cbRejet.DisplayMember = cbCode.DisplayMember = "Key";
            cbRejet.ValueMember = cbCode.ValueMember = "Value";

            var rejetItems =  new BindingList<KeyValuePair<string, int>>();
            var codeItems = new BindingList<KeyValuePair<string, int>>();

            rejetItems.Add(new KeyValuePair<string, int>("Global", Int32.Parse(Properties.Resources.REJET_GLOBAL)));
            rejetItems.Add(new KeyValuePair<string, int>("Sélectif", Int32.Parse(Properties.Resources.REJET_SELECTIF)));

            codeItems.Add(new KeyValuePair<string, int>("Correcteur", Int32.Parse(Properties.Resources.CODE_CORRECTEUR)));
            codeItems.Add(new KeyValuePair<string, int>("Détecteur", Int32.Parse(Properties.Resources.CODE_DETECTEUR)));

            cbRejet.DataSource = rejetItems;
            cbCode.DataSource = codeItems;
        }
        private void ChargerParametres()
        {
            txtTailleFenetre.Text = Properties.Settings.Default.TAILLE_FENETRE.ToString();
            cbRejet.SelectedValue = Properties.Settings.Default.TYPE_REJET;
            cbCode.SelectedValue = Properties.Settings.Default.TYPE_CODE;
            chkErreurs.Checked = Properties.Settings.Default.CONTIENT_ERREURS;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            int tailleFenetre;
            if(!Int32.TryParse(txtTailleFenetre.Text,out tailleFenetre))
            {
                MessageBox.Show("La taille de fenêtre est invalide.");
                return;
            }

            Properties.Settings.Default.TAILLE_FENETRE = tailleFenetre;
            Properties.Settings.Default.TYPE_REJET = Int32.Parse(cbRejet.SelectedValue.ToString());
            Properties.Settings.Default.TYPE_CODE = Int32.Parse(cbCode.SelectedValue.ToString());
            Properties.Settings.Default.CONTIENT_ERREURS = chkErreurs.Checked;

            Properties.Settings.Default.Save();

            this.Close();
            
        }
    }
}
