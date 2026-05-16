using System.Text;

namespace RaumfahrtMission
{
    public class Bahndaten
    {
        private Himmelskoerper _himmelskoerper;
        public Himmelskoerper Himmelskoerper {
            get => _himmelskoerper;
            init{
                if (value is not (Planet or Mond or Komet)){
                    throw new ArgumentException(
                        "Himmelskoerper muss ein Planet, Mond oder Komet sein.");
                }
                _himmelskoerper = value;
            }
        }
        public double Umlaufzeit {
            get => ((Planet)Himmelskoerper).Umlauf;
        }
        public double GroßeHalbachse {get; init;}
        public double Exzentrizität {get; init;}

        public Bahndaten(Himmelskoerper himmelskoerper, double großeHalbachse, double exzentrizität)
        {
            this.Himmelskoerper = himmelskoerper;
            this.GroßeHalbachse = großeHalbachse;
            this.Exzentrizität = exzentrizität;
        }
        public Bahndaten(Himmelskoerper himmelskoerper, double umlaufzeit, double großeHalbachse, double exzentrizität)
            : this(himmelskoerper, großeHalbachse, exzentrizität)
        {
            if (umlaufzeit != ((Planet)Himmelskoerper).Umlauf)
            {
                    Console.WriteLine($"Warnung: Umlaufzeit [{umlaufzeit}] stimmt nicht mit der Umlaufzeit [{((Planet)Himmelskoerper).Umlauf}] des Himmelskörpers [{Himmelskoerper.Name}] überein.");
            }
        }
    
        // TODO: ToString() Methode implementieren, um die Bahndaten übersichtlich auszugeben
        public override string ToString()        {
            // return $"Bahndaten für {Himmelskoerper.Name}:\n" +
            //        $"- Umlaufzeit: {Umlaufzeit} Jahre\n" +
            //        $"- Große Halbachse: {GroßeHalbachse} AE\n" +
            //        $"- Exzentrizität: {Exzentrizität}";
            var sb = new StringBuilder();
            sb.AppendLine($"Bahndaten für {Himmelskoerper}:");
            sb.Append($"   Große Halbachse: {GroßeHalbachse} AE, ");
            sb.Append($"Exzentrizität: {Exzentrizität}");
            return sb.ToString();
        }
    }

}