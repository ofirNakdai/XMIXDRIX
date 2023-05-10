using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logics
{
    public class GameBoard
    {
        private int m_boardSize;
        private eGameComponent[,] m_Board;

        public GameBoard(int i_size)
        {
            m_boardSize = i_size;
            m_Board = new eGameComponent[m_boardSize, m_boardSize];

            Empty();
        }

        public int Size
        {
            get
            {
                return m_boardSize;
            }
        }

        public void Empty()
        {
            for (int i = 0; i < m_boardSize; i++)
            {
                for (int j = 0; j < m_boardSize; j++)
                {
                    m_Board[i, j] = eGameComponent.Empty;
                }
            }
        }

        public eGameComponent GetCellValue(int i_Row, int i_Col)
        {
            return m_Board[i_Row - 1, i_Col - 1];
        }

        public void SetCellValue(int i_Row, int i_Col, eGameComponent i_Value)
        {
            m_Board[i_Row - 1, i_Col - 1] = i_Value;
        }

        public bool IsValidCell(int i_Row, int i_Col)
        {
            return (i_Row >= 1 && i_Row <= m_boardSize && i_Col >= 1 && i_Col <= m_boardSize);
        }

        public bool IsThereSequance(int i_Row, int j_Col)
        {
            return IsThereRowSequence(i_Row-1, j_Col-1) || isThereColSequence(i_Row-1, j_Col-1) || isThereDiagonalSequence(i_Row - 1, j_Col - 1);
        }

        private bool IsThereRowSequence(int i_Row, int j_Col)
        {
            bool areAllSame = true;
            for (int j = 0; j < m_boardSize; j++)
            {
                if (m_Board[i_Row, j] != m_Board[i_Row, j_Col])
                {
                    areAllSame = false;
                    break;
                }
            }
            return areAllSame;
        }

        private bool isThereColSequence(int i_Row, int j_Col)
        {
            bool areAllSame = true;
            for (int i = 0; i < m_boardSize; i++)
            {
                if (m_Board[i, j_Col] != m_Board[i_Row, j_Col])
                {
                    areAllSame = false;
                    break;
                }
            }
            return areAllSame;
        }

        public void GenerateEmptyCell(out int o_Row, out int o_Col)
        {
            Random random = new Random();
            List<int> EmptyCells = new List<int>(m_boardSize * m_boardSize);

            for (int i = 0; i < m_boardSize; i++)
            {
                for (int j = 0; j < m_boardSize; j++)
                {
                    if (m_Board[i, j] == eGameComponent.Empty)
                    {
                        EmptyCells.Add(i * m_boardSize + j);
                    }
                }
            }

            int GenerateIndex = random.Next(EmptyCells.Count);
            o_Col = EmptyCells[GenerateIndex] % m_boardSize;
            o_Row = (EmptyCells[GenerateIndex] - o_Col) / m_boardSize;
            o_Col += 1;
            o_Row += 1;
        }

        public bool IsFilled()
        {
            bool isFilled = true;

            for (int i = 0; i < m_boardSize; i++)
            {
                for (int j = 0; j < m_boardSize; j++)
                {
                    if (m_Board[i, j] == eGameComponent.Empty)
                    {
                        isFilled = false;
                        break;
                    }
                }
            }

            return isFilled;
        }

        private bool isThereDiagonalSequence(int i_Row, int j_Col)
        {
            bool areAllSame1 = true;
            bool areAllSame2 = true;
            for (int i = 0; i < m_boardSize; i++)
            {
                if (m_Board[i, i] != m_Board[i_Row, j_Col])
                {
                    areAllSame1 = false;
                    break;
                }
            }

            for (int i = 0; i < m_boardSize && !areAllSame1; i++)
            {
                if (m_Board[i, m_boardSize - 1 - i] != m_Board[i_Row, j_Col])
                {
                    areAllSame2 = false;
                    break;
                }
            }

            return areAllSame1 || areAllSame2;
        }
    }
}
