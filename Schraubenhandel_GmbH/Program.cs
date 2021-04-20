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
            Console.WriteLine("Sehr geehrter Kunde\nVielen Dank, dass Sie sich für uns entschieden haben\nWir bieten Ihnen folgendes an:\n(1) Normteile (2) Individuelle Schraubenanpassung und Berechnungen");
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


                            if (zweitesAuswahl == 2)
                            {
                                Console.WriteLine("Kerndurchmesser angeben");
                                double ii = Convert.ToDouble(Console.ReadLine());
                               double MasseReady = MassenFunktion(ii, erstesAuswahl, zweitesAuswahl);
                                Console.WriteLine("Die Masse beträgt " + MasseReady + " g");
                
                            }
                            if(zweitesAuswahl ==1)
                            {
                                Console.WriteLine("Kerndurchmesser angeben");
                                double ii = Convert.ToDouble(Console.ReadLine());
                                double PreisReady = MassenFunktion(ii, erstesAuswahl, zweitesAuswahl);
                                Console.WriteLine("Der Preis beträgt " + PreisReady + " $");
                            }
                            if (zweitesAuswahl == 3)
                            {
                                Console.WriteLine("Bitte wählen Sie die Festigkeitsklasse");
                                Console.WriteLine("(1) 4,6\n(2) 5,6\n(3) 5,8\n(4) 6,8\n(5) 8,8\n(6) 10,9\n(7) 12,9\nUnd einen Durchmesser in mm");
                                int f = Convert.ToInt32(Console.ReadLine());
                                double durchmes = Convert.ToDouble(Console.ReadLine());
                                int g = f - 1;
                                double Streckgrenzen = festigkeitsklasse[g, 2];
                                Console.WriteLine("Bitte Sicherheitsfaktor wählen");
                                double SicherheitNü = Convert.ToDouble(Console.ReadLine());
                                double Fzul; double sigmaZul;
                                double QuerschnittS;
                                MetrischesGewinde QuerschnittGewinde = new MetrischesGewinde();
                                Console.WriteLine("Bitte Steigung angeben");
                                QuerschnittGewinde.Steigung = Convert.ToDouble(Console.ReadLine());
                                QuerschnittS = QuerschnittGewinde.QuerschnittSS();
                                sigmaZul = Streckgrenzen / SicherheitNü;
                                Fzul = sigmaZul * QuerschnittS;

                                Console.WriteLine("\n" + Fzul + " N/mm^2");
                            }
                        }
                        


                        //SCHRAUBENERSTELLUNG (2.2)

                        if (erstesAuswahl == 1)                                                                                         
                        {
                            Nachfrage Nachfrag = new Nachfrage();

                            GewindeFrei GewindeFreiBest = new GewindeFrei();

                            NurMasse MasseReady2 = new NurMasse();

                            Variable Vari = new Variable();

                            do
                            {
                                Console.WriteLine("Für Ihre individuelle Schraubenanpassung sind einige Eingabedaten erforderlich.");    //Textfeld ggf. bearbeiten !

                                Console.WriteLine("Bitte Kerndurchmesser angeben");  
                                double ii = Convert.ToDouble(Console.ReadLine());

                                MasseReady2.mass2 = MassenFunktion(ii, erstesAuswahl, 1);      //Methodenaufruf, mitgabe: Kerndurchmesser ii, Parameter ersteAAuswahl; 1 -> Masse statt Preisausgabe
                                
                               

                                Console.WriteLine("Nun zum Gewinde:\n(1) Metrisches Gewinde nach ISO Norm\n(2) Trapezgewinde nach ISO Norm");

                                int gewindeauswahl = Convert.ToInt32(Console.ReadLine());
 
                                

                                Console.WriteLine("Bitte Steigung angeben");
                                GewindeFreiBest.Steigung = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Bitte Flankenwinkel angeben");
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
                                
                                Console.WriteLine("Sind alle Eingaben korrekt ?\n(9) für Wiederholung");
                                Nachfrag.richtig = Convert.ToInt32(Console.ReadLine());
                            }
                            while (Nachfrag.richtig == 9);

                            //Techn. Daten Wiedergabe     //Masseberechnung für Datenblatt 

                            Console.WriteLine("Techniches Datenblatt zur von Ihnen erstellten Schraube:\nGesamtdurchmesser " + Vari.Gesamt + "\nMasse:" + MasseReady2.mass2 + " g");
                            

                            Console.WriteLine("Vielen Dank");
                            //Schraubenschaft/Gewinde
                        }

                        Console.ReadKey();
                    }
                    break;



                //NORMTEILE (3)

                case 1:

                    Gesamtdurchmesser gesamtdurchmesser = new Gesamtdurchmesser();
                    MetrischesGewinde Gewindedaten = new MetrischesGewinde();

                    Console.WriteLine("Normteile: Schrauben werden eingeteilt nach ihrer Festigkeit: Bitte wählen Sie eine Festigkeitsklasse.");
                    Console.WriteLine("(1) 4,6\n(2) 5,6\n(3) 5,8\n(4) 6,8\n(5) 8,8\n(6) 10,9\n(7) 12,9");

                    int u = Convert.ToInt32(Console.ReadLine());
                    int r = u - 1;
                    double festigkeitsklasseEnd = festigkeitsklasse[r, 0];
                    double Zugfestigkeits = festigkeitsklasse[r, 1];
                    double Streckgrenze = festigkeitsklasse[r, 2];

                    Console.WriteLine("Bitte geben Sie den Gewindedurchmesser in mm ein");
                    double gewindedurchmesser = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Bitte Steigung angeben");
                    Gewindedaten.Steigung = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Bitte wählen Sie eine Anzahl aus");
                    int anzahl = Convert.ToInt32(Console.ReadLine());

                    double Höööhe = Gewindedaten.GewindeHöhe();                                                  //Metrisches Gewinde nac ISO Norm 
                    gesamtdurchmesser.Gewindebreite = gewindedurchmesser + (2 * Höööhe);


                    Console.WriteLine("Sie haben sich für " + anzahl + " Schrauben der Festigkeitsklasse " + festigkeitsklasse[r, 0] + " entschieden:");
                    Console.WriteLine("Technische Daten:\nZugfestigkeit: " + Zugfestigkeits + "\nStreckgrenze: " + Streckgrenze + "\nGewinde: M" + gewindedurchmesser + "\nGesamtdurchmesser:" + gesamtdurchmesser.Gewindebreite);



                    break;




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
                double Tangens = Math.Tan(Flankenwinkel / 2);
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
            Preis[4] = 9.89;   //Aluminiumlegierung ENAW-AlSi1MgMn

            double preisEnd = Preis[y];

            double Werkstoffpreis;


            Werkstoffpreis = (masse / 1000) * preisEnd;

            masse = (gesamtvolumen / 1000) * dichteEnd;
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
        class NurMasse
        {
            public double mass2 { get; set; }
        }

       

        







    }

}

