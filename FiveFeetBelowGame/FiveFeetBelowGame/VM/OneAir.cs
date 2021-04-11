// <copyright file="OneAir.cs" company="PlaceholderCompany">
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
    /// Air entity.
    /// </summary>
    public class OneAir : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneAir"/> class.
        /// </summary>
        public OneAir()
        {
            this.Breakable = false;
            this.IsSolid = false;
        }
    }
}
