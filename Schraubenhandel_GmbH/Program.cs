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
                case 2: //Schraubenerstellung/ Berechnung

                    
                    
                    {
                        Console.WriteLine("(1) Schraubeneinkauf: Hier können Sie Ihre eigene Schraube entwerfen und anschließend bei unserem Webshop Partner direkt bestellen\n(2) Schraubenberechnung: Hier berechnen wir für Sie alle wichtigen Daten für Schrauben mit Ihren Angaben\n\n0 für Hauptmenü\n");


                        int ersteAuswahl = Convert.ToInt32(Console.ReadLine());
                        if (ersteAuswahl == 0)
                        {
                            goto Hauptmenü;
                        }


                        if (ersteAuswahl == 2)
                        {
                            Console.WriteLine("Was möchten Sie berechnen?\n(1) Masse\n(2) Preis\n(3) maximale Zugkraft");
                            int zweiteAuswahl = Convert.ToInt32(Console.ReadLine());


                            if (zweiteAuswahl != 3)
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

                                Console.WriteLine("Infos zum Gewinde");

                                double volumenSchaft = Schaft();  //Methodenaufruf Methode "Schaft" zur Volumenberechnung des Schafts


                                double gesamtvolumen = volumenSchaft + Kopf.Volumenx;

                                List<double> dichte = new List<double>();   //Dichten in g/cm^3                                //Preise und Dichten nun doch lieber als Listen, da Benutzerfreundlicher beim Hinzufügen
                                dichte.Add(7.85);      //Stahl
                                dichte.Add(7.8);       //Edelstahl
                                dichte.Add(8.4);      //Messing
                                dichte.Add(2.7);      //Aluminium


                                Console.WriteLine("Bitte Werkstoff angeben:\n(1) Stahl\n(2) Edelstahl\n(3) Messing\n(4) Aluminium");
                                int xi;

                                xi = Convert.ToInt32(Console.ReadLine());
                                int y = xi - 1;

                                double dichteEnd = dichte[y];

                                double masse;
                                masse = (gesamtvolumen / 1000) * dichteEnd;


                                List<double> Preis = new List<double>();  //Preise in $/kg
                                Preis.Add(1.50);      //Stahl
                                Preis.Add(8.21);       //Edelstahl
                                Preis.Add(3.50);      //Messing
                                Preis.Add(2.00);      //Aluminium


                                double preisEnd = Preis[y];

                                double Werkstoffpreis;
                                Werkstoffpreis = (masse / 1000) * preisEnd;

                                if (zweiteAuswahl == 1)
                                {
                                    Console.WriteLine("Die Gesamtmasse der Schraube mit den eingegebenen Daten ist " + (masse) + " g.");
                                }
                                if (zweiteAuswahl == 2)
                                {
                                    Console.WriteLine("Der Preis der Schraube beträgt" + Werkstoffpreis + " $");
                                }
                            }
                            if(zweiteAuswahl == 3)
                            {
                                Console.WriteLine("Bitte wählen Sie die Festigkeitsklasse");
                                Console.WriteLine("(1) 4,6\n(2) 5,6\n(3) 5,8\n(4) 6,8\n(5) 8,8\n(6) 10,9\n(7) 12,9\nUnd einen Durchmesser in mm");
                                int f = Convert.ToInt32(Console.ReadLine());
                                double durchmes = Convert.ToDouble(Console.ReadLine());
                                int g = f - 1;
                                double Streckgrenzen = festigkeitsklasse[g, 2];
                                Console.WriteLine("Bitte Sicherheitsfaktor wählen");
                                double SicherheitNü = Convert.ToDouble(Console.ReadLine());
                                double Fzul; double sigmaZul; double querschnittS;
                                querschnittS = (Math.PI / 4) * ((durchmes / 2) * (durchmes / 2));
                                sigmaZul = Streckgrenzen / SicherheitNü;
                                Fzul = sigmaZul * querschnittS;

                                Console.WriteLine(Fzul);
                            }
                        }

                       
                        
                        //Schraubenerstellung

                        if (ersteAuswahl == 1)                                                                                          //Schraubenkopf
                        {
                            Nachfrage Nachfrag = new Nachfrage();
                            do
                            {
                                Console.WriteLine("Für Ihre individuelle Schraubenanpassung sind einige Eingabedaten erforderlich.\nBitte geben Sie die geforderten Daten in mm an.\nInfos zum SchraubenKopf\n(1)Vierkant\n(2) Sechskant\n(3) Innensechskannt\n\n0 für Hauptmenü\n");


                                int eingabe2 = Convert.ToInt32(Console.ReadLine());
                                if (eingabe2 == 0)
                                {
                                    goto Hauptmenü;
                                }

                                if (eingabe2 == 1)
                                {

                                    double KopfErstellung1 = Methode1(ersteAuswahl);

                                }
                                if (eingabe2 == 2)
                                {

                                    double KopfErstellung2 = Methode2(ersteAuswahl);

                                }
                                if (eingabe2 == 3)
                                {

                                    double KopfErstellung = Methode2(ersteAuswahl);

                                }
                                Console.WriteLine("Nun zum Schaft");
                                double schaft2 = Schaft();

                                Console.WriteLine("Sind alle Eingaben korrekt ?\n(9) für Wiederholung");
                                Nachfrag.richtig = Convert.ToInt32(Console.ReadLine());
                            }
                            while (Nachfrag.richtig == 9);

                            Console.WriteLine("Vielen Dank");
                            //Schraubenschaft/Gewinde
                        }

                        Console.ReadKey();
                    }
                    break;

                case 1:                 //Normteile

                    
                        Console.WriteLine("Normteile: Schrauben werden eingeteilt nach ihrer Festigkeit: Bitte whählen Sie eine Festigkeitsklasse.");
                        Console.WriteLine("(1) 4,6\n(2) 5,6\n(3) 5,8\n(4) 6,8\n(5) 8,8\n(6) 10,9\n(7) 12,9");
                    
                        int u = Convert.ToInt32(Console.ReadLine());
                        int r = u - 1;
                        double festigkeitsklasseEnd = festigkeitsklasse[r, 0];
                        double Zugfestigkeits = festigkeitsklasse[r, 1];
                        double Streckgrenze = festigkeitsklasse[r, 2];

                    Console.WriteLine("Bitte geben Sie den Gewindedurchmesser in mm ein");
                    double gewindedurchmesser = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Bitte wählen Sie eine Anzahl aus");
                    int anzahl = Convert.ToInt32(Console.ReadLine());
    

                    Console.WriteLine("Sie haben sich für" + anzahl + "Schrauben der Festigkeitsklasse " + festigkeitsklasse[r,0] +" entschieden:");
                    Console.WriteLine("Technische Daten:\nZugfestigkeit: " + Zugfestigkeits + "\nStreckgrenze: " + Streckgrenze + "\nGewinde: M" + gewindedurchmesser);
                    

                    
                    break;


                
                    
            }
            Console.ReadKey();
        }

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
            public string ErstellungV { get; set; }

            public double Volumen()
            {
                VolumenVierkant = breite * breite * Höhe;
                return VolumenVierkant;
            }
            public string VierkanntErstellung()
            {
                Console.WriteLine("Hier könnte ein Programm stehen");
                return ErstellungV;
            }

        }

        class Sechskant : Schraubenkopf //Vererbung 2: Sechskanntkopf KLASSE
        {
            public double Schlüsselweite { get; set; }
            public double VolumenSechskant { get; set; }

            private double Wurzel3 = Math.Sqrt(3);
            public int ProgrammSechs { get; set; }
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
                ProgrammSechs = 67893;
                return ProgrammSechs;


            }

        }
        class Innensechskannt : Schraubenkopf //Vererbung 3: Innensechskantschraube KLASSE
        {
            public double kreisDurchmesser { get; set; }
            public double innenHöhe { get; set; }
            public double VolumenInnensechskant { get; set; }
            public int ProgrammInnen { get; set; }
            public double Schlüsselweiten { get; set; }

            private double Wurzeln3 = Math.Sqrt(3);
            private double FlächeninhaltInnensechseck;

            public double Volumen3()
            {
                double HalbeDreiecke = Schlüsselweiten / Wurzeln3;
                FlächeninhaltInnensechseck = Wurzeln3 * ((3 * (HalbeDreiecke * HalbeDreiecke)) / 2);
                double innenVolumen = FlächeninhaltInnensechseck * innenHöhe;

                double kreisRadius = kreisDurchmesser / 2;
                double kreisVolumen = Math.PI * (kreisRadius * kreisRadius);
                
                VolumenInnensechskant = kreisVolumen - innenVolumen;

                return VolumenInnensechskant;
            }
            public int ProgrammInnensechskannt()
            {
                ProgrammInnen = 784392; //Platzhalter
                return ProgrammInnen;
            }
        }

        //METHODEN
        static double Schaft()  //METHODE: Berechnung des Volumens des Schraubenschafts
        {
            double schaftLänge;
            double durchmesser;

            Console.WriteLine("Länge angeben");
            schaftLänge = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Durchmesser angeben");
            durchmesser = Convert.ToDouble(Console.ReadLine());
            double radius = durchmesser / 2;

            double ergebnisSchaft = schaftLänge * (radius * radius) * Math.PI;

            return ergebnisSchaft;

        }
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
            else if (entscheidung == 1)
            {
                VierkantSchraube.VierkanntErstellung();
                return Convert.ToDouble(VierkantSchraube.ErstellungV);
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
                SechskantSchraube.ProgrammSechskannt();
                return Convert.ToDouble(SechskantSchraube.ProgrammSechs);
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
                Innensechskantschraube.ProgrammInnensechskannt();
                return Convert.ToDouble(Innensechskantschraube.ProgrammInnen);
            }
            else
                return 0;
            
        }
    }
}

        
    

