using System.Text;

namespace RaumfahrtMission{

    public abstract class Himmelskoerper
    {
        protected Himmelskoerper(string name, uint katalogNummer)
        {
            this.Name = name;
            this.KatalogNummer = katalogNummer;
        }
        private string _name = String.Empty;
        public string Name
        {
            get => _name;
            set => _name = (value ?? "Unknown").Trim();
            // if (value is null){ _name = value }else{_name = "Unknown"}
        }
        
        // katalognummer
        private uint _katalogNr;
        public uint KatalogNummer
        {
            get => _katalogNr;
            set
            {
                // check
                if (isCatalogueNumberNotValid(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Katalognummer nicht gültig (5 Zeichen).");
                }
                // zuweisung
                _katalogNr = value;
            }
        }
        protected static bool isCatalogueNumberNotValid(uint number)
        {
            return number < 10000 || number > 99999;
        }
        public override string ToString(){
            return $"{this.GetType().Name}: {Name}, KatalogNummer: {KatalogNummer}";
        }
    }

    public class Stern : Himmelskoerper
    {
        public Stern(string name, uint katalogNummer,
         char spektralKlasse , float scheinbareHelligkeit ) 
            : base(name, katalogNummer){
            this.SpektralKlasse = spektralKlasse;
            this.ScheinbareHelligkeit = scheinbareHelligkeit;
        }
        // Spektralklasse
        private char _spectralKlasse;
        public char SpektralKlasse
        {
            get => _spectralKlasse;
            set
            {
                char[] gueltigeSpektralKlassen = ['O', 'B', 'A', 'F', 'G', 'K', 'M'];
                if (!gueltigeSpektralKlassen.Contains(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Spektralklasse muss eine von (O, B, A, F, G, K, M) sein");
                }
                _spectralKlasse = value;
            }
        }
        // ScheinbareHelligkeit
        private double? _scheinbareHelligkeit;
        public double? ScheinbareHelligkeit { 
            get => _scheinbareHelligkeit;
            set{
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Scheinbare Helligkeit darf nicht kleiner als 0 sein.");
                }
                _scheinbareHelligkeit = value;
            } 
        }
        public string VollstaendigerTyp {
            get {
                return $"{this.GetType().Name} ({SpektralKlasse}-Klasse)";
                }
            }
        public override string ToString(){
            return $"{base.ToString()}, {VollstaendigerTyp}, scheinbare Helligkeit: {ScheinbareHelligkeit:F2}";
        }
    }

    public class Planet : Himmelskoerper
    {
        public Planet(string name, uint katNr, double umlaufzeit, uint katalogNummerReferenz) : base(name, katNr)
        {
            this.Umlaufzeit = umlaufzeit;
            this.ZentralkoerperKatalogNummer = katalogNummerReferenz;
        }
        // Umlaufzeit
        private double _umlaufzeit;
        public double Umlaufzeit { 
            get => _umlaufzeit; 
            set{
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Umlaufzeit darf nicht 0 oder weniger sein.");
                }
                _umlaufzeit = value;
            } 
        }

        // ZentralkoerperKatalogNummer
        private uint _zentralkoerperKatalogNummer;
        public uint ZentralkoerperKatalogNummer { 
            get => _zentralkoerperKatalogNummer;
            set 
            {
                if (isCatalogueNumberNotValid(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Katalognummer des Zentralgestirns nicht gültig (5 Zeichen).");
                }
                _zentralkoerperKatalogNummer = value;
            }
        }
        public override string ToString(){
            return $"{base.ToString()}, Umlaufzeit: {Umlaufzeit:F2},"+
            $" Kat Nr des Zentralkörpers : {ZentralkoerperKatalogNummer}";
        }
    }

    public class Mond : Planet
    {
        public Mond(string name, uint katNr, double umlaufzeit, uint katalogNummerReferenz) 
            : base(name, katNr, umlaufzeit, katalogNummerReferenz)
        {

        }
    }
    public class Komet(string name, uint katNr, double umlaufzeit, uint katalogNummerReferenz) 
        : Planet(name, katNr, umlaufzeit, katalogNummerReferenz)
    {
    }
}