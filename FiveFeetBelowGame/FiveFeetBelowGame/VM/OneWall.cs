// <copyright file="OneWall.cs" company="PlaceholderCompany">
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
    /// The boundaries of the map.
    /// </summary>
    public class OneWall : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneWall"/> class.
        /// </summary>
        public OneWall()
        {
            this.Breakable = false;
            this.IsSolid = true;
        }
    }
}
