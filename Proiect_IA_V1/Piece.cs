using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_V1
{

    class Piece
    {
        int team;
        int x, y;
        int strength = 1;
        public Piece(int team, int x, int y)
        {
            this.team = team;
            this.x = x;
            this.y = y;
            CheckPieceStrength();
        }

        public int CheckPieceStrength()
        {
            int[,] grid = Manager.grid;
            int cursorX = x;
            int cursorY = y;
            int streak = 0;
            for (cursorY = y + 1; cursorY <= y + 3; cursorY++) //right
            {
                if (cursorY == 7) break;
                if (grid[x, cursorY] == team)
                    strength++;
            }
            strength += streak;
            //^ incearca sa repare flaw-ul ca o piesa primeste str si daca nu e in streak [O x x O] 
            for (cursorY = y - 1; cursorY >= y - 3; cursorY--) //left
            {
                if (cursorY == -1) break;
                if (grid[x, cursorY] == team)
                    strength++;
            }
            for (cursorX = x + 1; cursorX <= x + 3; cursorX++) //up
            {
                if (cursorX == 6) break;
                if (grid[cursorX, y] == team)
                    strength++;
            }
            for (cursorX = y - 1; cursorY >= y - 3; cursorY--) //down
            {
                if (cursorY == -1) break;
                if (grid[cursorX, y] == team)
                    strength++;
            }

            return 0;
        }
        public override string ToString()
        {
            return $"Piece: [{Manager.names[team]}] ({x},{y}) Str: {strength}";
        }
    }
}
