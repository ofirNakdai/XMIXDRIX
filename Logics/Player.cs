namespace Logics
{
    public class Player
    {
        private readonly ePlayerType r_PlayerType;
        private readonly eGameComponent r_PlayerSign;
        private int m_Score = 0;

        public Player(ePlayerType i_PlayerType, eGameComponent i_PlayerSign)
        {
            r_PlayerType = i_PlayerType;
            r_PlayerSign = i_PlayerSign;
        }

        public ePlayerType PlayerType
        {
            get
            {
                return r_PlayerType;
            }
        }

        public eGameComponent PlayerSign
        {
            get
            {
                return r_PlayerSign;
            }
        }

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
    }
}
