namespace Assognments3 {
    internal class Program {
        static void Main(string[] args) {
            // wall은 0 
            // 사람은 1 
            // 빈 공간은 2
            
            //변수 선언
            int[,] blocks = new int[5, 5];
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
                
                Console.Write("방향을 입력 하시오: ");
                direction = Console.ReadLine();
                //showMap() 메소드 사용, 파라미터로 방향, 현재 포지션 x,y, 배열을 전달
                int[] positionChg = showMap(blocks, direction, personPosX, personPosY);
                personPosX = positionChg[0];
                personPosY = positionChg[1];
                

            }




        }

        static int[] showMap(int[,] blocks, String direction, int posX, int posY) {

            Boolean isValidKey = false;
            int[] personChgPos = new int[2] { posX, posY };

            isValidKey = direction == "w" || direction == "a" || direction == "s" || direction == "d";
            if(isValidKey == false) {
                Console.WriteLine("유효하지 않은 방향키입니다.");
                return personChgPos;
            }



            for(int idx1 = 0; idx1 <= blocks.GetUpperBound(0); idx1++) {
                for(int idx2 = 0; idx2 <= blocks.GetUpperBound(1); idx2++) {
                    if (blocks[idx1, idx2] == 1) {

                        if (direction == "w" && (blocks[posX-1, posY] != 0)) {
                            
                            blocks[posX-1, posY] = 1;
                            blocks[posX, posY] = 2;
                            personChgPos[0] = posX-1;
                            personChgPos[1] = posY;
                            
                            
                        } else if(direction == "a" && (blocks[posX, posY - 1] != 0)) {
                            
                            blocks[posX, posY - 1] = 1;
                            blocks[posX, posY] = 2;

                            personChgPos[0] = posX;
                            personChgPos[1] = posY - 1;
                        } else if (direction == "s" && (blocks[posX + 1, posY] != 0)) {
                            
                            blocks[posX + 1, posY] = 1;
                            blocks[posX, posY] = 2;
                            personChgPos[0] = posX + 1;
                            personChgPos[1] = posY;
                        } else if(direction == "d" && (blocks[posX, posY + 1] != 0)) {

                            blocks[posX, posY + 1] = 1;
                            blocks[posX, posY] = 2;
                            personChgPos[0] = posX;
                            personChgPos[1] = posY + 1;
                        } else {
                            Console.WriteLine("벽입니다.");
                        }
                        
                        
                        
                        


                    }





                }

            }

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

            return personChgPos;
        }

    }
}