using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveManPortalAssignment {
    internal class TexasHoldemGame {
        public void GameStart() {
            int money = 10000;

            TexasHoldemGamePlay gamePlay = new TexasHoldemGamePlay();

            while (true) {
                money = gamePlay.GameStart(money);

                if (money >= 100000) {
                    Console.WriteLine("내가 번 돈 : {0}원", money);
                    Console.WriteLine("==========================게임 승리!==========================");
                    break;
                } else if (money <= 0) {
                    Console.WriteLine("파산 : {0}원", money);
                    Console.WriteLine("==========================게임 패배!==========================");
                    break;
                }




            }
        }



    }
}
