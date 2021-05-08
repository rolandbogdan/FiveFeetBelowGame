// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using Model;

    /// <summary>
    /// Gamemodel class.
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// </summary>
        /// <param name="w">Double type parameter, it is the width of the gamearea.</param>
        /// <param name="h">Double type parameter, it is the height of the gamearea.</param>
        public GameModel(double w, double h)
        {
            this.GameWidth = w;
            this.GameHeight = h;
            this.SectionNumber = 0;
            this.PlayerHealth = 3;
            this.PlayerMaxHealth = 3;
            this.PlayerPickaxe = 1;
            this.Hs = new Highscore(this.SaveName, 0, this.PlayerPickaxe, this.PlayerBalance);
        }

        /// <summary>
        /// Gets or sets the name of this game instance.
        /// </summary>
        public string SaveName { get; set; }

        /// <summary>
        /// Gets or sets Rock prop represent the rocks of the map.
        /// </summary>
        public IGameObject[,] Blocks { get; set; }

        /// <summary>
        /// Gets or sets Player prop represent our player position.
        /// </summary>
        public Point PlayerPos { get; set; }

        /// <summary>
        /// Gets or sets the player of the game.
        /// </summary>
        public OnePlayer Player { get; set; }

        /// <summary>
        /// Gets or sets the player's balance.
        /// </summary>
        public int PlayerBalance { get; set; }

        /// <summary>
        /// Gets or sets the level of the player's pickaxe.
        /// </summary>
        public int PlayerPickaxe { get; set; }

        /// <summary>
        /// Gets or sets the player's health points.
        /// </summary>
        public int PlayerHealth { get; set; }

        /// <summary>
        /// Gets or sets the player's max health.
        /// </summary>
        public int PlayerMaxHealth { get; set; }

        /// <summary>
        /// Gets or sets the player neighboring blocks.
        /// </summary>
        public List<IGameObject> PlayerNeighborBlocks { get; set; }

        /// <summary>
        /// Gets Gamewidth represent the width of the map.
        /// </summary>
        public double GameWidth { get; private set; }

        /// <summary>
        /// Gets GameHeight represent the height of the map.
        /// </summary>
        public double GameHeight { get; private set; }

        /// <summary>
        /// Gets or sets TileSize represent the tile size in pixels.
        /// </summary>
        public double TileSize { get; set; }

        /// <summary>
        /// Gets or sets the number of the section the player is on.
        /// </summary>
        public int SectionNumber { get; set; }

        /// <summary>
        /// Gets tumber of vertical blocks.
        /// </summary>
        public int BlockNum
        {
            get
            {
                return (int)(this.GameHeight / this.TileSize) + 1;
            }
        }

        /// <summary>
        /// Gets the depth the player is at.
        /// </summary>
        public int PlayerDepth
        {
            get
            {
                return (this.SectionNumber * this.BlockNum) + (int)this.PlayerPos.Y;
            }
        }

        /// <summary>
        /// Gets or sets the highscore of this save.
        /// </summary>
        public Highscore Hs { get; set; }
    }
}
