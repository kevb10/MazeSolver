MazeSolver
==========

Generates and Solves a Maze

Assignmenet Description:

CIS 300 Homework Assignment 1

For this assignment, you will write a program that solves randomly-generated mazes using a backtracking algorithm. You will be provided a class library that contains a GUI control representing a maze, along with two other types that are needed to interact with it.

Due Date
Thursday, Sept. 18, 5:00 pm.

Extra Credit: Source Control
You can receive 15 points extra credit for your homework assignments (each homework assignment is worth 100 points) for using source control on at least five of your homework assignments. Instructions for setting up and using source control can be found in “Source Control“. To receive the extra credit, sometime after you have submitted Homework 6 and the beginning of the Final Exam for your section, meet with one of the instructors or TAs (i.e., Rod, Julie, Ying, or Navya) during their office hours. You will need to show them that you have complete versions of your projects checked in at about the same time you submitted them.

Functionality
A working executable has been provided. The program should first open a window resembling the following:



The maze displayed is randomly generated; hence, it will be different each time the program is run. Clicking the “New Maze” button will cause a new maze to be generated and displayed on the window. This new maze will fill the window, even if it has been resized since the last maze was drawn (resizing the window will not change the size of the current maze). Clicking inside the maze will cause a path to be drawn from the location of the click to an exit. If there is no such path, a MessageBox resembling the following will be shown:



Regardless of whether a path is found, any pre-existing path will be removed. When the main window is resized, the “New Maze” button will remain centered horizontally at the bottom of the window.

GUI Design
In order to be able to add a maze to a form, you will need to download the file, Ksu.Cis300.MazeLibrary.dll, and place it in your project in the same folder as your source code files. This file is a dynamic-link library (DLL) containing executable code (no source code) that can be used by your program. It provides the following three types, which are described in detail at the end of these instructions:

Maze: a GUI control representing a randomly-generated maze.
Cell: a structure containing row and column indices.
Direction: an enumeration whose values are four directions.
In order to be able to use this class library, you will need to do the following:

Add a reference to the DLL as follows:
In the Solution Explorer, right click on your project name (below the solution name) and select “Add ‑> Reference…”.
Along the left edge of the resulting window, click on “Browse”.
Click the “Browse…” button at the bottom.
Navigate to the DLL you downloaded and select it. You may get a security warning here – if so, just click “Yes”.
Make sure the box to the left of “Ksu.Cis300.MazeLibrary.dll” is checked, and click “OK”.
In the Design Window, add the Maze control to the Toolbox as follows:
In the Toolbox, right-click on “All Windows Forms”, and select “Choose Items”.
After all of the controls are loaded, click the “Browse…” button near the lower right.
Navigate to the DLL you downloaded and select it.
Make sure the box to the left of “Maze” is checked, and click “OK”.
“Maze” should now be listed in the Toolbox at the end of “All Windows Forms”.

In the Code Window, add a using directive for Ksu.Cis300.MazeLibrary.
You should now be able to construct the GUI using a Maze and a Button. Don’t worry about what the Maze looks like in the Design Window – it should look OK when you run the program. Use the Anchorproperties of both these controls to cause them to behave properly when the window is resized: anchor the Maze to all four edges, and anchor the Button to only the bottom edge.

Coding Requirements
You will need to add two event handlers and one other public method to your program. These are described in what follows.

A method to draw a path from a given location to an exit
This method will take one parameter of type Cell and return nothing. The parameter contains the row and column at which the path is to begin within the maze (see the description of the Cell type below). The algorithm you will use explores the maze in an orderly way, starting at the location given by the parameter. As it explores, it draws the path it has followed. If it reaches a dead end, it backtracks along the path it has followed, erasing that path until it reaches a place where it can try a different route. In order to keep it from following a cycle indefinitely, it keeps track of the locations it has already visited and avoids visiting them again (except to backtrack to them).

You will need at least the following local variables:

A Stack<Direction> to keep track of the path from the starting point to the current location. The Direction at the bottom will indicate the direction traveled from the starting point, and the succeedingDirections above it will indicate the direction traveled at each succeeding step.
A bool[,] (i.e., a 2-dimensional array of bools) to record which locations in the maze have been visited by the search. It should have the same number of rows and columns as the maze (see theMazeHeight and MazeWidth properties of the Maze below, and note that these are different from its Height and Width properties). You can construct a new bool[,] as follows:
bool[,] a = new bool[rows, cols];
where rows and cols are ints giving the number of rows and columns, respectively, in the array. This will give you an array whose elements are all false. You will need to set the starting location to trueto indicate that the search has been there. Thus, if the starting location is row i and column j, you will need to do something like:

a[i, j] = true;
A Direction indicating the direction in which the search will try to go next. This should initially be Direction.North (see the description of the Direction type below).
You will also need a Cell to keep track of the current location of the search within the maze, but you can use the parameter for this purpose if you wish.

Once your variables are all initialized, you will need a loop that iterates as long as the current location is in the maze (see the Maze‘s IsInMaze method below). Within this loop, there are three cases:

