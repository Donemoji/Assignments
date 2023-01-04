namespace Assognments3 {
    internal class Program {

        static int GAME_WIDTH = 10;
        static int GAME_HEIGHT = 10;
        static int _point = 0;
        static void Main(string[] args) {

            

            //Task.Delay(300).Wait();

            // wall은 0 
            // 사람은 1 
            // 빈 공간은 2
            // 코인은 3



            //변수 선언
            int[,] blocks = new int[GAME_WIDTH, GAME_HEIGHT];
            String direction = "";
            int personPosX = 1, personPosY = 1;

            //처음에 값 넣기. 
            for (int idx1 = 0; idx1 <= blocks.GetUpperBound(0); idx1++) {
                for (int idx2 = 0; idx2 <= blocks.GetUpperBound(1); idx2++) {
                    if (idx1 == 0 || idx1 == blocks.GetUpperBound(0)) {
                        blocks[idx1, idx2] = 0;
                    } else {
                        if (idx2 == 0 || idx2 == blocks.GetUpperBound(1)) {
                            blocks[idx1, idx2] = 0;
                        } else if (idx1 == 1 && idx2 == 1) {
                            blocks[idx1, idx2] = 1;
                            personPosX = idx1; 
                            personPosY = idx2;

                        } else {
                            blocks[idx1, idx2] = 2;
                        }

                    }

                }
            }



            //반복문 돌아가기전 initial 출력
            Console.WriteLine();
            for (int i = 0; i <= blocks.GetUpperBound(0); i++) {
                for (int k = 0; k <= blocks.GetUpperBound(0); k++) {
                    switch (blocks[i, k]) {
                        case 0:
                            Console.Write("□".PadRight(2, ' '));
                            break;
                        case 1:
                            Console.Write("웃".PadRight(2, ' '));
                            break;
                        case 2:
                            Console.Write(".".PadRight(3, ' '));
                            break;

                    }
                }
                Console.WriteLine();
            }


            //게임 시작
            while (true) {
                Console.WriteLine();
                Console.WriteLine("POINT : {0}", _point);
                Console.Write("방향을 입력 하시오: ");
                direction = Console.ReadLine();
                Console.Clear();
                
                Console.WriteLine();
                int[] positionChg = showMap(blocks, direction, personPosX, personPosY);
                personPosX = positionChg[0];
                personPosY = positionChg[1];
                


            }




        }

       

        static int coinCount = 0;
        static Boolean isPass = false;


        static int[] showMap(int[,] blocks, String direction, int posX, int posY) {

            Boolean isValidKey = false;
            int[] personChgPos = new int[2] { posX, posY };

            List<int[]> coinPoslist = new List<int[]>();
            

            


            isValidKey = direction == "w" || direction == "a" || direction == "s" || direction == "d";
            if(isValidKey == false) {
                
                Console.WriteLine("유효하지 않은 방향키입니다.");
                

            } else {

                for (int idx1 = 0; idx1 <= blocks.GetUpperBound(0); idx1++) {
                    for (int idx2 = 0; idx2 <= blocks.GetUpperBound(1); idx2++) {
                        
                        if (blocks[idx1, idx2] == 1) {
                            //Console.WriteLine("내 포지션: "+idx1 +","+idx2);

                            if (direction == "w" && (blocks[posX - 1, posY] != 0)) {

                                if (blocks[posX - 1, posY] == 3) {

                                    blocks[posX - 1, posY] = 1;
                                    blocks[posX, posY] = 2;
                                    personChgPos[0] = posX - 1;
                                    personChgPos[1] = posY;
                                    _point++;
                                    coinCount--;

                                } else if (blocks[posX - 1, posY] == 4) {

                                    blocks[posX - 1 + 9, posY] = 4;

                                    blocks[posX - 1, posY] = 0;
                                    blocks[posX, posY] = 2;

                                    blocks[posX - 1 +8, posY] = 1;
                                    
                                    personChgPos[0] = posX - 1 + 8;
                                    personChgPos[1] = posY;
                                    isPass= true;
                                    
                                  

                                } else {
                                    blocks[posX - 1, posY] = 1;
                                    blocks[posX, posY] = 2;
                                    personChgPos[0] = posX - 1;
                                    personChgPos[1] = posY;

                                }


                            } else if (direction == "a" && (blocks[posX, posY - 1] != 0)) {
                                if(blocks[posX, posY - 1] == 3) {
                                    blocks[posX, posY - 1] = 1;
                                    blocks[posX, posY] = 2;

                                    personChgPos[0] = posX;
                                    personChgPos[1] = posY - 1;
                                    _point++;
                                    coinCount--;


                                } else {
                                    blocks[posX, posY - 1] = 1;
                                    blocks[posX, posY] = 2;

                                    personChgPos[0] = posX;
                                    personChgPos[1] = posY - 1;

                                }
                            } else if (direction == "s" && (blocks[posX + 1, posY] != 0)) {
                                if (blocks[posX + 1, posY] == 3) {
                                    blocks[posX + 1, posY] = 1;
                                    blocks[posX, posY] = 2;
                                    personChgPos[0] = posX + 1;
                                    personChgPos[1] = posY;
                                    _point++;
                                    coinCount--;

                                } else if (blocks[posX + 1, posY] == 4) {

                                    blocks[posX + 1 - 9, posY] = 4;

                                    blocks[posX + 1, posY] = 0;
                                    blocks[posX, posY] = 2;

                                    blocks[posX + 1 - 8, posY] = 1;

                                    personChgPos[0] = posX + 1 - 8;
                                    personChgPos[1] = posY;
                                    isPass = false;



                                } else {
                                    blocks[posX + 1, posY] = 1;
                                    blocks[posX, posY] = 2;
                                    personChgPos[0] = posX + 1;
                                    personChgPos[1] = posY;

                                }
                            } else if (direction == "d" && (blocks[posX, posY + 1] != 0)) {
                                if (blocks[posX, posY + 1] == 3) {
                                    blocks[posX, posY + 1] = 1;
                                    blocks[posX, posY] = 2;
                                    personChgPos[0] = posX;
                                    personChgPos[1] = posY + 1;
                                    _point++;
                                    coinCount--;

                                } else {
                                    blocks[posX, posY + 1] = 1;
                                    blocks[posX, posY] = 2;
                                    personChgPos[0] = posX;
                                    personChgPos[1] = posY + 1;

                                }
                            }else if (direction == "w" && (blocks[posX - 1, posY] == 4)) {

                            }else {
                                Console.WriteLine(personChgPos[0] + " , " + personChgPos[1]);

                                if (blocks[posX - 1, posY] == 4 || blocks[posX, posY-1] == 4 || blocks[posX + 1, posY] == 4 || blocks[posX, posY + 1] == 4) {
                                    Console.WriteLine("ddd");
                                } else {
                                    //Console.WriteLine(posX + " , " + posY);

                                    //Console.WriteLine("벽입니다! 다시 방향을 입력하시오.");
                                }
                            }

                        }

                    }

                }       // for end

            }

            if(_point > 0 && isPass == false) {
                blocks[0, 4] = 4;
                //blocks[0, 5] = 4;
            }

            if (isPass) {

            }

            //코인 생긴곳에 생기는지 체크
            int coinPosX_ =0;
            int coinPosY_ =0;

            Random rnd = new Random();
            while (true) {
                if (coinCount > 5) {
                    break;
                } else {
                    coinPosX_ = rnd.Next(0 + 1, GAME_WIDTH - 1);
                    coinPosY_ = rnd.Next(0 + 1, GAME_WIDTH - 1);
                    
                    

                   
                    if((coinPosX_ == personChgPos[0] && coinPosY_ == personChgPos[1])) {
                        continue;
                    } else if(blocks[coinPosX_, coinPosY_] == 3) {
                        continue;
                    } else {
                        coinCount++;
                        break;
                    }


                }
            }


            if ((coinPosX_ >= 1 && coinPosX_ <= 8) && (coinPosY_ >= 1 && coinPosY_ <= 8)) {
                blocks[coinPosX_, coinPosY_] = 3;
                coinPoslist.Add(new int[] { coinPosX_, coinPosY_ });
            }

            //foreach (int[] k in coinPoslist) {
            //    Console.WriteLine(k[0] + "," + k[1]);

                
            //}






            for (int i = 0; i <= blocks.GetUpperBound(0); i++) {
                for (int k = 0; k <= blocks.GetUpperBound(0); k++) {
                    switch (blocks[i, k]) {
                        case 0:
                            Console.Write("□".PadRight(2, ' '));
                            break;
                        case 1:
                            Console.Write("웃".PadRight(2, ' '));
                            break;
                        case 2:
                            Console.Write(".".PadRight(3, ' '));
                            break;
                        case 3:
                            Console.Write("$".PadRight(3, ' '));
                            break;
                        case 4:
                            Console.Write("@".PadRight(3, ' '));
                            break;


                    }
                }
                Console.WriteLine();
            }

            return personChgPos;
        }

    }
}