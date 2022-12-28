using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatisClass {
    internal class TrumpCard {

        private int[] trumpCardSet;             // 내가 사용할 카드 세트
        private String[] trumpCardMark;         // 트럼프 카드의 마크(아이콘)
        

        public void SetUpTrumpCards() {
            
            trumpCardSet = new int[52];
            
            for(int idx =0; idx<trumpCardSet.Length; idx++) {

                trumpCardSet[idx] = idx + 1;

            }       // loop: 카드 초기 셋업하는 루프

            
            //트럼프 카드의 마크를 셋업한다.
            trumpCardMark = new string[] {"♥", "♠", "◆", "♣"}; 







        }       // SetUpTrumpCards()
        
        //카드를 섞는 함수 
        public void ShuffleCards() {
            ShuffleCards(200);
        }       //ShuffleCards()

        // 셔플 하고 카드를 한장 뽑아서 출력하는 함수
        public void ReRollCard() {
            ShuffleCards();
            RollCard();
        }       //ReRollCard()

        // 한장의 카드를 뽑는 함수
        public void RollCard() {

            int card = trumpCardSet[0];
            String cardMark = trumpCardMark[(card -1) / 13];
            String cardNumber = Math.Ceiling(card % 13.1).ToString();

            switch (cardNumber) {

                case "11":
                    cardNumber = "J";
                    break;

                case "12":
                    cardNumber = "Q";
                    break;

                case "13":
                    cardNumber = "K";
                    break;

                default:
                    //do nothing
                    break;


            }       //switch



            Console.WriteLine("내가 뽑은 카드는 {0}{1} 입니다.", cardMark, cardNumber);
            Console.WriteLine(" ----");
            Console.WriteLine("|{0}{1} |", cardMark, cardNumber);
            Console.WriteLine("|    |");
            Console.WriteLine("| {0}{1}|", cardNumber, cardMark);
            Console.WriteLine(" ----");



            

        }       // RollCard()



        private void PrintCardSet() {
            foreach (int card in trumpCardSet) {
                Console.Write("{0},  ", card);
            }
        }       // PrintCardSet()


        //카드를 섞는 함수
        private void ShuffleCards(int howManyLoop) {

            for (int idx = 0; idx < howManyLoop; idx++) {
                trumpCardSet = ShuffleOnce(trumpCardSet);
            }

        }     //ShuffleCards()


        private int[] ShuffleOnce(int[] intArr) {
            Random rndNums = new Random();
            int sourceIdx = rndNums.Next(0, intArr.Length);
            int destinationIdx = rndNums.Next(0, intArr.Length);

            int tempVar = intArr[sourceIdx];
            intArr[sourceIdx] = intArr[destinationIdx];
            intArr[destinationIdx] = tempVar;

            return intArr;

        }       // ShuffleOnce()



    }   // class TrumpCard
}
