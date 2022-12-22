using System.Diagnostics;

namespace Assingment2 {
    internal class Program {
        static void Main(string[] args) {

            //LAB1. 
            Random rnd = new Random();
            int biggest = 0;

            int[] rndNumContainer = new int[100];


            for (int idx = 0; idx < 100; idx++) {


                rndNumContainer[idx] = rnd.Next(0, 101);


                if (biggest < rndNumContainer[idx]) {
                    biggest = rndNumContainer[idx];
                }

                Console.WriteLine("계산한 최대값: {0}", biggest);
                Console.WriteLine("난수: {0}", rndNumContainer[idx]);
                Console.WriteLine("=============================");

            }

            Console.WriteLine("최종 최대값: {0}", biggest);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine();


            //LAB 2. 버블, 합병 분할 정렬

            int[] appleCnt = new int[100];



            for (int idx = 0; idx < 100; idx++) {
                appleCnt[idx] = rnd.Next(0, 300);

                for (int idx2 = 0; idx2 < appleCnt.Length; idx2++) {
                    if (idx == idx2) {
                        //do noting
                    } else {
                        if (appleCnt[idx] == appleCnt[idx2]) {
                            idx--;
                            break;
                        }
                    }



                }
            }

            int[] appleCntMergeSort = new int[100];
            appleCnt.CopyTo(appleCntMergeSort, 0);



            Console.Write("버블 정렬 되기전 난수: ");
            for (int idx = 0; idx < appleCnt.Length; ++idx) {
                Console.Write(appleCnt[idx] + ",  ");
            }


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int idx = 0; idx < appleCnt.Length - 1; idx++) {

                for (int idx2 = idx + 1; idx2 < appleCnt.Length; idx2++) {

                    if (appleCnt[idx] > appleCnt[idx2]) {

                        int temp = appleCnt[idx];
                        appleCnt[idx] = appleCnt[idx2];
                        appleCnt[idx2] = temp;


                    }

                }
            }
            stopwatch.Stop();



            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("=============================");
            Console.WriteLine("=============================");


            Console.Write("버블 정렬 된 난수: ");
            for (int idx = 0; idx < appleCnt.Length; ++idx) {
                Console.Write(appleCnt[idx] + ",  ");
            }
            Console.WriteLine();
            Console.WriteLine("time: " + stopwatch.ElapsedTicks + "ms");


            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine();


            //LAB2. 머지 소트 
            //int[] appleCntMergeSort = appleCnt;

            //appleCntMergeSort;
            Console.Write("M & S 정렬 되기전 난수: ");
            for (int idx = 0; idx < appleCntMergeSort.Length; ++idx) {
                Console.Write(appleCntMergeSort[idx] + ",  ");
            }
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("=============================");

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();

            int[] resultArr = SortArr(appleCntMergeSort, 0, appleCntMergeSort.Length - 1);
            stopwatch1.Stop();


            Console.Write("M & S 정렬 된 난수: ");
            for (int idx = 0; idx < resultArr.Length; ++idx) {
                Console.Write(resultArr[idx] + ",  ");
            }
            Console.WriteLine();
            Console.WriteLine("time: " + stopwatch1.ElapsedTicks + "ms");


            Console.WriteLine();
            Console.WriteLine();



        }


        public static int[] SortArr(int[] arr, int start, int end) {

            if (start < end) {
                int middle = (end + start) / 2;

                SortArr(arr, start, middle);
                SortArr(arr, middle + 1, end);

                MergeArr(arr, start, middle, end);

            }


            return arr;
        }

        public static void MergeArr(int[] arr, int left, int middle, int right) {
            int startArrayLength = middle - left + 1;
            int endArrayLength = right - middle;

            int[] startTempArray = new int[startArrayLength];
            int[] endTempArray = new int[endArrayLength];



            for (int idx = 0; idx < startArrayLength; ++idx)
                startTempArray[idx] = arr[left + idx];

            for (int idx2 = 0; idx2 < endArrayLength; ++idx2)
                endTempArray[idx2] = arr[middle + 1 + idx2];


            int i, j;

            i = 0;
            j = 0;

            int k = left;

            while (i < startArrayLength && j < endArrayLength) {

                if (startTempArray[i] <= endTempArray[j]) {

                    arr[k++] = startTempArray[i++];

                } else {

                    arr[k++] = endTempArray[j++];

                }

            }

            while (i < startArrayLength) {

                arr[k++] = startTempArray[i++];

            }

            while (j < endArrayLength) {

                arr[k++] = endTempArray[j++];

            }

        }



    }
}