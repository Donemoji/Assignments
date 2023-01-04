using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTetris {
    internal class GameManager {

        Diagram now;
        Point NowPosition {
            get {
                if (now == null) {
                    return new Point(0, 0);
                }
                return new Point(now.xPosition, now.yPosition);
            }
        }

        internal static GameManager Singleton {
            get;
            private set;
        }
        static GameManager() {
            Singleton = new GameManager();
        }
        GameManager() {
            now = new Diagram();
        }

        bool MoveLeft() {
            if (now.xPosition > 0) {
                now.MoveLeft();
                return true;
            }
            return false;
        }

        bool MoveRight() {
            if ((now.xPosition + 1) < GameRule.B_WIDTH) {
                now.MoveRight();
                return true;
            }
            return false;
        }

        bool MoveDown() {
            if ((now.xPosition + 1) < GameRule.B_HEIGHT) {
                now.MoveDown();
                return true;
            }
            return false;
        }




    }
}
