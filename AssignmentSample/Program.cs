namespace AssignmentSample {
    internal class Program {
        static void Main(string[] args) {


            List<char> snake = new List<char>();


            char ch = '*';

            for (int idx =0; idx <4; idx++) {
                snake.Add(ch);
            }
            bool gameLive = true;
            ConsoleKeyInfo consoleKey; 

            
            int x = 30, y = 20; 
            int dx = 1, dy = 0;
            int consoleWidthLimit = 80;
            int consoleHeightLimit = 24;
            Console.SetWindowSize(consoleWidthLimit+2, consoleHeightLimit+2);



            do 
            {
                Console.SetCursorPosition(0,0);
                Console.WriteLine(" c => 클리어 esc => 종료 ");
                
                Console.SetCursorPosition(30, 20);

                if (Console.KeyAvailable) {
                    consoleKey = Console.ReadKey(true);
                    switch (consoleKey.Key) {
                        case ConsoleKey.C:
                            Console.Clear();
                            break;
                        case ConsoleKey.UpArrow: 
                            dx = 0;
                            dy = -1;

                            break;
                        case ConsoleKey.DownArrow: 
                            dx = 0;
                            dy = 1;

                            break;
                        case ConsoleKey.LeftArrow: 
                            dx = -1;
                            dy = 0;

                            break;
                        case ConsoleKey.RightArrow: 
                            dx = 1;
                            dy = 0;

                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            Console.WriteLine("끝");
                            gameLive = false;
                            break;
                    }
                }

                Console.SetCursorPosition(x, y);

                x += dx;
                if (x > consoleWidthLimit) {
                    gameLive = false;
                    //x = 0;

                }
                if (x < 0) {
                    gameLive = false;
                    //x = consoleWidthLimit;

                }

                y += dy;
                if (y > consoleHeightLimit) {
                    gameLive = false;
                    //y = 2;
                }
                    
                if (y < 2) {
                    gameLive = false;
                    //y = consoleHeightLimit;

                }

                int idx = 0;

                if (dx == 0) {
                    if(dy == -1) {
                        foreach (char c in snake) {

                            Console.SetCursorPosition(x, y - snake.Count+idx+1);
                            Console.WriteLine("s");
                            idx++;
                            //Console.SetCursorPosition(x, y);

                        }
                    } else {
                        foreach (char c in snake) {

                            Console.SetCursorPosition(x, y + idx - snake.Count);
                            Console.WriteLine("s");
                            idx++;
                            //Console.SetCursorPosition(x, y);

                        }

                    }
                } else {
                    

                    foreach (char c in snake) {

                        Console.SetCursorPosition(x, y);

                        Console.Write(c);
                        idx++;
                    }
                }
                
                Thread.Sleep(100);


                //Console.Clear();

                //Console.SetCursorPosition(x, y);

                //
                //Console.Write(ch);

                
                

            } while (gameLive);






        }
    }
}