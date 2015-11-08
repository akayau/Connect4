using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4.Core
{
    /// <summary>
    /// The game board for connect 4, the board has no concept of player as it can be played by one or more players
    /// </summary>
    public class Board
    {
        int to_win = 4;
        int[,] state;

        public Board(int size) : this(size, size)
        {
        }

        public Board(int rows, int columns)
        {
            state = new int[rows, columns];
        }

        public int Rows
        {
            get { return state.GetLength(0); }
        }

        public int Columns
        {
            get { return state.GetLength(1); }
        }

        public int DropDiskAt(int col, int player)
        {
            // drop into col, return row or -1 if fail
            col -= 1;
            int row;
            int success = -1;

            for (row = 0; row < Rows; row++)
            {
                if (state[row, col] == 0)
                {
                    state[row, col] = player;
                    success = row;
                    break;
                }
            }
            if (row == Rows)
            {
                success = -1;
            }
            return success;
        }

        public bool CheckIfWin(int col, int row, int player)
        {
            col -= 1;
            int[] check_flags = { -1, 1, -2, 2, -3, 3 };

            //win count along each direction, forward and backward flags 
            int win_count, fflag, bflag;

            //4 directions (h,v,d1,d2)
            for (int direction = 0; direction < 4; direction++)
            {
                switch (direction)
                {
                    case 0: 
                        fflag = 0;
                        bflag = 0;
                        win_count = 1;
                        for (int i = 0; i < check_flags.Length; i++)
                        {
                            int this_col = col + check_flags[i];
                            if (this_col < 0 || this_col >= Columns) continue;
                            if (state[row, this_col] == player)
                            {
                                win_count++;
                            }
                            else
                            {
                                if (check_flags[i] < 0) bflag = 1;
                                else fflag = 1;
                            }
                            if (bflag == 1 && fflag == 1) break;

                        }

                        if (win_count == to_win)
                        {
                            return true;
                        }
                        break;

                    case 1: 
                        fflag = 0;
                        bflag = 0;
                        win_count = 1;

                        for (int i = 0; i < check_flags.Length; i++)
                        {
                            int this_row = row + check_flags[i];

                            if (this_row < 0 || this_row >= Rows) continue;

                            if (state[this_row, col] == player)
                            {
                                win_count++;
                            }
                            else
                            {
                                if (check_flags[i] < 0) bflag = 1;
                                else fflag = 1;
                            }
                            if (bflag == 1 && fflag == 1) break;

                        }

                        if (win_count == to_win)
                        {
                            return true;
                        }
                        break;


                    case 2: 

                        fflag = 0;
                        bflag = 0;
                        win_count = 1;

                        for (int i = 0; i < check_flags.Length; i++)
                        {
                            int this_row = row + check_flags[i];
                            int this_col = col + check_flags[i];

                            if (this_row < 0 || this_row >= Rows) continue;
                            if (this_col < 0 || this_col >= Columns) continue;

                            if (state[this_row, this_col] == player)
                            {
                                win_count++;
                            }
                            else
                            {
                                if (check_flags[i] < 0) bflag = 1;
                                else fflag = 1;
                            }
                            if (bflag == 1 && fflag == 1) break;

                        }

                        if (win_count == to_win)
                        {
                            return true;
                        }
                        break;

                    case 3: 

                        fflag = 0;
                        bflag = 0;
                        win_count = 1;

                        for (int i = 0; i < check_flags.Length; i++)
                        {
                            int this_row = row - check_flags[i];
                            int this_col = col + check_flags[i];

                            if (this_row < 0 || this_row >= Rows) continue;
                            if (this_col < 0 || this_col >= Columns) continue;

                            if (state[this_row, this_col] == player)
                            {
                                win_count++;
                            }
                            else
                            {
                                if (check_flags[i] < 0) bflag = 1;
                                else { fflag = 1; }
                            }
                            if (bflag == 1 && fflag == 1) break;

                        }

                        if (win_count == to_win)
                        {
                            return true;
                        }
                        break;

                }

            }

            return false;
        }
    }
}
