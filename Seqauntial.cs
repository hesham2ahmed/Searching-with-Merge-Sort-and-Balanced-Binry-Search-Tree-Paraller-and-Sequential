using System;

namespace TaskOS2
{
    public class Seqauntial
    {
        BBST bbst;
        public Seqauntial()
        {
        }

        public void run(long[] arr,long length,long value)
        {
            MergeSort(arr, 0, length - 1); //nlgn
            bbst = new BBST();
            bbst.CreateBBST(arr, 0, length - 1);
            search(value);//lg(n)
        }

        private void search(long value)
        {
            if (bbst.search(value))
                Console.WriteLine("EXSIT");
            else
                Console.WriteLine("Sorry it doesn't EXSIT !!");
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
    }
}
