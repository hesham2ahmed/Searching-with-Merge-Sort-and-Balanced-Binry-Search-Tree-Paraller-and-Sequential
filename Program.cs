using System;
using System.Diagnostics;
using System.IO;

namespace TaskOS2
{
    class Program
    {

        private static StreamReader streamReader;
        private static StreamWriter streamWriter;


        static void Main(string[] args)
        {

            String path = @"F:\TestNum2\textFile.txt";
            long length = 100;
            long[] arr = new long[length];

            createTestcCase(length, path);

            if (!readTestCase(path, arr))
                return;

            Stopwatch stopwatch = Stopwatch.StartNew();

            //Parallel1 parallel = new Parallel1();
            //parallel.run(arr, length, 7);


            //Seqauntial seqauntial = new Seqauntial(); 
             //seqauntial.run(arr,length,7);


            /*test cases
             * 11,7,5,-13,0,1,21,-31
             * 11,-12,-13,-4,-5
             * 1000  to 0
             * 100000000 to 0
             * 1000000 to 0
             * 1,2,3,4,5
             * 2147483647,65535 ,–2147483648,4294967295
             */



            stopwatch.Stop();
            Console.WriteLine("Time in milisecond " + stopwatch.ElapsedMilliseconds);



            writeInFile(arr, path);

        }








        public static void createTestcCase(long length, String path)
        {
            File.Delete(path);
            streamWriter = new StreamWriter(path);

            for (long i = length; i > 0; i--)
                streamWriter.WriteLine(i);
            streamWriter.Close();
        }

        public static bool readTestCase(String path, long[] array)
        {
            streamReader = new StreamReader(path);
            String line;
            long g = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                try
                {
                    array[g] = long.Parse(line);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry Overflow Exception in " + g + " index");
                    return false;
                }
                g++;
            }
            streamReader.Close();
            return true;
        }

        public static void writeInFile(long[] arr, String path)
        {
            File.Delete(path);
            streamWriter = new StreamWriter(path);

            for (int i = 0; i < arr.Length; i++)
                streamWriter.WriteLine(arr[i]);

            streamWriter.Close();
        }
    }
}
