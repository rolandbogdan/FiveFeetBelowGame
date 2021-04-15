// <copyright file="LevelGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.BL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FiveFeetBelowGame.VM;
    using Newtonsoft.Json;

    /// <summary>
    /// This class generates the .lvl file for the game, for the renderer to draw later.
    /// This generates the first 1000 blocks, and the procedural generator class will generate the rest.
    /// </summary>
    public class LevelGenerator
    {
        private int depth;

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelGenerator"/> class.
        /// </summary>
        public LevelGenerator()
        {
            string path = "map.txt";
            this.GenerateFirstSection(path);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelGenerator"/> class.
        /// </summary>
        /// <param name="saveName">Filename.</param>
        public LevelGenerator(string saveName)
        {
            string json = JsonConvert.SerializeObject(this.GenerateFirstSectionJson());

            if (saveName.EndsWith(".json"))
            {
                StreamWriter sw = new StreamWriter(saveName);
                sw.Write(json);
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(saveName + ".json");
                sw.Write(json);
                sw.Close();
            }
        }

        /// <summary>
        /// Generates the first section of the map for the json converter.
        /// </summary>
        /// <returns>Returns an object array of game items.</returns>
        private GameItem[,] GenerateFirstSectionJson()
        {
            GameItem[,] items = new GameItem[1011, 25];
            for (int x = 0; x < items.GetLength(0); x++)
            {
                for (int y = 0; y < items.GetLength(1); y++)
                {
                    if (x < 11)
                    {
                        items[x, y] = new OneAir() { ID = "air" };
                    }
                    else
                    {
                        char[] row = this.RowGenerator().ToCharArray();
                        if (row[y] == 'B')
                        {
                            items[x, y] = new OneWall() { ID = "wall" };
                            items[x, y].CX = x;
                            items[x, y].CY = y;
                        }
                        else if (row[y] == 'r')
                        {
                            items[x, y] = new OneRock() { ID = "rock" };
                            items[x, y].CX = x;
                            items[x, y].CY = y;
                            items[x, y].HealthPoints = 3;
                        }
                        else if (row[y] == ' ')
                        {
                            items[x, y] = new OneAir() { ID = "air" };
                            items[x, y].CX = x;
                            items[x, y].CY = y;
                        }
                        else
                        {
                            items[x, y] = new OneOre() { ID = "ore" };
                            items[x, y].CX = x;
                            items[x, y].CY = y;
                            items[x, y].HealthPoints = 5;
                            (items[x, y] as OneOre).Type = this.OreToGameItem(row[y]);
                        }
                    }
                }
            }

            return items;
        }

        /// <summary>
        /// Generates 1000 additional rows for the map.
        /// </summary>
        /// <param name="items">The map so far.</param>
        /// <returns>The new extended map.</returns>
        private GameItem[,] GenerateSectionJson(GameItem[,] items)
        {
            GameItem[,] output = new GameItem[items.GetLength(0) + 1000, items.GetLength(1)];

            for (int i = 0; i < items.GetLength(0); i++)
            {
                for (int j = 0; j < items.GetLength(1); j++)
                {
                    output[i, j] = items[i, j]; // reference problems maybe?
                }
            }

            for (int x = 0; x < items.GetLength(0); x++)
            {
                for (int y = 0; y < items.GetLength(1); y++)
                {
                    char[] row = this.RowGenerator().ToCharArray();
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i] == 'r')
                        {
                            items[x, y] = new OneRock();
                            items[x, y].CX = x;
                            items[x, y].CY = y;
                            items[x, y].HealthPoints = 3;
                        }
                        else if (row[i] == ' ')
                        {
                            items[x, y] = new OneAir();
                            items[x, y].CX = x;
                            items[x, y].CY = y;
                        }
                        else if (row[i] == 'B')
                        {
                            items[x, y] = new OneWall();
                            items[x, y].CX = x;
                            items[x, y].CY = y;
                        }
                        else
                        {
                            items[x, y] = new OneOre();
                            items[x, y].CX = x;
                            items[x, y].CY = y;
                            items[x, y].HealthPoints = 5;
                            (items[x, y] as OneOre).Type = this.OreToGameItem(row[i]);
                        }
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Determines the ore, based on the character.
        /// </summary>
        /// <param name="c">The character.</param>
        /// <returns>The oretype.</returns>
        private OreType OreToGameItem(char c)
        {
            switch (c)
            {
                case 'i': return OreType.Iron;
                case 'g': return OreType.Gold;
                case 'd': return OreType.Diamond;
                case '+': return OreType.Gem;
                case '*': return OreType.RareGem;
                default: return OreType.Rock;
            }
        }

        /// <summary>
        /// Generates the next 1000 depth.
        /// </summary>
        /// <param name="level"> The path of the lvl file. </param>
        public void GenerateSection(string level)
        {
            StreamWriter sw = new StreamWriter(level, true);
            for (int i = 0; i < 1000; i++)
            {
                sw.WriteLine(this.RowGenerator());
            }

            sw.Close();
        }

        /// <summary>
        /// Generates the first section of the map.
        /// </summary>
        /// <param name="level">The map's file path.</param>
        private void GenerateFirstSection(string level)
        {
            StreamWriter sw = new StreamWriter(level);

            for (int i = 0; i < 9; i++)
            {
                sw.WriteLine("                         "); // 9 air
            }

            sw.WriteLine("           P             "); // player
            sw.WriteLine("Bsssssssssss   sssssssssB"); // top grass level with opening
            sw.Close();
            this.GenerateSection(level);
        }

        /// <summary>
        /// Generates one row on the map.
        /// </summary>
        /// <returns>returns the certain row.</returns>
        private string RowGenerator() // rewrite maybe for json version?
        {
            this.depth++;
            Random r = new Random();
            string outp = string.Empty;
            for (int i = 0; i < 25; i++)
            {
                int a = r.Next(100);
                if (i == 0 || i == 24)
                {
                    outp += "B";
                }
                else
                {
                    if (a < 94)
                    {
                        outp += "r"; // rock
                    }
                    else if (a >= 94 && a <= 96)
                    {
                        outp += this.OreChooser(a);
                    }
                    else
                    {
                        outp += " ";
                    }
                }
            }

            // outp += $"  -- depth: {this.depth}";
            return outp;
        }

        /// <summary>
        /// Decides what ore to insert depending on the depth.
        /// </summary>
        /// <param name="a">A random integer.</param>
        /// <returns>A letter for the ore.</returns>
        private string OreChooser(int a)
        {
            if (this.depth <= 50)
            {
                return "i";
            }
            else if (this.depth <= 150)
            {
                if (a % 2 == 0)
                {
                    return "i";
                }
                else
                {
                    return "g";
                }
            }
            else if (this.depth <= 250)
            {
                if (a % 2 == 0)
                {
                    return "g";
                }
                else
                {
                    return "d";
                }
            }
            else if (this.depth <= 300)
            {
                if (a % 2 == 0)
                {
                    return "d";
                }
                else
                {
                    return "+";
                }
            }
            else if (this.depth >= 301)
            {
                if (a % 2 == 0)
                {
                    return "+";
                }
                else
                {
                    return "*";
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
