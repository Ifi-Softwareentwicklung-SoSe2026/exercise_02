<!--

author:   Volker Göhler
email:    volker.goehler@informatik.tu-freiberg.de
version:  0.0.2
language: de
narrator: Deutsch Female

edit: true
date: 2026-04-30

icon: img/TUBAF_Logo_blau.svg
comment:  Übung Softwareentwicklung 02

link:   https://raw.githubusercontent.com/vgoehler/LiaScript_CSS_Provider/refs/heads/main/dist/university.css

tags: [ Sommersemester2026, Softwareentwicklung, Übung02]

-->

[![LiaScript Course](https://raw.githubusercontent.com/LiaScript/LiaScript/master/badges/course.svg)](https://liascript.github.io/course/?https://raw.githubusercontent.com/Ifi-Softwareentwicklung-SoSe2026/exercise_02/refs/heads/main/README.md)

#  Aufgabe 02

Softwareentwicklung SoSe2026
============================

Bearbeitungszeitraum
====================

*04. Mai - 16. Mai 2026*

## Offene Fragen aus Aufgabe 01

Die folgenden Aufgaben aus der letzten Einheit (Aufgabe 01) sollten bearbeitet worden sein:

Aufgabe 1: Refactoring der `LeseDatenEin`-Methode (Arrays)
--------------------

- Wurde die `LeseDatenEin`-Methode so angepasst, dass sie ein `string[]`-Array als Parameter akzeptiert?
- Wurden die beiden `if`-Zweige durch eine gemeinsame Logik ersetzt?
- Wird die angepasste Methode sowohl für Kommandozeilenargumente als auch für die interaktive Eingabe verwendet?

Aufgabe 2: Erweiterung der Datenklasse um passive Eigenschaften
--------------------

- Wurde `UmlaufzeitInTagen` als schreibgeschützte Eigenschaft implementiert?
- Wurde `VollstaendigerTyp` als formatierte Zeichenkette implementiert?
- Werden die neuen Eigenschaften in der `GibtDatenAus`-Methode ausgegeben?

Aufgabe 3: Verwendung von `StringBuilder` und Überschreiben von `ToString()`
--------------------

- Wurde die `ToString()`-Methode in der `Himmelskoerper`-Klasse überschrieben?
- Wird `StringBuilder` verwendet, um den Ausgabestring aufzubauen?
- Ruft die `Ausgabe`-Methode nun `Console.WriteLine(koerper.ToString())` auf?

Aufgabe 4: Factory-Klasse zur Erstellung von `Himmelskoerper`-Objekten
--------------------

- Wurde eine statische Klasse `HimmelskoerperFactory` mit einer Methode `ErstelleHimmelskoerper` erstellt?
- Werden die Daten validiert und ein `Himmelskoerper`-Objekt zurückgegeben?
- Wird die direkte Objekterstellung in der `Main`-Methode durch den Aufruf der Factory-Methode ersetzt?

Aufgabe 5: Himmelskörper-Gleichheit anhand der Namen
--------------------

- Wurden die `==` und `!=`-Operatoren in der `Himmelskoerper`-Klasse überschrieben?
- Wurden `Equals` und `GetHashCode` entsprechend implementiert?

## Neue Aufgaben für diese Woche

Wir nutzen die nächsten Wochen, um die Grundlagen der objektorientierten Programmierung weiter zu vertiefen. Die folgenden Aufgaben bauen auf den bisherigen Kenntnissen auf und führen neue Konzepte ein.
Wir bauen teilweise auf Programmierergebnisse aus den vorherigen Aufgaben auf. Dazu gibt es im GitHub-Repository [Exercise_01](https://github.com/Ifi-Softwareentwicklung-SoSe2026/exercise_01) einen Unterordner solutions, falls Sie nicht so weit gekommen sein sollten.

### **📌 Vorbereitung: Projekt erstellen**

1. **Neues Projekt anlegen:**

   - Öffne **Visual Studio Code**.
   - Erstelle ein neues **C#-Konsolenprojekt** mit:
     ```bash
     dotnet new console -n RaumfahrtMission
     cd RaumfahrtMission
     code .
     ```
   - Füge die Datei `Himmelskoerper.cs` mit der `Himmelskörper` Klasse aus der vorherigen Übung hinzu.

2. **Namespace definieren:**

   - Alle Klassen sollen im Namespace **`RaumfahrtMission`** liegen.
   - Warum ist die Verwendung von Namespaces wichtig?
   - Die Main-Methode soll in der Datei `Program.cs` liegen und den Namespace `RaumfahrtMission` verwenden (`using`).

### **🌌 Aufgabe 1: Klassenhierarchie für Himmelskörper**

*Lernziele: Abstrakte Klassen, Vererbung, Constructor-Chaining, Properties*

---

#### **📝 Aufgabenstellung**

Erstelle eine **abstrakte Basisklasse `Himmelskoerper`** und leite davon die konkreten Klassen **`Stern`**, **`Planet`** und **`Mond`** ab.

- **Nur die abgeleiteten Klassen** (`Stern`, `Planet`, `Mond`) sollen instanziierbar sein.
- Jede Klasse soll einen **Constructor** haben, der alle Eigenschaften initialisiert.
- Nutze **Properties** mit `get;` und `set;` (oder `init;` für Immutability, falls gewünscht).

##### **🔧 Hilfestellungen**

```ascii
        +-----------------+
        | Himmelskoerper  |
        | (abstrakt)      |
        +-----------------+
               ^
               |
        +---------------+
        |               |
+-------------+ +-------------+
|    Stern    | |    Planet   |
+-------------+ +-------------+
                     ^
                     |
              +-------------+
              |     Mond    |
              +-------------+
```

**1. Abstrakte Basisklasse `Himmelskoerper`**
====================

- **Eigenschaften (Properties):**
  - `Name` (string)
  - `KatalogNummer` (uint)
- **Methoden:**
  - Überschreibe `ToString()` für eine formatierte Ausgabe.
  - Überschreibe `GetHashCode()` und `Equals()` (Vergleich über `Name`).
- **Constructor:**
  - Nimm `Name` und `KatalogNummer` als Parameter entgegen.


2. Klasse Stern (abgeleitet von Himmelskoerper)
====================

- Zusätzliche Eigenschaften:

   - Spektralklasse (char, z. B. 'G', 'M')
   - ScheinbareHelligkeit (float, z. B. -26.74 für die Sonne)

- Constructor:

   - Rufe den Base-Constructor mit base(name, katalogNummer) auf.
   - Initialisiere die zusätzlichen Eigenschaften.


3. Klasse Planet (abgeleitet von Himmelskoerper)
====================

- Zusätzliche Eigenschaften:

   - Umlaufzeit (float, in Erdjahren)
   - KatalogNummerReferenz (uint, Katalognummer des Zentralsterns)

- Constructor:

   - Rufe den Base-Constructor auf.


4. Klasse Mond (abgeleitet von Planet)
====================

- Zusätzliche Eigenschaften:

    - keine

- Constructor:

   - Ähnlich wie Planet, aber für Monde.


#### ✅ Testaufgabe

Erstelle in `Program.cs` folgende Objekte und gib sie aus:
```csharp

Stern sonne = new Stern("Sonne", 10001, 'G', -26.74f);
Planet erde = new Planet("Erde", 20001, 1.0f, 10001);
Mond mond = new Mond("Mond", 30001, 0.0748f, 20001);

Console.WriteLine(sonne);
Console.WriteLine(erde);
Console.WriteLine(mond);
```

#### 💡 Tipps

- Abstrakte Klasse: Kann nicht direkt instanziiert werden (new Himmelskoerper() ist unmöglich).
- `base()`: Ruft den Constructor der Basisklasse auf.
- `override`: Überschreibt Methoden der Basisklasse (z. B. `ToString()`).


### 📊 Aufgabe 2: Bahndaten (Immutable DataBean)

Lernziele: Immutable Klassen, Properties mit init;, GetHashCode()

#### 📝 Aufgabenstellung

Erstelle eine immutable Klasse Bahndaten mit:

- Eigenschaften (nur `get;`):

   - Himmelskoerper (Himmelskoerper-Objekt)
   - Umlaufzeit (double, in Erdjahren)
   - GroßeHalbachse (double, in AE)
   - Exzentrizität (double, 0 = Kreisbahn, 0 < e < 1 = Ellipse)

- Constructor: Initialisiere alle Eigenschaften.
- ToString(): Formatierte Ausgabe.
- GetHashCode(): Berechne einen Hash aus allen Eigenschaften.

#### 🔧 Hilfestellungen

1. Immutable Klasse mit init;
=====================

- Nutze `init;` statt `set;`, um die Klasse nach der Initialisierung unveränderlich zu machen.


2. `ToString()` und `GetHashCode()`
=====================

- `ToString()`: Verwende String Interpolation oder `StringBuilder` für die Ausgabe.
- `GetHashCode()`: Kombiniere die HashCodes aller Eigenschaften (z. B. mit XOR oder `HashCode.Combine`).

#### ✅ Testaufgabe

```csharp
Erstelle in Program.cs:

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


Console.WriteLine(erdbahn);
Console.WriteLine(mondbahn);
```



#### 💡 Tipps

- Immutability: Objekte können nach der Erstellung nicht mehr verändert werden.
- `init;`: Erlaubt die Initialisierung nur im Constructor oder bei der Objekterstellung.


### 💾 Aufgabe 3: Speichervisualisierung

Lernziele: params, GetHashCode(), optionaler unsafe-Code

#### 📝 Aufgabenstellung

Erstelle eine statische Klasse SpeicherVisualisierer mit:

- Methode VisualisiereSpeicher:

   - Nimm params object[] objekte entgegen.
   - Gib für jedes Objekt Typ, Wert und HashCode aus.

-  Methode ZeigeSpeicherInhaltUnsafe (Für Fortgeschrittene):

   - Nutze unsafe-Code, um den Speicherinhalt als Hex-Dump auszugeben.


#### 🔧 Hilfestellungen

1. Logische Speicherdarstellung
====================

- Verwende `GetType().Name` für den Typ und `GetHashCode()` für den HashCode.
- Nutze `params` für eine flexible Anzahl von Objekten.

   - parameter: `params object[] objekte` ermöglicht es, mehrere Objekte als Argumente zu übergeben, ohne ein Array explizit erstellen zu müssen.


2. (Optional) Hex-Dump mit unsafe
====================

- Projektoptionen: Aktiviere unsafe-Code in der .csproj-Datei:
```xml

<PropertyGroup>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
</PropertyGroup>
```


- Methode:

   - Berechne die Größe des Objekts mit `Marshal.SizeOf()`.
   - Kopiere die Daten in ein Byte-Array und gebe sie als Hex-Dump aus.
   - Achtung: Funktioniert nur für Werttypen oder blittable types (z. B. primitive Datentypen, Strukturen ohne Referenztypen).


#### ✅ Testaufgabe
```csharp

SpeicherVisualisierer.VisualisiereSpeicher(sonne, erde, erdbahn);
// Optional:
// SpeicherVisualisierer.ZeigeSpeicherInhaltUnsafe(erdbahn);
```

#### 💡 Tipps

- `params`: Erlaubt eine variable Anzahl an Parametern.
- `Marshal.SizeOf`: Gibt die Größe eines Objekts im Speicher zurück (funktioniert nur für Werttypen oder blittable types).
- `unsafe`: Erfordert explizite Aktivierung und ist plattformabhängig.

---- FIXME


### 🎨 Aufgabe 4: Bahnvisualisierung (ASCII)

Lernziele: Algorithmen, Konsolenausgabe, Ellipsengleichung

#### 📝 Aufgabenstellung

Erstelle eine statische Klasse BahnVisualisierer mit einer Methode ZeichneBahnAscii, die:

- Die Bahn eines Himmelskörpers als ASCII-Diagramm in der Konsole zeichnet.
- Die Sonne (Brennpunkt) als O und die Bahn als * darstellt.
- Die Exzentrizität der Bahn berücksichtigt.

#### 🔧 Hilfestellungen

1. Ellipsengleichung in Polarkoordinaten
====================

- Die Position eines Punktes auf einer Ellipse in Polarkoordinaten (relativ zu einem Brennpunkt) berechnet sich mit:
- $r = a * (1 - e²) / (1 + e * cos(θ))$
- Dabei gilt:
   - a: Große Halbachse
   - e: Exzentrizität
   - θ: Winkel (0 bis 2π)

2. Skalierung für die Konsole
=====================

- Skaliere die Koordinaten auf die Konsolengröße (z. B. 60x30 Zeichen).
- Berechne die Skalierungsfaktoren für x und y basierend auf der großen Halbachse und der maximalen Höhe der Ellipse.
- Die Sonne (Brennpunkt) befindet sich bei x = -a * e, y = 0 relativ zum Zentrum der Ellipse.
- Zeichne die Bahn, indem du für verschiedene Werte von θ die entsprechenden x- und y-Koordinaten berechnest und in einem 2D-Char-Array speicherst.

#### ✅ Testaufgabe

```csharp

BahnVisualisierer.ZeichneBahnAscii(erdbahn);
BahnVisualisierer.ZeichneBahnAscii(marsbahn);
```



#### 💡 Tipps

- Exzentrizität: Bei e = 0 ist die Bahn kreisförmig.
- Skalierung: Passe skalaX und skalaY an, um die Bahn in die Konsole zu passen.
- Winkel-Schrittweite: theta += 0.05 für eine glatte Bahn.

### 📚 Zusammenfassung der Lerninhalte


  
    
      Thema |       Inhalte
    --- | ----
      Namespaces |       Organisation von Code, Vermeidung von Namenskollisionen.
      Vererbung |       Abstrakte Klassen, `base()`, `override`.
      Immutability |       `init;`, unveränderliche Objekte.
      Speicherdarstellung | `GetHashCode()`, `Equals()`, `unsafe`-Code (optional).
      Algorithmen | Ellipsengleichung, Skalierung, ASCII-Kunst.
    
  


