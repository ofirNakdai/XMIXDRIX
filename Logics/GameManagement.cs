namespace Logics
{
    public class GameManagement
    {
        private Player[] m_Players = new Player[2];
        private Player m_CurrentPlayer = null;
        private GameBoard m_Board = null;
        private eGameState m_CurrentState = eGameState.Running;

        public Player[] Players
        {
            get
            {
                return m_Players;
            }
        }

        public eGameState CurrentState
        {
            get
            {
                return m_CurrentState;
            }
        }

        public GameBoard Board
        {
            get
            {
                return m_Board;
            }
        }

        public eGameComponent GetCurrentPlayerSign()
        {
            return m_CurrentPlayer.PlayerSign;
        }

        public void SetBoardBySize(int i_Size)
        {
            m_Board = new GameBoard(i_Size);
        }
        
        public void InitPlayers(ePlayerType i_GameStyle)
        {
            m_Players[0] = new Player(ePlayerType.Human, eGameComponent.X);
            m_Players[1] = new Player(i_GameStyle, eGameComponent.O);
        }

        public bool IsValidMove(int i_Row, int i_Col)
        {
            return m_Board.IsValidCell(i_Row, i_Col) && (m_Board.GetCellValue(i_Row, i_Col) == eGameComponent.Empty);
        }

        public void MakeMove(int i_Row, int i_Col)
        {
            m_Board.SetCellValue(i_Row, i_Col, m_CurrentPlayer.PlayerSign);
            alterCurrentPlayer();
        }

        private void alterCurrentPlayer()
        {
            if (m_CurrentPlayer == m_Players[0])
            {
                m_CurrentPlayer = m_Players[1];
            }
            else
            {
                m_CurrentPlayer = m_Players[0];
            }
        }

        public void CheckCurrentState(int i_Row, int i_Col)
        {
            if (m_Board.IsThereSequance(i_Row, i_Col))
            {
                m_CurrentState = eGameState.DecidedWinner;
                m_CurrentPlayer.Score++;
            }
            else if (m_Board.IsFilled())
            {
                m_CurrentState = eGameState.DecidedTie;
            }
        }

        public ePlayerType GetCurrentPlayerType()
        {
            return m_CurrentPlayer.PlayerType;
        }

        public void GetComputerMove(out int o_Row, out int o_Col)
        {
            m_Board.GenerateEmptyCell(out o_Row, out o_Col);
        }

        public void SetupNewRound()
        {
            m_Board.Empty();
            m_CurrentPlayer = m_Players[0];
            m_CurrentState = eGameState.Running;
        }
    }
}
