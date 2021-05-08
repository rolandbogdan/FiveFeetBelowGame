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
    using FiveFeetBelowGame.VM;
    using Model;
    using Newtonsoft.Json;
    using Repository;

    /// <summary>
    /// This class is responsible for reading and writing json files.
    /// </summary>
    public class JsonHandler
    {
        private int depth;

        private GameModel model;

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
        /// <param name="model">A gamemodel.</param>
        public JsonHandler(string saveName, ref GameModel model)
        {
            if (GlobalVariables.GameLoad)
            {
                model = this.LoadGame(saveName);
                this.model = model;
                GlobalVariables.GameLoad = false;
            }
            else
            {
                this.depth = 0;
                this.model = model;
                this.SaveMap(this.GenerateFirstSection(), saveName);
                this.LoadMap(saveName);
            }
        }

        /// <summary>
        /// Saves the game to a json file.
        /// </summary>
        /// <param name="map">The map thats being saved.</param>
        /// <param name="saveName">The filename.</param>
        public void SaveMap(IGameObject[,] map, string saveName)
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            string save = JsonConvert.SerializeObject(map, Formatting.Indented, settings);

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
        public void LoadMap(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string json = sr.ReadToEnd();
            sr.Close();

            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            IGameObject[,] output = JsonConvert.DeserializeObject<IGameObject[,]>(json, settings);
            this.model.Blocks = output;
        }

        /// <summary>
        /// Saves the game's state.
        /// </summary>
        /// <param name="saveName">The path.</param>
        public void SaveGame(string saveName)
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            string save = JsonConvert.SerializeObject(this.model, Formatting.Indented, settings);

            saveName = saveName.Replace(':', '-');
            saveName = saveName.Replace('/', '-');

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
        /// Loads a game state.
        /// </summary>
        /// <param name="saveName">The path.</param>
        /// <returns>The loaded game state.</returns>
        public GameModel LoadGame(string saveName)
        {
            StreamReader sr = new StreamReader(saveName);
            string json = sr.ReadToEnd();
            sr.Close();

            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;
            return JsonConvert.DeserializeObject<GameModel>(json, settings);
        }

        /// <summary>
        /// Generates a new section to the game.
        /// </summary>
        /// <returns>The new section.</returns>
        public IGameObject[,] GenerateNewSection()
        {
            IGameObject[,] items = new IGameObject[this.model.BlockNum, 25];
            for (int x = 0; x < items.GetLength(0); x++)
            {
                for (int y = 0; y < items.GetLength(1); y++)
                {
                    if (x < 2)
                    {
                        items[x, y] = new OneBlock(x, y, BlockType.Air);
                        this.depth++;
                    }
                    else
                    {
                        this.RowGenerator(ref items, x);
                        this.depth++;
                    }
                }
            }

            this.AddMonsters(ref items);

            IGameObject[,] arr = new IGameObject[items.GetLength(1), items.GetLength(0)];
            for (int i = 0; i < items.GetLength(0); i++)
            {
                for (int j = 0; j < items.GetLength(1); j++)
                {
                    arr[j, i] = items[i, j];
                }
            }

            return arr;
        }

        /// <summary>
        /// Gets the highscores from the saves folder.
        /// </summary>
        /// <returns>A list of the highscores.</returns>
        public HighscoreRepo GetHighscores()
        {
            HighscoreRepo hRepo = new HighscoreRepo();
            string[] filenames = Directory.GetFiles($"..\\..\\..\\Levels\\");
            foreach (string fname in filenames)
            {
                if (fname.EndsWith(".json") && !fname.StartsWith("..\\..\\..\\Levels\\autosave"))
                {
                    GameModel temp = this.LoadGame(fname);
                    temp.Hs.PlayerName = fname.Remove(0, 16);
                    temp.Hs.PlayerName = temp.Hs.PlayerName.Remove(temp.Hs.PlayerName.Length - 5, 5);
                    hRepo.Insert(new Highscore(temp.Hs.PlayerName, temp.Hs.DeepestPoint, temp.Hs.PickaxeLvl, temp.Hs.Balance));
                }
            }

            return hRepo;
        }

        /// <summary>
        /// Deletes all autosave json files.
        /// </summary>
        public void DeleteAutosaves()
        {
            string[] filenames = Directory.GetFiles($"..\\..\\..\\Levels\\");
            foreach (string fname in filenames)
            {
                if (fname.StartsWith("..\\..\\..\\Levels\\autosave"))
                {
                    File.Delete(fname);
                }
            }
        }

        /// <summary>
        /// Generates the first section of the map for the json converter.
        /// </summary>
        /// <returns>Returns an object array of game items.</returns>
        private IGameObject[,] GenerateFirstSection()
        {
            IGameObject[,] items = new IGameObject[42, 25];
            for (int x = 0; x < items.GetLength(0); x++)
            {
                for (int y = 0; y < items.GetLength(1); y++)
                {
                    if (x < 11)
                    {
                        items[x, y] = new OneBlock(x, y, BlockType.Air);
                        this.depth++;
                    }
                    else
                    {
                        this.RowGenerator(ref items, x);
                        this.depth++;
                    }
                }
            }

            this.AddMonsters(ref items);
            return items;
        }

        /// <summary>
        /// Generates one row on the map.
        /// </summary>
        private void RowGenerator(ref IGameObject[,] items, int row)
        {
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
                        tp = this.OreChooser();
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
        /// <returns>A letter for the ore.</returns>
        private BlockType OreChooser()
        {
            Random r = new Random();
            int b = r.Next(100);

            if (b < 50)
            {
                return BlockType.Iron;
            }
            else if (b >= 50 && b < 70)
            {
                return BlockType.Gold;
            }
            else if (b >= 70 && b < 85)
            {
                return BlockType.Diamond;
            }
            else if (b >= 85 && b < 95)
            {
                return BlockType.Gem;
            }
            else if (b >= 95)
            {
                return BlockType.RareGem;
            }
            else
            {
                return BlockType.Air;
            }
        }

        /// <summary>
        /// Generates the monsters on the map.
        /// </summary>
        /// <param name="map">The map.</param>
        private void AddMonsters(ref IGameObject[,] map)
        {
            Random r = new Random();
            for (int i = 15; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] as OneBlock != null && (map[i, j] as OneBlock).Type == BlockType.Air)
                    {
                        if (r.Next(100) % 5 == 0)
                        {
                            map[i, j] = new OneMonster(i, j);
                        }
                    }
                }
            }
        }
    }
}
