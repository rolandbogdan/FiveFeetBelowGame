// <copyright file="OnePlayer.cs" company="PlaceholderCompany">
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
    using System.Windows.Media;

    /// <summary>
    /// OnePlayer represent our player class.
    /// </summary>
    public class OnePlayer : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnePlayer"/> class.
        /// </summary>
        /// <param name="cx">X coordinate. </param>
        /// <param name="cy">Y coordinate. </param>
        public OnePlayer(double cx, double cy)
        {
            this.ID = Guid.NewGuid().ToString();
            this.IsDead = false;

            this.CX = cx;
            this.CY = cy;

            // this.DX = 10;
        }
    }
}
