using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPoker {
    internal class GamePlay {
        TrumpCardDeck trumpCard;
        List<int> playerTrumpCard;
        List<int> computerTrumpCard;
        Dictionary<String, int> playerTrumpCardDict;
        Dictionary<String, int> computerTrumpCardDict;


        public void showCardInText(List<int> cardDeck) {
            String[] trumpCardMark = new String[] { "♥", "♠", "◆", "♣" };
            foreach (int cards in cardDeck) {

                String trumpCardMarkTemp = trumpCardMark[(cards - 1) / 13];
                int trumpCardNumTemp = (int)Math.Ceiling(cards % 13.1);
                Console.Write("{0}{1}, ", trumpCardMarkTemp, trumpCardNumTemp);
            }
        }

        public void showCardInText(List<int> cardDeck, int iterator) {
            String[] trumpCardMark = new String[] { "♥", "♠", "◆", "♣" };
            
            for(int idx = 0; idx < iterator; idx++) {
                String trumpCardMarkTemp = trumpCardMark[(cardDeck[idx] - 1) / 13];
                int trumpCardNumTemp = (int)Math.Ceiling(cardDeck[idx] % 13.1);
                Console.Write("{0}{1}, ", trumpCardMarkTemp, trumpCardNumTemp);


            }



        }


        public int GameStart(int moneyBeforeGame) {
            Console.Clear();
            Console.WriteLine("게임을 시작합니다.");
            Console.WriteLine("======================================");
            Console.WriteLine("내 자산: {0}", moneyBeforeGame);


            playerTrumpCard = new List<int>();
            computerTrumpCard = new List<int>();


            int moneyBetting;
            int moneyAfter = 0;

            trumpCard = new TrumpCardDeck();
            trumpCard.SetUpTrumpCards();

            computerTrumpCard = trumpCard.ComputerRollInitCardsInTrump();
            computerTrumpCard.Sort();
            playerTrumpCard = trumpCard.PlayerRollCardsInTrump();
            playerTrumpCard.Sort();


            Console.WriteLine("컴퓨터 카드");
            trumpCard.ShowCardInTrumpVertical(computerTrumpCard, 5);
            Console.WriteLine();
            Console.WriteLine("나의 카드");
            trumpCard.ShowCardInTrumpVertical(playerTrumpCard, 13, 5);

            


            moneyBetting = HowMuchBet(moneyBeforeGame);

            if (moneyBetting == 0) {
                Console.WriteLine();
                Console.WriteLine("폴드");
                Console.WriteLine("내 자산: {0}", moneyBeforeGame);
                Console.ReadLine();
                moneyAfter = moneyBeforeGame;
                return moneyAfter;

            } else {

                // do nothing


            }



            Console.ReadLine();
            Console.Clear();

            computerTrumpCard.Clear();
            computerTrumpCard = trumpCard.ComputerRollExtraCardsInTrump();
            computerTrumpCard.Sort();


            Console.WriteLine("컴퓨터 카드");
            trumpCard.ShowCardInTrumpVertical(computerTrumpCard, 1);




            playerTrumpCard.Clear();
            playerTrumpCard = trumpCard.PlayerRollExtraCardsInTrump();
            playerTrumpCard.Sort();

            Console.WriteLine();
            Console.WriteLine("나의 카드");
            trumpCard.ShowCardInTrumpVertical(playerTrumpCard, 9, 5);




            PlayerCardChange();

            if (playerTrumpCard.Count > 5) {
                playerTrumpCard.RemoveRange(5, playerTrumpCard.Count - 5);
            }

            
            Console.Clear();

            Console.WriteLine("컴퓨터 카드");
            trumpCard.ShowCardInTrumpVertical(computerTrumpCard, 1);
            Console.WriteLine();
            Console.WriteLine("나의 카드");
            trumpCard.ShowCardInTrumpVertical(playerTrumpCard, 9);



            moneyAfter = WhoIsTheWinner(moneyBeforeGame, moneyBetting, playerTrumpCard, computerTrumpCard);

            Console.ReadLine();
            Console.Clear();

            return moneyAfter;


        }



        private void PlayerCardChange() {
            for (int idx = 0; idx < 2; idx++) {
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("추가 카드");
                showOneExtraCard(playerTrumpCard[5 + idx]);

                Console.Write("카드를 바꾸시겠습니까? (y/n) ");

                String yesOrNo = Console.ReadLine();

                if (yesOrNo == "y") {
                    Console.Write("몇번째 카드를 바꾸시겠습니까? (1 ~ 5) ");
                    int num = 0;
                    int.TryParse(Console.ReadLine(), out num);
                    if (num > 0 && num < 6) {
                        playerTrumpCard[num - 1] = playerTrumpCard[5 + idx];

                        Console.Clear();


                        Console.WriteLine("컴퓨터 카드");
                        trumpCard.ShowCardInTrumpVertical(computerTrumpCard, 1);
                        Console.WriteLine();
                        Console.WriteLine("나의 카드");
                        trumpCard.ShowCardInTrumpVertical(playerTrumpCard, 9, 5);


                        //보여주기
                    } else {
                        //다시
                        Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                        idx--;
                        continue;

                    }


                } else if (yesOrNo == "n") {
                    Console.WriteLine("카드를 안바꾸셨습니다.");
                    
                } else {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                    idx--;
                    continue;
                }
            }

            playerTrumpCard = playerTrumpCard.Distinct().ToList();

        }



        enum JokBo {
            NO_PAIR_TOP, ONE_PAIR, TWO_PAIR, TRIPLE, FOUR_CARD,
            FLUSH, STRAIT, MOUNTAIN, BACK_STRAIT, FULL_HOUSE,
            STRAIT_FLUSH, ROYAL_STRAIT_FLUSH
        }

        private Dictionary<String, String> PlayerCheckJokbo(List<int> playerCardNum, String[] playerCardMark) {

            Boolean isPStrait = false;
            Boolean isPFlush = false;
            String PStrait = "";

            String PFlushMark = "";
            String PFlushNum = "";

            String PFourCard = "";
            String PTriple = "";
            String[] PTwoPair = new String[2];
            String POnePair = "";
            String PHighTop = "";

            String jokBoNum = "";

            int jokboRank = 0;

            int pairCount = 0;

            List<int> temp = new List<int>();

            for (int idx = 0; idx < playerCardNum.Count; idx++) {
                for (int idx1 = 0; idx1 < playerCardNum.Count; idx1++) {
                    if (playerCardNum[idx] == playerCardNum[idx1]) {
                        if (idx == idx1) continue;
                        else {
                            pairCount++;

                            temp.Add(playerCardNum[idx]);

                        }
                    }

                }
            }

            if (pairCount == 12) {
                //isPFourCard = true;
                jokboRank = (int)JokBo.FOUR_CARD;
                jokBoNum = Math.Ceiling(temp[0] % 13.1).ToString();
            } else if (pairCount == 6) {
                //isPTripleCard = true;
                jokboRank = (int)JokBo.TRIPLE;
                jokBoNum = Math.Ceiling(temp[0] % 13.1).ToString();
            } else if (pairCount == 4) {
                temp.Sort();
                PTwoPair[0] = Math.Ceiling(temp[0] % 13.1).ToString();
                PTwoPair[1] = Math.Ceiling(temp[2] % 13.1).ToString();
                //isPTwoPair = true;
                jokboRank = (int)JokBo.TWO_PAIR;
            } else if (pairCount == 2) {
                jokBoNum = Math.Ceiling(temp[0] % 13.1).ToString();
                //isPOnePair = true;
                jokboRank = (int)JokBo.ONE_PAIR;
            } else {
                jokBoNum = Math.Ceiling(playerCardNum[4] % 13.1).ToString();
                jokboRank = (int)JokBo.NO_PAIR_TOP;
            }




            if (playerCardNum[4] - playerCardNum[0] == 4 && pairCount == 0) {
                jokboRank = (int)JokBo.STRAIT;
                jokBoNum = Math.Ceiling(playerCardNum[4] % 13.1).ToString();
            }

            if (playerCardNum[0] == 1 && playerCardNum[1] == 10 && pairCount == 0 ) {
                isPStrait = true;
                jokboRank = (int)JokBo.STRAIT;
                jokBoNum = Math.Ceiling(playerCardNum[4] % 13.1).ToString();
            }


            if (playerCardMark[0] == playerCardMark[4]) {
                isPFlush = true;
                PFlushMark = playerCardMark[0];
                jokBoNum = Math.Ceiling(playerCardNum[4] % 13.1).ToString();
                jokboRank = (int)JokBo.FLUSH;

            }

            if (isPFlush && isPStrait) {
                jokboRank = (int)JokBo.ROYAL_STRAIT_FLUSH;
            }
            String playerJokbo = "";





            switch (jokboRank) {

                case (int)JokBo.NO_PAIR_TOP:
                    playerJokbo = jokBoNum + "탑";
                    break;

                case (int)JokBo.ONE_PAIR:
                    playerJokbo = jokBoNum + "원페어";
                    break;
                case (int)JokBo.TWO_PAIR:
                    playerJokbo = PTwoPair[0] + "," + PTwoPair[1] + "투페어";
                    break;
                case (int)JokBo.TRIPLE:
                    playerJokbo = jokBoNum + "트리플";
                    break;
                case (int)JokBo.FOUR_CARD:
                    playerJokbo = jokBoNum + "포카드";
                    break;
                case (int)JokBo.FLUSH:
                    playerJokbo = PFlushMark + jokBoNum + "플러쉬";
                    break;

            }       //switch

            Dictionary<String, String> playerJokboPair = new Dictionary<String, String>();
            playerJokboPair.Add("JokBoRank", jokboRank.ToString());
            playerJokboPair.Add("JokBoName", playerJokbo);
            playerJokboPair.Add("JokBoNum", jokBoNum);




            return playerJokboPair;




        }

        private Dictionary<String, String> ComputerCheckJokbo(List<int> playerCardNum, String[] playerCardMark) {

            Boolean isPStrait = false;
            Boolean isPFlush = false;
            String PStrait = "";

            String PFlushMark = "";
            String PFlushNum = "";

            String PFourCard = "";
            String PTriple = "";
            String[] PTwoPair = new String[2];
            String[] PFullHouse = new string[2];
            String POnePair = "";
            String PHighTop = "";

            String jokBoNum = "";

            int jokboRank = 0;

            int pairCount = 0;

            List<int> temp = new List<int>();

            //Console.WriteLine("컴퓨터 숫자");
            //foreach (int k in playerCardNum) {
            //    Console.Write(k +", ");
            //}
            //Console.WriteLine();

            //Console.WriteLine("컴퓨터 마크");

            //foreach (String k in playerCardMark) {
            //    Console.Write(k + ", ");
            //}
            //Console.WriteLine();


            for (int idx = 0; idx < playerCardNum.Count; idx++) {
                for (int idx1 = 0; idx1 < playerCardNum.Count; idx1++) {
                    if (playerCardNum[idx] == playerCardNum[idx1]) {
                        if (idx == idx1) continue;
                        else {
                            pairCount++;
                            temp.Add(playerCardNum[idx]);

                        }
                    }

                }
            }

            if(pairCount == 10 || pairCount == 8) {
                if(pairCount == 10) {
                    temp = temp.Distinct().ToList();
                    temp.Sort();
                    jokboRank = (int)JokBo.FULL_HOUSE;
                     
                } else {
                    jokboRank = (int)JokBo.FULL_HOUSE;

                }

            }

            if (pairCount == 12) {
                //isPFourCard = true;
                jokboRank = (int)JokBo.FOUR_CARD;
                jokBoNum = Math.Ceiling(temp[0] % 13.1).ToString();
            } else if (pairCount == 6) {

                temp = temp.Distinct().ToList();
                if (temp.Count == 1) {
                    jokboRank = (int)JokBo.TRIPLE;
                    jokBoNum = Math.Ceiling(temp[0] % 13.1).ToString();

                } else {

                    temp.Sort();
                    PTwoPair[0] = Math.Ceiling(temp[1] % 13.1).ToString();
                    PTwoPair[1] = Math.Ceiling(temp[2] % 13.1).ToString();

                }
            } else if (pairCount == 4) {
                temp.Sort();
                PTwoPair[0] = Math.Ceiling(temp[0] % 13.1).ToString();
                PTwoPair[1] = Math.Ceiling(temp[2] % 13.1).ToString();
                //isPTwoPair = true;
                jokboRank = (int)JokBo.TWO_PAIR;
            } else if (pairCount == 2) {
                jokBoNum = Math.Ceiling(temp[0] % 13.1).ToString();
                //isPOnePair = true;
                jokboRank = (int)JokBo.ONE_PAIR;
            } else {

                if (playerCardNum.Contains(1)) {
                    jokBoNum = Math.Ceiling(playerCardNum[0] % 13.1).ToString();
                } else {
                    jokBoNum = Math.Ceiling(playerCardNum[6] % 13.1).ToString();
                }
                jokboRank = (int)JokBo.NO_PAIR_TOP;
            }

            for (int idx = 0; idx < 3; idx++) {
                if (playerCardNum[idx] - playerCardNum[idx + 4] == 4) {
                    jokboRank = (int)JokBo.STRAIT;

                    jokBoNum = Math.Ceiling(playerCardNum[idx + 4] % 13.1).ToString();
                }
            }


            for (int idx = 0; idx < 3; idx++) {
                if (playerCardNum[idx] == 1 && playerCardNum[idx + 1] == 10) {
                    isPStrait = true;
                    jokboRank = (int)JokBo.STRAIT;
                    jokBoNum = Math.Ceiling(playerCardNum[idx + 4] % 13.1).ToString();
                }
            }
            for (int idx = 0; idx < 3; idx++) {
                if (playerCardMark[idx] == playerCardMark[idx + 4]) {
                    isPFlush = true;
                    PFlushMark = playerCardMark[idx];
                    jokBoNum = Math.Ceiling(playerCardNum[idx + 4] % 13.1).ToString();
                    jokboRank = (int)JokBo.FLUSH;

                }
            }





            if (isPFlush && isPStrait) {
                jokboRank = (int)JokBo.ROYAL_STRAIT_FLUSH;
            }
            String playerJokbo = "";





            switch (jokboRank) {

                case (int)JokBo.NO_PAIR_TOP:
                    playerJokbo = jokBoNum + "탑";
                    break;

                case (int)JokBo.ONE_PAIR:
                    playerJokbo = jokBoNum + "원페어";
                    break;
                case (int)JokBo.TWO_PAIR:
                    playerJokbo = PTwoPair[0] + "," + PTwoPair[1] + "투페어";
                    break;
                case (int)JokBo.TRIPLE:
                    playerJokbo = jokBoNum + "트리플";
                    break;
                case (int)JokBo.FOUR_CARD:
                    playerJokbo = jokBoNum + "포카드";
                    break;
                case (int)JokBo.FLUSH:
                    playerJokbo = PFlushMark + jokBoNum + "플러쉬";
                    break;

            }       //switch

            Dictionary<String, String> playerJokboPair = new Dictionary<String, String>();
            playerJokboPair.Add("JokBoRank", jokboRank.ToString());
            playerJokboPair.Add("JokBoName", playerJokbo);
            playerJokboPair.Add("JokBoNum", jokBoNum);




            return playerJokboPair;




        }




        private int WhoIsTheWinner(int moneyBeforeGame, int betSize, List<int> playerCard, List<int> compCard) {

            String[] trumpCardMark = new String[] { "♥", "♠", "◆", "♣" };

            int moneyAfterGame;
            Boolean isPlayerWin = false;

            String[] playerCardMark = new String[5];
            List<int> playerCardNum = new List<int>();

            for (int idx = 0; idx < playerCard.Count; idx++) {

                playerCardMark[idx] = trumpCardMark[(playerCard[idx] - 1) / 13];
                playerCardNum.Add((int)Math.Ceiling(playerCard[idx] % 13.1));
            }

            Console.WriteLine();

            String[] compCardMark = new String[7];
            List<int> compCardNum = new List<int>();

            for (int idx = 0; idx < compCard.Count; idx++) {

                compCardMark[idx] = trumpCardMark[(compCard[idx] - 1) / 13];
                compCardNum.Add((int)Math.Ceiling(compCard[idx] % 13.1));

            }



            playerCardNum.Sort();
            compCardNum.Sort();
            Console.WriteLine();



            Dictionary<String, String> playerJokboPair = PlayerCheckJokbo(playerCardNum, playerCardMark);

            Dictionary<String, String> computerJokboPair = ComputerCheckJokbo(compCardNum, compCardMark);

            String compMarkTemp = ""; 
            String playerMarkTemp ="";


            switch (computerJokboPair["JokBoNum"]) {

                case "1":
                    compMarkTemp = "A";
                    break;

                case "11":
                    compMarkTemp = "J";
                    break;

                case "12":
                    compMarkTemp = "Q";
                    break;

                case "13":
                    compMarkTemp = "K";
                    break;

                default:
                    //do nothing
                    break;


            }       //switch


            switch (playerJokboPair["JokBoNum"]) {

                case "1":
                    playerMarkTemp = "A";
                    break;

                case "11":
                    playerMarkTemp = "J";
                    break;

                case "12":
                    playerMarkTemp = "Q";
                    break;

                case "13":
                    playerMarkTemp = "K";
                    break;

                default:
                    //do nothing
                    break;


            }       //switch


            Console.WriteLine("플레이어 족보 이름: " + playerJokboPair["JokBoName"]);
            //Console.WriteLine("플레이어 족보 숫자: " + playerJokboPair["JokBoNum"]);

            Console.WriteLine("컴퓨터 족보 이름: " + computerJokboPair["JokBoName"]);
            //Console.WriteLine("컴퓨터 족보 숫자: " + computerJokboPair["JokBoNum"]);




            int playerJokboRank = 0;
            int computerJokboRank = 0;
            int playerJokboNumber = 0;
            int computerJokboNumber = 0;

            int.TryParse(playerJokboPair["JokBoRank"], out playerJokboRank);
            int.TryParse(computerJokboPair["JokBoRank"], out computerJokboRank);


            if (playerJokboRank > computerJokboRank) {
                isPlayerWin = true;
            } else if (playerJokboRank == computerJokboRank) {

                int.TryParse(playerJokboPair["JokBoNum"], out playerJokboNumber);
                int.TryParse(computerJokboPair["JokBoNum"], out computerJokboNumber);

                

                if (playerJokboNumber > computerJokboNumber) {
                    isPlayerWin = true;
                } else if (playerJokboNumber < computerJokboNumber) {
                    isPlayerWin = false;
                } else {
                    Console.WriteLine("비겼습니다. 스플릿");
                    moneyAfterGame = moneyBeforeGame;
                    return moneyAfterGame;

                }



            } else {
                isPlayerWin = false;
            }






            if (isPlayerWin) {
                moneyAfterGame = moneyBeforeGame + (betSize * 2);
                Console.WriteLine("플레이어가 이겼습니다.");
                Console.WriteLine("내 자산: {0}", moneyAfterGame);
            } else {
                moneyAfterGame = moneyBeforeGame - (betSize * 3);
                Console.WriteLine("컴퓨터가 이겼습니다.");
                Console.WriteLine("내 자산: {0}", moneyAfterGame);
            }

            return moneyAfterGame;

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

        private void ShowCompCard() {

            Console.WriteLine("컴퓨터의 카드");
            foreach (int idx in computerTrumpCard) {
                trumpCard.ShowCardInTrump(idx);
                Console.WriteLine();
            }


        }

        private void showOneExtraCard(int card) {
            trumpCard.ShowCardInTrump(card);
        }

        private void ShowMyCard() {
            Console.WriteLine("나의 카드");
            foreach (int idx in playerTrumpCard) {
                trumpCard.ShowCardInTrump(idx);
                Console.WriteLine();
            }
        }

        

        private void ShowMyCard(int idx) {
            Console.WriteLine("나의 카드");
            for (int i = 0; i < idx; i++) {
                trumpCard.ShowCardInTrump(playerTrumpCard[i]);
            }
        }



    }
}
