namespace AssignmentPoker {
    internal class Program {
        static void Main(string[] args) {


            int money = 10000;

            GamePlay gamePlay = new GamePlay();

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