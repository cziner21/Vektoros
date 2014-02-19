using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Vektoros
{
    
    class Tombos
    {
        int[] tomb = new int[500000];
        public static int sum;
        //public  bool keszEAlso;
        //public  bool keszEFelso;
        public Tombos() {
            for (int i = 0; i < tomb.Length; i++) {
                tomb[i] = 1;
            }
            sum = 0;
            //keszEAlso = false;
            //keszEFelso = false;
        }

        public void AlsoFele() {
            for (int i = 0; i < tomb.Length / 2; i++) {
                lock (tomb){
                    sum += tomb[i];
                }
            }
            //keszEAlso = true;
        }

        public void FelsoFele() {
            for (int i = tomb.Length / 2; i < tomb.Length; i++) {
                lock (tomb) {
                    sum += tomb[i];
                }
            }
            //keszEFelso = true;
        }
    }

    class Program
    {
        static void Main(string[] args) {

            Tombos t = new Tombos();
            Thread szal1 = new Thread(t.AlsoFele);
            Thread szal2 = new Thread(t.FelsoFele);
            szal1.Start();
            szal2.Start();
            /*while (!(t.keszEAlso && t.keszEFelso)) {

            }*/
            szal1.Join();
            szal2.Join();
            Console.WriteLine("Az összeg: {0}", Tombos.sum);
            Console.ReadKey();
        }
    }
}
