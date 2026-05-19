using System.Runtime.InteropServices;
using RaumfahrtMission;

class Program
{
    static void Main(string[] args)
    {
        // Aufgabe 1: Himmelskörper erstellen
        // Himmelskörper erstellen
        Stern sonne = new Stern("Sonne", 10001, 'G', -26.74f);
        Planet erde = new Planet("Erde", 20001, 1.0f, 10001); // Referenz auf Sonne (KatalogNummer 10001)
        Mond mond = new Mond("Mond", 30001, 0.0748f, 20001); // Referenz auf Erde (KatalogNummer 20001)
        
        // Halley’scher Komet (1P/Halley)
        // TODO explain mit ToString() in class; then use Komet class with primary constructor
        var halley = new Komet(
            name: "Halley’scher Komet",
            katnr: 40001,
            umlauf: 76.0f,  // Umlaufzeit: ~76 Jahre
            katnrref: 10001  // Umkreist die Sonne (KatalogNummer 10001)
        );

        // array
        Himmelskoerper[] celestialBodies = [sonne, erde, mond, halley];

        // list
        var celestialBodiesList = new List<Himmelskoerper> {sonne, erde, mond, halley};
        celestialBodiesList.Add(new Planet("Mars", 20002, umlauf: 1.88f, katnrref: 10001));

        // schleife hier:

        foreach (var body in celestialBodiesList)
        {
            Console.WriteLine(body);
        }

        Console.WriteLine("----------------------------------");

         foreach (var body in celestialBodies)
        {
            Console.WriteLine(body);
        }

        Console.WriteLine("----------------------------------");

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

        // TODO: Bahndaten List erstellen und Loopen!

        var bahnList = new List<Bahndaten> { erdbahn, mondbahn, halleyBahn };
        bahnList.Add(new Bahndaten(
            himmelskoerper: new Planet("Mars", 20002, umlauf: 1.88f, katnrref: 10001),
            umlaufzeit: 1.88,
            großeHalbachse: 1.5237,
            exzentrizität: 0.0934
        ));

        foreach (var bahn in bahnList)
        {
            Console.WriteLine(bahn);
        }

        Console.WriteLine("----------------------------------");

        // Aufgabe 3: Speichervisualisierung
        SpeicherVisualisierer.VisualisiereSpeicher(sonne, erde, erdbahn);
        // Optional:
        SpeicherVisualisierer.ZeigeSpeicherInhaltUnsafe(erdbahn.Umlaufzeit);//*/

        // Aufgabe 4: Ausgabe der Bahndaten
        var vis = new BahnVisualisierer();
        // Bahn visualisieren
        vis.ZeichneBahnAscii(erdbahn);
        vis.ZeichneBahnAscii(mondbahn);
        // Bahn visualisieren (stark elliptisch!)
        vis.ZeichneBahnAscii(halleyBahn, breite: 60, hoehe: 30);//*/

    }
}