﻿// <copyright file="OneOre.cs" company="PlaceholderCompany">
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
    /// An ore block element.
    /// </summary>
    public class OneOre : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneOre"/> class.
        /// </summary>
        public OneOre()
        {
            this.ID = Guid.NewGuid().ToString();
            this.Type = OreType.Rock;
            this.IsDead = false;

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

        /// <summary>
        /// Occurs when entity is destroyed.
        /// </summary>
        protected override void IsDestroyed()
        {
            throw new NotImplementedException(); // TODO
        }
    }
}