
# Connect 4 - 3 Player Edition

## Overview

This is a **three-player** version of the classic **Connect 4** game, implemented in **C#**. The game features a **single human player competing against two AI opponents**, utilizing the **Minimax algorithm with Alpha-Beta pruning** for AI decision-making.

## Features

-   **Three-player gameplay**: One human player against two AI opponents.
    
-   **AI opponent**: Implemented using the **Minimax algorithm** with **Alpha-Beta pruning** for efficiency.
    
-   **Graphical User Interface (GUI)**: A simple, user-friendly interface to play the game.
    
-   **Customizable difficulty**: Adjust AI depth to modify difficulty levels.
    
-   **Win detection**: The game detects four connected pieces (horizontally, vertically, or diagonally) for a win condition.
    

## How to Play

1.  **Launch the game**.
    
2.  **The player competes against two AI opponents**.
    
3.  **Players take turns** dropping pieces into columns.
    
4.  **The first player to connect four pieces in a row wins!**
    
5.  If the board is full with no winner, the game ends in a draw.
    

## Installation & Running

1.  Clone the repository:
    
    ```
    git clone https://github.com/your-repo/connect4-3p.git](https://github.com/C-Daniel-C/Proiect_IA_V1.git
    cd Proiect_IA_V1
    ```
    
2.  Open the project in **Visual Studio**.
    
3.  Build and run the project.
    

## AI Implementation

The AI is implemented using the **Minimax algorithm with Alpha-Beta pruning** to optimize decision-making:

-   **Minimax** evaluates possible future game states and selects the best move.
    
-   **Alpha-Beta pruning** reduces the number of nodes evaluated, improving performance.
    
-   AI depth can be adjusted to control difficulty.
    

## Technologies Used

-   **C#** (Core Logic)
    
-   **.NET Framework** (GUI and backend support)
    
-   **WinForms/WPF** (for UI, if applicable)
    

## Future Improvements

-   Implement an **adaptive difficulty system**.
    
-   Improve UI with animations and better visualization.
    
-   Add **network multiplayer support**.

----------

Feel free to contribute and enhance the project!
