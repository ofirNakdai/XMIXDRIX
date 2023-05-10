using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logics
{
    public class GameManagement
    {
        private Player player1 = new Player(ePlayerType.Human);
        private Player player2 = null;
        private Player m_CurrentPlayer = null;
        private eCellContent m_CurrentPlayerSign = eCellContent.O; // NEED TO CHANGE
        private GameBoard m_Board = null;
        private eGameState m_CurrentState = eGameState.Running;

        public eGameState CurrentState
        {
            get
            {
                return m_CurrentState;
            }
            set //PROBABLY BETTER WITHOUT!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                m_CurrentState = value;
            }
        }
        public eCellContent CurrentPlayerSign
        {
            get
            {
                return m_CurrentPlayerSign;
            }
        }

        public void SetBoardBySize(int i_size)
        {
            m_Board = new GameBoard(i_size);
        }

        public GameBoard GetBoard()
        {
            return m_Board;
        }

        public void setOpponentType(ePlayerType i_gameStyle)
        {
            m_CurrentPlayer = player1; //CHANGE
            player2 = new Player(i_gameStyle);
        }

        public bool IsValidMove(int i_Row, int i_Col)
        {
            return m_Board.IsValidCell(i_Row, i_Col) && (m_Board.GetCellValue(i_Row, i_Col) == eCellContent.Empty);
        }

        public void MakeMove(int i_Row, int i_Col)
        {
            m_Board.SetCellValue(i_Row, i_Col, m_CurrentPlayerSign);
            alterCurrentPlayer(); //PROBABLY CHANGE THE WAY IT WORKS
        }

        private void alterCurrentPlayer() // PROBABLY CHANGE
        {
            if (m_CurrentPlayer == player1) //probably Array is better...
            {
                m_CurrentPlayer = player2;
                m_CurrentPlayerSign = eCellContent.X;
            }
            else
            {
                m_CurrentPlayer = player1;
                m_CurrentPlayerSign = eCellContent.O;
            }
        }

        public void CheckCurrentState(int i_Row, int i_Col) //probably cheange to without
        {
            if (m_Board.IsThereSequance(i_Row, i_Col))
            {
                m_CurrentState = eGameState.Winner;
                m_CurrentPlayer.Score++; //VALIDATE THAT IT IS REFERENCE TO REAL PLAYER.
            }
            else if (m_Board.IsFilled())
            {
                m_CurrentState = eGameState.Tie;
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
    }
}
