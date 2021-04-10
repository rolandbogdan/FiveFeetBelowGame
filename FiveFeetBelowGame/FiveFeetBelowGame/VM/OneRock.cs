// <copyright file="OneRock.cs" company="PlaceholderCompany">
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
    /// A rock entity in the game.
    /// </summary>
    public class OneRock : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneRock"/> class.
        /// </summary>
        public OneRock()
        {
            this.ID = Guid.NewGuid().ToString();
            this.Type = OreType.Rock;
            this.IsDead = false;
            this.Breakable = true;
            this.IsSolid = true;
            // this.CX = x;
            // this.CY = y;
            // this.area = new Geometry();
        }

        /// <summary>
        /// Gets or sets the type of the block.
        /// </summary>
        public OreType Type { get; set; }

        /// <summary>
        /// Gets or sets the hardness of the block.
        /// </summary>
        public int Hardness { get; set; }
    }
}
