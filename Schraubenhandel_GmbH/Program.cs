using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubenhandel_GmbH
{
    class Program
    {
        static void Main(string[] args)

       //HAUPTPROGRAMM (1)


        {
        Hauptmenü:
            Console.WriteLine("Sehr geehrte Kundin, sehr geehrter Kunde,\nvielen Dank, dass Sie sich für uns entschieden haben\nWir bieten Ihnen folgendes an:\n(1) Normteile (2) Individuelle Schraubenanpassung und Berechnungen");
            int anfang = Convert.ToInt32(Console.ReadLine());

            
            double[,] festigkeitsklasse = new double[7, 3];

            //Festigkeitsklasse       //Zugfestigkeit in [Nmm2]           //Streckgrenze in [Nmm2]
            festigkeitsklasse[0, 0] = 4.6; festigkeitsklasse[0, 1] = 400; festigkeitsklasse[0, 2] = 240;
            festigkeitsklasse[1, 0] = 5.6; festigkeitsklasse[1, 1] = 500; festigkeitsklasse[1, 2] = 300;
            festigkeitsklasse[2, 0] = 5.8; festigkeitsklasse[2, 1] = 500; festigkeitsklasse[2, 2] = 400;
            festigkeitsklasse[3, 0] = 6.8; festigkeitsklasse[3, 1] = 600; festigkeitsklasse[3, 2] = 480;
            festigkeitsklasse[4, 0] = 8.8; festigkeitsklasse[4, 1] = 800; festigkeitsklasse[4, 2] = 640;
            festigkeitsklasse[5, 0] = 10.9; festigkeitsklasse[5, 1] = 1000; festigkeitsklasse[5, 2] = 900;
            festigkeitsklasse[6, 0] = 12.9; festigkeitsklasse[6, 1] = 1200; festigkeitsklasse[6, 2] = 10.9;


            switch (anfang)
            {

                //SCHRAUBENBERECHNUNG (2.1)

                case 2:

                    {
                        Console.WriteLine("(1) Schraubeneinkauf: Hier können Sie Ihre eigene Schraube entwerfen und anschließend bei unserem Webshop Partner direkt bestellen\n(2) Schraubenberechnung: Hier berechnen wir für Sie alle wichtigen Daten für Schrauben mit Ihren Angaben\n\n0 für Hauptmenü\n");


                        int erstesAuswahl = Convert.ToInt32(Console.ReadLine());

                        if (erstesAuswahl == 0)
                        {
                            goto Hauptmenü;
                        }


                        if (erstesAuswahl == 2)
                        {
                            Console.WriteLine("Was möchten Sie berechnen?\n(1) Masse\n(2) Preis\n(3) maximale Zugkraft");
                            int zweitesAuswahl = Convert.ToInt32(Console.ReadLine());


                            if (zweitesAuswahl == 1)
                            {
                                Console.WriteLine("Kerndurchmesser angeben");
                                double ii = Convert.ToDouble(Console.ReadLine());
                                double MasseReady = MassenFunktion(ii, erstesAuswahl, zweitesAuswahl);
                                Console.WriteLine("Die Masse beträgt " + MasseReady + " g");

                            }
                            if (zweitesAuswahl == 2)
                            {
                                Console.WriteLine("Kerndurchmesser angeben");
                                double ii = Convert.ToDouble(Console.ReadLine());
                                double PreisReady = MassenFunktion(ii, erstesAuswahl, zweitesAuswahl);
                                Console.WriteLine("Der Preis beträgt " + (PreisReady / 1000) + " $");
                            }
                            if (zweitesAuswahl == 3)
                            {
                                Console.WriteLine("Bitte wählen Sie die Festigkeitsklasse:");
                                Console.WriteLine("(1) 4,6\n(2) 5,6\n(3) 5,8\n(4) 6,8\n(5) 8,8\n(6) 10,9\n(7) 12,9\nUnd einen Durchmesser in mm");
                                int f = Convert.ToInt32(Console.ReadLine());
                                double durchmes = Convert.ToDouble(Console.ReadLine());
                                int g = f - 1;
                                double Streckgrenzen = festigkeitsklasse[g, 2];
                                Console.WriteLine("Bitte geben Sie einen Sicherheitsfaktor ein:");
                                double SicherheitNü = Convert.ToDouble(Console.ReadLine());
                                double Fzul; double sigmaZul;
                                double QuerschnittS;
                                MetrischesGewinde QuerschnittGewinde = new MetrischesGewinde();
                                Console.WriteLine("Bitte Steigung angeben");
                                QuerschnittGewinde.Steigung = Convert.ToDouble(Console.ReadLine());
                                QuerschnittS = QuerschnittGewinde.QuerschnittSS();
                                sigmaZul = Streckgrenzen / SicherheitNü;
                                Fzul = sigmaZul * QuerschnittS;

                                Console.WriteLine("Maximal zulässige Gesamtkraft:" + "\n" + Fzul + " N/mm^2");
                            }
                        }



                        //SCHRAUBENERSTELLUNG (2.2)

                        if (erstesAuswahl == 1)
                        {
                            Nachfrage Nachfrag = new Nachfrage();

                            GewindeFrei GewindeFreiBest = new GewindeFrei();

                            NurPreis PreisReady2 = new NurPreis();

                            Variable Vari = new Variable();

                            do
                            {
                                Console.WriteLine("Für Ihre individuelle Schraubenanpassung sind einige Eingabedaten erforderlich.\n ");

                                Console.WriteLine("Bitte nennen Sie die gewünschte Gewindegröße in mm:");

                                double ii = Convert.ToDouble(Console.ReadLine());

                                PreisReady2.preis2 = MassenFunktion(ii, erstesAuswahl, 2);      //Methodenaufruf, mitgabe: Kerndurchmesser ii, Parameter ersteAAuswahl; 1 -> Masse statt Preisausgabe



                                Console.WriteLine("Bitte wählen Sie die gewünschte Gewindeart:\n(1) Metrisches Gewinde nach ISO Norm\n(2) Trapezgewinde nach ISO Norm");

                                int gewindeauswahl = Convert.ToInt32(Console.ReadLine());



                                Console.WriteLine("Bitte geben Sie die gewünschte Steigung in mm an:");
                                GewindeFreiBest.Steigung = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Bitte geben Sie den gewünschten Flankenwinkel an:");
                                GewindeFreiBest.Flankenwinkel = Convert.ToDouble(Console.ReadLine());

                                switch (gewindeauswahl)                                        //Angaben zum Gewinde 
                                {
                                    case 1:                                                    //Case 1: Metrisches Gewinde Winkel bestimmtbar
                                        {
                                            GewindeFreiBest.ergebniss = GewindeFreiBest.HöheFreiesGewinde();
                                            Vari.Gesamt = 2 * GewindeFreiBest.ergebniss + ii;
                                        }
                                        break;
                                    case 2:                                                    //Case 2: Trapezgewinde
                                        {

                                        }
                                        break;

                                }

                                Console.WriteLine("Sind alle Eingaben korrekt?\n(1) Alle Eingaben sind korrekt.\n(2) Die Eingaben sollen erneuert werden.");
                                Nachfrag.richtig = Convert.ToInt32(Console.ReadLine());
                            }
                            while (Nachfrag.richtig == 2);

                            Console.WriteLine("Anzahl angeben");
                            int anzzal = Convert.ToInt32(Console.ReadLine());
                            //Techn. Daten Wiedergabe     //Masseberechnung für Datenblatt 

                            double gesamtpreiss = PreisReady2.preis2 * anzzal + 10;
                            Console.WriteLine("Techniches Daten zur von Ihnen erstellten Schraube:\nGesamtdurchmesser " + Vari.Gesamt + "\nPreis (Setzt sich zusammen aus Werkstoffkosten und 10$ für Versand und Herstellung : " + gesamtpreiss + " $");
                            Console.WriteLine("Speditionsdienst?\n(1) DHL\n(2) DPD\n(3) Hermes");
                            int dienst = Convert.ToInt32(Console.ReadLine());
                            if (dienst == 1)
                            {
                                Console.WriteLine("Lieferzeit 1 - 3 Werktage");
                            }
                            if (dienst == 2)
                            {
                                Console.WriteLine("Lieferzeit 3 - 6 Wochen");
                            }

                            if (dienst == 3)
                            {
                                Console.WriteLine("Das Paket kommt nie an :(");
                            }




                            Console.WriteLine("Vielen Dank für Ihren Einkauf und beehren Sie uns bald wieder.");
                            //Schraubenschaft/Gewinde
                        }

                        Console.ReadKey();
                    }
                    break;

                case 1:
                    {
                        //NORMTEILE (3)
                        //Werkstofftabellen:
                        Console.WriteLine("Bitte WS wählen:\n(1) Baustahl S235JR\n(2) Vergütungsstahl 34CrNiMo6\n(3) Messing CuZn37\n(4) Aluminiumlegierung ENAW-AlSi1MgMn");

                        double[] dichte = new double[8];  //Dichten in g/cm^3
                        dichte[0] = 7.85;     //Baustahl S235JR
                        dichte[1] = 8;    //Vergütungsstahl 34CrNiMo6
                        dichte[2] = 8.44;     //Messing CuZn37
                        dichte[3] = 2.7;     //Aluminiuimlegierung ENAW-AlSi1MgMn


                        int welchedichte = Convert.ToInt32(Console.ReadLine());
                        double diedichte = dichte[welchedichte - 1];


                        Console.WriteLine("Bitte wählen Sie einen Schraubentyp:\n(1) Sechskantschrauben nach DIN EN ISO 4017 (durchgängiges Gewinde) bzw. nach DIN EN ISO 4014 (mit Schaft)\n(2) Vierkantschrauben mit Kernansatz DIN 479\n(3) Zylinderkopfschrauben mit Innensechskant nach DIN EN ISO 4762\n(4) Senkkopfschrauben mit Innensechskant nach DIN EN ISO 10642\n(5) Linsensenkkopfschrauben mit Schlitz nach DIN EN ISO 2010");
                        
                        int NormteilSwitch;
                        NormteilSwitch = Convert.ToInt32(Console.ReadLine());

                        switch(NormteilSwitch)
                            {
                            case 1:               // Sechskantschraube DIN EN ISO 4017 (durchgängiges Gewinde) / DIN EN ISO 4014 (mit Schaft)
                                {
                                    double[,] Normtabelle = new double[11, 5];


                                    //Bezeichnung           // Kopfgröße             //Kerndurchmesser      //Schlüsselweite          //Kopfhöhe
                                    Normtabelle[0, 0] = 4; Normtabelle[0, 1] = 7.7; Normtabelle[0, 2] = 3.40; Normtabelle[0, 3] = 7; Normtabelle[0, 4] = 2.8;
                                    Normtabelle[1, 0] = 6; Normtabelle[1, 1] = 11.1; Normtabelle[1, 2] = 5.07; Normtabelle[1, 3] = 10; Normtabelle[1, 4] = 4;
                                    Normtabelle[2, 0] = 8; Normtabelle[2, 1] = 14.4; Normtabelle[2, 2] = 6.82; Normtabelle[2, 3] = 13; Normtabelle[2, 4] = 5.3;
                                    Normtabelle[3, 0] = 10; Normtabelle[3, 1] = 18.9; Normtabelle[3, 2] = 8.56; Normtabelle[3, 3] = 17; Normtabelle[3, 4] = 6.4;
                                    Normtabelle[4, 0] = 12; Normtabelle[4, 1] = 21.1; Normtabelle[4, 2] = 10.32; Normtabelle[4, 3] = 19; Normtabelle[4, 4] = 7.5;
                                    Normtabelle[5, 0] = 14; Normtabelle[5, 1] = 24.5; Normtabelle[5, 2] = 12.07; Normtabelle[5, 3] = 21; Normtabelle[5, 4] = 8.8;
                                    Normtabelle[6, 0] = 16; Normtabelle[6, 1] = 26.8; Normtabelle[6, 2] = 14.08; Normtabelle[6, 3] = 24; Normtabelle[6, 4] = 10;
                                    Normtabelle[7, 0] = 18; Normtabelle[7, 1] = 30.1; Normtabelle[7, 2] = 15.57; Normtabelle[7, 3] = 27; Normtabelle[7, 4] = 11.5;
                                    Normtabelle[8, 0] = 20; Normtabelle[8, 1] = 33.5; Normtabelle[8, 2] = 17.57; Normtabelle[8, 3] = 30; Normtabelle[8, 4] = 12.5;
                                    Normtabelle[9, 0] = 22; Normtabelle[9, 1] = 35.7; Normtabelle[9, 2] = 19.57; Normtabelle[9, 3] = 34; Normtabelle[9, 4] = 14;
                                    Normtabelle[10, 0] = 24; Normtabelle[10, 1] = 40.0; Normtabelle[10, 2] = 21.07; Normtabelle[10, 3] = 36; Normtabelle[10, 4] = 15;

                                    Console.WriteLine("Bitte Aktion auswählen:(1) Masse");
                                    int ausgewählt0 = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Bitte Gewindegröße angeben\n4\n6\n8\n10\n12\n16\n20\n24");
                                    int eingegeben0 = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Bitte LKänge angeben");
                                    double LängeSechskant = Convert.ToDouble(Console.ReadLine());

                                    double KopfgrößeSechskant = Normtabelle[(eingegeben0 - 1), 1];
                                    double KerndurchmesserSechskant = Normtabelle[(eingegeben0 - 1), 2];
                                    double SchlüsselweiteSechskant = Normtabelle[(eingegeben0 - 1), 2];
                                    double KopfhöheSechskant = Normtabelle[(eingegeben0 - 1), 3];

                                    NormSechskant(ausgewählt0, KopfgrößeSechskant, KerndurchmesserSechskant, SchlüsselweiteSechskant, KopfhöheSechskant, diedichte, LängeSechskant);
                                }


                                break;
                            case 2:            // Vierkantschraube mit Kernansatz DIN 479
                                {
                                    double[,] Normtabelle2 = new double[8, 5];

                                    //Bezeichnung            // Kopfgröße           //Kerndurchmesser           //Schlüsselweite        //Kopfhöhe
                                    Normtabelle2[0, 0] = 4; Normtabelle2[0, 1] = 6; Normtabelle2[0, 2] = 3.40; Normtabelle2[0, 3] = 4; Normtabelle2[0, 4] = 4;
                                    Normtabelle2[1, 0] = 6; Normtabelle2[1, 1] = 8; Normtabelle2[1, 2] = 5.07; Normtabelle2[1, 3] = 6; Normtabelle2[1, 4] = 6;
                                    Normtabelle2[2, 0] = 8; Normtabelle2[2, 1] = 10; Normtabelle2[2, 2] = 6.82; Normtabelle2[2, 3] = 8; Normtabelle2[2, 4] = 8;
                                    Normtabelle2[3, 0] = 10; Normtabelle2[3, 1] = 13; Normtabelle2[3, 2] = 8.56; Normtabelle2[3, 3] = 10; Normtabelle2[3, 4] = 10;
                                    Normtabelle2[4, 0] = 12; Normtabelle2[4, 1] = 17; Normtabelle2[4, 2] = 10.32; Normtabelle2[4, 3] = 13; Normtabelle2[4, 4] = 12;
                                    Normtabelle2[5, 0] = 16; Normtabelle2[5, 1] = 22; Normtabelle2[5, 2] = 14.08; Normtabelle2[5, 3] = 17; Normtabelle2[5, 4] = 16;
                                    Normtabelle2[6, 0] = 20; Normtabelle2[6, 1] = 28; Normtabelle2[6, 2] = 17.57; Normtabelle2[6, 3] = 22; Normtabelle2[6, 4] = 20;
                                    Normtabelle2[7, 0] = 24; Normtabelle2[7, 1] = 32; Normtabelle2[7, 2] = 21.07; Normtabelle2[7, 3] = 24; Normtabelle2[7, 4] = 22;

                                    Console.WriteLine("Bitte Aktion auswählen:(1) Masse");
                                    int ausgewählt = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Bitte Gewindegröße angeben\n4\n6\n8\n10\n12\n16\n20\n24");
                                    int eingegeben = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Bitte LKänge angeben");
                                    double Längevierkant = Convert.ToDouble(Console.ReadLine());

                                    double KopfgrößeVierkant = Normtabelle2[(eingegeben - 1), 1];
                                    double KerndurchmesserVierkant = Normtabelle2[(eingegeben - 1), 2];
                                    double SchlüsselweiteVierkant = Normtabelle2[(eingegeben - 1), 2];
                                    double KopfhöheVierkant = Normtabelle2[(eingegeben - 1), 3];

                                    NormVierkant(ausgewählt, KopfgrößeVierkant, KerndurchmesserVierkant, SchlüsselweiteVierkant, KopfhöheVierkant, diedichte, Längevierkant);
                                    
                                }
                                break;

                                



                            case 3:             // Zylinderkopfschraube mit Innensechskant DIN EN ISO 4762
                                {
                                    double[,] Normtabelle3 = new double[11, 5];

                                    //Bezeichnung             // Kopfgröße         //Kerndurchmesser            //Schlüsselweite       //Kopfhöhe
                                    Normtabelle3[0, 0] = 4; Normtabelle3[0, 1] = 7; Normtabelle3[0, 2] = 3.40; Normtabelle3[0, 3] = 3; Normtabelle3[0, 4] = 4;
                                    Normtabelle3[1, 0] = 6; Normtabelle3[1, 1] = 10; Normtabelle3[1, 2] = 5.07; Normtabelle3[1, 3] = 5; Normtabelle3[1, 4] = 6;
                                    Normtabelle3[2, 0] = 8; Normtabelle3[2, 1] = 13; Normtabelle3[2, 2] = 6.82; Normtabelle3[2, 3] = 6; Normtabelle3[2, 4] = 8;
                                    Normtabelle3[3, 0] = 10; Normtabelle3[3, 1] = 16; Normtabelle3[3, 2] = 8.56; Normtabelle3[3, 3] = 8; Normtabelle3[3, 4] = 10;
                                    Normtabelle3[4, 0] = 12; Normtabelle3[4, 1] = 18; Normtabelle3[4, 2] = 10.32; Normtabelle3[4, 3] = 10; Normtabelle3[4, 4] = 12;
                                    Normtabelle3[5, 0] = 14; Normtabelle3[5, 1] = 21; Normtabelle3[5, 2] = 12.07; Normtabelle3[5, 3] = 12; Normtabelle3[5, 4] = 14;
                                    Normtabelle3[6, 0] = 16; Normtabelle3[6, 1] = 24; Normtabelle3[6, 2] = 14.08; Normtabelle3[6, 3] = 14; Normtabelle3[6, 4] = 16;
                                    Normtabelle3[7, 0] = 18; Normtabelle3[7, 1] = 27; Normtabelle3[7, 2] = 15.57; Normtabelle3[7, 3] = 14; Normtabelle3[7, 4] = 18;
                                    Normtabelle3[8, 0] = 20; Normtabelle3[8, 1] = 30; Normtabelle3[8, 2] = 17.57; Normtabelle3[8, 3] = 17; Normtabelle3[8, 4] = 20;
                                    Normtabelle3[9, 0] = 22; Normtabelle3[9, 1] = 33; Normtabelle3[9, 2] = 19.57; Normtabelle3[9, 3] = 17; Normtabelle3[9, 4] = 22;
                                    Normtabelle3[10, 0] = 24; Normtabelle3[10, 1] = 36; Normtabelle3[10, 2] = 21.07; Normtabelle3[10, 3] = 19; Normtabelle3[10, 4] = 24;
                                }
                                break;
                            case 4:              // Senkkopfschraube mit Innensechskant DIN EN ISO 10642
                                {
                                    double[,] Normtabelle4 = new double[9, 5];

                                    //Bezeichnung                     // Kopfgröße                  //Kerndurchmesser                //Schlüsselweite              //Kopftiefe
                                    Normtabelle4[0, 0] = 4; Normtabelle4[0, 1] = 7.5; Normtabelle4[0, 2] = 3.40; Normtabelle4[0, 3] = 2.5; Normtabelle4[0, 4] = 1.9;
                                    Normtabelle4[1, 0] = 6; Normtabelle4[1, 1] = 11.3; Normtabelle4[1, 2] = 5.07; Normtabelle4[1, 3] = 4; Normtabelle4[1, 4] = 3.7;
                                    Normtabelle4[2, 0] = 8; Normtabelle4[2, 1] = 15.2; Normtabelle4[2, 2] = 6.82; Normtabelle4[2, 3] = 5; Normtabelle4[2, 4] = 5;
                                    Normtabelle4[3, 0] = 10; Normtabelle4[3, 1] = 19.2; Normtabelle4[3, 2] = 8.56; Normtabelle4[3, 3] = 6; Normtabelle4[3, 4] = 6.2;
                                    Normtabelle4[4, 0] = 12; Normtabelle4[4, 1] = 23.1; Normtabelle4[4, 2] = 10.32; Normtabelle4[4, 3] = 8; Normtabelle4[4, 4] = 7.4;
                                    Normtabelle4[5, 0] = 14; Normtabelle4[5, 1] = 30; Normtabelle4[5, 2] = 12.07; Normtabelle4[5, 3] = 10; Normtabelle4[5, 4] = 8.2;
                                    Normtabelle4[6, 0] = 16; Normtabelle4[6, 1] = 30; Normtabelle4[6, 2] = 14.08; Normtabelle4[6, 3] = 10; Normtabelle4[6, 4] = 8.8;
                                    Normtabelle4[7, 0] = 20; Normtabelle4[7, 1] = 36; Normtabelle4[7, 2] = 17.57; Normtabelle4[7, 3] = 12; Normtabelle4[7, 4] = 10.2;
                                    Normtabelle4[8, 0] = 24; Normtabelle4[8, 1] = 39; Normtabelle4[8, 2] = 21.07; Normtabelle4[8, 3] = 14; Normtabelle4[8, 4] = 14;
                                }
                                break;
                            case 5:            // Linsensenkschraube mit Schlitz DIN EN ISO 2010
                                {
                                    double[,] Normtabelle5 = new double[5, 6];

                                    //Bezeichnung                    // Kopfgröße                   //Kerndurchmesser               //Schlüsselweite              //Kopftiefe                   // Kopfhöhe (Linsenhöhe)
                                    Normtabelle5[0, 0] = 4; Normtabelle5[0, 1] = 8.4; Normtabelle5[0, 2] = 3.40; Normtabelle5[0, 3] = 2.7; Normtabelle5[0, 4] = 2.7; Normtabelle5[0, 5] = 1.0;
                                    Normtabelle5[1, 0] = 5; Normtabelle5[1, 1] = 9.3; Normtabelle5[1, 2] = 5.07; Normtabelle5[1, 3] = 2.7; Normtabelle5[1, 4] = 2.7; Normtabelle5[1, 5] = 1.2;
                                    Normtabelle5[2, 0] = 6; Normtabelle5[2, 1] = 11.3; Normtabelle5[2, 2] = 6.82; Normtabelle5[2, 3] = 3.3; Normtabelle5[2, 4] = 3.3; Normtabelle5[2, 5] = 1.4;
                                    Normtabelle5[3, 0] = 8; Normtabelle5[3, 1] = 15.8; Normtabelle5[3, 2] = 10.32; Normtabelle5[3, 3] = 4.7; Normtabelle5[3, 4] = 4.7; Normtabelle5[3, 5] = 2.0;
                                    Normtabelle5[4, 0] = 10; Normtabelle5[4, 1] = 18.3; Normtabelle5[4, 2] = 12.07; Normtabelle5[4, 3] = 5.0; Normtabelle5[4, 4] = 5.0; Normtabelle5[4, 5] = 2.3;
                                }
                                break;



                        }


     }
            
                    break;


                default:

                    Console.WriteLine("Ungültige Eingabe\n");

                        goto Hauptmenü;
                    




            }
            Console.ReadKey();
        }                                                                                  //HAUPTPROGRAMM ENDE !



        //KLASSEN UND METHODEN 

        //KLASSEN
        class Nachfrage
        {
            public int richtig { get; set; }
        }

        class Schraubenkopf //Klasse Schraubenkopf MAIN KLASSE
        {
            public double Höhe { get; set; }
            public string Art { get; set; }
        }

        class Vierkant : Schraubenkopf //Vererbung 1: Vierkanntkopf KLASSE
        {
            public int name { get; set; }
            public double breite { get; set; }
            public double VolumenVierkant { get; set; }
            public string ProgrammVierkantUNBENUTZT { get; set; }

            public double Volumen()
            {
                VolumenVierkant = breite * breite * Höhe;
                return VolumenVierkant;
            }
            public string VierkanntErstellung()
            {
                Console.WriteLine("Hier könnte ein Programm stehen");
                return ProgrammVierkantUNBENUTZT;
            }

        }

        class Sechskant : Schraubenkopf //Vererbung 2: Sechskanntkopf KLASSE
        {
            public double Schlüsselweite { get; set; }
            public double VolumenSechskant { get; set; }

            private double Wurzel3 = Math.Sqrt(3);
            public int ProgrammSechsUNBENUTZT { get; set; }
            private double FlächeninhaltSechseck;
            public double Volumen2()                 //Schlüsselweite STATT Seitenlänge (fr keiner beschreibt einen Sechskantkopf mit einer Seitenlänge des Sechsecks xD)
            {
                double HalbesDreieck = Schlüsselweite / Wurzel3;
                FlächeninhaltSechseck = Wurzel3 * ((3 * (HalbesDreieck * HalbesDreieck)) / 2);
                VolumenSechskant = FlächeninhaltSechseck * Höhe;
                return VolumenSechskant;
            }
            public int ProgrammSechskannt()
            {
                ProgrammSechsUNBENUTZT = 67893;
                return ProgrammSechsUNBENUTZT;


            }

        }
        class Innensechskannt : Schraubenkopf //Vererbung 3: Innensechskantschraube KLASSE
        {
            public double kreisDurchmesser { get; set; }
            public double innenHöhe { get; set; }
            public double VolumenInnensechskant { get; set; }
            public int ProgrammInnenUNBENUTZT { get; set; }
            public double Schlüsselweiten { get; set; }

            private double Wurzeln3 = Math.Sqrt(3);
            private double FlächeninhaltInnensechseck;

            public double Volumen3()
            {
                double HalbeDreiecke = Schlüsselweiten / Wurzeln3;
                FlächeninhaltInnensechseck = Wurzeln3 * ((3 * (HalbeDreiecke * HalbeDreiecke)) / 2);
                double innenVolumen = FlächeninhaltInnensechseck * innenHöhe;

                double kreisRadius = kreisDurchmesser / 2;
                double kreisVolumen = Math.PI * (kreisRadius * kreisRadius) * Höhe;

                VolumenInnensechskant = kreisVolumen - innenVolumen;

                return VolumenInnensechskant;
            }
            public int ProgrammInnensechskannt()
            {
                ProgrammInnenUNBENUTZT = 784392; //Platzhalter
                return ProgrammInnenUNBENUTZT;
            }
        }

        //METHODEN


       

        
        class Volumen1            //KLASSE Kopfvolumen 
        {                         //Volumen Kopf als Klasse deklariert, damit die Eigenschaft auch außerhalb des If Blocks weiterverwendet werden kann.
            public double Volumenx { get; set; }
        }
        static double Methode1(int entscheidung)  //METHODE Vierkannt, greift auf Klasse Vierkannt zurück
        {
            Vierkant VierkantSchraube = new Vierkant();
            Console.WriteLine("Bitte Breite des Kopfes angeben");
            VierkantSchraube.breite = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Bitte Höhe des Kopfes angeben");
            double x = Convert.ToDouble(Console.ReadLine());
            VierkantSchraube.Höhe = x;

            if (entscheidung == 2)
            {
                VierkantSchraube.Volumen();
                return VierkantSchraube.VolumenVierkant;
            }
            if (entscheidung == 1)
            {
                VierkantSchraube.Volumen();
                return VierkantSchraube.VolumenVierkant;
            }
            else if (entscheidung == 3)
            {
                VierkantSchraube.VierkanntErstellung();
                return Convert.ToDouble(VierkantSchraube.ProgrammVierkantUNBENUTZT);
            }
            else
            {
                return 0;
            }

        }
        static double Methode2(int entscheidung2)  //METHODE Sechskannt, refers to class Sechskannt
        {
            Sechskant SechskantSchraube = new Sechskant();
            Console.WriteLine("Bitte Schlüsselweite des Kopfes angeben");
            double z = Convert.ToDouble(Console.ReadLine());
            SechskantSchraube.Schlüsselweite = z;
            Console.WriteLine("Bitte Höhe des Kopfes angeben");
            double yi = Convert.ToDouble(Console.ReadLine());
            SechskantSchraube.Höhe = yi;

            if (entscheidung2 == 2)
            {
                SechskantSchraube.Volumen2();
                return SechskantSchraube.VolumenSechskant;
            }
            else if (entscheidung2 == 1)
            {
                SechskantSchraube.Volumen2();
                return SechskantSchraube.VolumenSechskant;
            }
            else if (entscheidung2 == 3)
            {
                SechskantSchraube.ProgrammSechskannt();
                return Convert.ToDouble(SechskantSchraube.ProgrammSechsUNBENUTZT);
            }
            else
                return 0;
        }
        static double Methode3(int entscheidung3) //METHODE Innensechskannt
        {
            Innensechskannt Innensechskantschraube = new Innensechskannt();
            Console.WriteLine("Bitte Aussendurchmesser des Kopfes angeben");
            double auss = Convert.ToDouble(Console.ReadLine());
            Innensechskantschraube.kreisDurchmesser = auss;
            Console.WriteLine("Bitte Höhe des Kopfes angeben");
            double höh = Convert.ToDouble(Console.ReadLine());
            Innensechskantschraube.Höhe = höh;
            Console.WriteLine("Bitte Schlüsselweite des Innensechskannts angeben");
            double inns = Convert.ToDouble(Console.ReadLine());
            Innensechskantschraube.Schlüsselweiten = inns;
            Console.WriteLine("Bitte Höhe des Innensechskannts des Kopfes angeben");
            double innh = Convert.ToDouble(Console.ReadLine());
            Innensechskantschraube.Höhe = innh;

            if (entscheidung3 == 2)
            {
                Innensechskantschraube.Volumen3();
                return Convert.ToDouble(Innensechskantschraube.VolumenInnensechskant);
            }
            else if (entscheidung3 == 1)
            {
                Innensechskantschraube.Volumen3();
                return Convert.ToDouble(Innensechskantschraube.VolumenInnensechskant);
            }
            else if (entscheidung3 == 3)
            {
                Innensechskantschraube.ProgrammInnensechskannt();
                return Convert.ToDouble(Innensechskantschraube.ProgrammInnenUNBENUTZT);
            }
            else
                return 0;

        }
        // KLASSE GEWINDE

        class Gewinde
        {
            public double Steigung { get; set; }
        }
        class MetrischesGewinde : Gewinde
        {
            private double GewindeHoehe { get; set; }
            private double d { get; set; }
            private double Flankendurchmesser { get; set; }
            private double KerndurchmesserAußengewinde { get; set; }
            public double QuerschnittS { get; set; }
            public double ergebnisSchaft { get; set; }
            public double kerndurchmesser { get; set; }

            public double GewindeHöhe()                  //Auf Norm bezogen (Winkel 60 Grad)
            {
                GewindeHoehe = (Math.Sqrt(3) * Steigung) / 2;
                return GewindeHoehe;
            }
            public double QuerschnittSS()
            {
                GewindeHöhe();
                d = GewindeHoehe - (GewindeHoehe / 8);
                Flankendurchmesser = d - 0.6495 * Steigung;
                KerndurchmesserAußengewinde = d - 1.2269 * Steigung;

                QuerschnittS = (Math.PI / 4) * (((Flankendurchmesser + KerndurchmesserAußengewinde) / 2) * ((Flankendurchmesser + KerndurchmesserAußengewinde) / 2));
                return QuerschnittS;
            }
       
            public double SchaftVolumen(double kerndurchmesser)  //METHODE: Berechnung des Volumens des Schraubenschafts
            {
                
                double schaftLänge;
                
                

                Console.WriteLine("Länge angeben");
                schaftLänge = Convert.ToDouble(Console.ReadLine());
           
                double radius = kerndurchmesser / 2;

                ergebnisSchaft = schaftLänge * (radius * radius) * Math.PI;

                return ergebnisSchaft;
                
            }
            
            class Trapezgewinde
            {

  
            }          

     

        }
        class GewindeFrei : Gewinde                //Winkel frei bestimmbar
        {
            public double Flankenwinkel { get; set; }
            public double HöheGewindeFrei { get; set; }
            public double ergebniss { get; set; }

            public double HöheFreiesGewinde()
            {
                double Steigungdurch2 = Steigung / 2;
                double InRad = Flankenwinkel / (180 / Math.PI);
                double Tangens = Math.Tan(InRad / 2);
                HöheGewindeFrei = Steigungdurch2 / Tangens;
                return HöheGewindeFrei;
            }

        }
        class Variable
        {
            public double Gesamt { get; set; }
        }
        class Gesamtdurchmesser
        {
            public double Gewindebreite { get; set; }
        }





        //MASSEFUNKTION


        static double MassenFunktion(double KernInnenDurchmesser, int ersteAuswahl, int zweiteAuswahl)
        {
            Console.WriteLine("\nBitte geben Sie die geforderten Daten in mm an.\nInfos zum SchraubenKopf\n(1) Vierkant\n(2) Sechskant\n(3) Innensechskannt");

            int eingabe = Convert.ToInt32(Console.ReadLine());
            Volumen1 Kopf = new Volumen1();

            if (eingabe == 1)
            {

                Kopf.Volumenx = Methode1(ersteAuswahl);  //Mitgabe des Intergers eingabe, für Fallunterscheidung ín den Methoden, die unterschiedl. Methoden in den Klassen aufrufen
                                                         //Objekt "Kopf" der Klasse Volumen1 bekommt den Rückgabewert aus d. Methode1 zugewiesen
            }
            if (eingabe == 2)
            {

                Kopf.Volumenx = Methode2(ersteAuswahl);

            }
            if (eingabe == 3)
            {

                Kopf.Volumenx = Methode3(ersteAuswahl);

            }

            Console.WriteLine("Infos zum Schaft");

            MetrischesGewinde SchaftberechnungInSchraubenberechnung = new MetrischesGewinde();

            double volumenSchaftInSchraubenberechnung;  //Methodenaufruf Methode "Schaft" der Klasse MetrischesGewinde zur Volumenberechnung des Schafts

           
            volumenSchaftInSchraubenberechnung = SchaftberechnungInSchraubenberechnung.SchaftVolumen(KernInnenDurchmesser);

            Console.WriteLine("Bitte Werkstoff angeben:\n(1) Baustahl S235JR\n(2) Vergütungsstahl 34CrNiMo6\n(3) Messing CuZn37\n(4) Aluminiumlegierung ENAW-AlSi1MgMn");
            int xi;

            double gesamtvolumen = volumenSchaftInSchraubenberechnung + Kopf.Volumenx;

            double[] dichte = new double[8];  //Dichten in g/cm^3
            dichte[0] = 7.85;     //Baustahl S235JR
            dichte[1] = 8;    //Vergütungsstahl 34CrNiMo6
            dichte[2] = 8.44;     //Messing CuZn37
            dichte[3] = 2.7;     //Aluminiuimlegierung ENAW-AlSi1MgMn


            xi = Convert.ToInt32(Console.ReadLine());
            int y = xi - 1;


            double dichteEnd = dichte[y];

            


            double masse;
            masse = gesamtvolumen * dichteEnd;

            double[] Preis = new double[8];  //Preise in $/kg
            Preis[0] = 3.63;   //Baustahl S235JR
            Preis[1] = 10.28;    //Vergütungsstahl 34CrNiMo6
            Preis[2] = 7.13;   //Messing CuZn37
            Preis[3] = 9.89;   //Aluminiumlegierung ENAW-AlSi1MgMn

            double preisEnd = Preis[y];

            double Werkstoffpreis;

            masse = (gesamtvolumen / 1000) * dichteEnd;
            Werkstoffpreis = (masse / 1000) * preisEnd;
     
            if(zweiteAuswahl ==1)
            {
                return masse;
            }


            if (zweiteAuswahl == 2)
            {
                return Werkstoffpreis;
            }
            else
                return 0;
        }
        // Masseklasse 
        class NurPreis
        {
            public double preis2 { get; set; }
        }

        //NORMMETHODEN
         //1. Vierkant 

        static void NormVierkant(int welcheMethode, double Kopfgr, double Kerndurch, double SW, double Kopfh, double dichtee, double Längee)
        {
            
            if (welcheMethode == 1)
            {
                double MasseVierkant = dichtee * ((Kopfgr * Kopfh) + (Längee * Kerndurch));
                Console.WriteLine("Die Masse ist" + MasseVierkant + " g");
            }
            if (welcheMethode == 2)
            {
                //PLATZHALTER
            }
        }

        //2. Sechskant 

        static void NormSechskant(int welcheMethode, double Kopfgr, double Kerndurch, double SW, double Kopfh, double dichtee, double Längee)
        {
           if (welcheMethode == 1)
            {
                double Dreieckhalb = SW / Math.Sqrt(3);
                double Sechseck = Math.Sqrt(3) * (((3 * Dreieckhalb * Dreieckhalb)) / 2);
                double MasseSechkant = dichtee * ((Sechseck * Kopfh) + (Längee * Kerndurch));
                Console.WriteLine("Die Masse ist" + MasseSechkant + " g");
            }
           if (welcheMethode == 2)
            {
                //PLATZHALTER
            }
        }

        









    }

}

