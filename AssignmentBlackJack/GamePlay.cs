using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentBlackJack {
    internal class GamePlay {

        TrumpCard trumpCard;
        public int GameStart(int moneyBeforeGame) {

            Console.WriteLine("게임을 시작합니다.");
            Console.WriteLine("======================================"); 
            Console.WriteLine("내 자산: {0}", moneyBeforeGame);
            Console.WriteLine();

            int moneyBetting;
            int moneyAfter = 0;

            trumpCard = new TrumpCard();
            trumpCard.SetUpTrumpCards();
            int[] playerCompCards = PlayerCompRollCards(trumpCard);

            ShowCompCard(playerCompCards[1], playerCompCards[2]);

            moneyBetting = HowMuchBet(moneyBeforeGame);

            if(moneyBetting == 0) {
                Console.WriteLine();
                Console.WriteLine("폴드");
                Console.WriteLine("내 자산: {0}", moneyBeforeGame);
                moneyAfter = moneyBeforeGame;

            } else {
                ShowMyCard(playerCompCards[0]);
                moneyAfter = WhoIsTheWinner(moneyBeforeGame, moneyBetting, playerCompCards);

            }

            Console.ReadLine();
            Console.Clear();


            return moneyAfter;


        }

        private void ShowMyCard(int myCard) {
            Console.WriteLine();
            Console.WriteLine("나의 카드");
            trumpCard.ShowCardInTrump(myCard);
        }




        private void ShowCompCard(int compCard1, int compCard2) {
            
            
            int compCardHigh = (int)Math.Ceiling(compCard1 % 13.1);
            int compCardLow = (int)Math.Ceiling(compCard2 % 13.1);

            if(compCardLow > compCardHigh) {
                int temp = compCardHigh;
                compCardHigh = compCardLow;
                compCardLow = temp;
            }

            Console.WriteLine("컴퓨터 첫번째 카드");
            trumpCard.ShowCardInTrump(compCardLow);

            Console.WriteLine();

            Console.WriteLine("컴퓨터 두번째 카드");
            trumpCard.ShowCardInTrump(compCardHigh);



        }

        

        private int HowMuchBet(int moneyBeforeGame) {
            int bettingSize;

            while (true) {
                
                Console.Write("베팅 금액을 설정하시오: ");
                int.TryParse(Console.ReadLine(), out bettingSize);
                
                if (moneyBeforeGame - bettingSize < 0) {
                    Console.WriteLine("현재 가진 돈보다 배팅 금액이 많습니다. 다시 배팅 하세요.");
                    Console.WriteLine();
                } else {
                    Console.WriteLine("{0}원을 베팅 하셨습니다.", bettingSize);
                    return bettingSize;
                }

            }


        }

        private int[] PlayerCompRollCards(TrumpCard trumpCard) {

            int[] playerCompCards = trumpCard.PlayerCompRollCardsInTrump();
            return playerCompCards;

        }

        private int WhoIsTheWinner(int moneyBeforeGame, int betSize, int[] playerCompCards) {
            int playerCard = (int)Math.Ceiling(playerCompCards[0] % 13.1);
            int compCardHigh = (int)Math.Ceiling(playerCompCards[1] % 13.1);
            int compCardLow = (int)Math.Ceiling(playerCompCards[2] % 13.1);
            int moneyAfterGame;

            if (compCardLow > compCardHigh) {
                int temp = compCardHigh;
                compCardHigh = compCardLow;
                compCardLow = temp;
            }




            if (playerCard > compCardLow && playerCard < compCardHigh) {
                moneyAfterGame = moneyBeforeGame + (betSize * 2);
                Console.WriteLine("플레이어가 이겼습니다.");
                Console.WriteLine("내 자산: {0}", moneyAfterGame);
            } else {
                moneyAfterGame =  moneyBeforeGame - (betSize * 3);
                Console.WriteLine("컴퓨터가 이겼습니다.");
                Console.WriteLine("내 자산: {0}", moneyAfterGame);
            }

            return moneyAfterGame;

        }






    }
}
