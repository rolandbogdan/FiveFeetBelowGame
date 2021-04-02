// <copyright file="OneMonster.cs" company="PlaceholderCompany">
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
    /// A monster element.
    /// </summary>
    public class OneMonster : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneMonster"/> class.
        /// </summary>
        public OneMonster()
        {
            this.ID = Guid.NewGuid().ToString();
            this.HealthPoints = 3; // Starting hp?
            this.IsDead = false;

            // this.Damage = ...
            // this.CX = x;
            // this.CY = y;
            // this.area = new Geometry();
        }
    }
}
