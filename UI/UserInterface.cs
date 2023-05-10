using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex02.ConsoleUtils;
using Logics;

namespace UI
{
    public class UserInterface
    {

        GameManagement m_game = new GameManagement();

        
        public void Start()
        {
            initGame();
            runGame();
        }

        private void initGame()
        {
            const int k_BoardMenuSizeStartRange = 3;
            const int k_BoardMenuSizeEndRange = 9;
            const int k_GameStyleMenuSizeEndRange = 2;
            printBoardSizeMenu();
            int gameSize = getIntegerInRangeFromUser(k_BoardMenuSizeEndRange, k_BoardMenuSizeStartRange);
            printGameStyleManu();
            ePlayerType gameStyle = (ePlayerType)getIntegerInRangeFromUser(k_GameStyleMenuSizeEndRange);
            m_game.SetBoardBySize(gameSize);
            m_game.setOpponentType(gameStyle);
        }

        private void printBoardSizeMenu()
        {
            Console.WriteLine(
@"Please choose the size of board:
3. 3X3
4. 4X4
5. 5X5
6. 6X6
7. 7X7
8. 8X8
9. 9X9");
        }

        private void printGameStyleManu()
        {
            Console.WriteLine(
@"Choose your game style:
1. VS Computer
2. 2 Players");
        }

        private int getIntegerInRangeFromUser(int i_EndRange, int i_StartRange = 1)
        {
            bool isValid = (int.TryParse(Console.ReadLine(), out int inputValue) && inputValue <= i_EndRange && inputValue >= i_StartRange);

            while (!isValid) 
            {
                Console.WriteLine("Invalid input, try again");
                isValid = (int.TryParse(Console.ReadLine(), out inputValue) && inputValue <= i_EndRange && inputValue >= i_StartRange);
            }

            return inputValue;
        }

        private void runGame()
        {
            bool quitInput = false;

            do
            {
                m_game.GetBoard().Empty();
                m_game.CurrentState = eGameState.Running; //Probably better not directly change. alse, player automaticly becoms computer first, maybe better to create a new round method inside GameMgmt!!!!!!!!!!
                while (m_game.CurrentState == eGameState.Running && !quitInput)
                {
                    printBoard(m_game.GetBoard());
                    quitInput = getMove(out int row, out int col);
                    if(!quitInput)
                    {
                        while (!m_game.IsValidMove(row, col))
                        {
                            invalidCellMassage(); //TODOOOOOOOOOOOOOOOO
                            quitInput = getMove(out row, out col);
                        }

                        m_game.MakeMove(row, col);
                        m_game.CheckCurrentState(row, col);
                    }
                }

                if (!quitInput)
                {
                    showStateAndScore();
                    quitInput = askForAnotherRound();
                }               
            }
            while (!quitInput);

        }

        private bool getRowFromUser(out int o_Row)
        {
            string userInput = null;
            bool wantToQuit = false;
            o_Row = -1;

            do
            {
                Console.WriteLine("Please choose the row number:");
                userInput = Console.ReadLine();
                if (userInput == "Q")
                {
                    wantToQuit = true;
                }
            } while (!wantToQuit && !int.TryParse(userInput, out o_Row));

            return wantToQuit;
        }

        private bool getColFromUser(out int o_Col)
        {
            string userInput = null;
            bool wantToQuit = false;
            o_Col = -1;

            do
            {
                Console.WriteLine("Please choose the column number:");
                userInput = Console.ReadLine();
                if (userInput == "Q")
                {
                    wantToQuit = true;
                }
            } while (!wantToQuit && !int.TryParse(userInput, out o_Col));

            return wantToQuit;
        }

        private bool getMove(out int o_Row, out int o_Col) // return true if want to quit
        { 
            bool wantToQuit = false;

            if (m_game.GetCurrentPlayerType() == ePlayerType.Computer)
            {
                m_game.GetComputerMove(out o_Row, out o_Col);
            }
            else
            {
                wantToQuit = getRowFromUser(out o_Row);

                if (!wantToQuit)
                {
                    wantToQuit = getColFromUser(out o_Col);
                }
                else
                {
                    o_Row = -1;
                    o_Col = -1;
                }
            }

            return wantToQuit;
        }

        public ePlayerChar GetCellContentChar(eCellContent i_content)
        {
            ePlayerChar returnValue;

            if (i_content == eCellContent.O)
            {
                returnValue = ePlayerChar.O;
            }
            else if (i_content == eCellContent.X)
            {
                returnValue = ePlayerChar.X;
            }
            else
            {
                returnValue = ePlayerChar.Empty;
            }

            return returnValue;
        }

        private void showStateAndScore()
        {
            printBoard(m_game.GetBoard());
            if (m_game.CurrentState == eGameState.Winner)
            {
                Console.WriteLine($"{(char)GetCellContentChar(m_game.CurrentPlayerSign)} Won!!!");
            }
            else
            {
                Console.WriteLine("Its a Tie :|");
            }
            showScore();
        }

        private void showScore()
        {
            Console.WriteLine($@"
Scores:
=======================
BULSHIT!");
        }

        private void invalidCellMassage()
        {
            Console.WriteLine("Invalid Cell numbers");
        }

        private void printBoard(GameBoard i_Board)
        {
            Screen.Clear();
            for (int i = 0; i<= i_Board.Size; i++)
            {
                for (int j = 0; j <= i_Board.Size; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (i > 0 && j == 0)
                    {
                        Console.Write($"{i}|");
                    }
                    else if (i == 0 && j > 0)
                    {
                        Console.Write($"{j}   ");
                    }
                    else if (i > 0 && j > 0)
                    {
                        Console.Write($" {(char)GetCellContentChar(i_Board.GetCellValue(i, j))} |");
                    }
                    
                }
                    Console.WriteLine();
                if (i > 0)
                {
                    Console.WriteLine(" " + new string('=', 4 * i_Board.Size + 1));
                }
            }
        }

        private bool askForAnotherRound()
        {
            bool wantToQuit = false;
            Console.WriteLine(
@"Play another round?:
1. Yes
2. NO");
            int userInput = getIntegerInRangeFromUser(2);
            if (userInput == 2)
            {
                wantToQuit = true;
            }

            return wantToQuit;
        }

    }
}
