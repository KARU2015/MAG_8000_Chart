using System;
using System.Collections;
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
        string[] DurchschnittAufgesplittet;
        int DurchschnittAufgesplittetArrayCount;

        int OpenFilesCounter = 0;
        int p = 0;
        



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
                      
            openFileDialog.FileName = null;
            DialogResult dialogOpen =  openFileDialog.ShowDialog();
            
            dateipfad_lesen = openFileDialog.FileName;                 // Dateiname und Pfad eingelesen


            if (dialogOpen == DialogResult.OK)
            {
                DateiAufsplitten();                                     //ganze Datei wird in ein String eingelesen und aufgesplittet ==> String [] Aufgesplittet
                Chart_zeichnen();
                OpenFilesCounter++;
            }
            else if (dialogOpen == DialogResult.Cancel)
            {
                MessageBox.Show("Es wurde Abbrechen gedrückt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Datei nicht vorhanden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }




        public void Chart_zeichnen()                                      // Diagramm zeichnen mit Tagen um Uhrzeit
        {
            
            int Datum = 0;
            int Zeit = 1;
            int Durchfluss = 2;                     
            ctMAG8000.Series[0].Name = dateipfad_lesen;
            
            while (Durchfluss < AufgesplittetArrayCount)

            {
                ctMAG8000.Series[0].Points.AddY(Aufgesplittet[Durchfluss]);    
                ctMAG8000.Series[0].Points[p].AxisLabel = Aufgesplittet[Datum]+"\n" + Aufgesplittet[Zeit];    // Den ersten Punkt das Datum mit geben oder alle Punkte
                Durchfluss = Durchfluss + 12;
                Zeit = Zeit + 12;
                p++;

            }

            ctMAG8000.ChartAreas[0].CursorX.IsUserEnabled = true;
            ctMAG8000.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            ctMAG8000.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            ctMAG8000.ChartAreas[0].AxisX.ScrollBar.Enabled = true;            // Zoom & Scrollbar Hinzufügen
            


        }

      

        /// <summary>
        ///   Schaltflächen !!!
        ///   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
            MessageBox.Show(@" Wilkommen bei den Diagramm für den \n
                            Wasserzähler MAG 8000.\n
                            Neue Dateien können über Datei laden\n
                            hinzugefügt werden.\n
                            Im Diagramm kann mit gedrückter Maustaste rein gezoomt werden.\n\n\n 
                            erstellt von Rupprecht Karsten 3Q/2017\n
                            Version 1.3","Hilfe"                            
                            ,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }








        private void dateiLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dateiöffnen();
        }

        private void minMaxWerteAnzeigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MinMaxBerechnungGanzeDatei();
        }






        public void MinMaxBerechnungGanzeDatei()        // Berechnung auf eine Ganze Datei
        {

            int Datum = 0;       // Datum startet im Array als erster
            int Zeit = 1;        // Zeit startet ab 1
            int Durchfluss = 2;  // Durchfluss startet ab 1
            double MaxWert = 0;
            double MinWert = 10000;
            DateTime MaxWertDatum  = new DateTime(2000, 1, 1, 0, 0, 0);
            DateTime Vergleicher = new DateTime(2000, 1, 1, 0, 0, 0);
            DateTime MinWertDatum = new DateTime(2000, 1, 1, 0, 0, 0);
            double DDoubleDurchfluss;



            while (Durchfluss < AufgesplittetArrayCount)

            {
                DDoubleDurchfluss = Convert.ToDouble(Aufgesplittet[Durchfluss].Replace('.', ','));
                MaxWert = Math.Max(MaxWert, DDoubleDurchfluss);
                MinWert = Math.Min(MinWert, DDoubleDurchfluss);

                if (MaxWert == DDoubleDurchfluss)
                {
                   
                    MaxWertDatum = Convert.ToDateTime(Aufgesplittet[Datum] + " " + Aufgesplittet[Zeit]);
                }

                if (MinWert == DDoubleDurchfluss)
                {
                    MinWertDatum = Convert.ToDateTime(Aufgesplittet[Datum] + " "+ Aufgesplittet[Zeit]);
                }

                Datum = Datum + 12;                
                Zeit = Zeit + 12;
                Durchfluss = Durchfluss + 12;

                
            }

            if (MaxWertDatum == Vergleicher || MaxWertDatum == Vergleicher)
            {
                MessageBox.Show("Keine Messwerte aufgenommen!", "MIN/MAX - Berechnung", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            MessageBox.Show("Der Maximalwert war am " + MaxWertDatum + "  -->  " + MaxWert + " \n " +
                                "Der Minimalwert war am " + MinWertDatum + "  -->  " + MinWert , "MIN/MAX - Berechnung", MessageBoxButtons.OK,MessageBoxIcon.Information);


        }

        private void hDurchschnittsausgabeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bitte nur Messwertarchiv Daten auswählen.", "Viertelstündlicher Durchschnitt", MessageBoxButtons.OK);

            Dateiöffnen();
            einviertelDurchschnitt();




        }




        public void einviertelDurchschnitt()   //  01.05.17 00:00:00;    9294,00;    01.05.17 00:00:00;   9181,00;
        {
            string ZeilenInhalt;
            string[] AusleseZeile;
            ArrayList LAusleseZeile = new ArrayList();
            int Wasserstand1;
            int Wasserstand2;
            int Zeile;
            int ViertelStunde;
            int MaxWs1=0, MinWs1=9999, MaxWs2=0, MinWs2=9999;
            string Datum1 = "",Datum2 = "";
            int ZählerOutputWriter;


            try
            {
                Zeile = 1;
                ViertelStunde = 15;
                ZählerOutputWriter = 1;

                // Zeile für Zeile lesen und in einen Array [Aufgesplittet] abspeichern !!!!
                StreamReader sr = new StreamReader(dateipfad_lesen, false);
                {
                    while (sr.Peek() >= 0)
                    {
                      

                        ZeilenInhalt = sr.ReadLine();
                        AusleseZeile = ZeilenInhalt.Split(';');                  // Der String wird aufgeteilt

                        Wasserstand1 = Convert.ToInt32(AusleseZeile[2]);
                        Wasserstand2 = Convert.ToInt32(AusleseZeile[4]);

                        MaxWs1 = Math.Max(MaxWs1, Wasserstand1);                    // max Werte ermitteln
                        MaxWs2 = Math.Max(MaxWs2, Wasserstand2);

                        MinWs1 = Math.Min(MinWs1, Wasserstand1);                    // Min Werte ermitteln
                        MinWs2 = Math.Min(MinWs2, Wasserstand1);


                        if (Zeile == ViertelStunde)
                        {
                            Datum1 = AusleseZeile[0];
                            Datum2 = AusleseZeile[2];
                            

                            using (StreamWriter sw = new StreamWriter(dateipfad_lesen + "_1/4 Durchschnitt.csv"))
                            {
                                sw.WriteLine(Datum1  + ";"+ MaxWs1 + ";" + MinWs1 + ";" + Datum2 + ";" + MaxWs2 + ";" + MinWs2  );
                                ZählerOutputWriter++;
                            }


                            MaxWs1 = 0; MinWs1 = 9999; MaxWs2 = 0; MinWs2 = 9999;
                            Zeile = 1;
                        }
                        

                        
                        Zeile++;

                        LAusleseZeile.AddRange(AusleseZeile);

                    }

                    DurchschnittAufgesplittet = (string[])LAusleseZeile.ToArray(typeof(string));

                    DurchschnittAufgesplittetArrayCount = DurchschnittAufgesplittet.Count();        // Wird gezählt wieviel Array's es gibt und für die While Schleife verwendet

                    MessageBox.Show("Es wurden " + DurchschnittAufgesplittetArrayCount + " Zeilen eingelesen\n" +
                                    "und es wurden " + ZählerOutputWriter+" geschreiben. ",
                                    "Viertelstunden Max/Min Durchschnitt Wert",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                sr.Close();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "\n Datei nicht vorhanden. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }                        //  01.05.17 00:00:00;    9294,00;    01.05.17 00:00:00;   9181,00;




















        public void DateiAufsplitten()
        // Liest Datei ein und Splitet sie auf als ARRAYCOUNTER ist der Zählwert von Index Array deklariert
        {
            string ZeilenInhalt;
            string[] AusleseZeile;
            ArrayList LAusleseZeile = new ArrayList();
                        
            try
            {
                


                // Zeile für Zeile lesen und in einen Array [Aufgesplittet] abspeichern !!!!
                StreamReader sr = new StreamReader(dateipfad_lesen, false);
                {
                    while ( sr.Peek() >= 0)
                    {


                         ZeilenInhalt = sr.ReadLine();
                        ZeilenInhalt = ZeilenInhalt.Replace(" ", ";");
                        ZeilenInhalt = ZeilenInhalt.Replace("\r\n", ";");

                        AusleseZeile = ZeilenInhalt.Split(';');                  // Der String wird aufgeteilt
                        LAusleseZeile.AddRange(AusleseZeile);

                    }

                     Aufgesplittet = (string[])LAusleseZeile.ToArray(typeof(string));

                    AufgesplittetArrayCount = Aufgesplittet.Count();        // Wird gezählt wieviel Array's es gibt und für die While Schleife verwendet


                }
                







                /*

                StreamReader sr = new StreamReader(dateipfad_lesen, false);

                DateiInhalt = sr.ReadToEnd();                                   // Ganze Datei einlesen  
                DateiInhalt_orgnial = DateiInhalt;

                
                StringBuilder sb = new StringBuilder(DateiInhalt);              // Datei String wird eingelesen und " " Leerzeichen mit ";" ersetzt   klappt auch "\r\n\"
                sb.Replace(" ", ";");
                sb.Replace("\r\n", ";");

                DateiInhalt = sb.ToString();                                    // String Bulider wieder in Variable Schreiben

                Aufgesplittet = DateiInhalt.Split(';');                     // Der String wird aufgeteilt

                AufgesplittetArrayCount = Aufgesplittet.Count();        // Wird gezählt wieviel Array's es gibt und für die While Schleife verwendet

                if (OpenFilesCounter >= 1)
                {
                    //AufgesplittetArrayCount = OpenFilesCounter * AufgesplittetArrayCount;
                }
                
                */


                sr.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "\n Datei nicht vorhanden. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
















    }
}
