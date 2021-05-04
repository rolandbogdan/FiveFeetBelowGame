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
        }

        /// <summary>
        /// Gets or sets Rock prop represent the rocks of the map.
        /// </summary>
        public IGameObject[,] Blocks { get; set; }

        /// <summary>
        /// Gets or sets the part of the map thats being rendered.
        /// </summary>
        public IGameObject[,] RenderedBlocks { get; set; }

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
    }
}
