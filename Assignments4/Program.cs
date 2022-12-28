using System;
using System.Reflection.Metadata.Ecma335;

namespace Assignments4 {
    internal class Program {
        static void Main(string[] args) {

            Boolean isWin = false;

            int[,] randomNumberValue = GameInit();

            int[,] answer = AnswerInit(randomNumberValue);

            int posX = 0; 
            int posY = 0;



            while (true) {
                isWin = checkWin(randomNumberValue, answer);
                showMap(randomNumberValue);
                if (isWin) {
                    Console.WriteLine("축하합니다 승리 했습니다!");
                    break;
                }

                Console.Write("방향을 입력하시오: ");
                String direction = Console.ReadLine();
                
                int[] posChg = readDirection(direction, randomNumberValue, posX, posY);
                posX = posChg[0];
                posY = posChg[1];
                
                
            }

            


        }

        public static int[,] AnswerInit(int[,] rndValue) {

            int[,] answer = new int[(rndValue.GetUpperBound(0) + 1), (rndValue.GetUpperBound(1) + 1)];

            int numAnsIdx = 1;
            for (int idx1 = 0; idx1 <= answer.GetUpperBound(0); idx1++) {
                for (int idx2 = 0; idx2 <= answer.GetUpperBound(1); idx2++) {

                    if (idx1 == answer.GetUpperBound(0) && idx2 == answer.GetUpperBound(1)) {
                        answer[idx1, idx2] = 0;
                    } else {
                        answer[idx1, idx2] = numAnsIdx++;

                    }

                }

            }

            return answer;
        }

        public static Boolean checkWin(int[,] rndNumVal, int[,] answer) {

            for(int k =0; k<= rndNumVal.GetUpperBound(0); k++) {
                for (int y = 0; y <= rndNumVal.GetUpperBound(1); y++) {
                    if (rndNumVal[k,y] != answer[k, y]) {
                        return false;
                    }
                }
            }

            return true; 

        }

        public static int[,] GameInit() {

            Random random = new Random();
            int[] tempRndNumVal = new int[9];
            int[,] randomNumberValue = new int[3, 3];

            for (int k = 1; k < tempRndNumVal.Length; k++) {
                int tempInt = random.Next(1, tempRndNumVal.Length);

                for (int i = 0; i < tempRndNumVal.Length; i++) {
                    if (i == k) {
                        continue;
                    } else if (tempInt == tempRndNumVal[i]) {
                        k--;
                        break;
                    } else {
                        tempRndNumVal[k] = tempInt;
                    }

                }
            }

           

            int idxNum = 0;

            for (int k = 0; k <= randomNumberValue.GetUpperBound(0); k++) {

                for (int i = 0; i <= randomNumberValue.GetUpperBound(1); i++) {
                    randomNumberValue[k, i] = tempRndNumVal[idxNum++];
                }


            }

            return randomNumberValue;
        }



        public static int[] readDirection(String direction, int[,] rndNumVal, int posX, int posY) {

            int[] xChgPos = new int[2] { posX, posY };

            if(direction == "w" && (0 <= posX - 1 && posX-1 <= rndNumVal.GetUpperBound(0))) {
                int temp = rndNumVal[posX - 1, posY];

                rndNumVal[posX - 1, posY] = rndNumVal[posX, posY];

                rndNumVal[posX, posY] = temp;

                xChgPos[0] = posX - 1;
                xChgPos[1] = posY;


            } else if(direction == "a" && (0 <= posY - 1 && posY - 1 <= rndNumVal.GetUpperBound(0))) {
                int temp = rndNumVal[posX, posY-1];

                rndNumVal[posX, posY-1] = rndNumVal[posX, posY];

                rndNumVal[posX, posY] = temp;

                xChgPos[0] = posX;
                xChgPos[1] = posY - 1;


            } else if(direction == "s" && (0 <= posX + 1 && posX + 1 <= rndNumVal.GetUpperBound(0))) {
                int temp = rndNumVal[posX+1, posY];

                rndNumVal[posX+1, posY] = rndNumVal[posX, posY];

                rndNumVal[posX, posY] = temp;

                xChgPos[0] = posX + 1;
                xChgPos[1] = posY;
            } else if(direction == "d" && (0 <= posY + 1 && posY + 1 <= rndNumVal.GetUpperBound(0))) {
                int temp = rndNumVal[posX , posY+1];

                rndNumVal[posX , posY+1] = rndNumVal[posX, posY];

                rndNumVal[posX, posY] = temp;

                xChgPos[0] = posX;
                xChgPos[1] = posY + 1;
            } else {
                
            }

            return xChgPos;
        }

        public static void showMap(int[,] rndNums) {
            Console.Clear();
            Console.WriteLine("==================== 퍼즐 맞추기 =======================");
            Console.WriteLine("========================================================");
            for(int idx1 = 0; idx1 <= rndNums.GetUpperBound(0); idx1++) {
                for(int idx2 = 0; idx2 <= rndNums.GetUpperBound(1); idx2++) {
                    switch(rndNums[idx1, idx2]) {
                        case 0:
                            Console.Write("X".PadRight(10, ' '));
                            break;
                        default:
                            Console.Write("{0}".PadRight(12, ' '), rndNums[idx1, idx2]);
                            break;

                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("========================================================");
            
            



        }


    }
}