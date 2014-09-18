/* UserInterface.cs
 * Author: Kevin Harrison Manase
 * Homework 1 Assignment
 */

using Ksu.Cis300.MazeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ksu.Cis300.MazeSolver
{
    public partial class UserInterface : Form
    {
        private Stack<Direction> _directionStack = new Stack<Direction>(); // Stack of directions
        private int _rows; // number of rows in the maze
        private int _cols; // number of cols in the maze
        private bool[,] _isVisited; // if position was visited
        private Direction _theDirection = Direction.North; // Initialized at North

        /// <summary>
        /// Initializes the component,
        /// This is automatically added
        /// by the IDE
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();

        }

        /// <summary>
        /// The method used to solve the maze generated
        /// </summary>
        private void Solve(Cell cell)
        {
            _rows = uxMaze.MazeHeight;
            _cols = uxMaze.MazeWidth;
            _isVisited = new bool[_rows, _cols];

            /* Checks if we are still in maze  and clear*/
            if (uxMaze.IsInMaze(cell))
            {

                if (_theDirection == Direction.North || _theDirection == Direction.South ||
                   _theDirection == Direction.East || _theDirection == Direction.West)
                {

                    for (int i = 0; i < _rows; i++)
                    {
                        for (int j = 0; j < _cols; j++)
                        {
                            while (uxMaze.IsClear(cell, _theDirection) && _isVisited[i, j] == false)
                            {
                                Console.WriteLine("Is clear and is not visited");
                                uxMaze.DrawPath(cell, _theDirection);
                                // TODO: Set the current location to the cell in the current direction.
                                uxMaze.Step(cell, _theDirection++);
                                _directionStack.Push(_theDirection);
                                _theDirection = Direction.North;
                                _isVisited[i, j] = true;
                                //break;
                            }
                            
                            if (!uxMaze.IsClear(cell, _theDirection))
                            {
                                if (_theDirection <= Direction.West)
                                {
                                    Console.WriteLine("Incrementing");
                                    _theDirection++;
                                    break;
                                }
                            }



                            while (_theDirection > Direction.West &&
                               _directionStack.Count != 0)
                            {
                                Console.WriteLine("Pop direction");
                                Direction temp = _directionStack.Pop();
                                _theDirection = temp;
                                Cell newCell = uxMaze.ReverseStep(cell, _theDirection);
                                uxMaze.ErasePath(newCell, _theDirection);
                                uxMaze.Step(cell, _theDirection);
                                break;

                            }
                            if (_theDirection != Direction.North && _theDirection != Direction.South &&
                               _theDirection != Direction.East && _theDirection != Direction.West &&
                               _directionStack.Count == 0)
                            {
                                MessageBox.Show("Can't go anywhere from here");
                            }

                        }
                    }
                }
            }
        }
              



        /// <summary>
        /// Handles new maze button event on click.
        /// This will generate a completely new maze.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event e</param>
        private void uxButton_Click(object sender, EventArgs e)
        {
            uxMaze.Generate();
        }

        /// <summary>
        /// Handles the user interaction with the maze.
        /// This will calculate the cell where the user clicked
        /// From the the data received, thr program will try to 
        /// solve the maze using the location by calling the
        /// Solve() method.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Mouse click handler</param>
        private void uxMaze_MouseClick(object sender, MouseEventArgs e)
        {
            Point Mouse = e.Location;
            Cell Borders = uxMaze.GetCellFromPixel(Mouse);
            if (uxMaze.IsInMaze(Borders))
            {
                uxMaze.EraseAllPaths();
                Solve(Borders);
                uxMaze.Invalidate();
                Console.WriteLine("Clicked");
            }


        }


    }
}
