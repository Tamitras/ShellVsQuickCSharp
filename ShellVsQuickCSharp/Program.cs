using System.Numerics;

namespace ShellVsQuickCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<ulong> numbers = new List<ulong>();

            //var numbers = GenerateRandomNumbers(10); // 10^2 = 100
            //var numbers = GenerateRandomNumbers(100); // 10^3 = 1.000

            //numbers = GenerateRandomNumbers(1000); // 10^4 = 10.000
            //DoQuickSort(numbers.ToArray());


            //numbers = GenerateRandomNumbers(10000); // 10^5 = 100.000
            //DoQuickSort(numbers.ToArray());


            //numbers = GenerateRandomNumbers(100000); // 10^6 = 1.000.000
            //DoQuickSort(numbers.ToArray());


            //numbers = GenerateRandomNumbers(1000000); // 10^7 = 10.000.000
            //DoQuickSort(numbers.ToArray());


            //numbers = GenerateRandomNumbers(10000000); // 10^8 = 100.000.000
            //DoQuickSort(numbers.ToArray());

            //numbers = GenerateRandomNumbers(100000000); // 10^9 = 1.000.000.000
            //DoQuickSort(numbers.ToArray());

            numbers = GenerateRandomNumbers(1000000000); // 10^10 = 10.000.000.000
            DoQuickSort(numbers.ToArray());

            // Zerstört den Arbeitsspeicher!!!
            //numbers = GenerateRandomNumbers(10000000000); // 10^11 = 10.000.000.000
            //DoQuickSort(numbers.ToArray());
        }

        public static void DoQuickSort(ulong[] arr)
        {
            Console.WriteLine($"\n----------Starte sortieren von {arr.Length} Zahlen -------------------");

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here

            Quicksort.Quick_Sort(arr, 0, (ulong)(arr.Length - 1));

            watch.Stop();

            decimal elapsedMs = watch.ElapsedMilliseconds;
            var secs = Math.Round((elapsedMs / 1000),3);

            Console.WriteLine($"Quicksort beended nach {elapsedMs}ms | {secs}secs");
        }

        private static ulong LongRandom(ulong min, ulong max, Random rand)
        {
            ulong result = (ulong)rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (ulong)rand.Next((Int32)min, (Int32)max);
            return result;
        }

        private static List<ulong> GenerateRandomNumbers(ulong potenz)
        {
            List<ulong> numbers = new List<ulong>();
            Array arr = Array.CreateInstance(typeof(ulong), (int)(10 * potenz));

            Console.WriteLine("\n----------Generiere Zufallszahlen-------------------");

            Random rd = new Random();

            for (ulong i = 0; i < (ulong)(10 * potenz); i++)
            {

                if((ulong)numbers.Count == (ulong)((10*potenz)-1))
                {
                    break;
                }

                //ulong rand_num = (ulong)rd.Next(1, (ulong)(10 * potenz));
                ulong rand_num = LongRandom(1, (10 * potenz), rd);

                numbers.Add(rand_num);

                //if (!numbers.Contains(rand_num))
                //{
                //    numbers.Add(rand_num);
                //}
                //else
                //{
                //    i--;
                //}
            }

            return numbers;
        }
    }
}