using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logics
{
    class Player
    {
        private ePlayerType m_PlayerType;
        //private ePlayerChar m_PlayerChar;
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
            set
            {
                if(value.GetType() == m_PlayerType.GetType()) /// VALIDATE!
                {
                    m_PlayerType = value;
                }
            }
        }
       

        public Player(ePlayerType i_playerType)
        {
            m_PlayerType = i_playerType;
        }
    }
}
