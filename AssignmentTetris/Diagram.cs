using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTetris {
    internal class Diagram {

        public Diagram() {
            Reset();
        }

        public void Reset() {
            xPosition = GameRule.START_X; 
            yPosition = GameRule.START_Y;
        }

        public int xPosition {
            get { return xPosition; }
            private set { xPosition = value; }
        }

        public int yPosition {
            get { return yPosition; }
            private set { yPosition = value; }
        }

        internal void MoveLeft() {
            xPosition--;
        }
        internal void MoveRight() {
            xPosition++;
        }
        internal void MoveDown() {
            yPosition++;
        }



    }
}
