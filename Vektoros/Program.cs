using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vektoros
{
    
    class Tombos
    {
        int[] tomb = new int[500000];
        public static int sum;
        public Tombos() {
            for (int i = 0; i < tomb.Length; i++) {
                tomb[i] = 1;
            }
            sum = 0;
        }

        public void AlsoFele() {
            for (int i = 0; i < tomb.Length / 2; i++) {
                sum += tomb[i];
            }            
        }

        public void FelsoFele() {
            for (int i = tomb.Length / 2; i < tomb.Length; i++) {
                sum += tomb[i];
            }
        }
    }

    class Program
    {
        static void Main(string[] args) {

            Tombos t = new Tombos();
            t.AlsoFele();
            t.FelsoFele();
            Console.WriteLine("Az összeg: {0}", Tombos.sum);
            Console.ReadKey();
        }
    }
}
