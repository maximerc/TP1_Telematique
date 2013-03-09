using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1_Telematique
{
    class Reseau
    {
        private readonly frmMain _main;

        public Reseau(frmMain main)
        {
            _main = main;
        }

        public void demarrer()
        {
            _main.imprimer("Reseau en marche.");
        }
    }
}
