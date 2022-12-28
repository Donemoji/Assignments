using System;
using System.Collections;
using System.Diagnostics;

namespace Assingment2 {
    internal class Program {
        static void Main(string[] args) {

            //LAB1. 
            //변수 선언 
            int biggest = 0;
            int[] rndNumContainer = new int[100];

            //랜덤 객체 생성
            Random rnd = new Random();

            //최대값 찾는 반복문 
            for (int idx = 0; idx < rndNumContainer.Length; idx++) {

                //해당 인덱스의 배열에 랜덤값 대입
                rndNumContainer[idx] = rnd.Next(0, 101);

                //만약에 해당 인덱스 배열의 값보다 최대값 변수가 크다면 최대값 변수에 해당 인덱스 배열의 값 저장  
                if (biggest < rndNumContainer[idx]) {
                    biggest = rndNumContainer[idx];
                }

                //출력문
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


            //LAB 2. 버블, 합병 정렬

            //LAB 2-1. 버블 정렬
            //난수를 담을 변수 선언
            int[] appleCnt = new int[100];

            //난수 생성 및 중복 체크 작업을 하는 반복문
            for (int idx = 0; idx < 100; idx++) {
                
                //난수 생성
                appleCnt[idx] = rnd.Next(0, 300);

                //중복 체크
                for (int idx2 = 0; idx2 < appleCnt.Length; idx2++) {
                    
                    if (idx == idx2) {
                        //do noting
                    } else {

                        if (appleCnt[idx] == appleCnt[idx2]) {
                            
                            //중복수일 경우 인덱스 값을 하나 빼고 반복문 다시 실행
                            idx--;
                            break;
                        
                        }
                    }

                }

            }

            //머지 소트 정렬 할 배열 생성
            int[] appleCntMergeSort = new int[100];
            //난수 생성한 배열을 머지 소트 정렬할 배열로 카피
            appleCnt.CopyTo(appleCntMergeSort, 0);


            //출력문
            Console.Write("버블 정렬 되기전 난수: ");
            for (int idx = 0; idx < appleCnt.Length; ++idx) {
                Console.Write(appleCnt[idx] + ",  ");
            }

            //시간 체크
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //버블 정렬, 배열을 비교 해야 하므로 배열의 전체 길이에 1개를 빼야한다. 
            for (int idx = 0; idx < appleCnt.Length - 1; idx++) {

                //
                for (int idx2 = idx + 1; idx2 < appleCnt.Length; idx2++) {

                    if (appleCnt[idx] > appleCnt[idx2]) {

                        int temp = appleCnt[idx];
                        appleCnt[idx] = appleCnt[idx2];
                        appleCnt[idx2] = temp;


                    }

                }
            }
            //시간 체크
            stopwatch.Stop();

            //출력문
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





            //LAB2-2. 합병 정렬 
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();








        }//main


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