using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Game
{
    [Serializable]
    public class Level
    {
        public int x;
        public int y;
        public int[,] grid;

        public Level(string path) {
            StreamReader sr = new StreamReader(path);
            string firstLine = sr.ReadLine();
            string[] size = firstLine.Split(" ");
            this.x = Int32.Parse(size[0]);
            this.y = Int32.Parse(size[1]);
            this.grid = new int[x, y];

            for (int i = 0; i < this.x; i++)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(" ");
                for (int j = 0; j < this.y; j++)
                {
                    grid[i,j] = Int32.Parse(values[j]);
                }
            }
        }
    }
}
