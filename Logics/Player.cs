using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logics
{
    public class Player
    {
        private ePlayerType m_PlayerType;
        public eGameComponent m_PlayerSign { get; }
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

        public ePlayerType PlayerType
        {
            get 
            {
                return m_PlayerType;
            }
        }
       
        public Player(ePlayerType i_playerType, eGameComponent i_PlayerSign)
        {
            m_PlayerType = i_playerType;
            m_PlayerSign = i_PlayerSign;
        }
    }
}
