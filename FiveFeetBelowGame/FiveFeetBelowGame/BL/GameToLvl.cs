// <copyright file="GameToLvl.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Converts the game state to a .lvl file.
    /// </summary>
    public class GameToLvl
    {
        private GameModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameToLvl"/> class.
        /// </summary>
        /// <param name="model">The game model.</param>
        public GameToLvl(GameModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Saves the game state to a .lvl file.
        /// </summary>
        /// <param name="path">The path of the file you want to save to.</param>
        public void SaveToLvl(string path)
        {
            string actualPath = !path.EndsWith(".lvl") ? String.Format(path + ".lvl") : path;
            StreamWriter sw = new StreamWriter(actualPath);
            for (int i = 0; i < this.model.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < this.model.Blocks.GetLength(1); j++)
                {
                    sw.Write(this.BlockToCharConverter(this.model.Blocks[i, j]));
                }

                sw.WriteLine();
            }

            sw.Close();
        }

        private char BlockToCharConverter(GameItem gi)
        {
            string type = gi.GetType().ToString();
            if (type == typeof(OneAir).ToString())
            {
                return ' ';
            }
            else if (type == typeof(OneRock).ToString())
            {
                return 'r';
            }
            else if (type == typeof(OneWall).ToString())
            {
                return 'B';
            }
            else if (type == typeof(OneOre).ToString())
            {
                this.OreSelector(gi as OneOre);
            }
            else if (type == typeof(OnePlayer).ToString())
            {
                return 'P';
            }
            else if (type == typeof(OneMonster).ToString())
            {
                return 'M';
            }

            return ' ';
        }

        private char OreSelector(OneOre ore)
        {
            switch (ore.Type)
            {
                case OreType.Iron: return 'i';
                case OreType.Gold: return 'g';
                case OreType.Diamond: return 'd';
                case OreType.Gem: return '+';
                case OreType.RareGem: return '*';
                default: return 'r';
            }
        }
    }
}
