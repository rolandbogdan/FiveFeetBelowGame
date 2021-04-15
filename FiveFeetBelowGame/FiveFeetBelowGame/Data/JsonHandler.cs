// <copyright file="JsonHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// This class is responsible for reading and writing json files.
    /// </summary>
    public class JsonHandler
    {
        private int depth;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonHandler"/> class.
        /// </summary>
        public JsonHandler()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonHandler"/> class.
        /// </summary>
        /// <param name="saveName">Filename.</param>
        public JsonHandler(string saveName)
        {
            string json = JsonConvert.SerializeObject(this.GenerateFirstSection());

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
        /// Saves the game state to a json file.
        /// </summary>
        public void SaveMap(IGameObject[,] map, string saveName)
        {
            string save = JsonConvert.SerializeObject(map);

            if (saveName.EndsWith(".json"))
            {
                StreamWriter sw = new StreamWriter(saveName);
                sw.Write(save);
                sw.Close();
            }
            else
            {
                StreamWriter sw = new StreamWriter(saveName + ".json");
                sw.Write(save);
                sw.Close();
            }
        }

        /// <summary>
        /// Loads the json save file to a playable array.
        /// </summary>
        /// <param name="filePath">The path for the game file.</param>
        /// <returns>A playable IGameObject array, if the file exists. </returns>
        public IGameObject[,] LoadMap(string filePath)
        {
            if (File.Exists(filePath))
            {
                IGameObject[,] output = JsonConvert.DeserializeObject<IGameObject[,]>(filePath);
                return output;
            }
            else if (File.Exists(filePath + ".json"))
            {
                IGameObject[,] output = JsonConvert.DeserializeObject<IGameObject[,]>(filePath + ".json");
                return output;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Generates the first section of the map for the json converter.
        /// </summary>
        /// <returns>Returns an object array of game items.</returns>
        private IGameObject[,] GenerateFirstSection()
        {
            IGameObject[,] items = new IGameObject[1011, 25];
            for (int x = 0; x < items.GetLength(0); x++)
            {
                for (int y = 0; y < items.GetLength(1); y++)
                {
                    if (x < 11)
                    {
                        items[x, y] = new OneBlock(x, y, BlockType.Air);
                    }
                    else
                    {
                        this.RowGenerator(ref items, x);
                    }
                }
            }

            items[11, 11] = new OnePlayer(11, 11);
            return items;
        }

        /// <summary>
        /// Generates one row on the map.
        /// </summary>
        /// <returns>returns the certain row.</returns>
        private void RowGenerator(ref IGameObject[,] items, int row)
        {
            this.depth++;
            Random r = new Random();

            for (int i = 0; i < items.GetLength(1); i++)
            {
                int a = r.Next(100);
                BlockType tp = BlockType.Wall;
                if (i != 0 && i != 24)
                {
                    if (a < 94)
                    {
                        tp = BlockType.Rock;
                    }
                    else if (a >= 94 && a <= 96)
                    {
                        tp = this.OreChooser(a);
                    }
                    else
                    {
                        tp = BlockType.Air;
                    }
                }

                items[row, i] = new OneBlock(row, i, tp);
            }
        }

        /// <summary>
        /// Decides what ore to insert depending on the depth.
        /// </summary>
        /// <param name="a">A random integer.</param>
        /// <returns>A letter for the ore.</returns>
        private BlockType OreChooser(int a)
        {
            if (this.depth <= 50)
            {
                return BlockType.Iron;
            }
            else if (this.depth <= 150)
            {
                if (a % 2 == 0)
                {
                    return BlockType.Iron;
                }
                else
                {
                    return BlockType.Gold;
                }
            }
            else if (this.depth <= 250)
            {
                if (a % 2 == 0)
                {
                    return BlockType.Gold;
                }
                else
                {
                    return BlockType.Diamond;
                }
            }
            else if (this.depth <= 300)
            {
                if (a % 2 == 0)
                {
                    return BlockType.Diamond;
                }
                else
                {
                    return BlockType.Gem;
                }
            }
            else if (this.depth >= 301)
            {
                if (a % 2 == 0)
                {
                    return BlockType.Gem;
                }
                else
                {
                    return BlockType.RareGem;
                }
            }
            else
            {
                return BlockType.Air;
            }
        }

    }
}
