using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WhatisClass {
    internal class ClassExerciseLotto {
        public static void Main() {

            LottoNumber lottoNumber= new LottoNumber();
            int[] lottoNumbers = lottoNumber.GetLottonumber();

            //기존 스타일 if문 처리
            Console.Write("기존 스타일로 생성한 로또 번호는: ");
            foreach (int idx in lottoNumbers) {
                Console.Write("{0}, ", idx);
            }
            Console.WriteLine();


            //if문 처리 없이 swap 1~45까지 배열을 생성하고 swap
            lottoNumber.PrintLottoNumber();


            //RockScissorPaperGame.Play();



            TrumpCard trumpCard = new TrumpCard();
            trumpCard.SetUpTrumpCards();
            
            trumpCard.ReRollCard();

            for(int k =0; k<100; k++) {
                trumpCard.ReRollCard();
            }
            

        }       // Main()

    }
    enum RockScissorPaper {
        ROCK, SCISSOR, PAPER
    }

    enum Result {
        PLAYER_WIN, COMP_WIN, DRAW
    }


    public class RockScissorPaperGame {
        private static Random compNum; 


        public static void Play() {
            compNum = new Random();
            int compResult = compNum.Next(0, 2+1);
            int myResult = -1;

            Console.Write("가위 바위 보: ");
            String tempStr = Console.ReadLine();

            Console.Write("컴퓨터: "); 
            switch (compResult) {
                case (int)RockScissorPaper.ROCK:
                    Console.WriteLine("바위");
                    break;
                case (int)RockScissorPaper.SCISSOR:
                    Console.WriteLine("가위");
                    break;
                case (int)RockScissorPaper.PAPER:
                    Console.WriteLine("보");
                    break;
            }



            if (tempStr == "가위") {
                myResult= (int)RockScissorPaper.SCISSOR;
            } else if (tempStr == "바위") {
                myResult= (int)RockScissorPaper.ROCK;
            } else if (tempStr == "보") {
                myResult = (int)RockScissorPaper.PAPER;
            } else {
                Console.WriteLine("잘못된 입력입니다.");
                return;
                //잘못된 입력
            }

            int[] playerAndComputerResult = new int[] { myResult, compResult };
            PrintIsWin(playerAndComputerResult);

        }
        //가위 1 , 바위 0, 보 2
        private static void PrintIsWin(int[] result) {

            //0 -> 비김, 1-> 이김, 2-> 짐
            int finalResult = 0; 


            switch (result[0]) {

                case (int)RockScissorPaper.ROCK:

                    if (result[1] == (int)RockScissorPaper.ROCK) {
                        finalResult= (int)Result.DRAW;
                    }else if (result[1] == (int)RockScissorPaper.PAPER) {
                        finalResult = (int)Result.COMP_WIN;
                    } else {
                        finalResult = (int)Result.PLAYER_WIN;
                    }
                    break;


                case (int)RockScissorPaper.SCISSOR:

                    if (result[1] == (int)RockScissorPaper.SCISSOR) {
                        finalResult = (int)Result.DRAW;
                    } else if (result[1] == (int)RockScissorPaper.ROCK) {
                        finalResult = (int)Result.COMP_WIN;
                    } else {
                        finalResult = (int)Result.PLAYER_WIN;
                    }
                    break;


                case (int)RockScissorPaper.PAPER:

                    if (result[1] == (int)RockScissorPaper.PAPER) {
                        finalResult = (int)Result.DRAW;
                    } else if (result[1] == (int)RockScissorPaper.SCISSOR) {
                        finalResult = (int)Result.COMP_WIN;
                    } else {
                        finalResult = (int)Result.PLAYER_WIN;
                    }
                    break;


            }

            if(finalResult == (int)Result.DRAW) {
                Console.WriteLine("비김");

            } else if(finalResult == (int)Result.PLAYER_WIN) {
                Console.WriteLine("플레이어가 이김");

            } else {
                Console.WriteLine("컴퓨터가 이김");

            }

        }
    }




    public class LottoNumber {
        private const int LOTTO_INDEX = 6;
        private Random rndNums;
        private int[] lottoNums;
        private int[] lottoNumbers; 

        public int[] GetLottonumber() {
            lottoNums = new int[LOTTO_INDEX];
            rndNums = new Random();

            for (int idx =0; idx<LOTTO_INDEX; idx++) {
                int temp = rndNums.Next(1, 45 + 1);
                
                for(int idx1 = 0; idx1< lottoNums.Length; idx1++) {

                    if (idx == idx1) {
                        continue;
                    } else if (temp == lottoNums[idx1]) {
                        idx--;
                        
                        break;
                    } else {

                        lottoNums[idx] = temp;
                    }
                }

            }

            return lottoNums;


        }

         

        public void PrintLottoNumber() {
            lottoNumbers = new int[45]; 
            
            for(int idx =0; idx<lottoNumbers.Length; idx++) {
                lottoNumbers[idx] = idx + 1;
                //로또 번호를 순서대로 초기화
            }

            for(int idx =0; idx<100; idx++) {
                lottoNumbers = ShuffleOnce(lottoNumbers);
                //100번 정도 섞는다.

            }

            Console.Write("다른 스타일로 생성한 로또 번호는: ");
            for(int idx =0; idx <6; idx++) {
                Console.Write("{0}, ", lottoNumbers[idx]);
            }
            Console.WriteLine();

        }

        // 내부에서 사용하는 배열을 1번 섞는 함수
        private int[] ShuffleOnce(int[] lottoNumbers) {
            rndNums= new Random();
            int sourceIdx = rndNums.Next(0, lottoNumbers.Length);
            int destinationIdx = rndNums.Next(0, lottoNumbers.Length);

            int tempVar = lottoNumbers[sourceIdx];
            lottoNumbers[sourceIdx] = lottoNumbers[destinationIdx];
            lottoNumbers[destinationIdx] = tempVar;

            return lottoNumbers;

        }


    }
}
