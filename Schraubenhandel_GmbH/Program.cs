using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schraubenhandel_GmbH
{
    class Program
    {
<<<<<<< Updated upstream
        static void Main(string[] args)//jujiklj
=======

        static void Main(string[] args)

>>>>>>> Stashed changes
        {
            //HAUPTPROGRAMM
            {
                Console.WriteLine("Sehr geehrter Kunde\nVielen Dank, dass Sie sich für uns entschieden haben\nWir bieten Ihnen folgendes an:\n(1) Schraubeneinkauf: Hier können Sie Ihre eigene Schraube entwerfen und anschließend bei unserem Webshop Partner direkt bestellen\n(2) Schraubenberechnung: Hier berechnen wir für Sie alle wichtigen Daten für Schrauben mit Ihren Angaben");



                int ersteAuswahl = Convert.ToInt32(Console.ReadLine());


                if (ersteAuswahl == 2)
                {
                    Console.WriteLine("Was möchten Sie berechnen?\n(1) Masse\n(2) Preis");
                    int zweiteAuswahl = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nBitte geben Sie die geforderten Daten in mm an.\nInfos zum SchraubenKopf\n(1) Vierkant\n(2) Sechskant\n(3) Innensechskannt");

                    int eingabe = Convert.ToInt32(Console.ReadLine());
                    Volumen1 Kopf = new Volumen1();

                    if (eingabe == 1)
                    {

                        Kopf.Volumenx = Methode1(ersteAuswahl);


                    }
                    if (eingabe == 2)
                    {

                        Sechskant SechskantSchraube = new Sechskant();
                        Console.WriteLine("Bitte Seitenlänge des Kopfes angeben");
                        double z = Convert.ToDouble(Console.ReadLine());
                        SechskantSchraube.Seite = z;
                        Console.WriteLine("Bitte Höhe des Kopfes angeben");
                        double yi = Convert.ToDouble(Console.ReadLine());
                        SechskantSchraube.Höhe = yi;

                        SechskantSchraube.Volumen2();
                        Kopf.Volumenx = SechskantSchraube.VolumenSechskant;

                    }
                    if (eingabe == 3)
                    {
                        Innensechskannt Innensechskantschraube = new Innensechskannt();
                        Console.WriteLine("Bitte Aussendurchmesser des Kopfes angeben");
                        double auss = Convert.ToDouble(Console.ReadLine());
                        Innensechskantschraube.kreisDurchmesser = auss;
                        Console.WriteLine("Bitte Höhe des Kopfes angeben");
                        double höh = Convert.ToDouble(Console.ReadLine());
                        Innensechskantschraube.Höhe = höh;
                        Console.WriteLine("Bitte Innenseite des Kopfes angeben");
                        double inns = Convert.ToDouble(Console.ReadLine());
                        Innensechskantschraube.innenSeite = inns;
                        Console.WriteLine("Bitte Höhe des Innensechskannts des Kopfes angeben");
                        double innh = Convert.ToDouble(Console.ReadLine());
                        Innensechskantschraube.Höhe = innh;

                        Innensechskantschraube.Volumen3();
                        Kopf.Volumenx = Innensechskantschraube.VolumenInnensechskant;

                    }
                    Console.WriteLine("Infos zum Gewinde");

                    double volumenSchaft = Schaft();


                    double gesamtvolumen = volumenSchaft + Kopf.Volumenx;

                    double[] dichte = new double[8];  //Dichten in g/cm^3
                    dichte[0] = 7.85;     //Stahl
                    dichte[1] = 7.8;    //Edelstahl
                    dichte[2] = 8.4;     //Messing
                    dichte[3] = 2.7;     //Aluminiuim

                    Console.WriteLine("Bitte Werkstoff angeben:\n(1) Stahl\n(2) Edelstahl\n(3) Messing\n(4) Aluminium");
                    int xi;

                    xi = Convert.ToInt32(Console.ReadLine());
                    int y = xi - 1;

                    double dichteEnd = dichte[y];

                    double masse;
                    masse = (gesamtvolumen / 1000) * dichteEnd;

                    double[] Preis = new double[8];  //Preise in $/kg
                    Preis[0] = 1.50;   //Stahl
                    Preis[1] = 8.21;    //Edelstahl 
                    Preis[2] = 3.50;   //Messing
                    Preis[4] = 2.00;   //Aluminium

                    double preisEnd = Preis[y];

                    double Schraubenpreis;
                    Schraubenpreis = (masse / 1000) * preisEnd;

                    if (zweiteAuswahl == 1)
                    {
                        Console.WriteLine("Die Gesamtmasse der Schraube mit den eingegebenen Daten ist " + (masse) + " g.");
                    }
                    if (zweiteAuswahl == 2)
                    {
                        Console.WriteLine("Der Preis der Schraube beträgt" + Schraubenpreis + " $");
                    }

                }






                //Schraubenerstellung

                if (ersteAuswahl == 1)                                                                                          //Schraubenkopf
                {
                    Console.WriteLine("Für Ihre individuelle Schraubenanpassung sind einige Eingabedaten erforderlich.\nBitte geben Sie die geforderten Daten in mm an.\nInfos zum SchraubenKopf\n(1)Vierkant\n(2) Sechskant\n(3) Innensechskannt");


                    int eingabe2 = Convert.ToInt32(Console.ReadLine());

                    if (eingabe2 == 1)
                    {
                        double KopfErstellung1 = Methode1(ersteAuswahl);
                    }
                    if (eingabe2 == 2)
                    {
                        Sechskant SechskantSchraube = new Sechskant();
                        Console.WriteLine("Bitte Seitenlänge des Kopfes angeben");
                        double z = Convert.ToDouble(Console.ReadLine());
                        SechskantSchraube.Seite = z;
                        Console.WriteLine("Bitte Höhe des Kopfes angeben");
                        double yi = Convert.ToDouble(Console.ReadLine());
                        SechskantSchraube.Höhe = yi;

                        string KopfErstellung2 = SechskantSchraube.ProgrammSechskannt();
                        Console.WriteLine(KopfErstellung2);
                    }
                    if (eingabe2 == 3)
                    {
                        Innensechskannt Innensechskantschraube = new Innensechskannt();
                        Console.WriteLine("Bitte Aussendurchmesser des Kopfes angeben");
                        double auss = Convert.ToDouble(Console.ReadLine());
                        Innensechskantschraube.kreisDurchmesser = auss;
                        Console.WriteLine("Bitte Höhe des Kopfes angeben");
                        double höh = Convert.ToDouble(Console.ReadLine());
                        Innensechskantschraube.Höhe = höh;
                        Console.WriteLine("Bitte Innenseite des Kopfes angeben");
                        double inns = Convert.ToDouble(Console.ReadLine());
                        Innensechskantschraube.innenSeite = inns;
                        Console.WriteLine("Bitte Höhe des Innensechskannts des Kopfes angeben");
                        double innh = Convert.ToDouble(Console.ReadLine());
                        Innensechskantschraube.Höhe = innh;

                        string KopfErstellung3 = Innensechskantschraube.ProgrammInnensechskannt();
                        Console.WriteLine(KopfErstellung3);
                    }
                    Console.WriteLine("Nun zum Schaft");
                    double schaft2 = Schaft();

                    //Schraubenschaft/Gewinde
                }

                Console.ReadKey();
            }
        }

        //KLASSEN UND METHODEN 

        //KLASSEN

        class Schraubenkopf //Klasse Schraubenkopf
        {
            public double Höhe { get; set; }
            public string Art { get; set; }
        }

        class Vierkant : Schraubenkopf //Vererbung 1: Vierkanntkopf
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

        class Sechskant : Schraubenkopf //Vererbung 2: Sechskanntkopf
        {
            public double Seite { get; set; }
            public double VolumenSechskant { get; set; }

            private double i = Math.Sqrt(3);
            public string ProgrammSechs { get; set; }

            public double Volumen2()
            {
                VolumenSechskant = (0.67 * (Seite * Seite) * i) * Höhe;
                return VolumenSechskant;
            }
            public string ProgrammSechskannt()
            {
                ProgrammSechs = "Hier könnte ein Programm stehen";
                return ProgrammSechs;
            }

        }
        class Innensechskannt : Schraubenkopf //Vererbung 3: Innensechskantschraube
        {
            public double kreisDurchmesser { get; set; }
            public double innenSeite { get; set; }
            public double innenHöhe { get; set; }
            public double VolumenInnensechskant { get; set; }
            public string ProgrammInnen { get; set; }


            public double Volumen3()
            {
                double kreisRadius = kreisDurchmesser / 2;
                double kreisVolumen = Math.PI * (kreisRadius * kreisRadius);
                double innenVolumen = 0.67 * (innenSeite * innenSeite) * Math.Sqrt(3);
                VolumenInnensechskant = kreisVolumen - innenVolumen;

                return VolumenInnensechskant;
            }
            public string ProgrammInnensechskannt()
            {
                ProgrammInnen = "Hier könnte ein Programm stehen";
                return ProgrammInnen;
            }
        }

        //METHODEN
        static double Schaft() //Methode: Schruabenschaft/Gewinde
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
        class Volumen1
        {
            public double Volumenx { get; set; }
        }
        static double Methode1(int entscheidung)
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
    }
}

        
    

