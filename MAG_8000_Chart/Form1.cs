using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAG_8000_Chart
{
    public partial class frMAG8000 : Form
    {

        string dateipfad_lesen;
        int AufgesplittetArrayCount;
        String DateiInhalt, DateiInhalt_orgnial;
        string[] Aufgesplittet;

        int OpenFilesCounter = 0;
        int Zeit = 1;
        int p = 0;
        int ZählerArray = 2;

        public frMAG8000()

        {
            InitializeComponent();
            Dateiöffnen();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            Dateiöffnen();
        }
        
        public void Dateiöffnen()

        {
            openFileDialog.FileName = "";           
            DialogResult fileDialogResult = openFileDialog.ShowDialog();

            dateipfad_lesen = openFileDialog.FileName;                 // Dateiname und Pfad eingelesen
            
           if (fileDialogResult == DialogResult.OK)
            {                
                DateiAufsplitten();                                     //ganze Datei wird in ein String eingelesen und aufgesplittet ==> String [] Aufgesplittet
                Chart_zeichnen();
                OpenFilesCounter++;
            }
            else
            {
                MessageBox.Show(@"Datei nicht vorhanden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }                       
        }
        public void Chart_zeichnen() // Diagramm zeichnen mit Tagen um Uhrzeit
        {

            int Zeit = 1;
            int Datum = 0;

            int ZählerArray = 2;

            ctMAG8000.Series[0].Name = dateipfad_lesen;
            while (ZählerArray < AufgesplittetArrayCount)
            {
                ctMAG8000.Series[0].Points.AddY(Aufgesplittet[ZählerArray]);
                // Den ersten Punkt das Datum mit geben
                ctMAG8000.Series[0].Points[p].AxisLabel = Aufgesplittet[Datum] + "\n" + Aufgesplittet[Zeit];
                ZählerArray = ZählerArray + 12;
                p++;
                Zeit = Zeit + 12;
            }

            ctMAG8000.ChartAreas[0].CursorX.IsUserEnabled = true;
            ctMAG8000.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            ctMAG8000.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            ctMAG8000.ChartAreas[0].AxisX.ScrollBar.Enabled = true; // Zoom & Scrollbar Hinzufügen
        }





        private void btnWerteAnzeigen_Click(object sender, EventArgs e)
        {

            if (ctMAG8000.Series[0].IsValueShownAsLabel == true)
            {
                ctMAG8000.Series[0].IsValueShownAsLabel = false;
                werteEinblendenToolStripMenuItem.Text = "Werte einblenden";
            }
            
            else 
            {
                ctMAG8000.Series[0].IsValueShownAsLabel = true;
                werteEinblendenToolStripMenuItem.Text = "Werte ausblenden";
            }


        }

        private void btnChartReset_Click(object sender, EventArgs e)
        {
            p = 0;
            ctMAG8000.Series[0].Points.Clear();
        }

        private void hilfeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Wilkommen bei den Diagramm für den \n Wasserzähler MAG 8000.\n Neue Dateien können mit Doppelklick\nauf das Diagramm hinzugefügt werden.\nIm Diagramm kann mit gedrückter Maustaste rein gezoomt werden.\n\n\n erstellt von Rupprecht Karsten 3Q/2017\nVersion 1.1","Hilfe",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }


        private void dateiLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dateiöffnen();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        public void DateiAufsplitten()
        // Liest Datei ein und Splitet sie auf als ARRAYCOUNTER ist der Zählwert von Index Array deklariert
        {

            try
            {
                System.IO.StreamReader sr = new StreamReader(dateipfad_lesen, false);

                DateiInhalt = sr.ReadToEnd(); // Ganze Datei einlesen  
                DateiInhalt_orgnial = DateiInhalt;

                StringBuilder
                    sb = new StringBuilder(
                        DateiInhalt); // Datei String wird eingelesen und " " Leerzeichen mit ";" ersetzt   klappt auch "\r\n\"
                sb.Replace(" ", ";");
                sb.Replace("\r\n", ";");

                DateiInhalt = sb.ToString(); // String Bulider wieder in Variable Schreiben
                Aufgesplittet = DateiInhalt.Split(';'); // Der String wird aufgeteilt
                AufgesplittetArrayCount =
                    Aufgesplittet.Count(); // Wird gezählt wieviel Array's es gibt und für die While Schleife verwendet

                if (OpenFilesCounter >= 1)
                {
                    //AufgesplittetArrayCount = OpenFilesCounter * AufgesplittetArrayCount;
                }
                sr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Datei nicht vorhanden.  \n ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
















    }
}
