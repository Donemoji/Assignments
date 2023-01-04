using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPoker {
    internal class TrumpCardDeck {

        private int[] trumpCardSet;             // 내가 사용할 카드 세트
        private String[] trumpCardMark;         // 트럼프 카드의 마크(아이콘)
        


            

        public void ShowCardInTrumpVertical(List<int> cards, int yPos) {
            for (int idx = 0; idx < cards.Count; idx++) {

                String cardMark = trumpCardMark[(cards[idx] - 1) / 13];
                String cardNumber = Math.Ceiling(cards[idx] % 13.1).ToString();


                switch (cardNumber) {

                    case "1":
                        cardNumber = "A";
                        break;

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


                //Console.SetCursorPosition((idx) * 9, 5);

                SetCusrsorAndPrint(cardMark, cardNumber, idx, yPos);

                //if (cardNumber == "10") {
                //    Console.WriteLine(" -----");
                //    Console.WriteLine("|{0}{1} |", cardMark, cardNumber);
                //    Console.WriteLine("|     |");
                //    Console.WriteLine("|     |");
                //    Console.WriteLine("| {0}{1}|", cardNumber, cardMark);
                //    Console.WriteLine(" -----");

                //} else {
                //    Console.WriteLine(" -----");
                //    Console.WriteLine("|{0}{1}  |", cardMark, cardNumber);
                //    Console.WriteLine("|     |");
                //    Console.WriteLine("|     |");
                //    Console.WriteLine("|  {0}{1}|", cardNumber, cardMark);
                //    Console.WriteLine(" -----");

                //}

            }


        }

        int setCursorIndex = 0;

        public void SetCusrsorAndPrint(String cardMark, String cardNumber, int indexNumber, int yPos) {


                if (cardNumber == "10") {
                    Console.SetCursorPosition(indexNumber * 9, yPos + 0);
                    Console.WriteLine(" -----");
                    Console.SetCursorPosition(indexNumber * 9, yPos + 1);
                    Console.WriteLine("|{0}{1} |", cardMark, cardNumber);
                    Console.SetCursorPosition(indexNumber * 9, yPos + 2);
                    Console.WriteLine("|     |");
                    Console.SetCursorPosition(indexNumber * 9, yPos + 3);
                    Console.WriteLine("|     |");
                    Console.SetCursorPosition(indexNumber * 9, yPos + 4);
                    Console.WriteLine("| {0}{1}|", cardNumber, cardMark);
                    Console.SetCursorPosition(indexNumber * 9, yPos + 5);
                    Console.WriteLine(" -----");

                } else {
                    Console.SetCursorPosition(indexNumber * 9, yPos + 0);
                    Console.WriteLine(" -----");
                    Console.SetCursorPosition(indexNumber * 9, yPos + 1);
                    Console.WriteLine("|{0}{1}  |", cardMark, cardNumber);
                    Console.SetCursorPosition(indexNumber * 9, yPos + 2);
                    Console.WriteLine("|     |");
                    Console.SetCursorPosition(indexNumber * 9, yPos + 3);
                    Console.WriteLine("|     |");
                    Console.SetCursorPosition(indexNumber * 9, yPos + 4);
                    Console.WriteLine("|  {0}{1}|", cardNumber, cardMark);
                    Console.SetCursorPosition(indexNumber * 9, yPos + 5);
                    Console.WriteLine(" -----");

                }
            

        }


        public void ShowCardInTrumpVertical(List<int> cards, int yPos, int iterator) {
            for (int idx = 0; idx < iterator; idx++) {

                String cardMark = trumpCardMark[(cards[idx] - 1) / 13];
                String cardNumber = Math.Ceiling(cards[idx] % 13.1).ToString();


                switch (cardNumber) {

                    case "1":
                        cardNumber = "A";
                        break;

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


                //Console.SetCursorPosition((idx) * 9, 5);

                SetCusrsorAndPrint(cardMark, cardNumber, idx, yPos);

                //if (cardNumber == "10") {
                //    Console.WriteLine(" -----");
                //    Console.WriteLine("|{0}{1} |", cardMark, cardNumber);
                //    Console.WriteLine("|     |");
                //    Console.WriteLine("|     |");
                //    Console.WriteLine("| {0}{1}|", cardNumber, cardMark);
                //    Console.WriteLine(" -----");

                //} else {
                //    Console.WriteLine(" -----");
                //    Console.WriteLine("|{0}{1}  |", cardMark, cardNumber);
                //    Console.WriteLine("|     |");
                //    Console.WriteLine("|     |");
                //    Console.WriteLine("|  {0}{1}|", cardNumber, cardMark);
                //    Console.WriteLine(" -----");

                //}

            }


        }






        public void ShowCardInTrump(int card) {
            String cardMark = trumpCardMark[(card - 1) / 13];
            String cardNumber = Math.Ceiling(card % 13.1).ToString();


            switch (cardNumber) {

                case "1":
                    cardNumber = "A";
                    break;

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

            if (cardNumber == "10") {
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


        public List<int> PlayerRollCardsInTrump() {


            List<int> playerTrumpCard = new List<int>();
            for (int idx = 7; idx < 12; idx++) {
                playerTrumpCard.Add(trumpCardSet[idx]);

            }
            Console.WriteLine("");

            return playerTrumpCard;


        }       // PlayerCompRollCardsInTrump()

        public List<int> ComputerRollInitCardsInTrump() {

            ShuffleCards(1000);


            


            List<int> computerTrumpCard = new List<int>();



            for (int idx = 0; idx < 5; idx++) {
                
                computerTrumpCard.Add(trumpCardSet[idx]);
            }
            return computerTrumpCard;
            
            
        }       // PlayerCompRollCardsInTrump()


        public List<int> ComputerRollExtraCardsInTrump() {



            List<int> computerTrumpCard = new List<int>();



            for (int idx = 0; idx < 7; idx++) {

                computerTrumpCard.Add(trumpCardSet[idx]);
            }
            return computerTrumpCard;


        }       // PlayerCompRollCardsInTrump()

        public List<int> PlayerRollExtraCardsInTrump() {



            List<int> computerTrumpCard = new List<int>();



            for (int idx = 7; idx < 14; idx++) {

                computerTrumpCard.Add(trumpCardSet[idx]);
            }
            return computerTrumpCard;


        }       // PlayerCompRollCardsInTrump()




    }
}
