using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doga1004
{
    enum marka
    { 
        Opel,
        Suzuki,
        Skoda,
        BMW,
        Fiat,
    }
    class auto
    {
        private double _avgfogy;
        private int _tanksize;
        private double _aktualisBenzin;
        private bool _matrica = false;
        private string _rendszam;

        public double avgfogy
        {
            get => _avgfogy;
            set
            {
                if (value < 3.0) throw new Exception("Túl kicsi az átlagfogyasztáas.");
                if (value > 20.0) throw new Exception("Túl nagy az átlagfogyasztás.");
                _avgfogy = value;
            }
        }
        public int tanksize
        {
            get => _tanksize;
            set
            {
                if (value < 20) throw new Exception("Túl kicsi a tank mérete.");
                if (value > 100) throw new Exception("Túl nagy a tank mérete.");
                _tanksize = value;
            }
        }
        public double aktualisBenzin
        {
            get => _aktualisBenzin;
            set
            {
                if (value <= 0) throw new Exception("Ilyen alacsony nem lehet az aktuális benzinmennyiség.");
                if (value > _tanksize) throw new Exception("A benzinmennyiség nem egyeezhet a tank méretével.");
                _aktualisBenzin = value;
            }
        }
        public marka Marka { get; set; }
        public bool matrica
        {
            get => _matrica;
            set
            {
                _matrica = true;
                _matrica = value;
            }
        }
    }
    class Program
    {
        static Random rnd = new Random();
        static List<auto> Auto = new List<auto>();
        static void Main(string[] args)
        {
            Lista(30);
            LegtobbKM();
            Console.ReadKey();
        }

        private static void LegtobbKM()
        {
            int maxindex = 0;
            for (int i = 0; i < Auto.Count; i++)
            {
                if (Auto[i].aktualisBenzin + Auto[i].avgfogy > Auto[maxindex].aktualisBenzin + Auto[maxindex].avgfogy)
                {
                    maxindex = i;
                    Console.WriteLine($"A legtöbb km{Auto[maxindex].aktualisBenzin+Auto[maxindex].avgfogy}");
                }       
            }
        }

        private static void Lista(int autoszam)
        {
            for (int i = 0; i < autoszam; i++)
            {
                Auto.Add(new auto()
                {
                    Marka=(marka)rnd.Next(Enum.GetNames(typeof(marka)).Length)
                });
            }
        }
    }
}
