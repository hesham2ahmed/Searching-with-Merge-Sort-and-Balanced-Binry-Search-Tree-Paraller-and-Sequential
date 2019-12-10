using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskOS2
{
    public class Parallel1
    {
        public BBST bbst1, bbst2, bbst3, bbst4;
        Task task1, task2, task3, task4;


        public Parallel1() { }

        public void run(long[] arr, long length,long value)
        {

            if (length < 4)
            {
                Console.WriteLine("Sorry size of array must be greater than 3");
                return;
            }

            long first = (length / 4) -1;
            long second = (length / 2) -1;
            long third = (long)(length * 0.75) -1;

             task1 = new Task(() =>
            {
                MergeSort(arr, 0, first);
            });

             task2 = new Task(() =>
            {
                MergeSort(arr, first + 1, second);
            });

             task3 = new Task(() =>
            {
                MergeSort(arr, second + 1, third);
            });

             task4 = new Task(() =>
            {
                MergeSort(arr, third + 1, length - 1);
            });

            Task task5 = new Task(() =>
            {
                bbst1 = new BBST();
                bbst1.CreateBBST(arr, 0, first);
            });

            Task task6 = new Task(() =>
            {
                bbst2 = new BBST();
                bbst2.CreateBBST(arr, first + 1, second);
            });

            Task task7 = new Task(() => {
                bbst3 = new BBST();
                bbst3.CreateBBST(arr, second + 1, third);
            });

            Task task8 = new Task(() => {
                bbst4 = new BBST();
                bbst4.CreateBBST(arr, third + 1, length - 1);
            });

            task1.Start();
            task2.Start();
            task3.Start();
            task4.Start();

            task1.Wait();
            task5.Start();

            task2.Wait();
            task6.Start();

            task3.Wait();
            task7.Start();

            task4.Wait();
            task8.Start();

            task5.Wait();
            task6.Wait();
            task7.Wait();
            task8.Wait();

//            bbst1.preOrder(bbst1.root);
  //          Console.WriteLine();
    //        bbst2.preOrder(bbst2.root);
      //      Console.WriteLine();
        //    bbst3.preOrder(bbst3.root);
          //  Console.WriteLine();
           // bbst4.preOrder(bbst4.root);
           //Console.WriteLine();

            Search(value);

        }

        private void MergeSort(long[] input, long left, long right)
        {
            if (left < right)
            {
                long middle = (left + right) / 2;

                MergeSort(input, left, middle);
                MergeSort(input, middle + 1, right);

                Merge(input, left, middle, right);
            }
        }

        private void Merge(long[] input, long left, long middle, long right)
        {
            long[] leftArray = new long[middle - left + 1];
            long[] rightArray = new long[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            long i = 0;
            long j = 0;
            for (long k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }

        private void Search(long value)
        {
            bool t1, t2, t3, t4, result1, result2, result3, result4;
            t1 = t2 = t3 = t4 = result1 = result2 = result3 = result4 = false;

            task1 = new Task(() =>
            {
                Console.WriteLine("Task 1 is runinig");
                result1 = bbst1.search(value);
            });

            task2 = new Task(() =>
            {
                Console.WriteLine("Task 2 is runinig");
                result2 = bbst2.search(value);
            });

            task3 = new Task(() =>
            {
                Console.WriteLine("Task 3 is runinig");
                result3 = bbst3.search(value);
            });

            task4 = new Task(() =>
            {
                Console.WriteLine("Task 4 is runinig ");
                result4 = bbst4.search(value);
            });


            if (value >= bbst1.start && value <= bbst1.end)
            {
                task1.Start();
                t1 = true;
            }
            if (value >= bbst2.start && value <= bbst2.end)
            {
                task2.Start();
                t2 = true;
            }
            if (value >= bbst3.start && value <= bbst3.end)
            {
                task3.Start();
                t3 = true;

            }
            if (value >= bbst4.start && value <= bbst4.end){
                task4.Start();
                t4 = true;
            }

            if (t1) { 
                task1.Wait();
                if (result1){
                    Console.WriteLine("EXSIT at BBST 1");
                    return;
                }
                
            }
            if (t2) { 
                task2.Wait();
                if (result2){ 
                    Console.WriteLine("EXSIT at BBST 2");
                }
                
            }
            if (t3) { 
                task3.Wait();
                if (result3){
                    Console.WriteLine("EXSIT at BBST 3");
                    return;
                }
                
            }
            if (t4) { 
                task4.Wait();
                if (result4){
                    Console.WriteLine("EXSIT at BBST 4");
                    return;
                }
                
            }

            if (result1 == false && result2 == false && result3 == false && result4 == false)
                Console.WriteLine("Sorry it doesn't EXSIT !!");
        }
    }
}
