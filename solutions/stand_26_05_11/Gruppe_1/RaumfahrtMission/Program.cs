using System.Runtime.InteropServices;
using RaumfahrtMission;

class Program
{
    static void Main(string[] args)
    {
        // Aufgabe 1: Himmelskörper erstellen
        // Himmelskörper erstellen
        var sonne = new Stern("Sonne", 10001, 'G', -26.74f);
        Planet erde = new("Erde", 20001, 1.0f, 10001); // Referenz auf Sonne (KatalogNummer 10001)
        var mond = new Mond("Mond", 30001, 0.0748f, 20001); // Referenz auf Erde (KatalogNummer 20001)
        
        // Halley’scher Komet (1P/Halley)
        // TODO explain mit ToString() in class; then use Komet class with primary constructor
        var halley = new Planet(
            name: "Halley’scher Komet",
            katnr: 40001,
            umlauf: 76.0f,  // Umlaufzeit: ~76 Jahre
            katnrref: 10001  // Umkreist die Sonne (KatalogNummer 10001)
        );


        Console.WriteLine(sonne);
        Console.WriteLine(erde);
        Console.WriteLine(mond);
        Console.WriteLine(halley);

        /*
        // Aufgabe 2: Bahndaten erstellen
        // Bahndaten für Erde (um die Sonne)
        Bahndaten erdbahn = new Bahndaten(
            himmelskoerper: erde,
            umlaufzeit: 1.0,
            großeHalbachse: 1.0,
            exzentrizität: 0.0167
        );
        // Bahndaten für Mond (um die Erde)
        Bahndaten mondbahn = new Bahndaten(
            himmelskoerper: mond,
            umlaufzeit: 0.0748,
            großeHalbachse: 0.0026, // ~384.400 km in AE (1 AE ≈ 149,6 Mio. km)
            exzentrizität: 0.0549
        );
        // Bahndaten für Halley’schen Kometen
        Bahndaten halleyBahn = new Bahndaten(
            himmelskoerper: halley,
            umlaufzeit: 76.0,
            großeHalbachse: 17.8,  // 17.8 AE (Durchschnittliche Entfernung zur Sonne)
            exzentrizität: 0.967   // Sehr hohe Exzentrizität!
        );

        // Ausgabe
        Console.WriteLine(erdbahn);
        Console.WriteLine(mondbahn);
        Console.WriteLine(halleyBahn);//*/


        /*                
        // Aufgabe 3: Speichervisualisierung
        SpeicherVisualisierer.VisualisiereSpeicher(sonne, erde, erdbahn);
        // Optional:
        SpeicherVisualisierer.ZeigeSpeicherInhaltUnsafe(erdbahn.Umlaufzeit);//*/

        
        /*
        // Aufgabe 4: Ausgabe der Bahndaten
        var vis = new BahnVisualisierer();
        // Bahn visualisieren
        vis.ZeichneBahnAscii(erdbahn);
        vis.ZeichneBahnAscii(mondbahn);
        // Bahn visualisieren (stark elliptisch!)
        vis.ZeichneBahnAscii(halleyBahn, breite: 60, hoehe: 30);//*/


    }
}