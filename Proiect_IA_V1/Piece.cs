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
        int power = 1;
        public Piece(int team, int x, int y)
        {
            this.team = team;
            this.x = x;
            this.y = y;
            CheckPiecePower();
        }

        public int CheckPiecePower()
        {
            int[,] grid = Manager.grid;
            int cursorX = x;
            int cursorY = y;
            int streak = 0;
            for (cursorY = y + 1; cursorY <= y + 3; cursorY++) //right
            {
                if (cursorY == 7) break;
                if (grid[x, cursorY] == team)
                    power++;
            }
            power += streak;
            //^ incearca sa repare flaw-ul ca o piesa primeste str si daca nu e in streak [O x x O] 
            for (cursorY = y - 1; cursorY >= y - 3; cursorY--) //left
            {
                if (cursorY == -1) break;
                if (grid[x, cursorY] == team)
                    power++;
            }
            for (cursorX = x + 1; cursorX <= x + 3; cursorX++) //up
            {
                if (cursorX == 6) break;
                if (grid[cursorX, y] == team)
                    power++;
            }
            for (cursorX = y - 1; cursorY >= y - 3; cursorY--) //down
            {
                if (cursorY == -1) break;
                if (grid[cursorX, y] == team)
                    power++;
            }

            return 0;
        }
        public override string ToString()
        {
            return $"Piece: [{Manager.names[team]}] ({x},{y}) Power: {power}";
        }
    }
}
