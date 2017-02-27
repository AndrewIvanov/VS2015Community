using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ec447AndrewIvanovLab6
{
    class GameEngine : Form1
    {
        
        public int status;

        public CellSelection[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }
        public int Gametype
        {
            get { return gametype; }
        }



        public CellSelection[,] algorithm(CellSelection[,] grid, int gametype)
        {
            int countX = 0;
            int countO = 0;
            foreach (CellSelection NOX in grid)
            {
                if (NOX == CellSelection.X)
                {
                    countX++;
                }
                if (NOX == CellSelection.O)
                {
                    countO++;
                }
            }

            if (countO > countX && gametype == 1)
            {
                return grid;
            }
            if (countO >= countX && gametype == 0)
            {
                return grid;
            }


            for (int m = 0; m < 3; ++m)          // winning move time
            {
                if (grid[m, 0] == CellSelection.O && grid[m, 1] == CellSelection.O && grid[m, 2] == CellSelection.N)  // ROW-WISE
                {
                    grid[m, 2] = CellSelection.O; countO++; return grid;
                }
                if (grid[m, 0] == CellSelection.O && grid[m, 1] == CellSelection.N && grid[m, 2] == CellSelection.O) // ROW-WISE
                {
                    grid[m, 1] = CellSelection.O; countO++; return grid;
                }
                if (grid[m, 0] == CellSelection.N && grid[m, 1] == CellSelection.O && grid[m, 2] == CellSelection.O) // ROW-WISE
                {
                    grid[m, 0] = CellSelection.O; countO++; return grid;
                }

                if (grid[0, m] == CellSelection.O && grid[1, m] == CellSelection.O && grid[2, m] == CellSelection.N)  // COL-WISE
                {
                    grid[2, m] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, m] == CellSelection.O && grid[1, m] == CellSelection.N && grid[2, m] == CellSelection.O)  // COL-WISE
                {
                    grid[1, m] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, m] == CellSelection.N && grid[1, m] == CellSelection.O && grid[2, m] == CellSelection.O)  // COL-WISE
                {
                    grid[0, m] = CellSelection.O; countO++; return grid;
                }

                if (grid[0, 0] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 2] == CellSelection.N) // DIAG
                {
                    grid[2, 2] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, 0] == CellSelection.O && grid[1, 1] == CellSelection.N && grid[2, 2] == CellSelection.O) // DIAG
                {
                    grid[1, 1] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, 0] == CellSelection.N && grid[1, 1] == CellSelection.O && grid[2, 2] == CellSelection.O) // DIAG
                {
                    grid[0, 0] = CellSelection.O; countO++; return grid;
                }

                if (grid[0, 2] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 0] == CellSelection.N) // anti-DIAG
                {
                    grid[2, 0] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, 2] == CellSelection.O && grid[1, 1] == CellSelection.N && grid[2, 0] == CellSelection.O) // anti-DIAG
                {
                    grid[1, 1] = CellSelection.O; countO++; return grid;
                } 
                if (grid[0, 2] == CellSelection.N && grid[1, 1] == CellSelection.O && grid[2, 0] == CellSelection.O) // anti-DIAG
                {
                    grid[0, 2] = CellSelection.O; countO++; return grid;
                }

            } ///////////////////////////////////////////////////////////////////////////// END OF WINNING MOVE DETECTION



            for (int m = 0; m < 3; ++m)          // blocking move time
            {
                if (grid[m, 0] == CellSelection.X && grid[m, 1] == CellSelection.X && grid[m, 2] == CellSelection.N)  // ROW-WISE
                {
                    grid[m, 2] = CellSelection.O; countO++; return grid;
                }
                if (grid[m, 0] == CellSelection.X && grid[m, 1] == CellSelection.N && grid[m, 2] == CellSelection.X) // ROW-WISE
                {
                    grid[m, 1] = CellSelection.O; countO++; return grid;
                }
                if (grid[m, 0] == CellSelection.N && grid[m, 1] == CellSelection.X && grid[m, 2] == CellSelection.X) // ROW-WISE
                {
                    grid[m, 0] = CellSelection.O; countO++; return grid;
                }

                if (grid[0, m] == CellSelection.X && grid[1, m] == CellSelection.X && grid[2, m] == CellSelection.N)  // COL-WISE
                {
                    grid[2, m] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, m] == CellSelection.X && grid[1, m] == CellSelection.N && grid[2, m] == CellSelection.X)  // COL-WISE
                {
                    grid[1, m] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, m] == CellSelection.N && grid[1, m] == CellSelection.X && grid[2, m] == CellSelection.X)  // COL-WISE
                {
                    grid[0, m] = CellSelection.O; countO++; return grid;
                }

                if (grid[0, 0] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 2] == CellSelection.N) // DIAG
                {
                    grid[2, 2] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, 0] == CellSelection.X && grid[1, 1] == CellSelection.N && grid[2, 2] == CellSelection.X) // DIAG
                {
                    grid[1, 1] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, 0] == CellSelection.N && grid[1, 1] == CellSelection.X && grid[2, 2] == CellSelection.X) // DIAG
                {
                    grid[0, 0] = CellSelection.O; countO++; return grid;
                }

                if (grid[0, 2] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 0] == CellSelection.N) // anti-DIAG
                {
                    grid[2, 0] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, 2] == CellSelection.X && grid[1, 1] == CellSelection.N && grid[2, 0] == CellSelection.X) // anti-DIAG
                {
                    grid[1, 1] = CellSelection.O; countO++; return grid;
                }
                if (grid[0, 2] == CellSelection.N && grid[1, 1] == CellSelection.X && grid[2, 0] == CellSelection.X) // anti-DIAG
                {
                    grid[0, 2] = CellSelection.O; countO++; return grid;
                }

            } /////////////////////////////////////////////////////////////// END OF BLOCKING MOVE PORTION

            //if (gametype == 1)
            //{
            //    grid[0, 0] = CellSelection.O;
            //}

            for (int i = 0; i < 3; ++i)  // In case not block or winning move go to next available cell
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (grid[i, j] == CellSelection.N && countO < countX && gametype == 0)
                    {
                        grid[i, j] = CellSelection.O; countO++; return grid;
                    }
                    if (grid[i, j] == CellSelection.N && countO <= countX && gametype == 1)
                    {
                        grid[i, j] = CellSelection.O; countO++; return grid;
                    }
                   //if (gametype == 0 && countX > countO && grid[i,j] == CellSelection.N) 
                   // {

                   //     grid[i, j] = CellSelection.O; return grid;
                   //     countO++;
                   // }
                   //if (gametype == 1 && countX >= countO && grid[i, j] == CellSelection.N)
                   //{
                   //    grid[i, j] = CellSelection.O;
                   //    countO++;
                   //}
                }
            }

            return grid;
        }

        public CellSelection[,] Validator(CellSelection[,] grid)
        {

            return grid;
        }

        public CellSelection[,] FirstTime(CellSelection[,] grid)
        {
            grid[0, 0] = CellSelection.N;
            return grid;
        }

        public void WinDetector(CellSelection[,] grid)
        {
            int win1 = 0;
            int win2 = 0;
            for (int i = 0; i < 3; ++i)
            {
                if (grid[i, 0] == CellSelection.O && grid[i, 1] == CellSelection.O && grid[i, 2] == CellSelection.O) // Row win O
                {
                    win2++;
                }
                if (grid[0, i] == CellSelection.O && grid[1, i] == CellSelection.O && grid[2, i] == CellSelection.O) // Col win O
                {
                    win2++;
                }
                if (grid[i, 0] == CellSelection.X && grid[i, 1] == CellSelection.X && grid[i, 2] == CellSelection.X) // Row win X
                {
                    win1++;
                }
                if (grid[0, i] == CellSelection.X && grid[1, i] == CellSelection.X && grid[2, i] == CellSelection.X) // Col win X
                {
                    win1++;
                }
            }
            if (grid[0, 0] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 2] == CellSelection.X) // Diag win X
            {
                win1++;
            }
            if (grid[0, 2] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 0] == CellSelection.X) // anti-Diag win X
            {
                win1++;
            }
            if (grid[0, 0] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 2] == CellSelection.O) // Diag win O
            {
                win2++;
            }
            if (grid[0, 2] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 0] == CellSelection.O) // anti-Diag win O
            {
                win2++;
            }


            if (win2 == 1)
            {
                MessageBox.Show("You LOSE! T_T");
                status = 1;
            }
            if (win1 == 1)
            {
                MessageBox.Show("You WIN! ^_^");
                status = 1;
            }

            int count = 0;
            foreach (CellSelection NOX in grid)
            {
                if (NOX == CellSelection.N)
                {
                    count++;
                }
            }
            if (count == 0 && win1 != 1 && win2 != 1)
            {
                MessageBox.Show("Its a DRAW! >.<");
                status = 1;
            }
                
            

        }
        
    }
}
