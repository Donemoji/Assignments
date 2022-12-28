using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBlackJack {
    internal class TrumpCard {

        private int[] trumpCardSet;             // 내가 사용할 카드 세트
        private String[] trumpCardMark;         // 트럼프 카드의 마크(아이콘)

        

        public void ShowCardInTrump(int card) {
            String cardMark = trumpCardMark[(card - 1) / 13];
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

            if(cardNumber == "10") {
                Console.WriteLine(" -----");
                Console.WriteLine("|{0}{1} |", cardMark, cardNumber);
                Console.WriteLine("|     |");
                Console.WriteLine("|     |");
                Console.WriteLine("| {0}{1}|", cardNumber, cardMark);
                Console.WriteLine(" -----");

            } else {
                Console.WriteLine(" -----");
                Console.WriteLine("|{0}{1}  |", cardMark, cardNumber);
                Console.WriteLine("|     |");
                Console.WriteLine("|     |");
                Console.WriteLine("|  {0}{1}|", cardNumber, cardMark);
                Console.WriteLine(" -----");

            }




        }


        public void SetUpTrumpCards() {

            trumpCardSet = new int[52];

            for (int idx = 0; idx < trumpCardSet.Length; idx++) {

                trumpCardSet[idx] = idx + 1;

            }       // loop: 카드 초기 셋업하는 루프


            //트럼프 카드의 마크를 셋업한다.
            trumpCardMark = new string[] { "♥", "♠", "◆", "♣" };


        }       // SetUpTrumpCards()



        //카드를 섞는 함수 
        public void ShuffleCards() {
            ShuffleCards(200);
        }       //ShuffleCards()

        
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


        public int[] PlayerCompRollCardsInTrump() {
            
            ShuffleCards(300);
            
            return new int[] { trumpCardSet[0], trumpCardSet[1], trumpCardSet[2] };


        }       // PlayerCompRollCardsInTrump()

        
    }   // class TrumpCard
}
