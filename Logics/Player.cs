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

        public Player(ePlayerType i_PlayerType, eGameComponent i_PlayerSign)
        {
            PlayerType = i_PlayerType;
            PlayerSign = i_PlayerSign;
        }
    }
}