The current direction is one of the four defined directions (see the documentation for the Direction type below). We then have two sub-cases:
We can take a step in the current direction; i.e., there is no wall in the way (see the Maze‘s IsClear method) and the cell in the current direction (see the Maze‘s Step method) either is not in the maze or has not been visited. In this case, we need to:
Draw a path in the current direction (see the Maze‘s DrawPath method).
Set the current location to the cell in the current direction.
Record the direction we have gone by pushing the current direction onto the stack.
In order to prepare for the next iteration, reset the current direction to Direction.North.
If the cell we have reached is still in the maze, mark it as having been visited.
We can’t take a step in the current direction. In this case, we simply set the current direction to the next direction (see the documentation for the Direction type below) so that the next iteration can try going that way instead.
The current direction is not one of the four defined values and the stack is not empty. In this case, we’ve tried all four directions from the current cell and failed; hence, we need to backtrack:
Remove the direction from the top of the stack and make it the current direction.
Set the current location to the cell reached by going in the opposite of the current direction (see the Maze‘s ReverseStep method).
Erase the path from the (new) current cell going in the current direction (see the Maze‘s ErasePath method).
Set the current direction to the next direction so that the next iteration can try going that way.
The current direction is not one of the four defined values and the stack is empty. In this case, we’ve tried all four directions and failed, but we can’t backtrack any further; hence, there is no path to an exit. We display the message to this effect and return immediately.
Note: You are required to follow the above algorithm. While there are other algorithms, the simple ones (like always keeping a wall to your right) don’t work for this kind of maze problem (there may not be a wall to your right, or it may not connect to the exterior of the maze).

An event handler for the Maze
Double-clicking on the Maze control in the Design window will create an event handler for a mouse click. This event handler needs to do the following:

Find the location of the mouse click. This can be obtained from the Location property of the second parameter to the event handler. This property is a Point giving the pixel location of the mouse click relative to the upper left corner of the Maze control. A pixel location, however, isn’t very useful. You will therefore need to translate this location to a row and column of the maze (see the Maze‘sGetCellFromPixel method).
Because a click on the Maze control may not actually be within the borders of the maze itself, you will need to see if the Cell returned by the GetCellFromPixel method above is within the maze (see the Maze‘s IsInMaze method below). If so:
Erase all existing paths (see the Maze‘s EraseAllPaths method).
Draw a new path to an exit using the above method.
Signal that the graphical view of the Maze needs to be updated (see its Invalidate method below).
An event handler for the Button
This event handler simply needs to generate a new maze by calling the Maze control’s Generate method (see below).

The Ksu.Cis300.MazeLibrary Namespace
The DLL provided defines three types: Cell, Direction, and Maze. Each of these types is described in detail in what follows.

The Cell structure
Cell is a structure containing the following public properties:

int Row: gets the row number.
int Column: gets the column number.
Note that this structure is immutable. The above properties may contain any int values; however, they are used in this program to store row and column numbers within the maze. The top row and the left column of the maze are numbered 0.

The Direction enumeration
Direction is an enumeration having the following members:

Direction.North
Direction.East
Direction.South
Direction.West
Each of these members has an integer value. Their specific values aren’t important, but it is important to realize that each value is 1 greater than the one listed above it. Because they have integer values, integer arithmetic may be performed on them, and they can be compared like any other integer values. For example, if a Direction variable d has a value of Direction.North, then d++ will change that value toDirection.East. If d has a value of Direction.West, then d++ will still increment the value of d, but this new value will no longer be one of the four directions. Thus, to iterate through the four directions, we can initialize a variable (say d) to Direction.North and increment that variable for each successive iteration. We continue as long as

d <= Direction.West
The Maze class
Maze is a class defining a GUI control that displays random mazes. It contains the following public properties:

int MazeHeight: Gets the number of rows in the maze. Note that this is different from the Height property, which gets or sets the height of the control in pixels.
int MazeWidth: Gets the number of columns in the maze. Note that this is different from the Width property, which gets or sets the width of the control in pixels.
It also contains the following public methods:

void DrawPath(Cell cell, Direction d): Draws a path on the maze from the given cell to the adjacent cell in the given direction. If cell describes a location outside of the maze, or if it is impossible to go in the given direction (either because d is not one of the four directions or because there is a wall in that direction), it throws an ArgumentException. Note that it is possible to use this method to draw a path that exits the maze.
void EraseAllPaths(): Erases all paths that have been drawn on the maze.
void ErasePath(Cell cell, Direction d): Removes any path from the given cell to the adjacent cell in the given direction. If cell is not in the maze, it throws an ArgumentException.
void Generate(): Generates and draws a random maze to fill the control.
Cell GetCellFromPixel(Point p): Converts the given pixel location to a Cell representing its row and column in the maze. The pixel does not need to be within the maze boundary, in which case the returned Cell will not be within the maze.
void Invalidate(): Signals that the graphical view of the maze control needs to be redrawn. For efficiency, the DrawPath, ErasePath, and EraseAllPaths methods don’t cause the control to be redrawn; hence, after all updates to the maze are finished, this method should be called so that the updates are shown to the user. (Inherited from Control.)
bool IsClear(Cell cell, Direction d): Returns whether the way is clear to move from the given cell in the given direction. If cell is not in the maze, it throws an ArgumentException. If d is not one of the four directions, it simply returns false.
bool IsInMaze(Cell cell): Returns whether the given cell is within the maze.
Cell ReverseStep(Cell cell, Direction d): Returns the cell one step in the direction opposite the given direction from the given cell. Neither cell needs to be in the maze, and walls are ignored. If d is not one of the four directions, it throws an ArgumentException.
Cell Step(Cell cell, Direction d): Returns the cell one step in the given direction from the given cell. Neither cell needs to be inside the maze, and walls are ignored. If d is not one of the four directions, it throws an ArgumentException.
