using System;
using System.Collections.Generic;

namespace Logics
{
    public class GameBoard
    {
        private readonly int r_BoardSize;
        private eGameComponent[,] m_Board;

        public GameBoard(int i_Size)
        {
            r_BoardSize = i_Size;
            m_Board = new eGameComponent[r_BoardSize, r_BoardSize];
            this.Empty();
        }

        public int Size
        {
            get
            {
                return r_BoardSize;
            }
        }

        public void Empty()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
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
            return (i_Row >= 1 && i_Row <= r_BoardSize && i_Col >= 1 && i_Col <= r_BoardSize);
        }

        public bool IsThereSequance(int i_Row, int i_Col)
        {
            return isThereRowSequence(i_Row-1, i_Col-1) || isThereColSequence(i_Row-1, i_Col-1) || isThereDiagonalSequence(i_Row - 1, i_Col - 1);
        }

        private bool isThereRowSequence(int i_Row, int i_Col)
        {
            bool areAllSame = true;

            for (int j = 0; j < r_BoardSize; j++)
            {
                if (m_Board[i_Row, j] != m_Board[i_Row, i_Col])
                {
                    areAllSame = false;
                    break;
                }
            }

            return areAllSame;
        }

        private bool isThereColSequence(int i_Row, int i_Col)
        {
            bool areAllSame = true;

            for (int i = 0; i < r_BoardSize; i++)
            {
                if (m_Board[i, i_Col] != m_Board[i_Row, i_Col])
                {
                    areAllSame = false;
                    break;
                }
            }

            return areAllSame;
        }

        private bool isThereDiagonalSequence(int i_Row, int i_Col)
        {
            bool areAllSame1 = true;
            bool areAllSame2 = true;

            for (int i = 0; i < r_BoardSize; i++)
            {
                if (m_Board[i, i] != m_Board[i_Row, i_Col])
                {
                    areAllSame1 = false;
                    break;
                }
            }

            for (int i = 0; i < r_BoardSize && !areAllSame1; i++)
            {
                if (m_Board[i, r_BoardSize - 1 - i] != m_Board[i_Row, i_Col])
                {
                    areAllSame2 = false;
                    break;
                }
            }

            return areAllSame1 || areAllSame2;
        }

        public void GenerateEmptyCell(out int o_Row, out int o_Col)
        {
            Random random = new Random();
            List<int> emptyCells = new List<int>(r_BoardSize * r_BoardSize);

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    if (m_Board[i, j] == eGameComponent.Empty)
                    {
                        emptyCells.Add(i * r_BoardSize + j);
                    }
                }
            }

            int generateIndex = random.Next(emptyCells.Count);
            o_Col = emptyCells[generateIndex] % r_BoardSize;
            o_Row = (emptyCells[generateIndex] - o_Col) / r_BoardSize;
            o_Col += 1;
            o_Row += 1;
        }

        public bool IsFilled()
        {
            bool isFilled = true;

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
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
    }
}
