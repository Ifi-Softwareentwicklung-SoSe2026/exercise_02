using System.Text;

namespace RaumfahrtMission
{
   public class Bahndaten
   {
        public Bahndaten(Himmelskoerper himmelskoerper, double großeHalbachse, double exzentrizität)
        {
            this.Himmelskoerper = himmelskoerper;
            this.GroßeHalbachse = großeHalbachse;
            this.Exzentrizität = exzentrizität;
        }
        //TODO show this constructor overloading in the lecture! with explanation why we need it here
        public Bahndaten(Himmelskoerper himmelskoerper, double umlaufzeit, double großeHalbachse, double exzentrizität) 
            : this(himmelskoerper, großeHalbachse, exzentrizität)
        {
            // Umlaufzeit wird hier nicht direkt gespeichert, da sie bereits in Himmelskoerper.Umlaufzeit enthalten ist.
            // Diese Konstruktorüberladung ermöglicht es jedoch, die Umlaufzeit zu übergeben, falls sie von der Standardumlaufzeit abweicht.
        }   
        private Himmelskoerper _himmelskoerper;
        public Himmelskoerper Himmelskoerper{
            get=> _himmelskoerper;
            init {
                if (value is not (Planet or Mond or Komet)){
                    throw new ArgumentException("Himmelskoerper muss ein Planet, Mond oder Komet sein.");
                }
                _himmelskoerper = value;
            }
        }
        public double Umlaufzeit{
            get => ((Planet)Himmelskoerper).Umlaufzeit;
        }
        public string Name{
            get => Himmelskoerper.Name;
        }
        public double GroßeHalbachse {get; init;}
        public double Exzentrizität {get; init;}
   
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Himmelskoerper.ToString());
            sb.Append($"    Große Halbachse: {GroßeHalbachse} AE, Exzentrizität: {Exzentrizität}.");
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Himmelskoerper, Umlaufzeit, GroßeHalbachse, Exzentrizität);
        }
   } 
}