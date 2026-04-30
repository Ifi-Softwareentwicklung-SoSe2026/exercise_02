<!--

author:   Volker Göhler
email:    volker.goehler@informatik.tu-freiberg.de
version:  0.0.1
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

*04. Mai - 10. Mai 2026*

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

### **Aufgabe 1: Vererbung – Spezialisierung von `Himmelskoerper`**

**Zeitaufwand: 60 Minuten**

**Beschreibungstext:**
Die Klasse `Himmelskoerper` soll durch Vererbung spezialisiert werden. Erstelle abgeleitete Klassen für die verschiedenen Typen von Himmelskörpern (`Stern`, `Planet`, `Mond`), um typspezifische Eigenschaften und Methoden zu kapseln.

**Aufgabenbeschreibung:**

1. Erstelle eine abstrakte Basisklasse `Himmelskoerper` mit gemeinsamen Eigenschaften und einer abstrakten Methode `GibtDatenAus()`.
2. Leite die Klassen `Stern`, `Planet` und `Mond` von `Himmelskoerper` ab.
3. Implementiere die `GibtDatenAus()`-Methode in jeder abgeleiteten Klasse, sodass typspezifische Daten ausgegeben werden.
4. Passe die `HimmelskoerperFactory` an, sodass sie je nach Typ die richtige abgeleitete Klasse erstellt.

```csharp
abstract class Himmelskoerper
{
    public string Name { get; set; }
    public int KatalogNummer { get; set; }
    public abstract void GibtDatenAus();
}

class Stern : Himmelskoerper
{
    public char? Spektralklasse { get; set; }
    public float? ScheinbareHelligkeit { get; set; }
    public override void GibtDatenAus()
    {
        Console.WriteLine($"Stern: {Name}, Katalog-Nummer: {KatalogNummer}, Spektralklasse: {Spektralklasse}, Helligkeit: {ScheinbareHelligkeit}");
    }
}
```

### **Aufgabe 2: Interfaces – `IVergleichbar` und `IAusgabe`**

**Zeitaufwand: 45 Minuten**

**Beschreibungstext:**
Interfaces ermöglichen eine flexible Strukturierung von Code. Implementiere zwei Interfaces für die `Himmelskoerper`-Hierarchie.

**Aufgabenbeschreibung:**

1. Erstelle ein Interface `IAusgabe` mit einer Methode `GibtDatenAus()`.
2. Erstelle ein Interface `IVergleichbar` mit einer Methode `VergleicheMit(Himmelskoerper anderer)`, die einen `int`-Wert zurückgibt (analog zu `IComparable`).
3. Implementiere beide Interfaces in der `Himmelskoerper`-Klasse bzw. den abgeleiteten Klassen.
4. Nutze `IVergleichbar`, um Himmelskörper nach Katalog-Nummer zu sortieren.

```csharp
interface IAusgabe
{
    void GibtDatenAus();
}

interface IVergleichbar
{
    int VergleicheMit(Himmelskoerper anderer);
}
```

### **Aufgabe 3: Collections – `List<T>` und `Dictionary<TKey, TValue>`**

**Zeitaufwand: 60 Minuten**

**Beschreibungstext:**
Statt einzelner Objekte sollen nun mehrere Himmelskörper in Collections verwaltet werden.

**Aufgabenbeschreibung:**

1. Erstelle eine `List<Himmelskoerper>`, um mehrere Himmelskörper zu speichern.
2. Füge mindestens drei Himmelskörper unterschiedlichen Typs hinzu.
3. Iteriere über die Liste und rufe `GibtDatenAus()` für jeden Himmelskörper auf.
4. Erstelle ein `Dictionary<int, Himmelskoerper>`, das die Katalog-Nummer als Schlüssel verwendet.
5. Implementiere eine Methode `SucheNachKatalogNummer(int nummer)`, die den entsprechenden Himmelskörper zurückgibt.

```csharp
List<Himmelskoerper> himmelskörper = new List<Himmelskoerper>();
himmelskörper.Add(new Stern { Name = "Sonne", KatalogNummer = 10001, Spektralklasse = 'G' });

Dictionary<int, Himmelskoerper> katalog = new Dictionary<int, Himmelskoerper>();
foreach (var hk in himmelskörper)
{
    katalog[hk.KatalogNummer] = hk;
}
```

### **Aufgabe 4: LINQ – Abfragen auf Collections**

**Zeitaufwand: 45 Minuten**

**Beschreibungstext:**
LINQ (Language Integrated Query) ermöglicht elegante Abfragen auf Collections.

**Aufgabenbeschreibung:**

1. Nutze LINQ, um alle Sterne aus der `List<Himmelskoerper>` zu filtern.
2. Sortiere die gefilterten Sterne nach ihrer scheinbaren Helligkeit.
3. Gib die Namen der sortierten Sterne aus.
4. Berechne die durchschnittliche Umlaufzeit aller Planeten und Monde.

```csharp
using System.Linq;

var sterne = himmelskörper
    .OfType<Stern>()
    .OrderBy(s => s.ScheinbareHelligkeit)
    .ToList();

foreach (var stern in sterne)
{
    Console.WriteLine(stern.Name);
}
```

### **Aufgabe 5: Datei-I/O – Speichern und Laden**

**Zeitaufwand: 60 Minuten**

**Beschreibungstext:**
Die gesammelten Daten sollen persistiert werden können. Implementiere Funktionalität zum Speichern und Laden von Himmelskörper-Daten in/aus einer Datei.

**Aufgabenbeschreibung:**

1. Implementiere eine Methode `SpeichereDaten(List<Himmelskoerper> liste, string dateiname)`, die die Daten im CSV-Format in eine Datei schreibt.
2. Implementiere eine Methode `LadeDaten(string dateiname)`, die die CSV-Datei einliest und eine `List<Himmelskoerper>` zurückgibt.
3. Nutze `StreamWriter` und `StreamReader` für die Datei-I/O.
4. Behandle mögliche Ausnahmen (z. B. Datei nicht gefunden).

```csharp
using System.IO;

void SpeichereDaten(List<Himmelskoerper> liste, string dateiname)
{
    using (StreamWriter writer = new StreamWriter(dateiname))
    {
        foreach (var hk in liste)
        {
            writer.WriteLine($"{hk.Name},{hk.KatalogNummer},{hk.GetType().Name}");
        }
    }
}
```
