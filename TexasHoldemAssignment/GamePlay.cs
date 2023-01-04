using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldemAssignment {

    enum JokBo {
        NO_PAIR_TOP, ONE_PAIR, TWO_PAIR, TRIPLE, FOUR_CARD,
        FLUSH, STRAIT, MOUNTAIN, BACK_STRAIT, FULL_HOUSE,
        STRAIT_FLUSH, ROYAL_STRAIT_FLUSH
    }


    internal class GamePlay {
        TrumpCardDeck trumpCard;
        List<int> playerTrumpCard;
        List<int> computerTrumpCard;
        List<int> sharedTrumpCard;



        public int GameStart(int moneyBeforeGame) {
            Console.Clear();
            Console.WriteLine("게임을 시작합니다.");
            Console.WriteLine("======================================");
            Console.WriteLine("내 자산: {0}", moneyBeforeGame);
            Console.WriteLine();

            int moneyBetting;
            int moneyAfter;

            trumpCard = new TrumpCardDeck();
            trumpCard.SetUpTrumpCards();

            computerTrumpCard = trumpCard.ComputerRollCardsInTrump();
            computerTrumpCard.Sort();
            playerTrumpCard = trumpCard.PlayerRollCardsInTrump();
            playerTrumpCard.Sort();
            sharedTrumpCard = trumpCard.SharedRollCardsInTrump();
            sharedTrumpCard.Sort();



            Console.WriteLine("컴퓨터 카드");
            trumpCard.ShowCardInTrumpVertical(computerTrumpCard, 5);
            Console.WriteLine();
            Console.WriteLine("나의 카드");
            trumpCard.ShowCardInTrumpVertical(playerTrumpCard, 13);



            //1차 베팅

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

            moneyAfter = moneyBeforeGame - moneyBetting;


            //1차 베팅






            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine("내 자산: {0}", moneyAfter);
            Console.WriteLine();


            Console.WriteLine("컴퓨터 카드");
            trumpCard.ShowCardInTrumpVertical(computerTrumpCard, 4);

            Console.WriteLine();
            Console.WriteLine("나의 카드");
            trumpCard.ShowCardInTrumpVertical(playerTrumpCard, 12);



            Console.WriteLine();
            Console.WriteLine("공유 카드");
            trumpCard.ShowCardInTrumpVertical(sharedTrumpCard, 20);


            //2차 베팅


            Console.WriteLine();

            moneyBetting = HowMuchBet(moneyAfter);

            





            Console.WriteLine();


            moneyAfter = WhoIsTheWinner(moneyBeforeGame, moneyBetting, playerTrumpCard, computerTrumpCard, sharedTrumpCard);

            Console.ReadLine();
            Console.Clear();

            return moneyAfter;


        }

        private String SwitchAceToFourteen(String item) {

            String switched = "";
            switch (item) {

                case "1":
                    switched = "14";
                    break;

                case "A":
                    switched = "14";
                    break;

                case "J":
                    switched = "11";
                    break;

                case "Q":
                    switched = "12";
                    break;

                case "K":
                    switched = "13";
                    break;

                default:
                    switched = item;
                    break;


            }       //switch

            return switched;
        }



        private int WhoIsTheWinner(int moneyBeforeGame, int betSize, List<int> playerCard, List<int> compCard, List<int> sharedCard) {

            String[] trumpCardMark = new String[] { "♥", "♠", "◆", "♣" };

            int moneyAfterGame;
            Boolean isPlayerWin = false;

            String[] playerCardMark = new String[7];
            List<int> playerCardNum = new List<int>();

            String[] computerCardMark = new String[7];
            List<int> computerCardNum = new List<int>();

            String[] sharedCardMark = new String[5];
            List<int> sharedCardNum = new List<int>();


            for (int idx = 0; idx < playerCard.Count; idx++) {

                playerCardMark[idx] = trumpCardMark[(playerCard[idx] - 1) / 13];
                playerCardNum.Add((int)Math.Ceiling(playerCard[idx] % 13.1));
            }



            for (int idx = 0; idx < compCard.Count; idx++) {

                computerCardMark[idx] = trumpCardMark[(compCard[idx] - 1) / 13];
                computerCardNum.Add((int)Math.Ceiling(compCard[idx] % 13.1));

            }

            for (int idx = 0; idx < sharedCard.Count; idx++) {

                sharedCardMark[idx] = trumpCardMark[(sharedCard[idx] - 1) / 13];
                sharedCardNum.Add((int)Math.Ceiling(sharedCard[idx] % 13.1));

                playerCardMark[idx + 2] = sharedCardMark[idx];
                playerCardNum.Add((int)Math.Ceiling(sharedCard[idx] % 13.1));

                computerCardMark[idx + 2] = sharedCardMark[idx];
                computerCardNum.Add((int)Math.Ceiling(sharedCard[idx] % 13.1));

            }



            Dictionary<String, String> computerJokboPair = CheckJokbo(computerCardNum, computerCardMark);

            Dictionary<String, String> playerJokboPair = CheckJokbo(playerCardNum, playerCardMark);


            String compNumTemp = "";
            String playerNumTemp = "";


            switch (computerJokboPair["JokBoNum"]) {

                case "A":
                    compNumTemp = "14";
                    break;

                case "J":
                    compNumTemp = "11";
                    break;

                case "Q":
                    compNumTemp = "12";
                    break;

                case "K":
                    compNumTemp = "13";
                    break;

                default:
                    compNumTemp = computerJokboPair["JokBoNum"];
                    break;


            }       //switch


            switch (playerJokboPair["JokBoNum"]) {

                case "A":
                    playerNumTemp = "14";
                    break;

                case "J":
                    playerNumTemp = "11";
                    break;

                case "Q":
                    playerNumTemp = "12";
                    break;

                case "K":
                    playerNumTemp = "13";
                    break;

                default:
                    playerNumTemp = playerJokboPair["JokBoNum"];
                    break;


            }       //switch





            Console.WriteLine("플레이어 족보 이름: " + playerJokboPair["JokBoName"]);

            Console.WriteLine("컴퓨터 족보 이름: " + computerJokboPair["JokBoName"]);
            Console.WriteLine();

            int playerJokboRank = 0;
            int computerJokboRank = 0;
            int playerJokboNumber = 0;
            int computerJokboNumber = 0;

            int.TryParse(playerJokboPair["JokBoRank"], out playerJokboRank);
            int.TryParse(computerJokboPair["JokBoRank"], out computerJokboRank);


            if (playerJokboRank > computerJokboRank) {
                isPlayerWin = true;
            } else if (playerJokboRank == computerJokboRank) {

                int.TryParse(playerNumTemp, out playerJokboNumber);
                int.TryParse(compNumTemp, out computerJokboNumber);



                if (playerJokboNumber > computerJokboNumber) {
                    isPlayerWin = true;
                } else if (playerJokboNumber < computerJokboNumber) {
                    isPlayerWin = false;
                } else {

                    if(playerJokboRank == (int)JokBo.FULL_HOUSE || playerJokboRank == (int)JokBo.TWO_PAIR) {
                        int playerSecondNumber =0;
                        int computerSecondNumber =0;
                        
                        int.TryParse(SwitchAceToFourteen(playerJokboPair["JokBoNumExtra"]), out playerSecondNumber);
                        int.TryParse(SwitchAceToFourteen(computerJokboPair["JokBoNumExtra"]), out computerSecondNumber);

                        if(playerSecondNumber > computerSecondNumber) {
                            isPlayerWin = true;

                        } else if(playerSecondNumber < computerSecondNumber) {
                            isPlayerWin = false;

                        } else {
                            Console.WriteLine("비겼습니다. 스플릿");
                            moneyAfterGame = moneyBeforeGame;
                            return moneyAfterGame;
                        }


                    } else {
                        Console.WriteLine("비겼습니다. 스플릿");
                        moneyAfterGame = moneyBeforeGame;
                        return moneyAfterGame;
                    }


                }



            } else {
                isPlayerWin = false;
            }



            if (isPlayerWin) {
                moneyAfterGame = moneyBeforeGame + (betSize * 2);
                Console.WriteLine("플레이어가 이겼습니다.");
                Console.WriteLine("내 자산: {0}", moneyAfterGame);
            } else {
                moneyAfterGame = moneyBeforeGame - (betSize * 2);
                Console.WriteLine("컴퓨터가 이겼습니다.");
                Console.WriteLine("내 자산: {0}", moneyAfterGame);
            }

            return moneyAfterGame;

        }

        private Dictionary<String, String> CheckJokbo(List<int> cardNum, String[] cardMark) {
            Dictionary<String, String> playerJokboPair = new Dictionary<String, String>();

            Boolean isPStrait = false;
            Boolean isPFlush = false;
            Boolean isBackStrait = false;


            String PFlushMark = "";

            String[] PTwoPair = new String[2];
            String[] PFullHouse = new string[2];

            String jokBoNum = "";

            int jokboRank = 0;

            int pairCount = 0;

            List<int> temp = new List<int>();

            List<int> tempNum = cardNum.ToList();
            tempNum.Sort();


            for (int idx = 0; idx < cardNum.Count; idx++) {
                for (int idx1 = 0; idx1 < cardNum.Count; idx1++) {
                   
                    if(idx == idx1) {
                        continue;
                    } else {
                        if(cardNum[idx] == cardNum[idx1]) {
                            temp.Add(cardNum[idx]);
                            //Console.WriteLine(1);
                            pairCount++;
                        }
                    }
                   
                }
            }
            //Console.WriteLine(pairCount);






            if (pairCount == 10 || pairCount == 8 || pairCount == 14 || pairCount == 18) {
                // 10-> 3, 2, 2    8 -> 3, 2         14 -> 4, 2         18 -> 4, 3
                if (pairCount == 10) {
                    temp = temp.Distinct().ToList();
                    temp.Sort();
                    jokboRank = (int)JokBo.FULL_HOUSE;

                    if (temp.Contains(1)) {
                        PFullHouse[0] = Math.Ceiling(temp[2] % 13.1).ToString();
                        PFullHouse[1] = Math.Ceiling(temp[0] % 13.1).ToString();

                    } else {
                        PFullHouse[0] = Math.Ceiling(temp[1] % 13.1).ToString();
                        PFullHouse[1] = Math.Ceiling(temp[2] % 13.1).ToString();

                    }

                } else {
                    temp = temp.Distinct().ToList();
                    temp.Sort();
                    jokboRank = (int)JokBo.FULL_HOUSE;

                    if (temp.Contains(1)) {
                        PFullHouse[0] = Math.Ceiling(temp[1] % 13.1).ToString();
                        PFullHouse[1] = Math.Ceiling(temp[0] % 13.1).ToString();

                    } else {
                        PFullHouse[0] = Math.Ceiling(temp[0] % 13.1).ToString();
                        PFullHouse[1] = Math.Ceiling(temp[1] % 13.1).ToString();

                    }



                }

            } else if (pairCount == 12) {
               
                temp = temp.Distinct().ToList();
                temp.Sort();

                if(temp.Count == 2) {
                    if (temp.Contains(1)) {
                        PFullHouse[0] = Math.Ceiling(temp[1] % 13.1).ToString();
                        PFullHouse[1] = Math.Ceiling(temp[0] % 13.1).ToString();

                    } else {
                        PFullHouse[0] = Math.Ceiling(temp[0] % 13.1).ToString();
                        PFullHouse[1] = Math.Ceiling(temp[1] % 13.1).ToString();

                    }



                } else {
                    jokboRank = (int)JokBo.FOUR_CARD;
                    jokBoNum = Math.Ceiling(temp[0] % 13.1).ToString();

                }

            } else if (pairCount == 6) {

                temp = temp.Distinct().ToList();
                if (temp.Count == 1) {
                    jokboRank = (int)JokBo.TRIPLE;
                    jokBoNum = Math.Ceiling(temp[0] % 13.1).ToString();

                } else if (temp.Count == 3){

                    temp.Sort();

                    if (temp.Contains(1)) {
                        PTwoPair[0] = Math.Ceiling(temp[2] % 13.1).ToString();
                        PTwoPair[1] = Math.Ceiling(temp[0] % 13.1).ToString();

                    } else {
                        PTwoPair[0] = Math.Ceiling(temp[1] % 13.1).ToString();
                        PTwoPair[1] = Math.Ceiling(temp[2] % 13.1).ToString();

                    }

                    jokboRank = (int)JokBo.TWO_PAIR;



                }
            } else if (pairCount == 4) {

                temp = temp.Distinct().ToList();
                temp.Sort();

                if (temp.Contains(1)) {
                    PTwoPair[0] = Math.Ceiling(temp[1] % 13.1).ToString();
                    PTwoPair[1] = Math.Ceiling(temp[0] % 13.1).ToString();

                } else {
                    PTwoPair[0] = Math.Ceiling(temp[0] % 13.1).ToString();
                    PTwoPair[1] = Math.Ceiling(temp[1] % 13.1).ToString();

                }
                jokboRank = (int)JokBo.TWO_PAIR;

            } else if (pairCount == 2) {
                jokBoNum = Math.Ceiling(temp[0] % 13.1).ToString();
                
                jokboRank = (int)JokBo.ONE_PAIR;
            } else {

                if (cardNum.Contains(1)) {
                    jokBoNum = Math.Ceiling(tempNum[0] % 13.1).ToString();
                } else {
                    jokBoNum = Math.Ceiling(tempNum[6] % 13.1).ToString();
                }
                jokboRank = (int)JokBo.NO_PAIR_TOP;
            }




            cardNum.Sort();

            foreach (int item in cardNum) {
                Console.Write(item+", ");
            }
            Console.WriteLine();


            List<int> tempStraitCheck = cardNum.ToList();
            
            tempStraitCheck = tempStraitCheck.Distinct().ToList();
            tempStraitCheck.Sort();

            if (tempStraitCheck.Count == 6) {
                for (int idx = 0; idx < 2; idx++) {
                    if (tempStraitCheck[idx + 4] - tempStraitCheck[idx] == 4) {
                        isPStrait = true;

                        jokboRank = (int)JokBo.STRAIT;

                        jokBoNum = Math.Ceiling(tempStraitCheck[idx + 4] % 13.1).ToString();
                    }
                }

                for (int idx = 0; idx < 2; idx++) {
                    if (tempStraitCheck[idx] == 1 && tempStraitCheck[idx + 1] == 10) {
                        isBackStrait = true;
                        jokboRank = (int)JokBo.STRAIT;
                        jokBoNum = Math.Ceiling(tempStraitCheck[idx] % 13.1).ToString();
                    }
                }
            } else if (tempStraitCheck.Count == 5) {

                if (tempStraitCheck[4] - tempStraitCheck[0] == 4) {
                    isPStrait = true;


                    jokboRank = (int)JokBo.STRAIT;
                    jokBoNum = Math.Ceiling(tempStraitCheck[4] % 13.1).ToString();
                }

                if (tempStraitCheck[0] == 1 && tempStraitCheck[1] == 10) {
                    isBackStrait = true;
                    jokboRank = (int)JokBo.STRAIT;
                    jokBoNum = Math.Ceiling(tempStraitCheck[0] % 13.1).ToString();
                }





            } else if (tempStraitCheck.Count == 7) {

                for (int idx = 0; idx < 3; idx++) {
                    if (tempStraitCheck[idx + 4] - tempStraitCheck[idx] == 4) {
                        isPStrait = true;

                        jokboRank = (int)JokBo.STRAIT;

                        jokBoNum = Math.Ceiling(tempStraitCheck[idx + 4] % 13.1).ToString();
                    }
                }

                for (int idx = 0; idx < 3; idx++) {
                    if (tempStraitCheck[idx] == 1 && tempStraitCheck[idx + 1] == 10) {
                        isBackStrait = true;

                        jokboRank = (int)JokBo.STRAIT;
                        jokBoNum = Math.Ceiling(tempStraitCheck[idx] % 13.1).ToString();
                    }
                }
            } else {
                //do nothing
            }

            List<String> tempMarkCheck = cardMark.ToList();
            tempMarkCheck.Sort();
            
            for (int idx = 0; idx < 3; idx++) {
                if (tempMarkCheck[idx] == tempMarkCheck[idx + 4]) {
                    isPFlush = true;
                    PFlushMark = tempMarkCheck[idx];
                    jokboRank = (int)JokBo.FLUSH;

                    

                    if(jokboRank != (int)JokBo.STRAIT) {
                        jokBoNum = "";
                    }

                }
            }




            if (isPFlush && isPStrait) {
                jokboRank = (int)JokBo.STRAIT_FLUSH;

            }

            if (isPFlush && isBackStrait) {
                jokboRank = (int)JokBo.ROYAL_STRAIT_FLUSH;
            }


            String playerJokbo = "";


            switch (jokBoNum) {

                case "1":
                    jokBoNum = "A";
                    break;

                case "11":
                    jokBoNum = "J";
                    break;

                case "12":
                    jokBoNum = "Q";
                    break;

                case "13":
                    jokBoNum = "K";
                    break;

                default:
                    //do nothing
                    break;

            }

            if(jokboRank == (int)JokBo.FULL_HOUSE) {
                jokBoNum = GetMark(PFullHouse[1]);
                playerJokboPair.Add("JokBoNumExtra", PFullHouse[0]);

                PFullHouse[0] = GetMark(PFullHouse[0]);
                PFullHouse[1] = GetMark(PFullHouse[1]);


            } else if(jokboRank == (int)JokBo.TWO_PAIR) {
                jokBoNum = GetMark(PTwoPair[1]);
                playerJokboPair.Add("JokBoNumExtra", PTwoPair[0]);

                PTwoPair[0] = GetMark(PTwoPair[0]);
                PTwoPair[1] = GetMark(PTwoPair[1]);

            }



            switch (jokboRank) {

                case (int)JokBo.NO_PAIR_TOP:
                    playerJokbo = jokBoNum + " 탑";
                    break;

                case (int)JokBo.ONE_PAIR:
                    playerJokbo = jokBoNum + " 원페어";
                    break;
                case (int)JokBo.TWO_PAIR:
                    playerJokbo = PTwoPair[0] + " , " + PTwoPair[1] + " 투페어";
                    break;
                case (int)JokBo.TRIPLE:
                    playerJokbo = jokBoNum + " 트리플";
                    break;
                case (int)JokBo.FOUR_CARD:
                    playerJokbo = jokBoNum + " 포카드";
                    break;
                case (int)JokBo.FLUSH:
                    playerJokbo = PFlushMark + jokBoNum + " 플러쉬";
                    break;
                case (int)JokBo.STRAIT_FLUSH:
                    playerJokbo = PFlushMark + jokBoNum + " 스트레이트 플러쉬";
                    break;
                case (int)JokBo.ROYAL_STRAIT_FLUSH:
                    playerJokbo = "로열 스트레이트 플러쉬";
                    break;
                case (int)JokBo.FULL_HOUSE:
                    playerJokbo = PFullHouse[0] + " , " + PFullHouse[1] + " 풀하우스 ";
                    break;
                case (int)JokBo.STRAIT:
                    playerJokbo = jokBoNum + " 스트레이트 ";
                    break;





            }       //switch

            playerJokboPair.Add("JokBoRank", jokboRank.ToString());
            playerJokboPair.Add("JokBoName", playerJokbo);
            
            
            playerJokboPair.Add("JokBoNum", jokBoNum);




            return playerJokboPair;




        }

        private String GetMark(String mark) {
            String returnmark = "";
            switch (mark) {

                case "1":
                    returnmark = "A";
                    break;

                case "11":
                    returnmark = "J";
                    break;

                case "12":
                    returnmark = "Q";
                    break;

                case "13":
                    returnmark = "K";
                    break;

                default:
                    returnmark = mark;
                    //do nothing
                    break;

            }

            return returnmark;

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









    }       //class
}
