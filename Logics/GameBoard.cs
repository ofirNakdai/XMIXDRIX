using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logics
{
    public class GameBoard
    {
        private int m_boardSize;
        private eCellContent[,] m_Board;

        public GameBoard(int i_size)
        {
            m_boardSize = i_size;
            m_Board = new eCellContent[m_boardSize, m_boardSize];

            Empty();
        }

        public int Size //ADDED - probably need the UI to include this and not the way it is.
        {
            get
            {
                return m_boardSize;
            }
        }
        //public ePlayerChar[,] Board //ADDED - probably need the UI to include this and not the way it is.
        //{
        //    get
        //    {
        //        return m_Board;
        //    }
        //}
        //public int BoardSize //ADDED -  probably need the UI to include this and not the way it is.
        //{
        //    get
        //    {
        //        return m_boardSize;
        //    }
        //}

        public void Empty()
        {
            for (int i = 0; i < m_boardSize; i++)
            {
                for (int j = 0; j < m_boardSize; j++)
                {
                    m_Board[i, j] = eCellContent.Empty;
                }
            }
        }

        public eCellContent GetCellValue(int i_Row, int i_Col)
        {
            return m_Board[i_Row - 1, i_Col - 1];
        }

        public void SetCellValue(int i_Row, int i_Col, eCellContent i_Value)
        {
            m_Board[i_Row - 1, i_Col - 1] = i_Value;
        }

        public bool IsValidCell(int i_Row, int i_Col)
        {
            return (i_Row >= 1 && i_Row <= m_boardSize && i_Col >= 1 && i_Col <= m_boardSize);
        }

        public bool IsThereSequance(int i_Row, int j_Col)
        {
            return IsThereRowSequence(i_Row-1, j_Col-1) || isThereColSequence(i_Row-1, j_Col-1) || isThereDiagonalSequence(i_Row - 1, j_Col - 1); //NEED TO IMPLEMENT DIAGONAL
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
                    if (m_Board[i, j] == eCellContent.Empty)
                    {
                        EmptyCells.Add(i * m_boardSize + j);
                    }
                }
            }

            int GenerateIndex = random.Next(EmptyCells.Count);
            o_Col = EmptyCells[GenerateIndex] % m_boardSize;
            o_Row = (EmptyCells[GenerateIndex] - o_Col) / m_boardSize;
            o_Col += 1;             //ADDED
            o_Row += 1;             //ADDED
        }

        public bool IsFilled()
        {
            bool isFilled = true;

            for (int i = 0; i < m_boardSize; i++)
            {
                for (int j = 0; j < m_boardSize; j++)
                {
                    if (m_Board[i, j] == eCellContent.Empty)
                    {
                        isFilled = false;
                        break;
                    }
                }
            }

            return isFilled;
        }

        private bool isThereDiagonalSequence(int i_Row, int j_Col) //NEED TO IMPLEMENT
        {
            bool areAllSame = true;
            for (int i = 0; i < m_boardSize; i++)
            {
                if (m_Board[i, i] != m_Board[i_Row, j_Col])
                {
                    areAllSame = false;
                    break;
                }
            }

            for (int i = 0; i < m_boardSize && !areAllSame; i++)
            {
                if (m_Board[i, m_boardSize - 1 - i] != m_Board[i_Row, j_Col])
                {
                    areAllSame = false;
                    break;
                }
            }

            return areAllSame;
        }
    }
}
