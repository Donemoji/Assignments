using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveManPortalAssignment {
    enum MoveMan {
        WALL, PERSON, DOT, PORTAL, DoLLAR
    }


    internal class MoveManGame {
        


        private const int GAME_WIDTH = 10;
        private const int GAME_HEIGHT = 10;
        private int[,] blocks;
        private String direction;
        private int personPosX; 
        private int personPosY;
        private Boolean isNorthPortalPass; 
        private Boolean isSouthPortalPass;
        private Boolean isEastPortalPass;
        private Boolean isWestPortalPass;

        public MoveManGame() {

            blocks = new int[GAME_WIDTH, GAME_HEIGHT];
            personPosX = 1;
            personPosY = 1;
            isNorthPortalPass = false;
            isSouthPortalPass = false;
            isEastPortalPass = false;
            isWestPortalPass= false;

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



            blocks[0, 4] = (int)MoveMan.PORTAL;
            blocks[9, 4] = (int)MoveMan.PORTAL;

            blocks[4, 0] = (int)MoveMan.PORTAL;
            blocks[4, 9] = (int)MoveMan.PORTAL;

            for (int i = 0; i <= blocks.GetUpperBound(0); i++) {
                for (int k = 0; k <= blocks.GetUpperBound(0); k++) {
                    switch (blocks[i, k]) {
                        case (int)MoveMan.WALL:
                            Console.Write("□".PadRight(2, ' '));
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

            Console.WriteLine();




        }

        public void GameStart() {

            Console.Write("방향을 입력 하시오 (w, a, s, d): ");
            direction = Console.ReadLine();
            Console.Clear();

            showMap();
            Console.WriteLine();

        }

        




        public void Show() {
            for (int i = 0; i <= blocks.GetUpperBound(0); i++) {
                for (int k = 0; k <= blocks.GetUpperBound(0); k++) {
                    switch (blocks[i, k]) {
                        case (int)MoveMan.WALL:
                            Console.Write("□".PadRight(2, ' '));
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

        private void showMap() {
            Boolean isValidKey = direction == "w" || direction == "a" || direction == "s" || direction == "d";
            
            if (isValidKey) {
                //OpenAndClosePortal();

                CalculateWallAndPortal();
                if (isNorthPortalPass) {

                    Console.Clear();
                    CoinMan coinMan = new CoinMan(personPosX, personPosY);
                    int[] position = coinMan.GameStart();
                    Console.Clear();
                    personPosX = position[0];
                    personPosY = position[1];
                    blocks[personPosX, personPosY] = (int)MoveMan.PERSON;
                    isNorthPortalPass = false;

                } else if (isSouthPortalPass) {
                    Console.Clear();
                    PuzzleGame puzzleGame = new PuzzleGame();
                    puzzleGame.GameStart();
                    Console.Clear();
                    isSouthPortalPass= false;

                } else if(isWestPortalPass) {

                    Console.Clear();
                    MineDectectionGame mineDectectionGame = new MineDectectionGame();
                    mineDectectionGame.GameStart();
                    Console.Clear();
                    isWestPortalPass=false;
                } else if (isEastPortalPass) {

                    Console.Clear();
                    TexasHoldemGame texasHoldemGame = new TexasHoldemGame();
                    texasHoldemGame.GameStart();
                    Console.Clear();

                    isEastPortalPass = false;

                } else {
                    

                }

                Show();


            } else {
                Show();
                Console.WriteLine("유효하지 않은 방향키입니다.");
            }

        }
        //WALL, PERSON, DOT, PORTAL

        private void OpenAndClosePortal() {
            isNorthPortalPass = false;
            isSouthPortalPass = false;
            isEastPortalPass = false;
            isWestPortalPass = false;


            Boolean isInitial = !(isNorthPortalPass && isSouthPortalPass && isEastPortalPass && isWestPortalPass);

            if (isInitial) {

                blocks[0, 4] = (int)MoveMan.PORTAL;     //north
                blocks[9, 4] = (int)MoveMan.PORTAL;     //south

                blocks[4, 0] = (int)MoveMan.PORTAL;     //west
                blocks[4, 9] = (int)MoveMan.PORTAL;     //east

            }






        }




        private void CalculateWallAndPortal() {

            Boolean isPlayerCheck = false;


            for (int idx1 = 0; idx1 <= blocks.GetUpperBound(0); idx1++) {
                for (int idx2 = 0; idx2 <= blocks.GetUpperBound(1); idx2++) {

                    if (blocks[idx1, idx2] == (int)MoveMan.PERSON && !(isPlayerCheck)) {

                        if (direction == "w" && (blocks[personPosX - 1, personPosY] != (int)MoveMan.WALL)) {

                            if (blocks[personPosX - 1, personPosY] == (int)MoveMan.PORTAL) {

                                blocks[personPosX - 1 + 9, personPosY] = (int)MoveMan.PORTAL;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;

                                personPosX = personPosX - 1 + 8;

                                isNorthPortalPass = true;
                                isSouthPortalPass = false; 
                                isWestPortalPass= false;
                                isEastPortalPass= false;

                                isPlayerCheck= true;

                            } else {

                                blocks[personPosX - 1, personPosY] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                personPosX = personPosX - 1;
                                isPlayerCheck = true;

                            }

                        } else if (direction == "a" && (blocks[personPosX, personPosY - 1] != (int)MoveMan.WALL)) {
                            
                            if (blocks[personPosX, personPosY - 1] == (int)MoveMan.PORTAL) {
                                
                                //blocks[personPosX, personPosY - 1 + 9] = (int)MoveMan.PORTAL;
                                //blocks[personPosX, personPosY - 1] = (int)MoveMan.WALL;
                                //blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                //blocks[personPosX, personPosY - 1 + 8] = (int)MoveMan.PERSON;

                                //personPosY = personPosY - 1 + 8;

                                isNorthPortalPass = false;
                                isSouthPortalPass = false;
                                isWestPortalPass = true;
                                isEastPortalPass = false;
                                isPlayerCheck = true;


                            } else {

                                blocks[personPosX, personPosY - 1] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                personPosY = personPosY - 1;
                                isPlayerCheck = true;

                            }

                        } else if (direction == "s" && (blocks[personPosX + 1, personPosY] != (int)MoveMan.WALL)) {
                            
                            if (blocks[personPosX + 1, personPosY] == (int)MoveMan.PORTAL) {

                                //blocks[personPosX + 1 - 9, personPosY] = (int)MoveMan.PORTAL;
                                //blocks[personPosX + 1, personPosY] = (int)MoveMan.WALL;
                                //blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                //blocks[personPosX + 1 - 8, personPosY] = (int)MoveMan.PERSON;
                                
                                //personPosX = personPosX + 1 - 8;

                                isNorthPortalPass = false;
                                isSouthPortalPass = true;
                                isWestPortalPass = false;
                                isEastPortalPass = false;
                                isPlayerCheck = true;


                            } else {

                                blocks[personPosX + 1, personPosY] = (int)MoveMan.PERSON;
                                blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                personPosX = personPosX + 1;
                                isPlayerCheck= true;



                            }

                        } else if (direction == "d" && (blocks[personPosX, personPosY + 1] != (int)MoveMan.WALL)) {
                            
                            if (blocks[personPosX, personPosY + 1] == (int)MoveMan.PORTAL) {
                                
                                //blocks[personPosX, personPosY + 1 - 9] = (int)MoveMan.PORTAL;
                                //blocks[personPosX, personPosY + 1] = (int)MoveMan.WALL;
                                //blocks[personPosX, personPosY] = (int)MoveMan.DOT;
                                //blocks[personPosX, personPosY + 1 - 8] = (int)MoveMan.PERSON;

                                //personPosY = personPosY + 1 - 8;

                                isNorthPortalPass = false;
                                isSouthPortalPass = false;
                                isWestPortalPass = false;
                                isEastPortalPass = true;

                                isPlayerCheck = true;

                            } else {

                                //바뀐 곳은 pass

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

    }
}
