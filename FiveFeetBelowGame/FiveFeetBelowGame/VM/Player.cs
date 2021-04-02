// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A player entity in the game.
    /// </summary>
    public class Player : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        public Player()
        {
            this.ID = Guid.NewGuid().ToString();
            this.HealthPoints = 3; // Starting hp?
            this.Inventory = new GameItem[5][]; // MMore expensive ores require more space, thus jagged array
            this.IsDead = false;
            this.Pickaxe = new OnePickaxe(1);

            // this.CX = x;
            // this.CY = y;
            // this.area = new Geometry();
        }

        /// <summary>
        /// Gets or sets the pickaxe of the player.
        /// </summary>
        public OnePickaxe Pickaxe { get; set; }

        /// <summary>
        /// Gets or sets the inventory of the player.
        /// </summary>
        public GameItem[][] Inventory { get; set; }
    }
}
