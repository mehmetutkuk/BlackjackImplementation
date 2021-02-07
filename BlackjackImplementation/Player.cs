using System;
using System.Collections.Generic;

namespace BlackjackImplementation
{
    public class Player
    {
        protected List<GenericCards> playerHands = new List<GenericCards>();

        public List<GenericCards> PlayerHands
        {
            get { return playerHands; }

            set {
                playerHands.AddRange(value);   
            }
        }

        public int PlayerPoint {
            get { return playerPoint; }
            set { playerPoint = value; }
        }

        public void AddPoint(int point)
        {
            playerPoint += point;
        }
        private int playerPoint;

        public Player()
        {

        }
    }
}
