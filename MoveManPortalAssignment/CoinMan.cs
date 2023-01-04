using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveManPortalAssignment {
    internal class CoinMan {

        private const int GAME_WIDTH = 10;
        private const int GAME_HEIGHT = 10;
        private int[,] blocks;
        private String direction;
        private int personPosX;
        private int personPosY;
        private Boolean isSouthPortalPass;

        public int _point = 0;

        private int coinCount;
        private int coinPosX_;
        private int coinPosY_;

        Random rnd;

        public CoinMan(int posX, int posY) {
            blocks = new int[GAME_WIDTH, GAME_HEIGHT];
            personPosX = posX;
            personPosY = posY;
            isSouthPortalPass = false;
            coinCount = 0;
            coinPosX_ = 0;
            coinPosY_ = 0;


            for (int idx1 = 0; idx1 <= blocks.GetUpperBound(0); idx1++) {
                for (int idx2 = 0; idx2 <= blocks.GetUpperBound(1); idx2++) {
                    if (idx1 == 0 || idx1 == blocks.GetUpperBound(0)) {
                        blocks[idx1, idx2] = (int)MoveMan.WALL;
                    } else {
                        if (idx2 == 0 || idx2 == blocks.GetUpperBound(1)) {
                            blocks[idx1, idx2] = (int)MoveMan.WALL;
                        } else if (idx1 == personPosX && idx2 == personPosY) {
                            blocks[idx1, idx2] = (int)MoveMan.PERSON;
                            
                        } else {
                            blocks[idx1, idx2] = (int)MoveMan.DOT;
                        }

                    }

                }
            }

            blocks[9, 4] = (int)MoveMan.PORTAL;     //south


            for (int i = 0; i <= blocks.GetUpperBound(0); i++) {
                for (int k = 0; k <= blocks.GetUpperBound(0); k++) {
                    switch (blocks[i, k]) {
                        case (int)MoveMan.WALL:
                            Console.Write("■".PadRight(2, ' '));
                            break;
                        case (int)MoveMan.PERSON:
                            Console.Write("웃".PadRight(2, ' '));
                            break;
                        case (int)MoveMan.DOT:
                            Console.Write(".".PadRight(3, ' '));
                            break;
                        case (int)MoveMan.PORTAL:
                            Console.Write("@".PadRight(3, ' '));
                            break;


                    }
                }
                Console.WriteLine();
            }



        }




        public int[] GameStart() {
            while (true) {

                Console.WriteLine();
                Console.WriteLine("POINT : {0}", _point);

                Console.Write("방향을 입력 하시오 (w, a, s, d): ");
                direction = Console.ReadLine();
                

                Console.Clear();

                ShowMap();

                if(isSouthPortalPass == true) {
                    return new int[] {personPosX, personPosY};
                } else {
                    GenerateCoin();
                }
            }
            
        }

        private void GenerateCoin() {
            rnd = new Random();

            while (true) {
                if (coinCount > 5) {
                    break;
                } else {
                    coinPosX_ = rnd.Next(0 + 1, GAME_WIDTH - 1);
                    coinPosY_ = rnd.Next(0 + 1, GAME_WIDTH - 1);


                    if ((coinPosX_ == personPosX && coinPosY_ == personPosY)) {
                        continue;
                    } else if (blocks[coinPosX_, coinPosY_] == (int)MoveMan.DoLLAR) {
                        continue;
                    } else {
                        coinCount++;
                        break;
                    }


                }
            }


            if ((coinPosX_ >= 1 && coinPosX_ <= 8) && (coinPosY_ >= 1 && coinPosY_ <= 8)) {
                blocks[coinPosX_, coinPosY_] = (int)MoveMan.DoLLAR;
            }
        }


        private void ShowMap() {
            Boolean isValidKey = direction == "w" || direction == "a" || direction == "s" || direction == "d";

            if (isValidKey) {

                CalculateWallAndPortal();

                if (isSouthPortalPass) {
                    //do nothing

                } else {
                    Show();
                }

                


            } else {
                Show();
                Console.WriteLine("유효하지 않은 방향키입니다.");
            }

        }

        private void CalculateWallAndPortal() {

            Boolean isPlayerCheck = false;


            for (int idx1 = 0; idx1 <= blocks.GetUpperBound(0); idx1++) {
                for (int idx2 = 0; idx2 <= blocks.GetUpperBound(1); idx2++) {

                    if (blocks[idx1, idx2] == (int)MoveMan.PERSON && !(isPlayerCheck)) {

                        if (direction == "w" && (blocks[personPosX - 1, personPosY] != (int)MoveMan.WALL)) {


                            if (blocks[personPosX - 1, personPosY] == (int)MoveMan.DoLLAR) {

                                blocks[personPosX - 1, personPosY] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                
                                personPosX = personPosX - 1;
                                isPlayerCheck = true;
                                
                                _point++;
                                coinCount--;

                            } else {

                                blocks[personPosX - 1, personPosY] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                
                                personPosX = personPosX - 1;
                                isPlayerCheck = true;

                            }




                        } else if (direction == "a" && (blocks[personPosX, personPosY - 1] != (int)MoveMan.WALL)) {

                            


                            if (blocks[personPosX, personPosY - 1] == (int)MoveMan.DoLLAR) {
                                
                                blocks[personPosX, personPosY - 1] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                
                                personPosY = personPosY - 1;
                                isPlayerCheck = true;

                                _point++;
                                coinCount--;


                            } else {

                                blocks[personPosX, personPosY - 1] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                
                                personPosY = personPosY - 1;
                                isPlayerCheck = true;

                            }



                        } else if (direction == "s" && (blocks[personPosX + 1, personPosY] != (int)MoveMan.WALL)) {

                            


                            if (blocks[personPosX + 1, personPosY] == (int)MoveMan.DoLLAR) {
                                
                                blocks[personPosX + 1, personPosY] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                
                                personPosX = personPosX + 1;
                                isPlayerCheck = true;
                                
                                _point++;
                                coinCount--;

                            } else if (blocks[personPosX + 1, personPosY] == (int)MoveMan.PORTAL) {
                                
                                //TODO
                                personPosX = personPosX + 1 - 8;

                                isSouthPortalPass = true;
                                isPlayerCheck = true;



                            } else {

                                blocks[personPosX + 1, personPosY] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                
                                personPosX = personPosX + 1;
                                isPlayerCheck = true;

                            }




                        } else if (direction == "d" && (blocks[personPosX, personPosY + 1] != (int)MoveMan.WALL)) {

                            

                            if (blocks[personPosX, personPosY + 1] == (int)MoveMan.DoLLAR) {
                                
                                blocks[personPosX, personPosY + 1] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;

                                personPosY = personPosY + 1;
                                isPlayerCheck = true;

                                _point++;
                                coinCount--;

                            } else {

                                blocks[personPosX, personPosY + 1] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                
                                personPosY = personPosY + 1;
                                isPlayerCheck = true;

                            }



                        } else {
                            //Console.WriteLine(personChgPos[0] + " , " + personChgPos[1]);

                            if (blocks[personPosX - 1, personPosY] == 4 || blocks[personPosX, personPosY - 1] == 4 || blocks[personPosX + 1, personPosY] == 4 || blocks[personPosX, personPosY + 1] == 4) {
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


        public void Show() {
            for (int i = 0; i <= blocks.GetUpperBound(0); i++) {
                for (int k = 0; k <= blocks.GetUpperBound(0); k++) {
                    switch (blocks[i, k]) {
                        case (int)MoveMan.WALL:
                            Console.Write("■".PadRight(2, ' '));
                            break;
                        case (int)MoveMan.PERSON:
                            Console.Write("웃".PadRight(2, ' '));
                            break;
                        case (int)MoveMan.DOT:
                            Console.Write(".".PadRight(3, ' '));
                            break;
                        case (int)MoveMan.PORTAL:
                            Console.Write("@".PadRight(3, ' '));
                            break;
                        case (int)MoveMan.DoLLAR:
                            Console.Write("$".PadRight(3, ' '));
                            break;

                    }
                }
                Console.WriteLine();
            }
        }











    }
}
