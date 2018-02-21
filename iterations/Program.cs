using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iterations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var test = new int [6];
            LosowanieMetdaGlowna.LosowanieLiczb(test);
            foreach (var liczba in test)
            {
                Console.WriteLine(liczba+ ", ");
            }
        }
    }
}
