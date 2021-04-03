// <copyright file="OnePickaxe.cs" company="PlaceholderCompany">
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
    /// The pickaxe game element.
    /// </summary>
    public class OnePickaxe
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnePickaxe"/> class.
        /// </summary>
        /// <param name="lvl">The level of the pickaxe.</param>
        public OnePickaxe(int lvl)
        {
            this.PickaxeLvl = lvl;
            this.DamageCalc();
        }

        /// <summary>
        /// Gets or sets the material the pickaxe is made from.
        /// </summary>
        public OneOre Material { get; set; }

        /// <summary>
        /// Gets or sets the damage it deals.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Gets or sets the lvl of the pickaxe.
        /// </summary>
        public int PickaxeLvl { get; set; }

        /// <summary>
        /// Calculates the damage of the pickaxe.
        /// </summary>
        public void DamageCalc()
        {
            switch (this.PickaxeLvl)
            {
                case 1: this.Damage = 1; break;
                case 2: this.Damage = 2; break;
                case 3: this.Damage = 3; break;
                case 4: this.Damage = 5; break;
                case 5: this.Damage = 7; break;
                default: this.Damage = 7 + this.PickaxeLvl; break;
            }
        }
    }
}
