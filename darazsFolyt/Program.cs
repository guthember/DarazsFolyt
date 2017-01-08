using System;

namespace darazsFolyt
{
    class Darazs
    {
        const int DARAB = 20;
        int[] doboz;
        int[] atlag;
        int aDb;


        public int Db { get { return aDb; } }

        public Darazs()
        {
            doboz = new int[DARAB];
            atlag = new int[DARAB + 1];

            int egyDb = 0;
            for (int i = 0; i < DARAB; i++)
            {
                Random vel = new Random(Guid.NewGuid().GetHashCode());
                if (vel.NextDouble() < 0.5)
                {
                    doboz[i] = 1;
                    egyDb++;
                }
                else
                {
                    doboz[i] = 2;
                }
            }
            
            atlag[egyDb]++;
            aDb = egyDb;
        }

        public void Kiir()
        {
            foreach (int szam in doboz)
            {
                Console.Write("{0} ", szam);
            }
            Console.WriteLine();
        }
    
        public void KiirEloszlas()
        {
            foreach (int szam in atlag)
            {
                Console.Write("{0} ",szam);
            }
        }


        public int SzimulaciosLepes()
        {
            int hely;
            Random vel = new Random(Guid.NewGuid().GetHashCode());
            hely = vel.Next(0, DARAB);
            doboz[hely] = 3 - doboz[hely];
            if (doboz[hely] == 1)
            {
                aDb++;
            }
            else
            {
                aDb--;
            }

            atlag[aDb]++;
            return hely;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Darazs dModell = new Darazs();
                 
            Console.WriteLine();
            dModell.Kiir();

            for (int i = 0; i < 10000; i++)
            {
                //Console.Write("hely: {0}, 1. doboz: {1},   ",dModell.SzimulaciosLepes(),dModell.Db);
                //dModell.Kiir();
                dModell.SzimulaciosLepes();
            }

            dModell.KiirEloszlas();

            Console.ReadKey();
        }
    }
}
