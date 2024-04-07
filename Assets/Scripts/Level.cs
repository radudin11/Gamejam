using System;
using System.IO;
using UnityEngine;


namespace Game
{
    public class Level
    {
        public int x;
        public int y;
        public int[,] grid;
        public int enemies;
        public int bricks;

        public Level(int x, int y, double percentBricks, double percentEnemies)
        {
            this.x = x; 
            this.y = y;
            this.bricks = (int)(x * y * percentBricks);
            this.enemies = (int)(x * y * percentEnemies);

            grid = new int[x, y];

            //Debug.Log(enemies);
            for (int i = 0; i < enemies; i++)
            {
                int r = UnityEngine.Random.Range(1, x * (x + 1) / 2 + 1);
                //Debug.Log(r);
                for (int j = 1; j <= x; j++)
                {
                    if (r <= j * (j + 1) / 2)
                    {
                        int col = UnityEngine.Random.Range(0, y);
                        while (grid[x - j, col] != 0)
                        {
                            if (x - j > 0 && grid[x - j - 1, col] == 100)
                            {
                                col = UnityEngine.Random.Range(0, y);
                                continue;
                            }
                            if ((x - j < x - 1 && grid[x - j + 1, col] == 100))
                            {
                                col = UnityEngine.Random.Range(0, y);
                                continue;
                            }
                            col = UnityEngine.Random.Range(0, y);
                        }
                        grid[x - j, col] = 100;
                        break;
                    }
                }
            }

            int actualBricks = 0;
            for (int i = x - 1; i >= 0 && actualBricks < bricks; i--)
            {
                for (int j = 0;  j < y && actualBricks < bricks; j++)
                {
                    int p = UnityEngine.Random.Range(0, 1000);
                    if (i < x - 1 && grid[i+1,j] >= 100)
                    {
                        continue;
                    }
                    if (p < 850 && grid[i,j] == 0)
                    {
                        //Debug.Log(i + " " + j);
                        grid[i, j] = 10;
                        actualBricks++;
                    }
                }
            }
            this.bricks = actualBricks;
            
        }

        public void printGrid()
        {
            string s = "";
            for (int i =0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    s += grid[i, j] + " ";
                }
                s += "\n";
            }
            Debug.Log(s);
        }
    }
}