using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_IA_V1
{

    class Piece
    {
        public int team;
        public int x, y;
        public int power = 1;

        public Piece(int team, int x, int y, int[,] new_grid)
        {
            this.team = team;
            this.x = x;
            this.y = y;
            CheckPiecePower(new_grid);
        }

        public int CheckPiecePower(int[,] new_grid)
        {
            int[,] grid = new_grid;
            int cursorX = x;
            int cursorY = y;
            int streak = 0;
            for (cursorY = y + 1; cursorY <= y + 3; cursorY++) //right
            {
                if (cursorY == 7) break;
                if (grid[x, cursorY] == team)
                    power++;
                else
                    break;
            }
            //power += streak;
            //^ incearca sa repare flaw-ul ca o piesa primeste str si daca nu e in streak [O x x O] 
            for (cursorY = y - 1; cursorY >= y - 3; cursorY--) //left
            {
                if (cursorY == -1) break;
                if (grid[x, cursorY] == team)
                    power++;
                else
                    break;
            }
            for (cursorX = x + 1; cursorX <= x + 3; cursorX++) //up
            {
                if (cursorX == 6) break;
                if (grid[cursorX, y] == team)
                    power++;
                else
                    break;
            }
            for (cursorX = x - 1; cursorY >= x - 3; cursorY--) //down
            {
                if (cursorX == -1) break;
                if (grid[cursorX, y] == team)
                    power++;
                else
                    break;
            }
            for (int i = 1; i <= 3; i++) //diag_down_right
            {
                cursorX = x + i;
                cursorY = y + i;
                if (cursorX >= 6 || cursorY>=7) break;
                if (grid[cursorX, cursorY] == team)
                    power++;
                else
                    break;
            }
            for (int i = 1; i <= 3; i++) //diag_up_right
            {
                cursorX = x - i;
                cursorY = y + i;
                if (cursorX <= -1 || cursorY >= 7) break;
                if (grid[cursorX, cursorY] == team)
                    power++;
                else
                    break;
            }
            for (int i = 1; i <= 3; i++) //diag_up_left
            {
                cursorX = x - i;
                cursorY = y - i;
                if (cursorX <= -1 || cursorY <= -1) break;
                if (grid[cursorX, cursorY] == team)
                    power++;
                else
                    break;
            }
            for (int i = 1; i <= 3; i++) //diag_down_left
            {
                cursorX = x + i;
                cursorY = y - i;
                if (cursorX >= 6 || cursorY <= -1) break;
                if (grid[cursorX, cursorY] == team)
                    power++;
                else
                    break;
            }


            return 0;
        }
        public override string ToString()
        {
            return $"Piece: [{Manager.names[team]}] ({x},{y}) Power: {power}";
        }
    }
}
