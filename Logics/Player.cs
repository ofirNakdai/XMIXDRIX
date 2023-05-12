using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logics
{
    public class Player
    {
        public ePlayerType PlayerType { get; } 
        public eGameComponent PlayerSign { get; }
        private int m_Score = 0;

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                if (value > 0)
                    m_Score = value;
            }
        }

        public Player(ePlayerType i_playerType, eGameComponent i_PlayerSign)
        {
            PlayerType = i_playerType;
            PlayerSign = i_PlayerSign;
        }
    }
}
