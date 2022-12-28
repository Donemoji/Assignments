namespace AssignmentBlackJack {
    internal class Program {
        static void Main(string[] args) {

            // - 컴퓨터가 2장을 뽑아서 보여준다. 
            // - 플레이어가 베팅을 한다. (패스 하려면 0 포인트를 베팅) 
            // - 플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 있는 카드라면
            //   플레이어가 2배 벌어 간다.
            // - 플레이어가 뽑은 카드가 컴퓨터가 뽑은 2장의 카드 사이에 없다면 
            //   플레이어는 베팅금액을 잃음 
            // - 플레이어는 10000 포인트를 들고 게임을 시작함
            // - 게임종료는 100000 포인트를 벌거나 모두 잃을때

            int money = 10000; 

            GamePlay gamePlay = new GamePlay();

            while (true) {
                money = gamePlay.GameStart(money);

                if(money >= 100000) {
                    Console.WriteLine("내가 번 돈 : {0}원", money);
                    Console.WriteLine("==========================게임 승리!==========================");
                    break;
                }else if(money <= 0) {
                    Console.WriteLine("파산 : {0}원", money);
                    Console.WriteLine("==========================게임 패배!==========================");
                    break;
                }




            }


             





        }
    }
}